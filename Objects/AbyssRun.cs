using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class AbyssRun
    {
        public List<InventoryTypeWIthMarketOrders> Loot {  get; set; }
        public int FilamentType { get; set; }
        public string FilamentName { get; set; }
        public string LootValue
        {
            get
            {
                decimal value = 0;
                if (this.Loot != null)
                {
                    foreach (InventoryTypeWIthMarketOrders type in this.Loot)
                    {
                        if (type.BuyOrders != null && type.BuyOrders.Count > 0)
                        {
                            value += (type.BuyOrders.OrderByDescending(x => x.price).ToList()[0].price * type.Quantity);
                        }
                    }
                }
                return value.ToString("C");
            }
        }
        public bool Success { get; set; }
        public string ShipType { get; set; }
        public decimal FilamentCost { get; set; }
        public int AbyssRunID { get; set; }
    }
}
