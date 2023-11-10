using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class InventoryMarketGroups
    {
        public InventoryMarketGroups() { }
        public InventoryMarketGroups(System.Data.DataRow dr)
        {
            marketGroupID = Convert.ToInt32(dr["marketGroupID"]);
            marketGroupName = dr["marketGroupName"].ToString();
            parentGroupID = Convert.ToInt32(dr["parentGroupID"]);
            description = dr["description"].ToString();
        }
        public int marketGroupID { get; set; }
        public string marketGroupName { get; set; }
        public int parentGroupID { get; set; }
        public string description { get; set; }
    }
}
