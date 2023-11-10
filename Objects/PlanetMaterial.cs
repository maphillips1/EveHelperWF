using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class PlanetMaterial
    {
        public PlanetMaterial() { }
        public PlanetMaterial(System.Data.DataRow row) {
            schematicID = Convert.ToInt32(row["schematicID"]);
            schematicName = Convert.ToString(row["schematicName"]);
            quantity = Convert.ToInt32(row["quantity"]);
            isInput = Convert.ToBoolean(row["isInput"]);
            typeID = Convert.ToInt32(row["typeID"]);
            typeName = Convert.ToString(row["typeName"]);
            volume = Convert.ToDecimal(row["volume"]);
            groupID = Convert.ToInt32(row["groupID"]);
            groupName = Convert.ToString(row["groupName"]);
            cycleTime = Convert.ToInt32(row["cycleTime"]);
        }

        public int schematicID {  get; set; }
        public string schematicName { get; set; }
        public int quantity { get; set; }
        public bool isInput { get; set; }
        public int typeID { get; set; }
        public string typeName { get; set; }
        public decimal volume { get; set; }
        public int groupID { get; set; }
        public string groupName {  get; set; }
        public decimal sellPricePer { get;set; }
        public decimal sellPriceTotal
        {
            get
            {
                return sellPricePer * quantity;
            }
        }
        public decimal buyPricePer { get; set; }
        public decimal buyPriceTotal
        {
            get
            {
                return buyPricePer * quantity;
            }
        }
        public int cycleTime { get; set; }

        public List<PlanetMaterial> Inputs { get; set; }
    }
}
