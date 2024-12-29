using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ZKill_Objects
{
    public class ZkillTopAllTimeData
    {
        public int kills {  get; set; }
        public long characterID {  get; set; }
        public long corporationID { get; set; }
        public long allianceID { get; set; }
        public long factionID { get; set; }
        public int shipTypeID { get; set; }
        public long solarSystemID { get; set; }

    }
}
