using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class MarketOrder
    {
        public string duration { get; set; }
        public bool is_buy_order { get; set; }
        public DateTime issued { get; set; }
        public Int64 location_id { get; set; }
        public int min_volume { get; set; }
        public Int64 order_id { get; set; }
        public decimal price { get; set; }
        public string range { get; set; }
        public Int64 system_id { get; set; }
        public int type_id { get; set; }
        public int volume_remain { get; set; }
        public int volume_total { get; set; }
        public string LocationName { get; set; }
        public string FormattedPriceString
        {
            get
            {
                return price.ToString("N0");
            }
        }
    }

    public class CachedMarketOrders
    {
        public DateTime cachedTime { get; set; }
        public int type_id { get; set; }
        public bool is_buy_order { get; set; }
        public List<MarketOrder> orders { get; set; }
    }
}
