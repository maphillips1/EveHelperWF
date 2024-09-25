using EveHelperWF.Objects;
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
using System.Windows.Forms.VisualStyles;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class LPStore : Objects.FormBase
    {
        List<NPCCorporation> corporations = new List<NPCCorporation>();
        List<ESILPOffer> allOffers = new List<ESILPOffer>();
        public LPStore()
        {
            InitializeComponent();
            LoadCombo();
        }

        private void LoadCombo()
        {
            corporations = Database.SQLiteCalls.LoadNPCCorpLPOffers();

            NPCCorpCombo.DisplayMember = "npcCorporationName";
            NPCCorpCombo.ValueMember = "npcCorporationID";
            NPCCorpCombo.DataSource = corporations;
        }

        private void NPCCorpCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NPCCorpCombo.SelectedValue != null)
            {
                long npcCorpId = (long)NPCCorpCombo.SelectedValue;

                if (npcCorpId > 0)
                {
                    allOffers = ESI_Calls.ESILoyalty.GetCorpLPOffers(npcCorpId);

                    if (allOffers?.Count > 0)
                    {
                        allOffers = allOffers.OrderBy(x => x.typeName).ToList();
                        DatabindGridView<List<ESILPOffer>>(LPOfferGridView, allOffers);
                    }
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (allOffers?.Count > 0)
            {
                if (SearchTextBox.Text?.Length > 3)
                {
                    string[] splitString = SearchTextBox.Text.Split(' ');
                    List<ESILPOffer> filteredOffers = allOffers;
                    foreach (string part in splitString)
                    {
                        filteredOffers = filteredOffers.FindAll(x => x.typeName.ToLower().Contains(part.ToLower()));
                    }
                    DatabindGridView<List<ESILPOffer>>(LPOfferGridView, filteredOffers);
                }
                else
                {
                    DatabindGridView<List<ESILPOffer>>(LPOfferGridView, allOffers);
                }
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, new EventArgs());
            }
        }
    }
}
