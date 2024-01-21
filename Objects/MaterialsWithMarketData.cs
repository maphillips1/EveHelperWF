using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class MaterialsWithMarketData
    {
        public int materialTypeID { get; set; }
        public string materialName { get; set; }
        public int quantity { get; set; }
        public decimal quantityPerRun { get; set; }
        public Int64 quantityTotal { get; set; }
        public Decimal volumeTotal { get; set; }
        public decimal pricePer { get; set; }
        public decimal priceTotal { get; set; }
        public bool Buildable { get; set; }
        public bool Reactable { get; set; }
        public bool Build { get; set; }
        public bool React { get; set; }
        public int ParentMaterialTypeID { get; set; }
        public string controlName { get; set; }
        public int RunsNeeded { get; set; }
        private List<MaterialsWithMarketData> m_ChildMaterials {  get; set; }
        public List<MaterialsWithMarketData> ChildMaterials
        {
            get
            {
                if (m_ChildMaterials == null) { m_ChildMaterials = new List<MaterialsWithMarketData>();}
                return m_ChildMaterials;
            }
            set
            {
                m_ChildMaterials = value;
            }
        }
    }
}
