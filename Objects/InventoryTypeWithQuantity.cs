using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class InventoryTypeWithQuantity
    {
        public int typeID {  get; set; }
        public string typeName { get; set; }
        
        public long quantity { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public string quantityString
        {
            get
            {
                return quantity.ToString("N0");
            }
            set
            {
                Int32 testValue = 0;
                if (Int32.TryParse(value, out testValue))
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
