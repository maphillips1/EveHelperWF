using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class CostIndice
    {
        public Int64 solar_system_id { get; set; }
        public List<CostIndiceActivity> cost_indices { get; set; }
    }

    public class CachedCostIndices
    {
        public DateTime cachedTime { get; set; }
        public List<CostIndice> cost_indices { get; set; }
    }
}
