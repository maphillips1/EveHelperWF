using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class InventoryTypeWIthMarketOrders : InventoryType
    {
        public int Quantity { get; set; }
        public List<MarketOrder> BuyOrders { get; set; }
        public List<MarketOrder> SellOrders { get; set; }
    }
}
