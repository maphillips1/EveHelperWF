using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ZKill_Objects
{
    public class ZkillTopLists
    {
        public string type {  get; set; }
        public string title { get; set; }
        public List<ZkillTopListsValues> values { get; set; }
    }
}
