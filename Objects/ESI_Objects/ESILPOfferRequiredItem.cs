using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class ESILPOfferRequiredItem
    {
        public int quantity {  get; set; }
        public int type_id { get; set; }
        public string typeName { get; set; }
    }
}
