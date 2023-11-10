using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class Region
    {
        public Region() { }
        public Region(System.Data.DataRow dataRow) {
            regionName = Convert.ToString(dataRow["regionName"]);
            regionID = Convert.ToInt32(dataRow["regionID"]);
        } 

        public string regionName {  get; set; }
        public int regionID { get; set; }
    }
}
