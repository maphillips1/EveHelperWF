using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class InventoryTypeWithQuantity
    {
        public InventoryTypeWithQuantity(int typeId, string typeName)
        {
            this.typeID = typeId;
            this.typeName = typeName;
            this.quantity = 0;
        }
        public int typeID {  get; set; }
        public string typeName { get; set; }
        public long quantity { get; set; }
        public string quantityString
        {
            get
            {
                return quantity.ToString();
            }
            set
            {
                long testValue = 0;
                if (Int64.TryParse(value, out testValue))
                {
                    this.quantity = testValue;
                }
                else
                {
                    this.quantity = 0;
                }
            }
        }
    }
}
