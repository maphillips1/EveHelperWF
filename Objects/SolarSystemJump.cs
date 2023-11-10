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
        public SolarSystemJump(string solarSystemName, bool isRegional)
        {
            this.solarSystemName = solarSystemName;
            this.isRegional = isRegional;
        }
        public string solarSystemName { get; set; }
        public bool isRegional { get; set; }
    }
}
