using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class Planet
    {
        public Planet()
        {

        }

        public Planet(System.Data.DataRow row)
        {
            itemName = Convert.ToString(row["itemName"]);
            typeName = Convert.ToString(row["typeName"]);
            groupName = Convert.ToString(row["groupName"]);
        }
        
        public string itemName { get; set; }
        public string typeName { get; set; }
        public string groupName { get; set; }
    }
}
