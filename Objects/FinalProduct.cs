using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class FinalProduct
    {
        public int finalProductTypeId {  get; set; }
        public string finalProductTypeName { get; set; }
        public decimal additionalCosts { get; set; }
        public int blueprintOrReactionTypeId { get; set; }
        public int TotalOutcome { get; set; }
        public int RunsPerCopy { get; set; }
        public int NumOfCopies { get; set; }
        public int TotalRuns
        {
            get
            {
                return (RunsPerCopy * NumOfCopies);
            }
        }
        public decimal customSellPrice { get; set; }
        public decimal jitaSellPrice { get; set; }
        public decimal jitaBuyPrice { get; set; }
        public decimal CostPerItem { get; set; }
        public decimal totalOutcomeVolume { get; set; }
        public decimal profit {  get; set; }
        public string TotalCost
        {
            get
            {
                return CommonHelper.FormatIsk(CostPerItem * TotalOutcome);
            }
        }
    }
}
