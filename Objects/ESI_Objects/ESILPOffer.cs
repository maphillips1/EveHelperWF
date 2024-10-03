using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class ESILPOffer
    {
        public int ak_cost { get; set; }
        public long isk_cost { get; set; }
        public string formattedIskCost
        {
            get
            {
                return CommonHelper.FormatIskShortened(isk_cost);
            }
        }
        public int lp_cost { get; set; }
        public int offer_id { get; set; }
        public int quantity { get; set; }
        public List<ESILPOfferRequiredItem> required_items {  get; set; }
        public int type_id { get; set; }
        public string typeName { get; set; }
        public string m_RequiredItemsString {  get; set; }
        public decimal sellValue { get; set; }
        public decimal buyValue { get; set; }
        public string totalSellValue
        {
            get
            {
                if (sellValue > 0)
                {
                    decimal totalValue = sellValue * quantity;
                    return CommonHelper.FormatIskShortened(totalValue);
                }
                return "0";
            }
        }
        public string totalBuyValue
        {
            get
            {
                if ( buyValue > 0)
                {
                    decimal totalValue = buyValue * quantity;
                    return CommonHelper.FormatIskShortened(totalValue);
                }
                return "0";
            }
        }
        public string requiredItemsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (required_items?.Count > 0)
                {
                    foreach (ESILPOfferRequiredItem requiredItem in required_items)
                    {
                        if (requiredItem.sellValue > 0)
                        {
                            sb.AppendLine(requiredItem.typeName + " x " + requiredItem.quantity.ToString("N0") + " : Price = " + requiredItem.totalSellValue);
                        }
                        else
                        {
                            sb.AppendLine(requiredItem.typeName + " x " + requiredItem.quantity.ToString("N0"));
                        }
                    }
                }
                else
                {
                    sb.AppendLine("");
                }
                return sb.ToString();
            }
        }
        public decimal ProfitSell
        {
            get
            {
                decimal profit = sellValue * quantity;
                decimal totalCost = isk_cost;
                if (required_items?.Count > 0)
                {
                    required_items.ForEach(x => totalCost += (x.quantity * x.sellValue));
                }
                profit = profit - totalCost;
                return profit;
            }
        }
        public decimal ProfitBuy
        {
            get
            {
                decimal profit = buyValue * quantity;
                decimal totalCost = isk_cost;
                if (required_items?.Count > 0)
                {
                    required_items.ForEach(x => totalCost += (x.quantity * x.sellValue));
                }
                profit = profit - totalCost;
                return profit;
            }
        }
        public string ProfitSellString
        {
            get
            {
                return CommonHelper.FormatIskShortened(ProfitSell);
            }
        }
        public string ProfitBuyString
        {
            get
            {
                return CommonHelper.FormatIskShortened(ProfitBuy);
            }
        }

        public decimal iskLPBuyDecimal
        {
            get
            {
                return ProfitBuy / lp_cost;
            }
        }

        public decimal iskLPSellDecimal
        {
            get
            {
                return ProfitSell / lp_cost;
            }
        }

        public string IskLpBuy
        {
            get
            {
                return Math.Round(iskLPBuyDecimal, 2).ToString("N2");
            }
        }

        public string IskLpSell
        {
            get
            {
                return Math.Round(iskLPSellDecimal, 2).ToString("N2");
            }
        }
    }
}
