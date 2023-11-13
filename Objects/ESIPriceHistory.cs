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
        public double average {  get; set; }
        public string date { get; set; }
        public double highest { get; set; }
        public double lowest { get; set; }
        public Int64 order_count { get; set; }
        public Int64 volume { get; set; }
        public string formattedHighest
        {
            get
            {
                return highest.ToString("N0");
            }
        }

        public string formattedLowest
        {
            get
            {
                return lowest.ToString("N0");
            }
        }
        public string formattedAverage
        {
            get
            {
                return average.ToString("N0");
            }
        }
    }
}
