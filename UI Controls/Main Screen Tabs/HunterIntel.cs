using EveHelperWF.Objects.ESI_Objects;
using EveHelperWF.UI_Controls.Support_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class HunterIntel : Objects.FormBase
    {

        public HunterIntel()
        {
            InitializeComponent();
            //by default, show local scan
            LoadLocalScan();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string searchText = SearchTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string searchResults = ESI_Calls.ESIUniverse.SearchUniverseFindIDs(searchText);

                if (!string.IsNullOrWhiteSpace(searchResults))
                {
                    Objects.ESI_Objects.UniverseIdSearchResults itemsFound = new Objects.ESI_Objects.UniverseIdSearchResults();
                    itemsFound = Newtonsoft.Json.JsonConvert.DeserializeObject<Objects.ESI_Objects.UniverseIdSearchResults>(searchResults);

                    if (itemsFound != null)
                    {
                        HandleSearchResults(itemsFound);
                    }
                }
                else
                {
                    MessageBox.Show("Could not find a match. Due to CCP logic, the name must be exact. Check your text and try again");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void HandleSearchResults(UniverseIdSearchResults searchResults)
        {
            List<UniverseIdSearchResultItem> combinedItems = new List<UniverseIdSearchResultItem>();

            searchResults.systems?.ForEach(x => x.resultType = "system");
            searchResults.constellations?.ForEach(x => x.resultType = "constellation");
            searchResults.regions?.ForEach(x => x.resultType = "region");
            searchResults.characters?.ForEach(x => x.resultType = "character");
            searchResults.alliances?.ForEach(x => x.resultType = "alliance");
            searchResults.inventory_types?.ForEach(x => x.resultType = "inventory type");

            combinedItems.AddRange(searchResults.systems);
            combinedItems.AddRange(searchResults.constellations);
            combinedItems.AddRange(searchResults.regions);
            combinedItems.AddRange(searchResults.characters);
            combinedItems.AddRange(searchResults.alliances);
            combinedItems.AddRange(searchResults.inventory_types);

            UniverseIdSearchResultItem selectedItem = null;

            if (combinedItems.Count == 1)
            {
                selectedItem = combinedItems[0];
            }
            else if (combinedItems.Count > 0)
            {
                {
                    HunterIntelSearchResult hunterIntelSearchResult = new HunterIntelSearchResult(combinedItems);
                    hunterIntelSearchResult.StartPosition = FormStartPosition.CenterParent;
                    if (hunterIntelSearchResult.ShowDialog() == DialogResult.OK)
                    {
                        selectedItem = hunterIntelSearchResult.SelectedItem;
                    }
                    else
                    {
                        MessageBox.Show("Selection Cancelled");
                        return;
                    }
                }
            }
            if (selectedItem != null)
            {
                LoadDataForItem(selectedItem);
            }
            else
            {
                MessageBox.Show("No Results");
            }
        }

        private void LoadDataForItem(UniverseIdSearchResultItem item)
        {
            StatsPanel.Controls.Clear();
            switch (item.resultType)
            {
                case "character":
                    HunterIntelCharacterStats hunterIntelCharacterStats = new HunterIntelCharacterStats(item);
                    hunterIntelCharacterStats.Dock = DockStyle.Fill;
                    StatsPanel.Controls.Add(hunterIntelCharacterStats);
                    break;
                default:

                    break;
            }
        }

        private void LoadLocalScan()
        {
            StatsPanel.Controls.Clear();
            HunterLocalScan localScan = new HunterLocalScan();
            localScan.Dock = DockStyle.Fill;
            StatsPanel.Controls.Add(localScan);
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void LoadLocalScanButton_Click(object sender, EventArgs e)
        {
            LoadLocalScan();
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Enter a name of anything. Must match exactly because ccp";
            }
        }
    }
}