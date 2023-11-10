using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class Decryptor
    {
        public int typeID { get; set; }
        public string typeName { get; set; }
        public decimal probMultiplier { get; set; }
        public int runModifier { get; set; }
        public int meModifier { get; set; }
        public int teModifier { get; set; }
    }
}
