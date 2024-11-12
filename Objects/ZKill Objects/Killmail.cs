using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ZKill_Objects
{
    public class Killmail
    {
        public Killmail()
        {
            zkb = new ZKB();
        }
        public long killmail_id { get; set; }
        public ZKB zkb  { get; set; }
    }
}
