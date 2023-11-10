using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class InventionProbability
    {
        public InventionProbability() { }
        public InventionProbability(System.Data.DataRow dr)
        {

            typeID = Convert.ToInt32(dr["typeID"]);
            productTypeID = Convert.ToInt32(dr["productTypeID"]);
            probability = Convert.ToDecimal(dr["probability"]);
        }
        public int typeID { get; set; }
        public decimal productTypeID { get; set; }
        public decimal probability { get; set; }
    }
}
