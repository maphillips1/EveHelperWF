using EveHelperWF.Objects;
using EveHelperWF.ScreenHelper;
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
    public partial class AbyssalStatistics : Objects.FormBase
    {
        private List<InventoryType> filamentTypes = new List<InventoryType>();
        private List<AbyssRunShipType> shipTypes = new List<AbyssRunShipType>();
        private List<AbyssRun> AbyssRuns = new List<AbyssRun>();
        private List<AbyssRun>? FilteredList;
        public AbyssalStatistics(List<AbyssRun> runs)
        {
            InitializeComponent();
            AbyssRuns = runs;
            LoadCombos();
            LoadStats();
        }

        private void LoadCombos()
        {
            LoadFilamentTypeCombo();
            LoadShipTypeCombo();
        }

        private void LoadFilamentTypeCombo()
        {
            filamentTypes = Database.SQLiteCalls.GetFilamentTypesForDropDown();
            FilamentCombo.DisplayMember = "typeName";
            FilamentCombo.ValueMember = "typeID";
            FilamentCombo.DataSource = filamentTypes;
        }

        private void LoadShipTypeCombo()
        {
            shipTypes.Add(new AbyssRunShipType { shipType = 0, shipTypeName = "All" });
            shipTypes.Add(new AbyssRunShipType { shipType = 1, shipTypeName = "Cruiser" });
            shipTypes.Add(new AbyssRunShipType { shipType = 2, shipTypeName = "Destroyer" });
            shipTypes.Add(new AbyssRunShipType { shipType = 3, shipTypeName = "Frigate" });

            ShipClassCombo.DisplayMember = "shipTypeName";
            ShipClassCombo.ValueMember = "shipType";
            ShipClassCombo.DataSource = shipTypes;
        }

        private void LoadStats()
        {
            FilterList();
            if (FilteredList.Count > 0)
            {
                LootFlowPanel.Controls.Clear();
                LoadBasicLabels(FilteredList);
                LoadLootTable(FilteredList);
            }
            else
            {
                ClearControls();
            }
        }

        private void ClearControls()
        {
            NumRunsLabel.Text = String.Empty;
            SuccessRateLabel.Text = String.Empty;
            LootValueLabel.Text = String.Empty;
            FilamentCostLabel.Text = String.Empty;
            AverageLootRunLabel.Text = String.Empty;
            ProfitLabel.Text = String.Empty;
            LootFlowPanel.Controls.Clear();
        }

        private void FilterList()
        {
            FilteredList = new List<AbyssRun>(AbyssRuns);
            int selectedFilament = Convert.ToInt32(FilamentCombo.SelectedValue);
            if (selectedFilament > 0)
            {
                FilteredList = FilteredList.FindAll(x => x.FilamentType == selectedFilament);
            }

            int selectedShipClass = Convert.ToInt32(ShipClassCombo.SelectedValue);
            if (selectedShipClass > 0)
            {
                FilteredList = FilteredList.FindAll(x => x.ShipType == ShipClassCombo.Text);
            }
        }

        private void LoadBasicLabels(List<AbyssRun> filteredList)
        {
            decimal totalLootValue = 0;
            decimal totalFilamentCost = 0;
            decimal averageLootValue = 0;
            int successCount = filteredList.FindAll(x => x.Success == true).Count;
            decimal successPercent = (decimal)successCount / (decimal)filteredList.Count;

            foreach (AbyssRun run in filteredList)
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
            NumRunsLabel.Text = filteredList.Count().ToString("N0");
            SuccessRateLabel.Text = successPercent.ToString("P2");
            LootValueLabel.Text = CommonHelper.FormatIskShortened(totalLootValue);
            FilamentCostLabel.Text = CommonHelper.FormatIskShortened(totalFilamentCost);
            AverageLootRunLabel.Text = CommonHelper.FormatIskShortened(averageLootValue);
            ProfitLabel.Text = CommonHelper.FormatIskShortened(totalLootValue - totalFilamentCost);
        }

        private void LoadLootTable(List<AbyssRun> filteredList)
        {
            Dictionary<int, int> typeDrops = new Dictionary<int, int>();
            foreach (AbyssRun run in filteredList)
            {
                if (run.Loot.Count > 0)
                {
                    foreach (InventoryTypeWIthMarketOrders order in run.Loot)
                    {
                        if (typeDrops.Keys.Contains(order.typeId))
                        {
                            typeDrops[order.typeId] += 1;
                        }
                        else
                        {
                            typeDrops.Add(order.typeId, 1);
                        }
                    }
                }
            }
            InventoryType invType;
            decimal dropChance = 0;
            Label lootLabel;
            foreach (KeyValuePair<int,int> kvp in typeDrops.OrderByDescending(x => x.Value))
            {
                invType = CommonHelper.InventoryTypes.Find(x => x.typeId == kvp.Key);
                if (invType != null)
                {
                    dropChance = (decimal)kvp.Value / (decimal)filteredList.Count;
                    lootLabel = new Label();
                    lootLabel.Text = string.Format("{0} - Drop Chance {1}", invType.typeName, dropChance.ToString("P2"));
                    lootLabel.AutoSize = true;
                    lootLabel.Padding = new Padding(5);
                    LootFlowPanel.Controls.Add(lootLabel);
                }
            }
        }

        private void ShipClassCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void FilamentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStats();
        }
    }
}
