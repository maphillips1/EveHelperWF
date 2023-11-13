using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class CachedPriceHistory
    {
        public List<ESIPriceHistory> priceHistory {  get; set; }
        public DateTime cachedTime { get; set; }
    }
}
