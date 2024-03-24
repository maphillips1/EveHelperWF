using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class AbyssTracker : Objects.FormBase
    {
        private List<InventoryType> filamentTypes = new List<InventoryType>();
        private List<AbyssRunShipType> shipTypes = new List<AbyssRunShipType>();
        private static string AbyssRunFileName = Path.Combine(Enums.Enums.AbyssRunDirectory, "AbyssRuns.json");
        private BindingList<AbyssRun> AbyssRuns = new BindingList<AbyssRun>();

        private bool ignoreChangedEvent = false;

        #region "Load"

        public AbyssTracker()
        {
            InitializeComponent();
            LoadFilamentTypeCombo();
            LoadShipTypeCombo();
            LoadCurrentAbyssRuns();
        }

        private void LoadFilamentTypeCombo()
        {
            filamentTypes = Database.SQLiteCalls.GetFilamentTypesForDropDown();
            FilamentTypeCombo.DisplayMember = "typeName";
            FilamentTypeCombo.ValueMember = "typeID";
            FilamentTypeCombo.DataSource = filamentTypes;
        }

        private void LoadShipTypeCombo()
        {
            shipTypes.Add(new AbyssRunShipType { shipType = 1, shipTypeName = "Cruiser" });
            shipTypes.Add(new AbyssRunShipType { shipType = 2, shipTypeName = "Destroyer" });
            shipTypes.Add(new AbyssRunShipType { shipType = 3, shipTypeName = "Frigate" });

            ShipTypeCombo.DisplayMember = "shipTypeName";
            ShipTypeCombo.ValueMember = "shipType";
            ShipTypeCombo.DataSource = shipTypes;
        }

        private void LoadCurrentAbyssRuns()
        {
            string fileContent = FileIO.FileHelper.GetFileContent(Enums.Enums.AbyssRunDirectory, AbyssRunFileName);
            if (!String.IsNullOrWhiteSpace(fileContent))
            {
                AbyssRuns = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<AbyssRun>>(fileContent);
            }

            if (AbyssRuns == null)
            {
                AbyssRuns = new BindingList<AbyssRun>();
            }

            DataBindTrackerGrid();
        }
        #endregion

        #region "Events"
        private void DeleteRunButton_Click(object sender, EventArgs e)
        {
            if (AbyssTrackerGridView.SelectedRows.Count > 0)
            {
                int selectedAbyssRunID = (int)AbyssTrackerGridView.SelectedRows[0].Cells["abyssRunID"].Value;

                if (selectedAbyssRunID > 0)
                {
                    AbyssRun run = AbyssRuns.ToList().Find(x => x.AbyssRunID == selectedAbyssRunID);
                    if (run != null)
                    {
                        AbyssRuns.Remove(run);
                    }
                    SaveRunsToFile();
                }
            }
            DataBindTrackerGrid();
        }

        private void AddRunButton_Click(object sender, EventArgs e)
        {
            ignoreChangedEvent = true;
            this.Cursor = Cursors.WaitCursor;
            int selectedFilamentId = (int)FilamentTypeCombo.SelectedValue;
            int selectedShipType = (int)(ShipTypeCombo.SelectedValue);
            bool success = SuccessCheckbox.Checked;
            if (selectedFilamentId > 0 && selectedShipType > 0)
            {
                int runID = 1;

                if (AbyssRuns.Count > 0)
                {
                    runID = AbyssRuns.OrderByDescending(x => x.AbyssRunID).ToList()[0].AbyssRunID + 1;
                }

                AbyssRun run = new AbyssRun();
                run.FilamentType = selectedFilamentId;
                run.FilamentName = filamentTypes.Find(x => x.typeId == selectedFilamentId).typeName;
                run.ShipType = shipTypes.Find(x => x.shipType == selectedShipType).shipTypeName;
                run.Success = success;
                run.Loot = new List<InventoryTypeWIthMarketOrders>();
                run.AbyssRunID = runID;

                List<MarketOrder> filamentCostSellOrders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(selectedFilamentId, Enums.Enums.TheForgeRegionId, false);

                if (filamentCostSellOrders.Count > 0)
                {
                    decimal filamentCost = filamentCostSellOrders.OrderBy(x => x.price).ToList()[0].price;
                    switch (selectedShipType)
                    {
                        case 1:
                            run.FilamentCost = filamentCost;
                            break;
                        case 2:
                            run.FilamentCost = (filamentCost * 2);
                            break;
                        case 3:
                            run.FilamentCost = (filamentCost * 3);
                            break;
                    }
                }

                if (!String.IsNullOrWhiteSpace(LootTextBox.Text))
                {
                    string[] splitItems = LootTextBox.Text.Split("\r\n");

                    List<AppraisedItem> appraisedItems = AppraisalHelper.ParseTypeIds(splitItems);

                    if (appraisedItems.Count > 0)
                    {
                        InventoryTypeWIthMarketOrders newType = null;
                        foreach (AppraisedItem appraisedItem in appraisedItems)
                        {
                            if (appraisedItem.typeID > 0)
                            {
                                newType = new InventoryTypeWIthMarketOrders();

                                newType.typeId = appraisedItem.typeID;
                                newType.typeName = appraisedItem.typeName;
                                newType.Quantity = appraisedItem.quantity;
                                newType.BuyOrders = ESI_Calls.ESIMarketData.GetBuyOrder(newType.typeId, Enums.Enums.TheForgeRegionId);
                                run.Loot.Add(newType);
                            }
                        }
                    }
                }

                AbyssRuns.Add(run);

                SaveRunsToFile();
                DataBindTrackerGrid();

                //Reset Loot TextBox
                LootTextBox.Text = string.Empty;
                MessageBox.Show("Added Run!");
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Enter the Filament Type and Ship Type");
            }
            ignoreChangedEvent = false;
        }

        private void LootTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreChangedEvent)
            {
                ignoreChangedEvent = true;
                string text = LootTextBox.Text;

                string[] inputItems = text.Replace("\r\n", "\n").Replace("\n", "\r\n").Replace("\t", " ").Split("\r\n");
                if (inputItems != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (string item in inputItems)
                    {
                        stringBuilder.AppendLine(item);
                    }
                    LootTextBox.Text = stringBuilder.ToString();
                }
                ignoreChangedEvent = false;
            }
        }
        #endregion

        #region "Methods"

        private void DatabindSummaryInfo()
        {
            decimal totalLootValue = 0;
            decimal totalFilamentCost = 0;
            decimal averageLootValue = 0;

            foreach (AbyssRun run in AbyssRuns)
            {
                totalFilamentCost += run.FilamentCost;
                foreach (InventoryTypeWIthMarketOrders type in run.Loot)
                {
                    if (type.BuyOrders != null && type.BuyOrders.Count > 0)
                    {
                        totalLootValue += (type.Quantity * type.BuyOrders.OrderByDescending(x => x.price).ToList()[0].price);
                    }
                }
            }

            if (AbyssRuns.Count > 0)
            {
                averageLootValue = totalLootValue / AbyssRuns.Count;
            }

            TotalLootValueLabel.Text = totalLootValue.ToString("N0");
            TotalFilamentCostLabel.Text = totalFilamentCost.ToString("N0");
            AverageLootLabel.Text = averageLootValue.ToString("N0");
            ProfitLabel.Text = (totalLootValue - totalFilamentCost).ToString("N0");
        }

        private void SaveRunsToFile()
        {
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(AbyssRuns);

            if (!string.IsNullOrWhiteSpace(fileContent))
            {
                FileIO.FileHelper.SaveFileContent(Enums.Enums.AbyssRunDirectory, AbyssRunFileName, fileContent);
            }
        }

        private void DataBindTrackerGrid()
        {
            DatabindGridView<List<AbyssRun>>(AbyssTrackerGridView, AbyssRuns.OrderByDescending(x => x.AbyssRunID).ToList());
            
            DatabindSummaryInfo();
            this.Refresh();
        }
        #endregion
    }
}
