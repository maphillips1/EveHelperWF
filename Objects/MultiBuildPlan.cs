using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class MultiBuildPlan
    {
        public MultiBuildPlan()
        {
            FinalProducts = new List<FinalProduct>();
            completedBuilds = new List<int>();

            BuildPlanName = "";
            BuildPlanNotes = "";
        }
        public List<FinalProduct> FinalProducts { get; set; }
        public CalculationHelperClass IndustrySettings { get; set; }
        public List<MaterialsWithMarketData> InputMaterials { get; set; }
        public List<MaterialsWithMarketData> AllItems { get; set; }
        public List<BlueprintInfo> BlueprintStore { get; set; }
        public string BuildPlanName { get; set; }
        public string BuildPlanNotes { get; set; }
        public List<OptimizedBuild> OptimizedBuilds { get; set; }
        public Dictionary<int, List<OptimizedBuild>> OptimumBuildGroups { get; set; }
        public List<InventoryTypeWithQuantity> CurrentInventory { get; set; }
        public List<int> completedBuilds { get;set; }
    }
}
