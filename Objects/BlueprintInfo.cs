using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class BlueprintInfo
    {
        public int BlueprintTypeId { get; set; }
        public int ProductTypeId { get; set; }
        public string BlueprintName { get; set; }
        public int ME {  get; set; }
        public int TE { get; set; }
        public int MaxRuns { get; set; }
        public bool IsManufactured { get; set; }
        public bool IsReacted { get; set; }
    }
}
