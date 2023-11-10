using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class IndustryActivityMaterials
    {
        public IndustryActivityMaterials(System.Data.DataRow dr)
        {
            typeID = Convert.ToInt32(dr["typeID"]);
            activityID = Convert.ToInt32(dr["activityID"]);
            materialTypeID = Convert.ToInt32(dr["materialTypeID"]);
            materialName = dr["typeName"].ToString();
            quantity = Convert.ToInt32(dr["quantity"]);
            activityName = dr["activityName"].ToString();
            isManufacturable = Convert.ToBoolean(dr["isManufacturable"]);
            isReactable = Convert.ToBoolean(dr["isReactable"]);
        }

        public IndustryActivityMaterials()
        {

        }

        public int typeID { get; set; }
        public int activityID { get; set; }
        public int materialTypeID { get; set; }
        public string materialName { get; set; }
        public int quantity { get; set; }
        public string activityName { get; set; }
        public bool isManufacturable { get; set; }
        public bool isReactable { get; set; }
    }
}
