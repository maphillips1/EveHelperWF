using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class IndustryImplant
    {
        public const int ImplantTypeManufacturing = 1;
        public const int ImplantTypeTEREsearch = 2;
        public const int ImplantTypeMEResearch = 3;
        public const int ImplantTypeCopy = 4;

        public int ImplantTypeID { get; set; }
        public string ImplantName { get; set; }
        public int ImplantBonus { get; set; }
        public int ImplantType { get; set; }
    }
}
