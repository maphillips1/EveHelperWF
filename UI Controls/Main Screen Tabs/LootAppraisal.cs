using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.Objects.ESI_Objects.Market_Objects;
using EveHelperWF.ScreenHelper;
using System.ComponentModel;
using System.Data;

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class LootAppraisal : Objects.FormBase
    {
        private List<AppraisedItem> appraisedItems = new List<AppraisedItem>();
        private bool IgnoreTextChangedEvent = false;
        private bool ctrlPressed = false;
        private bool vPressed = false;

        #region "Init"
        public LootAppraisal()
        {
            InitializeComponent();
        }
        #endregion

        #region "Events"
        private void AppraiseButton_Click(object sender, EventArgs e)
        {
            IgnoreTextChangedEvent = true;
            string rawText = InputTextMultiLine.Text;

            if (!string.IsNullOrEmpty(rawText))
            {
                string rawInput = InputTextMultiLine.Text;
                string[] inputItems = rawInput.Replace("\r\n", "\n").Replace("\n", "\r\n").Split("\r\n");
                if (inputItems != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    TotalSellValueLabel.Text = "Loading..";
                    TotalBuyValueLabel.Text = "Loading..";
                    appraisedItems = AppraisalHelper.ParseTypeIds(inputItems);
                    if (appraisedItems.Count > 0)
                    {
                        DatabindGridView<List<AppraisedItem>>(ResultsGridView, appraisedItems);
                        if (!GetPricesWorker.IsBusy)
                        {
                            GetPricesWorker.RunWorkerAsync();
                        }
                    }
                }
            }
            IgnoreTextChangedEvent = false;
        }

        private void InputTextMultiLine_TextChanged(object sender, EventArgs e)
        {
            if (!IgnoreTextChangedEvent)
            {
                IgnoreTextChangedEvent = true;
                string text = InputTextMultiLine.Text;

                InputTextMultiLine.Text = text.Replace("\r\n", "\n").Replace("\n", "\r\n");
                IgnoreTextChangedEvent = false;
            }
        }
        #endregion

        #region "Background Worker Processes"
        private void GetPricesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ESIMarketType> marketTypes = new List<ESIMarketType>();
            appraisedItems.ForEach(x => marketTypes.Add(new ESIMarketType() { typeID = x.typeID, quantity = x.quantity }));

            marketTypes = ESIMarketData.GetPriceForItemListWithQuantityAsync(marketTypes, (int)Enums.Enums.OrderType.Buy, Enums.Enums.TheForgeRegionId).Result;

            AppraisedItem item = null;
            foreach (var marketType in marketTypes)
            {
                item = appraisedItems.Find(x => x.typeID == marketType.typeID);
                item.buyPricePer = marketType.pricePer;
                item.buyPriceTotal = marketType.priceTotal;
            }

            marketTypes.ForEach(x => x.priceTotal = 0);

            marketTypes = ESIMarketData.GetPriceForItemListWithQuantityAsync(marketTypes, (int)Enums.Enums.OrderType.Sell, Enums.Enums.TheForgeRegionId).Result;

            foreach (var marketType in marketTypes)
            {
                item = appraisedItems.Find(x => x.typeID == marketType.typeID);
                item.sellPricePer = marketType.pricePer;
                item.sellPriceTotal = marketType.priceTotal;
            }

            e.Result = appraisedItems;
        }

        private void GetPricesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                this.appraisedItems = (List<AppraisedItem>)e.Result;
            }

            DatabindGridView<List<AppraisedItem>>(ResultsGridView, appraisedItems.OrderByDescending(x => x.sellPriceTotal).ToList<AppraisedItem>());

            decimal totalBuyValue = 0;
            decimal totalSellValue = 0;

            foreach (AppraisedItem appraisedItem in this.appraisedItems)
            {
                totalBuyValue += appraisedItem.buyPriceTotal;
                totalSellValue += appraisedItem.sellPriceTotal;
            }

            TotalBuyValueLabel.Text = totalBuyValue.ToString("C");
            TotalSellValueLabel.Text = totalSellValue.ToString("C");

            ResultsGridView.Columns["sellPricePer"].DefaultCellStyle.Format = "C";
            ResultsGridView.Columns["sellPriceTotal"].DefaultCellStyle.Format = "C";
            ResultsGridView.Columns["buyPricePer"].DefaultCellStyle.Format = "C";
            ResultsGridView.Columns["buyPriceTotal"].DefaultCellStyle.Format = "C";

            AppraiseButton.Enabled = true;
            this.Refresh();
            this.Cursor = Cursors.Default;
        }
        #endregion

    }
}
