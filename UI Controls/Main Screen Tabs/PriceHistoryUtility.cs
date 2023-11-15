using EveHelperWF.Objects;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class PriceHistoryUtility : Objects.FormBase
    {
        List<Objects.Region> regions = new List<Objects.Region>();
        private List<Objects.SolarSystem> solarSystems = new List<Objects.SolarSystem>();
        BindingList<InventoryTypes> foundTypes = null;
        BindingList<InventoryTypes> TrackedTypes = new BindingList<InventoryTypes>();

        private static string TrackedTypeDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                     "TrackedTypes\\");
        private static string TrackedTypeFileName = Path.Combine(TrackedTypeDirectory, "TrackedTypes.json");

        public PriceHistoryUtility()
        {
            InitializeComponent();
            ProgressLabel.Visible = false;
            UpdateHistoryProgressBar.Visible = false;
            LoadRegions();
            LoadTrackedTypes();
        }

        private void LoadRegions()
        {
            regions = Database.SQLiteCalls.LoadRegions();
            RegionCombo.DisplayMember = "regionName";
            RegionCombo.ValueMember = "regionID";
            RegionCombo.DataSource = regions;
            RegionCombo.SelectedValue = ScreenHelper.Enums.TheForgeRegionId;
        }
        private void LoadTrackedTypes()
        {
            string fileContent = FileIO.FileHelper.GetCachedFileContent(TrackedTypeDirectory, TrackedTypeFileName);

            if (!string.IsNullOrEmpty(fileContent))
            {
                TrackedTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<InventoryTypes>>(fileContent);
                TrackedTypesGrid.DataSource = TrackedTypes;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemSearchTextBox.Text))
            {
                foundTypes = new BindingList<InventoryTypes>();
                string searchText = "'" + ItemSearchTextBox.Text + "%'";
                List<InventoryTypes> searchResults = Database.SQLiteCalls.InventoryTypeSearchLoadAll(searchText);
                foreach (InventoryTypes invType in searchResults)
                {
                    foundTypes.Add(invType);
                }
                ItemSearchResultsGrid.DataSource = foundTypes;
            }
        }

        private void SaveTrackedTypes()
        {
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(TrackedTypes);
            FileIO.FileHelper.SaveCachedFile(TrackedTypeDirectory, TrackedTypeFileName, fileContent);
        }

        private void TrackItemsButton_Click(object sender, EventArgs e)
        {
            if (ItemSearchResultsGrid.SelectedRows.Count > 0)
            {
                int typeId = 0;
                foreach (DataGridViewRow row in ItemSearchResultsGrid.SelectedRows)
                {
                    typeId = Convert.ToInt32(row.Cells["typeId"].Value);
                    if (typeId > 0)
                    {
                        TrackedTypes.Add(foundTypes.ToList().Find(x => x.typeId == typeId));
                    }
                }
            }
            if (TrackedTypes != null && TrackedTypes.Count > 0)
            {
                SaveTrackedTypes();
                TrackedTypesGrid.DataSource = TrackedTypes;
            }
        }

        private void UpdatePriceHistoryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PriceHistoryBackgroundWorkerClass typesToUpdate = (PriceHistoryBackgroundWorkerClass)(e.Argument);

            int i = 1;
            int progress = 0;
            foreach (InventoryTypes type in typesToUpdate.InventoryTypes)
            {
                ScreenHelper.MarketBrowserHelper.GetPriceHistoryForRegionAndType(typesToUpdate.RegionID, type.typeId);
                progress = (int)(i / typesToUpdate.InventoryTypes.Count);
                UpdatePriceHistoryWorker.ReportProgress(progress);
                i++;
            }
        }

        private void UpdatePriceHistoryWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateHistoryProgressBar.Value = e.ProgressPercentage;
        }

        private void UpdatePriceHistoryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressLabel.Visible = false;
            UpdateHistoryProgressBar.Visible = false;
            UpdatePriceHistoryButton.Enabled = true;
            RegionCombo.Enabled = true;
        }

        private void UpdatePriceHistoryButton_Click(object sender, EventArgs e)
        {

            if ((int)RegionCombo.SelectedValue > 0 && TrackedTypes.Count > 0 && !UpdatePriceHistoryWorker.IsBusy)
            {
                UpdatePriceHistoryButton.Enabled = false;
                RegionCombo.Enabled = false;
                ProgressLabel.Visible = true;
                UpdateHistoryProgressBar.Visible = true;
                PriceHistoryBackgroundWorkerClass utilityClass = new PriceHistoryBackgroundWorkerClass();
                utilityClass.RegionID = (int)RegionCombo.SelectedValue;
                utilityClass.InventoryTypes = TrackedTypes.ToList();
                UpdatePriceHistoryWorker.RunWorkerAsync(argument: utilityClass);
            }
        }

        private void ViewPriceHistoryButton_Click(object sender, EventArgs e)
        {
            LoadPriceHistoryViewer();
        }

        private void TrackedTypesGrid_DoubleClick(object sender, EventArgs e)
        {
            LoadPriceHistoryViewer();
        }

        private void LoadPriceHistoryViewer()
        {
            int typeId = 0;
            if (TrackedTypesGrid.SelectedRows.Count > 0)
            {
                typeId = Convert.ToInt32(TrackedTypesGrid.SelectedRows[0].Cells["trackedTypeId"].Value);
                if (typeId > 0)
                {
                    int regionID = (int)RegionCombo.SelectedValue;

                    InventoryTypes trackedType = TrackedTypes.ToList().Find(x => x.typeId == typeId);

                    if (typeId > 0 && regionID > 0)
                    {
                        PriceHistoryViewer historyViewer = new PriceHistoryViewer(typeId, regionID, trackedType.typeName);
                        historyViewer.StartPosition = FormStartPosition.CenterScreen;
                        historyViewer.Show();
                    }
                }
            }
        }
    }
}
