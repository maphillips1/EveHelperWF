using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.Objects.ZKill_Objects;
using EveHelperWF.ScreenHelper;
using EveHelperWF.ZKill_Calls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class HunterLocalScan : UserControl
    {
        private bool isLoading;
        private List<int> covertShipTypeIds = new List<int>();
        private List<int> capitalShipGroups = new List<int>();
        public HunterLocalScan()
        {
            isLoading = true;
            InitializeComponent();
            LoadCovertTypes();
            LoadCapitalShipGroups();
            ResultsGridView.BackColor = Enums.Enums.BackgroundColor;
            ResultsGridView.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);

            foreach (DataGridViewColumn column in ResultsGridView.Columns)
            {
                column.DefaultCellStyle.BackColor = Enums.Enums.BackgroundColor;
                column.DefaultCellStyle.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);
            }

            isLoading = false;
        }

        private void LoadCovertTypes()
        {
            covertShipTypeIds = Database.SQLiteCalls.GetCovertTypeIds();
        }

        private void LoadCapitalShipGroups()
        {
            capitalShipGroups.Add(30);
            capitalShipGroups.Add(547);
            capitalShipGroups.Add(659);
            capitalShipGroups.Add(485);
            capitalShipGroups.Add(4594);
        }

        private void LocalScanTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                ResultsGridView.Rows.Clear();
                Invalidate();
                string rawInput = LocalScanTextBox.Text;
                if (!string.IsNullOrEmpty(rawInput))
                {
                    string[] splitNames = rawInput.Split('\n');
                    StringBuilder sb = new StringBuilder();
                    foreach (string item in splitNames)
                    {
                        sb.AppendLine(item);
                    }
                    LocalScanTextBox.Text = sb.ToString();
                    LoadSearchResults(splitNames.ToList());
                }
                this.Cursor = Cursors.Default;
                isLoading = false;
            }
        }

        private void LoadSearchResults(List<string> names)
        {
            string searchResults = ESI_Calls.ESIUniverse.SearchUniverseFindIDs(names);

            if (!string.IsNullOrWhiteSpace(searchResults))
            {
                Objects.ESI_Objects.UniverseIdSearchResults itemsFound = new Objects.ESI_Objects.UniverseIdSearchResults();
                itemsFound = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.ESI_Objects.UniverseIdSearchResults>(searchResults);

                if (itemsFound != null)
                {
                    HandleSearchResults(itemsFound);
                }
            }
        }

        private void HandleSearchResults(Objects.ESI_Objects.UniverseIdSearchResults itemsFound)
        {
            if (itemsFound.characters?.Count > 0)
            {
                ZKillStats zKillStats = new ZKillStats();
                foreach (Objects.ESI_Objects.UniverseIdSearchResultItem item in itemsFound.characters)
                {
                    zKillStats = LoadZkillStatsForCharacter(item);


                    LoadStatsGrid(zKillStats);
                }
            }
        }

        private ZKillStats LoadZkillStatsForCharacter(Objects.ESI_Objects.UniverseIdSearchResultItem item)
        {
            ZKillStats stats = new ZKillStats();

            if (item.id > 0)
            {
                stats = Zkill_Calls.LoadStats("characterID", item.id).Result;
                stats.characterName = item.name;
                LoadCorpAllianceForStats(ref stats);
            }

            return stats;
        }

        private void LoadCorpAllianceForStats(ref ZKillStats stats)
        {
            if (stats != null)
            {
                Objects.ESI_Objects.ESICharacter esiChar = ESI_Calls.ESICharacter.LoadCharacterForId(stats.id);
                if (esiChar.CorporationId > 0)
                {
                    Objects.ESI_Objects.ESI_Corporation esiCorp = ESI_Calls.ESICorporation.LoadCorporationById(esiChar.CorporationId);
                    if (esiCorp != null)
                    {
                        stats.corpName = esiCorp.Name;
                    }
                }
                if (esiChar.AllianceId > 0)
                {
                    Objects.ESI_Objects.ESI_Alliance esiAlliance = ESI_Calls.ESIAlliance.LoadAllianceById(esiChar.AllianceId);
                    if (esiAlliance != null)
                    {
                        stats.allianceName = esiAlliance.Name;
                    }
                }
            }
        }

        private void LoadStatsGrid(ZKillStats stats)
        {
            DataGridViewRow dataGridViewRow;
            ZkillTopLists characterTop;
            ZkillTopLists shipTop = null;
            int topShipTypeId;
            InventoryType shipType;
            if (stats.topLists != null)
            {
                shipTop = stats.topLists.Find(x => x.type == "shipType");
            }
            bool recentCovertShip = false;
            string topShip = "";
            bool recentCapital = false;

            if (shipTop != null && shipTop.values?.Count > 0)
            {
                topShipTypeId = shipTop.values[0].shipTypeID;
                shipType = CommonHelper.InventoryTypes.Find(x => x.typeId == topShipTypeId);
                if (shipType != null)
                {
                    topShip = shipType.typeName;
                }
                recentCovertShip = HasRecentKillsWithCovert(shipTop);
                recentCapital = HasRecentKillsWithCapital(shipTop);
            }

            dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(ResultsGridView);
            dataGridViewRow.Cells[0].Value = stats.characterName;
            dataGridViewRow.Cells[1].Value = stats.corpName;
            dataGridViewRow.Cells[2].Value = stats.allianceName;
            dataGridViewRow.Cells[3].Value = recentCovertShip;
            dataGridViewRow.Cells[4].Value = recentCapital;
            dataGridViewRow.Cells[5].Value = stats.shipsDestroyed;
            dataGridViewRow.Cells[6].Value = stats.shipsLost;
            dataGridViewRow.Cells[7].Value = stats.avgGangSize;
            dataGridViewRow.Cells[8].Value = stats.dangerRatio;
            dataGridViewRow.Cells[9].Value = topShip;


            ResultsGridView.Rows.Add(dataGridViewRow);
            Invalidate();
        }

        private bool HasRecentKillsWithCovert(ZkillTopLists shipTop)
        {
            bool hasCovert = false;
            if (shipTop != null)
            {
                foreach (ZkillTopListsValues ship in shipTop.values)
                {
                    if (covertShipTypeIds.Contains(ship.shipTypeID))
                    {
                        hasCovert = true;
                        break;
                    }
                }
            }
            return hasCovert;
        }

        private bool HasRecentKillsWithCapital(ZkillTopLists shipTop)
        {
            bool hasCapital = false;
            if (shipTop != null)
            {
                InventoryType invType = new InventoryType();
                foreach (ZkillTopListsValues ship in shipTop.values)
                {
                    invType = CommonHelper.InventoryTypes.Find(x => x.typeId == ship.shipTypeID);
                    if (invType != null)
                    {
                        if (capitalShipGroups.Contains(invType.groupId))
                        {
                            hasCapital = true;
                            break;
                        }
                    }
                }
            }
            return hasCapital;
        }

        private void LocalScanTextBox_Enter(object sender, EventArgs e)
        {
            isLoading = true;
            LocalScanTextBox.Text = "";
            isLoading = false;
        }
    }
}
