using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EveHelperWF.Objects
{
    public class IndustryActivitySkill
    {
        public IndustryActivitySkill() { }
        public IndustryActivitySkill(System.Data.DataRow dr)
        {
            typeID = Convert.ToInt32(dr["typeID"]);
            skillID = Convert.ToInt32(dr["skillID"]);
            skillName = Convert.ToString(dr["typeName"]);
            activityName = Convert.ToString(dr["activityName"]);
            level = Convert.ToInt32(dr["level"]);
        }

        public int typeID { get; set; }
        public int skillID { get; set; }
        public string skillName { get; set; }
        public string activityName { get; set; }
        public int level { get; set; }
    }
}
