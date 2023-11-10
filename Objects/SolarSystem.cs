using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace EveHelperWF.Objects
{
    public class SolarSystem
    {
        public SolarSystem() { }
        public SolarSystem(System.Data.DataRow dr)
        {
            regionID = Convert.ToInt32(dr["regionID"]);
            constellationID = Convert.ToInt32(dr["constellationID"]);
            solarSystemID = Convert.ToInt32(dr["solarSystemID"]);
            solarSystemName = Convert.ToString(dr["solarSystemName"]);
            constellationName = Convert.ToString(dr["constellationName"]);
            regionName = Convert.ToString(dr["regionName"]);
            security = Math.Round(Convert.ToDecimal(dr["security"]), 1);
        }

        [Browsable(false)]
        public int regionID { get; set; }
        [Browsable(false)]
        public int constellationID { get; set; }
        [Browsable(false)]
        public int solarSystemID { get; set; }
        public string regionName { get; set; }
        public string constellationName { get; set; }
        public string solarSystemName { get; set; }
        public decimal security { get; set; }
    }
}
