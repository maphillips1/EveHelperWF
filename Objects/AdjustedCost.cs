using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class AdjustedCost
    {
        public decimal adjusted_price { get; set; }
        public decimal average_price { get; set; }
        public decimal type_id { get; set; }

    }

    public class CachedAdjustedCost
    {
        public DateTime cachedTime { get; set; }
        public List<AdjustedCost> costs { get; set; }
    }
}
