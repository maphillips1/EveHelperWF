using EveHelperWF.Objects;
using EveHelperWF.UI_Controls.Support_Screens;
using System.ComponentModel;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class PriceHistoryUtility : Objects.FormBase
    {
        List<Objects.Region> regions = new List<Objects.Region>();
        private List<Objects.SolarSystem> solarSystems = new List<Objects.SolarSystem>();
        BindingList<InventoryType> foundTypes = null;
        BindingList<InventoryType> TrackedTypes = new BindingList<InventoryType>();

        private static string TrackedTypeFileName = Path.Combine(Enums.Enums.TrackedTypeDirectory, "TrackedTypes.json");

        #region "Init"
        public PriceHistoryUtility()
        {
            InitializeComponent();
            ProgressLabel.Visible = false;
            UpdateHistoryProgressBar.Visible = false;
            CancelButton.Visible = false;
            LoadRegions();
            LoadTrackedTypes();
        }

        private void LoadRegions()
        {
            regions = Database.SQLiteCalls.LoadRegions();
            RegionCombo.DisplayMember = "regionName";
            RegionCombo.ValueMember = "regionID";
            RegionCombo.DataSource = regions;
            RegionCombo.SelectedValue = Enums.Enums.TheForgeRegionId;
        }
        private void LoadTrackedTypes()
        {
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.TrackedTypeDirectory, TrackedTypeFileName);

            if (!string.IsNullOrEmpty(fileContent))
            {
                TrackedTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<InventoryType>>(fileContent);

                DatabindGridView<BindingList<InventoryType>>(TrackedTypesGrid, TrackedTypes);
            }
        }
        #endregion

        #region "Events"
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemSearchTextBox.Text))
            {
                foundTypes = new BindingList<InventoryType>();
                string searchText = "'" + ItemSearchTextBox.Text + "%'";
                List<InventoryType> searchResults = Database.SQLiteCalls.InventoryTypeSearchLoadAll(searchText);
                foreach (InventoryType invType in searchResults)
                {
                    foundTypes.Add(invType);
                }
                DatabindGridView<BindingList<InventoryType>>(ItemSearchResultsGrid, foundTypes);
            }
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
                DatabindGridView<BindingList<InventoryType>>(TrackedTypesGrid, TrackedTypes);
            }
        }

        private void UpdatePriceHistoryButton_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(RegionCombo.SelectedValue) > 0 && TrackedTypes.Count > 0 && !UpdatePriceHistoryWorker.IsBusy)
            {
                UpdatePriceHistoryButton.Enabled = false;
                RegionCombo.Enabled = false;
                ProgressLabel.Visible = true;
                UpdateHistoryProgressBar.Visible = true;
                CancelButton.Visible = true;
                PriceHistoryBackgroundWorkerClass utilityClass = new PriceHistoryBackgroundWorkerClass();
                utilityClass.RegionID = Convert.ToInt32(RegionCombo.SelectedValue);
                utilityClass.InventoryTypes = TrackedTypes.ToList();
                UpdateHistoryProgressBar.Minimum = 0;
                UpdateHistoryProgressBar.Maximum = TrackedTypes.Count();
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

        private void ItemSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (UpdatePriceHistoryWorker.IsBusy && !UpdatePriceHistoryWorker.CancellationPending)
            {
                UpdatePriceHistoryWorker.CancelAsync();
                MessageBox.Show("Update Cancelled!", "Cancel");
            }
        }

        private void DeleteTrackedItemButton_Click(object sender, EventArgs e)
        {
            int typeId = 0;
            if (TrackedTypesGrid.SelectedRows.Count > 0)
            {
                typeId = Convert.ToInt32(TrackedTypesGrid.SelectedRows[0].Cells["trackedTypeId"].Value);
                if (typeId > 0)
                {

                    InventoryType trackedType = TrackedTypes.ToList().Find(x => x.typeId == typeId);

                    if (trackedType != null)
                    {
                        TrackedTypes.Remove(trackedType);
                        SaveTrackedTypes();
                    }
                }
            }
        }
        #endregion

        #region "Methods"
        private void SaveTrackedTypes()
        {
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(TrackedTypes);
            FileIO.FileHelper.SaveFileContent(Enums.Enums.TrackedTypeDirectory, TrackedTypeFileName, fileContent);
        }

        private void LoadPriceHistoryViewer()
        {
            int typeId = 0;
            if (TrackedTypesGrid.SelectedRows.Count > 0)
            {
                typeId = Convert.ToInt32(TrackedTypesGrid.SelectedRows[0].Cells["trackedTypeId"].Value);
                if (typeId > 0)
                {
                    int regionID = Convert.ToInt32(RegionCombo.SelectedValue);

                    InventoryType trackedType = TrackedTypes.ToList().Find(x => x.typeId == typeId);

                    if (typeId > 0 && regionID > 0)
                    {
                        PriceHistoryViewer historyViewer = new PriceHistoryViewer(typeId, regionID, trackedType.typeName);
                        historyViewer.StartPosition = FormStartPosition.CenterScreen;
                        historyViewer.Show();
                    }
                }
            }
        }
        #endregion

        #region "Background Worker"
        private void UpdatePriceHistoryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PriceHistoryBackgroundWorkerClass typesToUpdate = (PriceHistoryBackgroundWorkerClass)(e.Argument);

            int i = 1;
            foreach (InventoryType type in typesToUpdate.InventoryTypes)
            {
                if (!UpdatePriceHistoryWorker.CancellationPending)
                {
                    ScreenHelper.MarketBrowserHelper.GetPriceHistoryForRegionAndType(typesToUpdate.RegionID, type.typeId);
                    UpdatePriceHistoryWorker.ReportProgress(i);
                }
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
            CancelButton.Visible = false;
            UpdatePriceHistoryButton.Enabled = true;
            RegionCombo.Enabled = true;
        }

        #endregion
    }
}
