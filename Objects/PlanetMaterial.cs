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

        public List<PlanetMaterial> Inputs
        {
            get
            {
                if(m_Inputs== null)
                {
                    m_Inputs = new List<PlanetMaterial>();
                }
                return m_Inputs;
            }
            set
            {
                m_Inputs = value;
            }
        }
        private List<PlanetMaterial> m_Inputs { get; set; }
    }
}
