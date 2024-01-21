using System;

namespace EveHelperWF.Objects
{
    public class BuildPlan
    {
        public Int32 finalProductTypeID { get; set; }
        public CalculationHelperClass IndustrySettings { get; set; }
        public List<MaterialsWithMarketData> InputMaterials { get; set; }
        public List<MaterialsWithMarketData> AllItems { get; set; }
        public string BuildPlanName {  get; set; }
        public string BuildPlanNotes { get; set;}
        public decimal additionalCosts { get; set; }
        public int parentBlueprintOrReactionTypeID { get; set; }
        public int TotalOutcome {  get; set; }
        public int RunsPerCopy {  get; set; }
        public int NumOfCopies {  get; set; }
        public List<OptimizedBuild> OptimizedBuilds { get; set; }
        public int TotalRuns
        {
            get
            {
                return (RunsPerCopy * NumOfCopies);
            }
        }
    }
}
