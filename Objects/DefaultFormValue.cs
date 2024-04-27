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
        public int Datacore1SkillLevel { get; set; }
        public int Datacore2SkillLevel { get; set; }
        public int EncryptionStarshipSkillLevel { get; set; }

        //Copying
        public int CopyNumCopies { get; set; }
        public int CopyRunsCopy {  get; set; }
        public int CopySystemID { get; set; }
        public int CopyStructureTypeId { get; set; }
        public int CopyStructureRig { get; set; }
        public decimal CopyTax { get; set; }
        public int CopyImplantTypeID { get; set; }

        //ME
        public int MEFromLevel { get; set; }
        public int METoLevel { get; set;}
        public int MESystemID { get; set; }
        public int MEStructureTypeID { get; set; }
        public int MEStructureRIg { get; set; }
        public decimal METax { get; set; }
        public int MEImplantTypeID { get; set; }

        //TE
        public int TEFromLevel { get; set; }
        public int TEToLevel { get; set;}
        public int TESystemID { get; set;}
        public int TEStructureTypeID { get; set;}
        public int TEStructureRIg { get;set; }
        public decimal TETax { get; set; }
        public int TEImplantTypeID { get; set;}

        // Skills
        public int AccountingSKill { get; set; }
        public int BrokersSkill { get; set; }
        public int IndustrySkill { get; set; }
        public int AdvancedIndustrySkill { get; set; }
        public int CapitalShipConstructionSkill { get; set; }
        public int AdvacnedSmallConstructionSkill { get; set; }
        public int AdvacnedMediumConstructionSkill { get;set; }
        public int AdvacnedLargeConstructionSkill { get; set; }
        public int AdvancedCapitalConstructionSkill { get; set; }
        public int AdvancedIndustrialConstructionSkill { get; set; }
        public int ReactionsSkill { get; set; }
        public int ResearchSkill { get; set; }
    }
}
