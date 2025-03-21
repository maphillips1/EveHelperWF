﻿using EveHelperWF.Database;
using EveHelperWF.Objects;
using System.ComponentModel;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class SystemFinder : Objects.FormBase
    {
        private List<SolarSystem> solarSystems = new List<SolarSystem>();
        List<Objects.Region> regions = new List<Objects.Region>();
        int selectedRegion;
        int stationFilter;

        #region "Init"
        public SystemFinder()
        {
            InitializeComponent();
            LoadRegions();
            LoadStationCombo();
            MaxSecurityUpDown.Value = 1;
        }

        public SystemFinder(bool temperate)
        {
            InitializeComponent();
            LoadRegions();
            LoadStationCombo();
            MaxSecurityUpDown.Value = 1;
        }

        private void LoadRegions()
        {
            regions = SQLiteCalls.LoadRegions();
            RegionCombobox.DisplayMember = "regionName";
            RegionCombobox.ValueMember = "regionID";
            RegionCombobox.DataSource = regions;
            RegionCombobox.SelectedIndex = -1;
        }

        private void LoadStationCombo()
        {
            Dictionary<int, string> stations = new Dictionary<int, string>();
            stations.Add(1, "Do Not Filter");
            stations.Add(2, "Has Station");
            stations.Add(3, "Has No Station");

            StationComboBox.DisplayMember = "Value";
            StationComboBox.ValueMember = "Key";
            StationComboBox.DataSource = stations.ToList();
            StationComboBox.SelectedValue = 1;
        }
        #endregion

        #region "Events"
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (RegionCombobox.SelectedValue != null)
            {
                selectedRegion = Convert.ToInt32(RegionCombobox.SelectedValue);
            }
            else
            {
                selectedRegion = 0;
            }
            if (!PlanetSearchBackgroundWorker.IsBusy)
            {
                SearchButton.Enabled = false;
                LoadingLabel.Visible = true;
                PlanetSearchBackgroundWorker.RunWorkerAsync();
            }
            if (StationComboBox.SelectedValue != null)
            {
                stationFilter = Convert.ToInt32(StationComboBox.SelectedValue);
            }
            else
            {
                stationFilter = (int)(Enums.Enums.StationFilter.DoNotFilter);
            }
        }

        private void SystemNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, new EventArgs());
            }
        }
        #endregion

        #region "Background Worker"
        private void PlanetSearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            List<SolarSystem> solarSystems = Database.SQLiteCalls.SolarSystemSearch(TemperateCheckbox.Checked,
               IceCheckBox.Checked, GasCheckBox.Checked, OceanicCheckbox.Checked, LavaCheckbox.Checked, BarrenCheckbox.Checked,
               StormCheckbox.Checked, PlasmaCheckbox.Checked, WormholesCheckbox.Checked, IncludePochvenCheckbox.Checked,
               stationFilter, MinSecurityUpDown.Value, MaxSecurityUpDown.Value, selectedRegion, SystemNameTextBox.Text);
            e.Result = solarSystems;
        }

        private void PlanetSearchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                this.solarSystems = (List<SolarSystem>)e.Result;
            }
            if (this.solarSystems.Count > 0)
            {
                DatabindGridView<List<SolarSystem>>(SolarSystemResultsGrid, this.solarSystems);
            }
            SearchButton.Enabled = true;
            LoadingLabel.Visible = true;
            LoadingLabel.Text = "Matching Systems : " + this.solarSystems.Count.ToString();
        }

        private void SolarSystemResultsGrid_DoubleClick(object sender, EventArgs e)
        {
            SolarSystem system = null;
            if (SolarSystemResultsGrid.SelectedRows.Count > 0)
            {
                string solarSystemName = Convert.ToString(SolarSystemResultsGrid.SelectedRows[0].Cells["systemName"].Value);
                system = solarSystems.Find(x => x.solarSystemName == solarSystemName);
            }
            if (system != null)
            {
                SolarSystemInfo solarSystemInfo = new SolarSystemInfo(system);
                solarSystemInfo.StartPosition = FormStartPosition.CenterScreen;
                solarSystemInfo.Show();
            }
        }
        #endregion
    }
}
