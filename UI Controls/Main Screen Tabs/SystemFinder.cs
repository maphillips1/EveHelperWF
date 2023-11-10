using EveHelperWF.Database;
using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class SystemFinder : Objects.FormBase
    {
        private List<SolarSystem> solarSystems = new List<SolarSystem>();
        List<Objects.Region> regions = new List<Objects.Region>();
        int selectedRegion;
        public SystemFinder()
        {
            InitializeComponent();
            LoadRegions();
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (RegionCombobox.SelectedValue != null)
            {
                selectedRegion = (int)RegionCombobox.SelectedValue;
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
        }

        private void PlanetSearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<SolarSystem> solarSystems = Database.SQLiteCalls.SolarSystemSearch(TemperateCheckbox.Checked,
               IceCheckBox.Checked, GasCheckBox.Checked, OceanicCheckbox.Checked, LavaCheckbox.Checked, BarrenCheckbox.Checked,
               StormCheckbox.Checked, PlasmaCheckbox.Checked, WormholesCheckbox.Checked, IncludePochvenCheckbox.Checked,
               HasStationCheckBox.Checked, MinSecurityUpDown.Value, MaxSecurityUpDown.Value, selectedRegion, SystemNameTextBox.Text);
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
                SolarSystemResultsGrid.DataSource = solarSystems;
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
    }
}
