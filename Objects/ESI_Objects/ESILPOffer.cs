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
                return CommonHelper.FormatIsk(isk_cost);
            }
        }
        public int lp_cost { get; set; }
        public int offer_id { get; set; }
        public int quantity { get; set; }
        public List<ESILPOfferRequiredItem> required_items {  get; set; }
        public int type_id { get; set; }
        public string typeName { get; set; }
        private string m_RequiredItemsString {  get; set; }
        public string requiredItemsString
        {
            get
            {
                if (String.IsNullOrWhiteSpace(m_RequiredItemsString))
                {
                    StringBuilder sb = new StringBuilder();
                    if (required_items?.Count > 0)
                    {
                        required_items.ForEach(x => sb.AppendLine(x.typeName + " x " + x.quantity.ToString("N0")));
                    }
                    else
                    {
                        sb.AppendLine("None");
                    }
                    m_RequiredItemsString = sb.ToString();
                }
                return m_RequiredItemsString;
            }
        }
    }
}
