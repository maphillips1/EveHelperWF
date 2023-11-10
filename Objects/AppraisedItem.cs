using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class AppraisedItem
    {
        public string typeName { get; set; }
        [Browsable(false)]
        public int typeID { get; set; }
        public int quantity { get; set; }
        public decimal sellPricePer { get; set; }
        public decimal sellPriceTotal { get; set; }
        public decimal buyPricePer { get; set; }
        public decimal buyPriceTotal { get; set; }
    }
}
