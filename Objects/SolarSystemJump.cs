using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class SolarSystemJump
    {
        public SolarSystemJump() { }
        public SolarSystemJump(string solarSystemName, bool isRegional, decimal security, long toSolarSystemId)
        {
            this.solarSystemName = solarSystemName;
            this.isRegional = isRegional;
            this.security = security;
            this.toSolarSystemId = toSolarSystemId; 
        }

        public string solarSystemName { get; set; }
        public bool isRegional { get; set; }
        public decimal security { get; set; }
        public long toSolarSystemId { get; set; }
    }
}
