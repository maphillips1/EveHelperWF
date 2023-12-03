using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class ESIPriceHistory
    {
        public string date { get; set; }
        public double average { get; set; }
        public double lowest { get; set; }
        public double highest { get; set; }
        public Int64 order_count { get; set; }
        public Int64 volume { get; set; }
    }
}
