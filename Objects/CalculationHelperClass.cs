using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class CalculationHelperClass
    {
        public int SelectedTypeID { get; set; }
        public int Runs { get; set; }
        public bool InventBlueprint { get; set; }


        public int ME { get; set; }
        public int TE { get; set; }
        public int CompME { get; set; }
        public int CompTE { get; set; }


        public int ManufacturingStructureTypeID { get; set; }
        public int MEStructureTypeID { get; set; }
        public int TEStructureTypeID { get; set; }
        public int CopyingStructureTypeID { get; set; }
        public int InventionStructureTypeID { get; set; }
        public int ReverseEngStructureTypeID { get; set; }
        public int ReactionsStructureTypeID { get; set; }


        public StructureRigBonus ManufacturingStructureRigBonus { get; set; }
        public StructureRigBonus MEStructureRigBonus { get; set; }
        public StructureRigBonus TEStructureRigBonus { get; set; }
        public StructureRigBonus CopyStructureRigBonus { get; set; }
        public StructureRigBonus InventionStructureRigBonus { get; set; }
        public StructureRigBonus ReverseEngStructureRigBonus { get; set; }
        public StructureRigBonus ReactionStructureRigBonus { get; set; }


        public int InputOrderType { get; set; }
        public int OutputOrderType { get; set; }


        public int ManufacturingImplantTypeID { get; set; }
        public int MEImplantTypeID { get; set; }
        public int TEImplantTypeID { get; set; }
        public int CopyImplantTypeID { get; set; }


        public int ManufacturingSolarSystemID { get; set; }
        public int MESolarSystemID { get; set; }
        public int TESolarSystemID { get; set; }
        public int CopyingSolarSystemID { get; set; }
        public int InventionSolarSystemID { get; set; }
        public int ReverseEngineeringSolarSystemID { get; set; }
        public int ReactionSolarSystemID { get; set; }


        public decimal FactionStanding { get; set; }


        public decimal ManufacturingFacilityTax { get; set; }
        public decimal CopyingFacilityTax { get; set; }
        public decimal MEFacilityTax { get; set; }
        public decimal TEFacilityTax { get; set; }
        public decimal InventionFacilityTax { get; set; }
        public decimal ReverseEngFacilityTax { get; set; }
        public decimal ReactionsFacilityTax { get; set; }


        public decimal SkillTimeBonus { get; set; }
        public decimal SkillMEBonus { get; set; }

        public bool BuildComponents { get; set; }

        public int InventionDecryptorId { get; set; }
        public int InventionProductTypeId { get; set; }

        public int MEFromLevel { get; set; }
        public int METoLevel { get; set; }

        public int TEFromLevel { get; set; }
        public int TEToLevel { get; set;}

        public int NumCopies { get; set; }
        public int RunsPerCopy { get; set; }

        //skills
        public int AccountingSkill { get; set; }
        public int BrokersSkill { get; set; }
        public int IndustrySkill { get; set; }
        public int AdvancedIndustrySkill { get; set; }
        public int CapitalShipConstructionSkill { get; set; }
        public int AdvacnedSmallConstructionSkill { get; set; }
        public int AdvacnedMediumConstructionSkill { get; set; }
        public int AdvacnedLargeConstructionSkill { get; set; }
        public int AdvancedCapitalConstructionSkill { get; set; }
        public int AdvancedIndustrialConstructionSkill { get; set; }
        public int ReactionsSkill { get; set; }
        public int ResearchSkill { get; set; }
    }

    public class StructureRigBonus
    {
        public const int ME = 1;
        public const int TE = 2;
        public int RigMEBonus { get; set; }
        public int RigTEBonus { get; set; }
    }
}
