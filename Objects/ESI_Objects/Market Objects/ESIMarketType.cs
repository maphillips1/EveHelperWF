using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects.Market_Objects
{
    public class ESIMarketType
    {
        public ESIMarketType()
        {
            this.quantity = 1;
        }
        public int typeID {  get; set; }
        public decimal pricePer { get; set; }
        public decimal priceTotal { get; set; }
        public long quantity { get; set; }
    }
}
