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
        public int typeID { get; set; }
        public int materialTypeID { get; set; }
        public string materialName { get; set; }
        public int quantity { get; set; }
        public string activityName { get; set; }
        public bool isManufacturable { get; set; }
        public bool isReactable { get; set; }
    }
}
