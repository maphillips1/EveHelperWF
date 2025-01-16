using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ZKill_Objects
{
    public class ZKillStats
    {
        public string characterName {  get; set; }
        public string corpName { get; set; }
        public string allianceName { get; set; }
        public string type {  get; set; }
        public long id { get; set; }
        public List<ZKillTopAllTime> topAllTime { get; set; }
        public int shipsLost { get; set; }
        public int pointsLost { get; set; }
        public double iskLost { get; set; }
        public int attackersLost { get; set; }
        public int soloLosses {  get; set; }
        public int shipsDestroyed {  get; set; }
        public int pointsDestroyed { get; set; }
        public double iskDestroyed { get; set; }
        public int attackersDestroyed { get; set; }
        private int soloKills {  get; set; }
        public long sequence {  get; set; }
        public long epoch { get; set; }
        public decimal dangerRatio { get; set; }
        public decimal gangRatio { get; set; }
        public decimal avgGangSize { get; set; }
        public decimal soloRatio { get; set; }
        public bool calcTrophies { get; set; }
        public int allTimeSum { get; set; }
        public int nextTopRecalc { get; set; }
        public List<ZkillTopLists> topLists { get; set; }
    }
}
