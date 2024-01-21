using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class TreeViewGroup
    {
        public string groupName { get; set; }
        public int groupID { get; set; }
        public int categoryID { get; set; }
        public List<TreeViewGroup> children { get; set; }
        public List<InventoryType> items { get; set; }

    }
}
