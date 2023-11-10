using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class IndustryActivityTypes
    {
        public IndustryActivityTypes() { }
        public IndustryActivityTypes(System.Data.DataRow dr)
        {
            typeID = Convert.ToInt32(dr["typeID"]);
            activityID = Convert.ToInt32(dr["activityID"]);
            time = Convert.ToInt64(dr["time"]);
            activityName = dr["activityName"].ToString();
            productTypeId = Convert.ToInt32(dr["productTypeID"]);
            productName = dr["typeName"].ToString();
        }

        public int typeID { get; set; }
        public int activityID { get; set; }
        public Int64 time { get; set; }
        public string activityName { get; set; }
        public int productTypeId { get; set; }
        public string productName { get; set; }
    }
}
