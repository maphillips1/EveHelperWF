using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ZKill_Objects
{
    public class ZKB
    {
        public long locationID {  get; set; }
        public string hash { get; set; }
        public double fittedValue { get; set; }
        public double droppedValue { get; set; }
        public double totalValue { get; set; }
        public int points { get; set; }
        public bool npc {  get; set; }
        public bool solo { get; set; }
        public bool awox { get; set; }
    }
}
