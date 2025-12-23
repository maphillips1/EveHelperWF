using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class StructureProfile
    {
        public StructureProfile()
        {
            profileName = "";
        }

        public string profileName {  get; set; }
        public int profileId { get; set; }
        public int structureTypeId { get; set; }
        public int MERig {  get; set; }
        public int TERig { get; set; }
        public int solarSystemID { get; set; }
        public decimal taxAmount { get; set; }
    }
}
