using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class ShoppingListItem : InventoryTypes
    {
        public int Quantity { get; set; }
        public double BoughtAtPrice { get; set; }
        public bool Bought { get; set; }
    }
}
