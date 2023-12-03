using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class ShoppingList
    {
        public List<ShoppingListItem> ShoppinglistItems { get; set; }
        public double TotalShoppingListValue
        {
            get
            {
                double total = 0;
                foreach (ShoppingListItem item in ShoppinglistItems)
                {
                    total += item.Quantity * item.BoughtAtPrice;
                }
                return total;
            }
        }
    }
}
