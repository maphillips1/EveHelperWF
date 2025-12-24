using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class OptimizedBuild
    {
        public int BlueprintOrReactionTypeID { get; set; }
        public int BuiltOrReactedTypeId { get; set; }
        public string BuiltOrReactedName { get; set; }
        public int RunsNeeded { get; set; }
        public long TotalQuantityNeeded { get; set; }
        public bool isBuilt { get; set; }
        public bool isReacted { get; set; }
        public bool isFinalProduct { get; set; }
        public List<MaterialsWithMarketData> InputMaterials { get; set; }
        public decimal TotalBuildCost { get; set; }
        public int BatchesNeeded { get; set; }
        public int MaxRunsPerBatch { get; set; }
        public long TimePerRun { get; set; }
        public int ExtraOutput { get; set; }
        public decimal JobCost { get; set; }
        public decimal PricePerItem { get;set; }
        public decimal MaterialCost { get; set; }
        public decimal AdditionalCost { get; set; }
        public decimal inputMaterialTax { get; set; }
    }
}
