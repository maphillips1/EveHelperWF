using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class InventoryType
    {
        public InventoryType() { }

        public int typeId { get; set; }
        public int groupId { get; set; }
        public string typeName { get; set; }
        public decimal volume { get; set; }
        public Decimal basePrice { get; set; }
        public int marketGroupId { get; set; }
        public string marketGroupName { get; set; }
        public int parentMarketGroupId { get; set; }
        public string groupName { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }

    }
}
