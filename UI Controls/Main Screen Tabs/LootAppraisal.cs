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

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class LootAppraisal : Objects.FormBase
    {
        private List<AppraisedItem> appraisedItems = new List<AppraisedItem>();

        #region "Init"
        public LootAppraisal()
        {
            InitializeComponent();
        }
        #endregion

        #region "Events"
        private void AppraiseButton_Click(object sender, EventArgs e)
        {
            string rawText = InputTextMultiLine.Text;

            if (!string.IsNullOrEmpty(rawText))
            {
                string rawInput = InputTextMultiLine.Text;
                string[] inputItems = null;
                if (rawInput.Contains("\r\n"))
                {
                    inputItems = InputTextMultiLine.Text.Replace("\t", " ").Split("\r\n");
                }
                else if (rawInput.Contains("\n"))
                {
                    inputItems = InputTextMultiLine.Text.Replace("\t", " ").Split("\n");
                }
                if (inputItems != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    TotalSellValueLabel.Text = "Loading...";
                    TotalBuyValueLabel.Text = "Loading...";
                    appraisedItems = AppraisalHelper.ParseTypeIds(inputItems);
                    if (appraisedItems.Count > 0)
                    {
                        ResultsGridView.DataSource = appraisedItems;
                        AppraiseButton.Enabled = false;
                        if (!GetPricesWorker.IsBusy)
                        {
                            GetPricesWorker.RunWorkerAsync();
                        }
                    }
                }

            }
        }

        private void InputTextMultiLine_TextChanged(object sender, EventArgs e)
        {
            string text = InputTextMultiLine.Text;

            if (text.Contains("\n"))
            {
                if (!text.Contains("\r"))
                {
                    text = text.Replace("\n", "\r\n");
                    InputTextMultiLine.Text = text;
                }
            }
            else
            {
                text = text + "\r\n";
                InputTextMultiLine.Text = text;
            }
        }
        #endregion

        #region "Background Worker Processes"
        private void GetPricesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (AppraisedItem appraisedItem in appraisedItems)
            {
                if (appraisedItem.typeID > 0)
                {
                    appraisedItem.buyPricePer = AppraisalHelper.GetItemBuyPrice(appraisedItem.typeID);
                    appraisedItem.buyPriceTotal = appraisedItem.buyPricePer * appraisedItem.quantity;

                    appraisedItem.sellPricePer = AppraisalHelper.GetItemSellPrice(appraisedItem.typeID);
                    appraisedItem.sellPriceTotal = appraisedItem.sellPricePer * appraisedItem.quantity;
                }
            }
            e.Result = appraisedItems;
        }

        private void GetPricesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                this.appraisedItems = (List<AppraisedItem>)e.Result;
            }

            ResultsGridView.DataSource = appraisedItems.OrderByDescending(x => x.sellPriceTotal).ToList<AppraisedItem>();

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
