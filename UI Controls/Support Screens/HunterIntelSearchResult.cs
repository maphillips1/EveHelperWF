using EveHelperWF.Objects.ESI_Objects;
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
    public partial class HunterIntelSearchResult : Objects.FormBase
    {
        private List<UniverseIdSearchResultItem> searchResultItems { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UniverseIdSearchResultItem SelectedItem { get; set; }
        public HunterIntelSearchResult(List<UniverseIdSearchResultItem> searchResults)
        {
            InitializeComponent();
            this.searchResultItems = searchResults;
            SearchResultsGrid.DatabindGridView(this.searchResultItems);
        }

        private void SearchResultsGrid_DoubleClick(object sender, EventArgs e)
        {
            if (SearchResultsGrid.SelectedRows.Count > 0)
            {
                UniverseIdSearchResultItem selectedItem = (UniverseIdSearchResultItem)SearchResultsGrid.SelectedRows[0].DataBoundItem;
                if (selectedItem != null)
                {
                    this.SelectedItem  = selectedItem;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
