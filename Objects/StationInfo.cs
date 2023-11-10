using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class StationInfo
    {
        public StationInfo() { }

        public StationInfo(System.Data.DataRow dataRow) {
            stationName =Convert.ToString(dataRow["stationName"]);
            factionName = Convert.ToString(dataRow["factionName"]);
        }

        public string stationName { get; set; }
        public string factionName {  get; set; }
    }
}
