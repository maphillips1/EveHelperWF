using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects
{
    public  class UniverseIdSearchResultItem
    {
        public long id {  get; set; }
        public string name { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string resultType { get; set; }

    }
}
