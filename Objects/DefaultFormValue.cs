using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class DefaultFormValue
    {
        //Main
        public decimal RunsUpDownValue { get; set; }
        public int InputTypeComboValue { get; set; }
        public int OutputTypeComboValue { get; set; }
        public bool InventBlueprintValue { get; set; }
        //Manufacturing
        public bool InventBlueprintCheckboxValue { get; set; } 
        public decimal ManufacturingMEValue { get; set; }
        public decimal ManufacturingTEValue { get; set; }
        public decimal CompMEValue { get; set; }
        public decimal CompTEValue { get; set; }
        public decimal ManufacturingTaxValue { get; set; }
        public int ManufacturingSystemValue { get; set; }
        public int ManufacturingStructureValue { get; set; }
        public int ManufacturingStructureMERigValue { get; set; }
        public int ManufacturingStructureTERigValue { get; set; }
        public int ManufacturingImplantValue { get; set; }
        public bool BuildComponentsValue { get; set; }
        //Reactions
        public int ReactionsSystemValue { get; set; }
        public int ReactionStructureValue { get; set; }
        public int ReactionStructureMERigValue { get; set; }
        public int ReactionStructureTERigValue { get; set; }
        public decimal ReactionTaxValue { get; set; }
        //Invention
        public int InventionSystemValue { get; set; }
        public int InventionStructureValue { get; set; }
        public int InventionStructureCostRigValue { get; set; }
        public int InventionStructureTimeRigValue { get; set; }
        public int InventionDecryptorValue { get; set; }
        public decimal InventionTaxValue { get; set; }
    }
}
