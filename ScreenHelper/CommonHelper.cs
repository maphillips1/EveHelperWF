using EveHelperWF.Objects;
using EveHelperWF.UI_Controls.Main_Screen_Tabs;
using FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveHelperWF.ScreenHelper
{
    public static class CommonHelper
    {
        private static List<EveHelperWF.Objects.StructureProfile> m_StructureProfiles = new List<EveHelperWF.Objects.StructureProfile>();
        private static List<Objects.InventoryType> m_InventoryTypes = new List<InventoryType>();
        public static List<Objects.InventoryType> InventoryTypes
        {
            get
            {
                if (m_InventoryTypes == null) { m_InventoryTypes = new List<InventoryType>(); }
                return m_InventoryTypes;
            }
            set
            {
                m_InventoryTypes = value;
            }
        }
        private static List<Objects.SolarSystem> m_SolarSystemLists = new List<SolarSystem>();
        public static List<Objects.SolarSystem> SolarSystemList
        {
            get
            {
                if (m_SolarSystemLists == null) { m_SolarSystemLists = new List<Objects.SolarSystem>(); }
                return m_SolarSystemLists;
            }
            set
            {
                m_SolarSystemLists = value;
            }
        }
        public static List<Objects.AdjustedCost> AdjustedCosts
        {
            get
            {
                if (m_AdjustedCosts == null)
                {
                    m_AdjustedCosts = new List<Objects.AdjustedCost>();
                }
                return m_AdjustedCosts;
            }
            set
            {
                m_AdjustedCosts = value;
            }
        }
        private static List<Objects.AdjustedCost> m_AdjustedCosts = null;
        public static List<Objects.CostIndice> CostIndicies
        {
            get
            {
                if (m_CostIndicies == null)
                {
                    m_CostIndicies = new List<Objects.CostIndice>();
                }
                return m_CostIndicies;
            }
            set
            {
                m_CostIndicies = value;
            }
        }
        public static List<EveHelperWF.Objects.StructureProfile> structureProfiles
        {
            get
            {
                if (m_StructureProfiles == null) { m_StructureProfiles = new List<EveHelperWF.Objects.StructureProfile>();}
                return m_StructureProfiles;
            }
            set
            {
                m_StructureProfiles = value;
            }
        }
        private static List<Objects.CostIndice> m_CostIndicies = null;
        public static List<Objects.EngineerngComplex> EngineerngComplices = null;
        public static List<Objects.RefineryComplex> RefinerComplices = null;


        public static void Init()
        {
            LoadInventoryTypes();
            LoadSolarSystems();
            LoadEngineeringComplexes();
            LoadRefineryComplices();
            if (structureProfiles?.Count == 0)
            {
                LoadStructureProfiles();
            }
        }

        public static void InitLongLoading()
        {
            LoadAdjustedCosts();
            LoadCostIndicies();
        }

        public static void LoadInventoryTypes()
        {
            InventoryTypes = Database.SQLiteCalls.GetInventoryTypes();
        }

        public static void LoadAdjustedCosts()
        {
            AdjustedCosts = ESI_Calls.ESIMarketData.GetAdjustedCosts();
        }

        public static void LoadCostIndicies()
        {
            CostIndicies = ESI_Calls.ESIIndustry.GetCostIndices();
        }

        public static void LoadSolarSystems()
        {
            FileHelper.LogError("Loading Solar Systems", "");
            SolarSystemList = Database.SQLiteCalls.GetSolarSystems();
            FileHelper.LogError("Loading systems done. Solar system count = " + SolarSystemList?.Count(), "");
        }

        public static void LoadRefineryComplices()
        {
            RefinerComplices = new List<Objects.RefineryComplex>();

            Objects.RefineryComplex athanor = new Objects.RefineryComplex();
            athanor.StructureTypeID = 35835;
            athanor.StructureName = "Athanor";
            athanor.StructureSize = 1;
            athanor.ReactionTimeBonus = 0;
            RefinerComplices.Add(athanor);

            Objects.RefineryComplex tatara = new Objects.RefineryComplex();
            tatara.StructureTypeID = 35836;
            tatara.StructureName = "Tatara";
            tatara.StructureSize = 2;
            tatara.ReactionTimeBonus = 25;
            RefinerComplices.Add(tatara);
        }

        public static void LoadEngineeringComplexes()
        {
            EngineerngComplices = new List<Objects.EngineerngComplex>();

            Objects.EngineerngComplex raitaru = new Objects.EngineerngComplex();
            raitaru.StructureName = "Raitaru";
            raitaru.StructureTypeId = (int)Enums.Enums.EngineeringStructureType.Raitaru;
            raitaru.MatBonus = 1;
            raitaru.TimeRequirementBonus = 15;
            raitaru.IskRequirementBonus = 3;
            raitaru.StructureSize = 1;
            EngineerngComplices.Add(raitaru);

            Objects.EngineerngComplex azbel = new Objects.EngineerngComplex();
            azbel.StructureName = "Azbel";
            azbel.StructureTypeId = (int)Enums.Enums.EngineeringStructureType.Azbel;
            azbel.MatBonus = 1;
            azbel.TimeRequirementBonus = 20;
            azbel.IskRequirementBonus = 4;
            azbel.StructureSize = 2;
            EngineerngComplices.Add(azbel);

            Objects.EngineerngComplex sotiyo = new Objects.EngineerngComplex();
            sotiyo.StructureName = "Sotiyo";
            sotiyo.StructureTypeId = (int)Enums.Enums.EngineeringStructureType.Sotiyo;
            sotiyo.MatBonus = 1;
            sotiyo.TimeRequirementBonus = 30;
            sotiyo.IskRequirementBonus = 5;
            sotiyo.StructureSize = 3;
            EngineerngComplices.Add(sotiyo);
        }

        public static void LoadStructureProfiles()
        {

            string fileName = Enums.Enums.StructureProfilesDirectory + "StructureProfiles.json";
            if (File.Exists(fileName))
            {
                string allText = FileHelper.GetFileContent(fileName);
                structureProfiles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EveHelperWF.Objects.StructureProfile>>(allText);
            }
        }

        public static string FormatIsk(decimal iskAmount)
        {
            string formattedIsk = "";

            if (iskAmount > 0)
            {
                formattedIsk = iskAmount.ToString("C");
                formattedIsk = formattedIsk.Replace(NumberFormatInfo.CurrentInfo.CurrencySymbol, "");
                formattedIsk = formattedIsk.Trim() + " isk";
            }
            else
            {
                formattedIsk = iskAmount.ToString("C");
                formattedIsk = formattedIsk.Replace(NumberFormatInfo.CurrentInfo.CurrencySymbol, "");
                formattedIsk = formattedIsk.Trim() + " isk";
            }

            return formattedIsk;
        }

        public static string FormatIskShortened(decimal iskAmount)
        {
            string formattedIsk = "";

            if (iskAmount > 0)
            {
                decimal shortenedAmount;
                switch (iskAmount)
                {
                    case >= 1000000000000:
                        shortenedAmount = Math.Round(iskAmount / (decimal)1000000000000, 3);
                        formattedIsk = shortenedAmount.ToString("C") + " T";
                        break;
                    case >= 1000000000:
                        shortenedAmount = Math.Round(iskAmount / (decimal)1000000000, 3);
                        formattedIsk = shortenedAmount.ToString("C") + " B";
                        break;
                    case >= 1000000:
                        shortenedAmount = Math.Round(iskAmount / (decimal)1000000, 3);
                        formattedIsk = shortenedAmount.ToString("C") + " M";
                        break;
                    case >= 1000:
                        shortenedAmount = Math.Round(iskAmount / (decimal)1000, 3);
                        formattedIsk = shortenedAmount.ToString("C") + " K";
                        break;
                    default:
                        formattedIsk = iskAmount.ToString("C");
                        break;

                }

                formattedIsk = formattedIsk.Replace(NumberFormatInfo.CurrentInfo.CurrencySymbol, "");
                formattedIsk = formattedIsk.Trim() + " isk";
            }
            else
            {
                formattedIsk = iskAmount.ToString("C");
                formattedIsk = formattedIsk.Replace(NumberFormatInfo.CurrentInfo.CurrencySymbol, "");
                formattedIsk = formattedIsk.Trim() + " isk";
            }

            return formattedIsk;
        }

        public static List<ComboListItem> GetStructureBonusComboItems()
        {
            List<ComboListItem> comboListItems = new List<ComboListItem>();
            comboListItems.Add(new ComboListItem());
            comboListItems.Add(new ComboListItem() { key = 1, value = "- 2.0 %" });
            comboListItems.Add(new ComboListItem() { key = 2, value = "- 2.4 %" });
            return comboListItems;
        }


        public static decimal GetManufacturingStructureMEBonus(Objects.CalculationHelperClass calculationHelperClass, BlueprintInfo bpInfo)
        {
            decimal bonus = 1;

            EveHelperWF.Objects.StructureProfile structureProfile = null;
            EngineerngComplex structureProfileEngineeringComplex = null;
            Objects.EngineerngComplex complex = null;
            int solarSystemId = 0;
            int meRig = 0;
            if (bpInfo != null && bpInfo.StructureProfileId > 0)
            {
                structureProfile = structureProfiles.Find(x => x.profileId == bpInfo.StructureProfileId);
                structureProfileEngineeringComplex = EngineerngComplices.Find(x => x.StructureTypeId == structureProfile.structureTypeId);
            }

            if (structureProfileEngineeringComplex != null)
            {
                complex = structureProfileEngineeringComplex;
                solarSystemId = structureProfile.solarSystemID;
                meRig = structureProfile.MERig;
            }
            else if(calculationHelperClass.ManufacturingStructureTypeID > 0)
            {
                complex = EngineerngComplices.Find(x => x.StructureTypeId == calculationHelperClass.ManufacturingStructureTypeID);
                solarSystemId = calculationHelperClass.ManufacturingSolarSystemID;
                if (calculationHelperClass.ManufacturingStructureRigBonus != null)
                {
                    meRig = calculationHelperClass.ManufacturingStructureRigBonus.RigMEBonus;
                }
            }

            if (complex != null)
            {
                bool isLowSec = false;
                bool isNullSec = false;

                if (solarSystemId > 0)
                {
                    Objects.SolarSystem solarSystem = SolarSystemList.Find(x => x.solarSystemID == solarSystemId);
                    isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                    isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
                }

                if (complex != null)
                {
                    bonus -= (Convert.ToDecimal(complex.MatBonus) / 100);
                }

                if (meRig > 0)
                {
                    decimal rigBonus = 0;
                    if (meRig == 1)
                    {
                        rigBonus = Convert.ToDecimal(0.02);
                    }
                    else if (meRig == 2)
                    {
                        rigBonus = Convert.ToDecimal(0.024);
                    }
                    if (isLowSec)
                    {
                        rigBonus *= Convert.ToDecimal(1.9);
                    }
                    else if (isNullSec)
                    {
                        rigBonus *= Convert.ToDecimal(2.1);
                    }
                    rigBonus = 1 - (rigBonus);

                    bonus *= rigBonus;
                }
            }

            return bonus;
        }

        public static decimal GetReactionStructureMEBonus(Objects.CalculationHelperClass calculationHelperClass, BlueprintInfo bpInfo)
        {
            decimal bonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;
            int solarSystemId = 0;
            int meRig = 0;

            RefineryComplex refineryComplex = null;
            EveHelperWF.Objects.StructureProfile structureProfile = null;

            if (bpInfo != null && bpInfo.StructureProfileId > 0)
            {
                structureProfile = structureProfiles.Find(x => x.profileId == bpInfo.StructureProfileId);
                refineryComplex = RefinerComplices.Find(x => x.StructureTypeID == structureProfile.structureTypeId);
            }

            if (refineryComplex != null)
            {
                solarSystemId = structureProfile.solarSystemID;
                meRig = structureProfile.MERig;
            }
            else if (calculationHelperClass.ReactionSolarSystemID > 0)
            {
                solarSystemId = calculationHelperClass.ReactionSolarSystemID;
                if (calculationHelperClass.ReactionsStructureTypeID > 0)
                {
                    refineryComplex = RefinerComplices.Find(x => x.StructureTypeID == calculationHelperClass.ReactionsStructureTypeID);
                    if (calculationHelperClass.ReactionStructureRigBonus != null)
                    {
                        meRig = calculationHelperClass.ReactionStructureRigBonus.RigMEBonus;
                    }
                }
            }

            if (solarSystemId > 0)
            {
                Objects.SolarSystem solarSystem = SolarSystemList.Find(x => x.solarSystemID == calculationHelperClass.ReactionSolarSystemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (refineryComplex != null)
            {

                if (meRig > 0)
                {
                    decimal rigBonus = 0;
                    if (meRig == 1)
                    {
                        rigBonus = Convert.ToDecimal(0.02);
                    }
                    else if (meRig == 2)
                    {
                        rigBonus = Convert.ToDecimal(0.024);
                    }
                    //if (isLowSec)
                    //{
                    //    rigBonus *= Convert.ToDecimal(1.9);
                    //}
                    if (isNullSec)
                    {
                        rigBonus *= Convert.ToDecimal(1.1);
                    }
                    rigBonus = 1 - (rigBonus);

                    bonus *= rigBonus;
                }
            }

            return bonus;
        }

        public static decimal GetManufacturingStructureCostBonus(Objects.CalculationHelperClass helperClass, BlueprintInfo bpInfo)
        {
            decimal costBonus = 1;

            Objects.EngineerngComplex complex = null;
            if (bpInfo != null && bpInfo.StructureProfileId > 0)
            {
                EveHelperWF.Objects.StructureProfile structureProfile = structureProfiles.Find(x => x.profileId == bpInfo.StructureProfileId);
                complex = EngineerngComplices.Find(x => x.StructureTypeId == structureProfile.structureTypeId);
            }

            if (complex == null && helperClass.ManufacturingStructureTypeID > 0)
            {
                complex = EngineerngComplices.Find(x => x.StructureTypeId == helperClass.ManufacturingStructureTypeID);
            }

            if (complex != null)
            {
                costBonus -= (Convert.ToDecimal(complex.IskRequirementBonus) / 100);
            }

            return costBonus;
        }

        public static decimal GetBaseCost(List<MaterialsWithMarketData> manuMats, bool useQuantityTotal, int runsNeeded)
        {
            decimal baseCost = 0;
            AdjustedCost? adjustedCost;
            long quantity = 0;
            foreach (MaterialsWithMarketData mat in manuMats)
            {
                if (useQuantityTotal)
                {
                    quantity = mat.quantity * runsNeeded;
                }
                else
                {
                    quantity = mat.quantity;
                }
                adjustedCost = AdjustedCosts.Find(x => x.type_id == mat.materialTypeID);
                if (adjustedCost != null)
                {
                    if (adjustedCost.adjusted_price > 0)
                    {

                        baseCost += Math.Round(adjustedCost.adjusted_price * quantity);
                    }
                    else
                    {
                        baseCost += Math.Round(adjustedCost.average_price * quantity);
                    }
                }
            }

            return baseCost;
        }

        public static decimal GetCostIndexForSystemID(int solarSystemID, string activityName)
        {
            decimal costIndex = 0;

            if (CommonHelper.CostIndicies.Count > 0)
            {
                CostIndice? costIndice = CostIndicies.Find(x => x.solar_system_id == solarSystemID);
                if (costIndice != null)
                {
                    costIndex = costIndice.cost_indices.Find(x => x.activity == activityName).cost_index;
                }
            }

            return costIndex;
        }

        public static decimal CalculateManufacturingJobCost(List<Objects.MaterialsWithMarketData> Mats, Objects.CalculationHelperClass helperClass, int runsNeeded, BlueprintInfo bpinfo)
        {

            decimal baseCost = GetBaseCost(Mats, true, runsNeeded);
            decimal jobCost = 0;
            decimal costIndice = 0;
            double sccSurcharge = Enums.Enums.SCCSurcharge;
            decimal structureBonus = GetManufacturingStructureCostBonus(helperClass, bpinfo);
            decimal jobGrossCost = 0;
            int solarSystemId = helperClass.ManufacturingSolarSystemID;
            decimal tax = helperClass.ManufacturingFacilityTax;


            if (bpinfo != null && bpinfo.StructureProfileId > 0)
            {
                Objects.StructureProfile profile = structureProfiles.Find(x => x.profileId == bpinfo.StructureProfileId);
                EngineerngComplex complex = EngineerngComplices.Find(x => x.StructureTypeId == profile.structureTypeId);
                if (complex != null)
                {
                    solarSystemId = profile.solarSystemID;
                    tax = profile.taxAmount;
                }
            }

            if (solarSystemId > 0)
            {
                costIndice = GetCostIndexForSystemID(solarSystemId, CostIndiceActivity.ActivityManufacturing);
            }

            jobGrossCost = Math.Round(baseCost * costIndice);

            jobGrossCost = Math.Round(jobGrossCost * structureBonus);

            jobCost = jobGrossCost;

            jobCost += Math.Round(baseCost * (Convert.ToDecimal(tax) / 100));

            jobCost += Math.Round(baseCost * (decimal)sccSurcharge);

            return jobCost;
        }

        public static decimal CalculateReactionJobCost(List<Objects.MaterialsWithMarketData> Mats, Objects.CalculationHelperClass helperClass, int runsNeeded, BlueprintInfo bpinfo)
        {
            decimal baseCost = GetBaseCost(Mats, true, runsNeeded);
            decimal jobCost = 0;
            decimal costIndice = 0;
            double sccSurcharge = Enums.Enums.SCCSurcharge;
            decimal jobGrossCost = 0;
            int solarSystemId = helperClass.ReactionSolarSystemID;
            decimal tax = helperClass.ReactionsFacilityTax;


            if (bpinfo != null && bpinfo.StructureProfileId > 0)
            {
                Objects.StructureProfile profile = structureProfiles.Find(x => x.profileId == bpinfo.StructureProfileId);
                RefineryComplex complex = RefinerComplices.Find(x => x.StructureTypeID == profile.structureTypeId);
                if (complex != null)
                {
                    solarSystemId = profile.solarSystemID;
                    tax = profile.taxAmount;
                }
            }

            if (solarSystemId > 0)
            {
                costIndice = GetCostIndexForSystemID(solarSystemId, CostIndiceActivity.ACtivityReaction);
            }

            jobGrossCost = Math.Round(baseCost * costIndice);

            jobCost = jobGrossCost;

            jobCost += Math.Round(baseCost * (Convert.ToDecimal(tax) / 100));

            jobCost += Math.Round(baseCost * (decimal)sccSurcharge);

            return jobCost;
        }

        public static decimal GetTotalCostOfChildMats(List<MaterialsWithMarketData> childMats)
        {
            decimal totalCost = 0;
            foreach (MaterialsWithMarketData mat in childMats)
            {
                totalCost += mat.priceTotal;
            }
            return totalCost;
        }

        public static decimal CalculateTaxAndFees(decimal iskBeingTaxed, Objects.CalculationHelperClass helperClass, int orderType)
        {
            decimal taxAndFees = 0;
            decimal baseSalesTax = Convert.ToDecimal(0.08);
            decimal baseBrokersFee = Convert.ToDecimal(0.03);
            int accountingSkillLevel = helperClass.AccountingSkill;
            decimal accountingSkillBonus = (Convert.ToDecimal(.0088) * Convert.ToDecimal(accountingSkillLevel));
            int brokerRelationsSKillLevel = helperClass.BrokersSkill;
            decimal brokerRelationsSkillBonus = Convert.ToDecimal(.003) * Convert.ToDecimal(brokerRelationsSKillLevel);
            bool isBuyOrder = (orderType == 2);
            decimal totalSalesTax = baseSalesTax - accountingSkillBonus;
            decimal totalBrokerFee = baseBrokersFee - brokerRelationsSkillBonus;

            if (isBuyOrder)
            {
                taxAndFees += (iskBeingTaxed * totalSalesTax);
            }
            else
            {
                taxAndFees += (iskBeingTaxed * totalSalesTax);
                taxAndFees += (iskBeingTaxed * totalBrokerFee);
            }

            return taxAndFees;
        }

        public static long CalculateManufacturingReactionJobTime(int bpReactionTypeID, long baseTime, CalculationHelperClass helperClass, int TEValue, bool isReaction, BlueprintInfo bpInfo)
        {
            //The base time passed in should be the numruns * time per run
            decimal totalTime = (decimal)baseTime;
            if (isReaction)
            {
                decimal ReactionSkillBonus = 1 - (((decimal)helperClass.ReactionsSkill * 4) / 100);
                decimal reactionStructureBonus = ReactionStructureTimeBonus(helperClass.ReactionsStructureTypeID, bpInfo);
                decimal reactionRigBonus = StructureRigTimeFactor(helperClass.ReactionStructureRigBonus.RigTEBonus, helperClass.ReactionSolarSystemID, isReaction, bpInfo);

                totalTime = totalTime * ReactionSkillBonus;
                totalTime *= reactionStructureBonus;
                totalTime *= reactionRigBonus;
                totalTime = Math.Ceiling(totalTime);
            }
            else
            {
                decimal TEDecimal = 1 - (decimal)TEValue / 100;
                decimal industryFactor = 1 - ((decimal)(helperClass.IndustrySkill * 4) / 100);
                decimal advIndyFactor = 1 - ((decimal)(helperClass.AdvancedIndustrySkill * 3) / 100);
                decimal skillFactor = BPSpecificSkillFactor(bpReactionTypeID, helperClass);
                decimal structureBonus = GetManufacturingStructureTimeBonus(helperClass.ManufacturingStructureTypeID, bpInfo);
                decimal structureRigFactor = StructureRigTimeFactor(helperClass.ManufacturingStructureRigBonus.RigTEBonus, helperClass.ManufacturingSolarSystemID, isReaction, bpInfo);
                decimal implantBonus = ManufacturingImplantBonus(helperClass.ManufacturingImplantTypeID);

                totalTime *= TEDecimal;
                totalTime *= industryFactor;
                totalTime *= advIndyFactor;
                totalTime *= skillFactor;
                totalTime *= structureBonus;
                totalTime *= structureRigFactor;
                totalTime *= implantBonus;
                totalTime = Math.Ceiling(totalTime);
            }
            return Convert.ToInt64(totalTime);
        }

        private static decimal BPSpecificSkillFactor(int bpReactionTypeId, CalculationHelperClass helperClass)
        {
            decimal factor = 1;
            decimal singleFactor = 1;

            if (BPRequiresSkill(bpReactionTypeId, (int)Enums.Enums.SkillID.AdvancedSmallShipConstruction))
            {
                singleFactor = 1 - ((decimal)(helperClass.AdvacnedSmallConstructionSkill * 1) / 100);
                factor *= singleFactor;
            }
            if (BPRequiresSkill(bpReactionTypeId, (int)Enums.Enums.SkillID.AdvancedMediumShipConstruction))
            {
                singleFactor = 1 - ((decimal)(helperClass.AdvacnedMediumConstructionSkill * 1) / 100);
                factor *= singleFactor;
            }
            if (BPRequiresSkill(bpReactionTypeId, (int)Enums.Enums.SkillID.AdvancedLargeShipConstruction))
            {
                singleFactor = 1 - ((decimal)(helperClass.AdvacnedLargeConstructionSkill * 1) / 100);
                factor *= singleFactor;
            }
            if (BPRequiresSkill(bpReactionTypeId, (int)Enums.Enums.SkillID.AdvancedCapitalShipConstruction))
            {
                singleFactor = 1 - ((decimal)(helperClass.AdvancedCapitalConstructionSkill * 1) / 100);
                factor *= singleFactor;
            }
            if (BPRequiresSkill(bpReactionTypeId, (int)Enums.Enums.SkillID.AdvancedIndustrialShipConstruction))
            {
                singleFactor = 1 - ((decimal)(helperClass.IndustrySkill * 1) / 100);
                factor *= singleFactor;
            }

            return factor;
        }

        private static bool BPRequiresSkill(int bpReactionTypeId, int skillID)
        {
            bool skillRequired = false;

            List<IndustryActivitySkill> skills = Database.SQLiteCalls.GetINdustryActivitySkills(bpReactionTypeId, Enums.Enums.ActivityManufacturing);

            if (skills != null && skills.Find(x => x.skillID == skillID) != null)
            {
                skillRequired = true;
            }

            return skillRequired;
        }

        private static decimal GetManufacturingStructureTimeBonus(int manuComplexId, BlueprintInfo bpInfo)
        {
            decimal Factor = 1;
            EngineerngComplex engineerngComplex = null;
            if (bpInfo != null && bpInfo.StructureProfileId > 0)
            {
                Objects.StructureProfile structureProfile = structureProfiles.Find(x => x.profileId == bpInfo.StructureProfileId);
                engineerngComplex = EngineerngComplices.Find(x => x.StructureTypeId == structureProfile.structureTypeId);
            }

            if (engineerngComplex == null && manuComplexId > 0)
            {
                engineerngComplex = EngineerngComplices.Find(x => x.StructureTypeId == manuComplexId);
                if (engineerngComplex != null)
                {
                    Factor = 1 - (decimal)engineerngComplex.TimeRequirementBonus / 100;
                }
            }

            return Factor;
        }

        private static decimal StructureRigTimeFactor(int TERigType, int systemID, bool isReaction, BlueprintInfo bpInfo)
        {
            decimal bonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;
            int solarSystemId = systemID;
            int teRig = TERigType;

            if (bpInfo != null && bpInfo.StructureProfileId > 0)
            {
                Objects.StructureProfile structureProfile = structureProfiles.Find(x => x.profileId == bpInfo.StructureProfileId);
                if (isReaction)
                {
                    RefineryComplex complex = RefinerComplices.Find(x => x.StructureTypeID == structureProfile.structureTypeId);
                    if (complex != null)
                    {
                        teRig = structureProfile.TERig;
                        solarSystemId = structureProfile.solarSystemID;
                    }
                }
                else
                {
                    EngineerngComplex complex = EngineerngComplices.Find(x => x.StructureTypeId == structureProfile.structureTypeId);
                    if (complex != null)
                    {
                        teRig = structureProfile.TERig;
                        solarSystemId = structureProfile.solarSystemID;
                    }
                }
            }

            if (solarSystemId > 0)
            {
                Objects.SolarSystem solarSystem = SolarSystemList.Find(x => x.solarSystemID == solarSystemId);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (teRig > 0)
            {

                decimal rigBonus = 0;
                if (teRig == 1)
                {
                    rigBonus = Convert.ToDecimal(0.2);
                }
                else if (teRig == 2)
                {
                    rigBonus = Convert.ToDecimal(0.24);
                }
                if (isLowSec && !isReaction)
                {
                    rigBonus *= Convert.ToDecimal(1.9);
                }
                if (isNullSec)
                {
                    if (isReaction)
                    {
                        rigBonus *= Convert.ToDecimal(1.1);
                    }
                    else
                    {
                        rigBonus *= Convert.ToDecimal(2.1);
                    }
                }
                rigBonus = 1 - (rigBonus);

                bonus *= rigBonus;
            }

            return bonus;
        }

        private static decimal ManufacturingImplantBonus(int implantTypeId)
        {
            decimal factor = 1;

            InventoryType inventoryType = InventoryTypes.Find(x => x.typeId == implantTypeId);
            if (inventoryType != null)
            {
                if (inventoryType.typeName.Contains("05"))
                {
                    factor = (decimal)0.95;
                }
                else if (inventoryType.typeName.Contains("03"))
                {
                    factor = (decimal)0.97;
                }
                else if (inventoryType.typeName.Contains("01"))
                {
                    factor = (decimal)0.99;
                }
            }

            return factor;
        }

        private static decimal ReactionStructureTimeBonus(int reactionStructureTypeId, BlueprintInfo bpInfo)
        {
            decimal factor = 1;
            BlueprintBrowserHelper.Init();

            RefineryComplex refineryComplex = null;

            if (bpInfo != null && bpInfo.StructureProfileId > 0)
            {
                Objects.StructureProfile structureProfile = structureProfiles.Find(x => x.profileId == bpInfo.StructureProfileId);
                refineryComplex = RefinerComplices.Find(x => x.StructureTypeID == structureProfile.structureTypeId);
            }

            if (refineryComplex == null && reactionStructureTypeId > 0)
            {
                refineryComplex = RefinerComplices.Find(x => x.StructureTypeID == reactionStructureTypeId);
            }

            if (refineryComplex != null)
            {
                factor -= (decimal)refineryComplex.ReactionTimeBonus / 100;
            }

            return factor;
        }

        public static void PerformReactionMECalculations(ref List<MaterialsWithMarketData> childMats, CalculationHelperClass industrySettings, int runsNeeded, BlueprintInfo? bpinfo)
        {
            decimal totalStructureMEBonus = 1;
            long quantityTotal = 0;
            if (industrySettings.ReactionsStructureTypeID > 0)
            {
                totalStructureMEBonus = CommonHelper.GetReactionStructureMEBonus(industrySettings, bpinfo);
            }
            foreach (Objects.MaterialsWithMarketData mat in childMats)
            {
                //Calculation
                //Total = BaseQuantity * runs * (Bonus Percentage total (rigs, structure bonuses, etc) )

                //Step 1 = Quantity Total * runs Ceiling
                quantityTotal = (long)((mat.quantity * runsNeeded));

                //Step 3 = Apply the structure ME Bonuses
                quantityTotal = (long)(Math.Ceiling(quantityTotal * totalStructureMEBonus));

                //Always need at least one.
                if (quantityTotal < runsNeeded) { quantityTotal = runsNeeded; }

                mat.quantityTotal += quantityTotal;
                mat.quantityPerRun = quantityTotal / runsNeeded;
            }
        }

        public static void PerformManufacturingMECalculations(ref List<MaterialsWithMarketData> outputMaterials,
                                                              CalculationHelperClass industrySettings,
                                                              int runsNeeded,
                                                              int bpME,
                                                              BlueprintInfo bpInfo)
        {
            decimal totalStructureMEBonus = 1;
            decimal MEBonus = (100m - Convert.ToDecimal(bpME)) / 100;
            long quantityTotal = 0;
            List<Int32> buildableMats = new List<int>();
            if (industrySettings.ManufacturingStructureTypeID > 0 || 
                  (bpInfo != null && bpInfo.StructureProfileId > 0))
            {
                totalStructureMEBonus = CommonHelper.GetManufacturingStructureMEBonus(industrySettings, bpInfo);
            }
            foreach (Objects.MaterialsWithMarketData mat in outputMaterials)
            {
                //Calculation
                //QuantityTotal = BaseMat * Num Runs. Completed in SetBaseInputValues. 
                //
                //QuantityTotal = Math.Ceiling(QuantityTotal * (Bonus Percentage total (rigs, structure bonuses, etc) )
                quantityTotal = mat.quantity * runsNeeded;

                //Step 1 = Set quantity Total to Base Blueprint * ME.
                quantityTotal = (long)Math.Ceiling(quantityTotal * MEBonus * totalStructureMEBonus);

                //You always need at least 1 item per run
                if (quantityTotal < runsNeeded) { quantityTotal = runsNeeded; }

                mat.quantityTotal += quantityTotal;
                mat.quantityPerRun = quantityTotal / runsNeeded;
            }
        }

        public static Color GetInvertedColor(Color c)
        {
            return Color.FromArgb(c.ToArgb() ^ 0xffffff);
        }
    }
}
