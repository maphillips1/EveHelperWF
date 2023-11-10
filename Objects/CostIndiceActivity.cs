using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class CostIndiceActivity
    {
        public const string ActivityManufacturing = "manufacturing";
        public const string ActivityTE = "researching_time_efficiency";
        public const string ActivityME = "researching_material_efficiency";
        public const string ActivityCOPY = "copying";
        public const string ActivityInvention = "invention";
        public const string ACtivityReaction = "reaction";

        public string activity { get; set; }
        public decimal cost_index { get; set; }
    }
}
