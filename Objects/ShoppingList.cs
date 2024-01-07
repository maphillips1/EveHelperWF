using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class ShoppingList
    {
        public List<ShoppingListItem> ShoppinglistItems
        { 
            get
            {
                if (m_ShoppingListItems == null)
                {
                    m_ShoppingListItems = new List<ShoppingListItem>();
                }
                return m_ShoppingListItems;
            }
            set
            {
                m_ShoppingListItems = value;
            }
        }
        private List<ShoppingListItem> m_ShoppingListItems { get; set; }
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
