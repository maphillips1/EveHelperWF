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
        public SolarSystemJump(string solarSystemName, bool isRegional, decimal security)
        {
            this.solarSystemName = solarSystemName;
            this.isRegional = isRegional;
            this.security = security;
        }

        public string solarSystemName { get; set; }
        public bool isRegional { get; set; }
        public decimal security { get; set; }
    }
}
