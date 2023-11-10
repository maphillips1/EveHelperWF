using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class InventoryTypes
    {
        public InventoryTypes() { }

        public InventoryTypes(System.Data.DataRow dr)
        {
            typeId = Convert.ToInt32(dr["typeID"]);
            groupId = Convert.ToInt32(dr["groupID"]);
            typeName = dr["typeName"].ToString();
            description = dr["description"].ToString();
            volume = Convert.ToDecimal(dr["volume"]);
            portionSize = Convert.ToInt32(dr["portionSize"]);
            if (!System.DBNull.Value.Equals(dr["raceID"])) { raceId = Convert.ToInt32(dr["raceID"]); }
            if (!System.DBNull.Value.Equals(dr["basePrice"])) { basePrice = Convert.ToDecimal(dr["basePrice"]); }
            if (!System.DBNull.Value.Equals(dr["marketGroupID"])) { marketGroupId = Convert.ToInt32(dr["marketGroupID"]); }
            if (!System.DBNull.Value.Equals(dr["parentGroupID"])) { parentMarketGroupId = Convert.ToInt32(dr["parentGroupID"]); }
            if (!System.DBNull.Value.Equals(dr["marketGroupName"])) { marketGroupName = dr["marketGroupName"].ToString(); }
            if (!System.DBNull.Value.Equals(dr["iconID"])) { iconId = Convert.ToInt32(dr["iconID"]); }
            if (!System.DBNull.Value.Equals(dr["soundID"])) { soundId = Convert.ToInt32(dr["soundID"]); }
            if (!System.DBNull.Value.Equals(dr["graphicID"])) { graphicId = Convert.ToInt32(dr["graphicID"]); }
            groupId = Convert.ToInt32(dr["groupID"]);
            groupName = dr["groupName"].ToString();
            categoryID = Convert.ToInt32(dr["categoryID"]);
            categoryName = dr["categoryName"].ToString();
        }

        public int typeId { get; set; }
        public int groupId { get; set; }
        public string typeName { get; set; }
        public string description { get; set; }
        public decimal volume { get; set; }
        public int portionSize { get; set; }
        public int raceId { get; set; }
        public Decimal basePrice { get; set; }
        public int marketGroupId { get; set; }
        public string marketGroupName { get; set; }
        public int parentMarketGroupId { get; set; }
        public int iconId { get; set; }
        public int soundId { get; set; }
        public int graphicId { get; set; }
        public string groupName { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }

    }
}
