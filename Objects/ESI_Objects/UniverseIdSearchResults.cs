using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class UniverseIdSearchResults
    {
        public UniverseIdSearchResults()
        {
            characters = new List<UniverseIdSearchResultItem>();
            systems = new List<UniverseIdSearchResultItem>();
            alliances = new List<UniverseIdSearchResultItem>();
            constellations = new List<UniverseIdSearchResultItem>();
            regions = new List<UniverseIdSearchResultItem>();
            inventory_types = new List<UniverseIdSearchResultItem>();
        }
        public List<UniverseIdSearchResultItem> characters {  get; set; }
        public List<UniverseIdSearchResultItem> systems { get; set; }
        public List<UniverseIdSearchResultItem> alliances { get; set; }
        public List<UniverseIdSearchResultItem> constellations { get; set; }
        public List<UniverseIdSearchResultItem> regions { get; set; }
        public List<UniverseIdSearchResultItem> inventory_types { get; set; }
    }
}
