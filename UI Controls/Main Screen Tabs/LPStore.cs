using EveHelperWF.Objects;
using EveHelperWF.Objects.ESI_Objects;
using EveHelperWF.Objects.ESI_Objects.Market_Objects;
using System.Data;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class LPStore : Objects.FormBase
    {
        List<NPCCorporation> corporations = new List<NPCCorporation>();
        List<ESILPOffer> allOffers = new List<ESILPOffer>();
        Dictionary<int, int> bpcOutcomeTypeIDs = new Dictionary<int, int>();
        public LPStore()
        {
            InitializeComponent();
            LoadCombo();
            InfoLoadingLabel.Visible = false;
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

            if (GetMarketDataPriceWorker.IsBusy)
            {
                MessageBox.Show("Still getting price data from previous request. please wait until it is done.");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            InfoLoadingLabel.Visible = true;
            bpcOutcomeTypeIDs.Clear();
            SearchTextBox.Text = string.Empty;
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
                        AddInputsForBPCs();
                        DatabindGridView<List<ESILPOffer>>(LPOfferGridView, allOffers);

                        if (!GetMarketDataPriceWorker.IsBusy)
                        {
                            GetMarketDataPriceWorker.RunWorkerAsync(allOffers);
                        }

                    }
                }
            }
            this.Cursor = Cursors.Default;
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

        private void AddInputsForBPCs()
        {
            List<IndustryActivityMaterials> materials = null;
            List<IndustryActivityProduct> products = null;
            foreach (ESILPOffer offer in allOffers)
            {
                products = Database.SQLiteCalls.GetIndustryActivityProducts(offer.type_id, Enums.Enums.ActivityManufacturing);
                materials = Database.SQLiteCalls.GetIndustryActivityMaterials(offer.type_id, Enums.Enums.ActivityManufacturing);
                if (materials?.Count > 0 && products?.Count > 0)
                {
                    if (!bpcOutcomeTypeIDs.Keys.Contains(offer.type_id))
                    {
                        bpcOutcomeTypeIDs.Add(offer.type_id, products[0].productTypeID);
                    }
                    foreach (IndustryActivityMaterials material in materials)
                        {
                            offer.required_items.Add(new ESILPOfferRequiredItem()
                            {
                                quantity = material.quantity,
                                type_id = material.materialTypeID,
                                typeName = material.materialName
                            });
                        }
                }
            }
        }

        private void GetMarketInformationForOffers(List<ESILPOffer> offersForMarketData)
        {
            if (offersForMarketData?.Count > 0)
            {
                List<ESIMarketType> eSIMarketTypes = new List<ESIMarketType>();
                foreach (ESILPOffer offer in offersForMarketData)
                {
                    if (bpcOutcomeTypeIDs.Keys.Contains(offer.type_id))
                    {
                        eSIMarketTypes.Add(new ESIMarketType() { typeID = bpcOutcomeTypeIDs[offer.type_id], quantity = 1 });
                    }
                    else
                    {
                        eSIMarketTypes.Add(new ESIMarketType() { typeID = offer.type_id, quantity = 1 });
                    }

                    if (offer.required_items?.Count > 0)
                    {
                        foreach (ESILPOfferRequiredItem requiredItem in offer.required_items)
                        {
                            if (eSIMarketTypes.Find(x => x.typeID == requiredItem.type_id) == null)
                            {
                                eSIMarketTypes.Add(new ESIMarketType() { typeID = requiredItem.type_id, quantity = 1 });
                            }
                        }
                    }
                }

                eSIMarketTypes = ESI_Calls.ESIMarketData.GetPriceForItemListWithQuantityAsync(eSIMarketTypes, (int)Enums.Enums.OrderType.Buy, Enums.Enums.TheForgeRegionId).Result;

                foreach (ESILPOffer offer in offersForMarketData)
                {
                    if (bpcOutcomeTypeIDs.Keys.Contains(offer.type_id))
                    {
                        offer.buyValue = eSIMarketTypes.Find(x => x.typeID == bpcOutcomeTypeIDs[offer.type_id]).pricePer;
                    }
                    else
                    {
                        offer.buyValue = eSIMarketTypes.Find(x => x.typeID == offer.type_id).pricePer;
                    }
                }

                eSIMarketTypes = ESI_Calls.ESIMarketData.GetPriceForItemListWithQuantityAsync(eSIMarketTypes, (int)Enums.Enums.OrderType.Sell, Enums.Enums.TheForgeRegionId).Result;

                foreach (ESILPOffer offer in offersForMarketData)
                {
                    if (bpcOutcomeTypeIDs.Keys.Contains(offer.type_id))
                    {
                        offer.sellValue = eSIMarketTypes.Find(x => x.typeID == bpcOutcomeTypeIDs[offer.type_id]).pricePer;
                    }
                    else
                    {
                        offer.sellValue = eSIMarketTypes.Find(x => x.typeID == offer.type_id).pricePer;
                    }

                    if (offer.required_items?.Count > 0)
                    {
                        foreach (ESILPOfferRequiredItem requiredItem in offer.required_items)
                        {
                            requiredItem.sellValue = eSIMarketTypes.Find(x => x.typeID == requiredItem.type_id).pricePer;
                        }
                    }
                }
            }
        }

        private void GetMarketDataPriceWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                List<ESILPOffer> offers = (List<ESILPOffer>)e.Argument;

                GetMarketInformationForOffers(offers);

                e.Result = offers;
            }
            else
            {
                e.Result = null;
            }
        }

        private void GetMarketDataPriceWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List<ESILPOffer> offers = (List<ESILPOffer>)e.Result;
                allOffers = offers;
                allOffers = allOffers.OrderByDescending(x => x.iskLPBuyDecimal).ToList();
                DatabindGridView<List<ESILPOffer>>(LPOfferGridView, allOffers);
            }

            InfoLoadingLabel.Visible = false;
        }
    }
}
