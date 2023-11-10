using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class IndustryActivityProduct
    {
        public IndustryActivityProduct() { }
        public IndustryActivityProduct(System.Data.DataRow dr)
        {
            typeID = Convert.ToInt32(dr["typeID"]);
            activityID = Convert.ToInt32(dr["activityID"]);
            productTypeID = Convert.ToInt32(dr["productTypeID"]);
            productName = Convert.ToString(dr["typeName"]);
            quantity = Convert.ToInt32(dr["quantity"]);
            activityName = Convert.ToString(dr["activityName"]);
        }

        public int typeID { get; set; }
        public int activityID { get; set; }
        public int productTypeID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public string activityName { get; set; }
        public decimal pricePer { get; set; }
        public decimal priceTotal { get; set; }
    }
}
