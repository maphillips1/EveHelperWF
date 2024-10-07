using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class ShoppingListItem : InventoryType
    {
        public int Quantity { get; set; }
        public double BoughtAtPrice { get; set; }
        public bool Bought { get; set; }
        public string QuantityString
        {
            get
            {
                return Quantity.ToString("N0");
            }
            set
            {
                int testValue;
                if (int.TryParse(value, out testValue))
                {
                    Quantity = testValue;
                }
                else
                {
                    Quantity = 0;
                }
            }
        }

        public string BoutAtPriceString
        {
            get
            {
                return BoughtAtPrice.ToString("N2");
            }
            set
            {
                double testValue;
                if (double.TryParse(value, out testValue))
                {
                    BoughtAtPrice = testValue;
                }
                else
                {
                    BoughtAtPrice = 0;
                }
            }
        }
    }
}
