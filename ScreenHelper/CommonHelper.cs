using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveHelperWF.ScreenHelper
{
    public static class CommonHelper
    {
        public static List<Objects.InventoryType> InventoryTypes = null;
        public static List<Objects.SolarSystem> SolarSystemList = null;
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
        private static List<Objects.CostIndice> m_CostIndicies = null;
        public static List<Objects.EngineerngComplex> EngineerngComplices = null;


        public static void Init()
        {
            LoadInventoryTypes();
            LoadSolarSystems();
            LoadEngineeringComplexes();
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
            SolarSystemList = Database.SQLiteCalls.GetSolarSystems();
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
                    case > 1000000000:
                        shortenedAmount = Math.Round(iskAmount / (decimal)1000000000, 3);
                        formattedIsk = shortenedAmount.ToString("C") + " B";
                        break;
                    case > 100000000:
                        shortenedAmount = Math.Round(iskAmount / (decimal)1000000, 3);
                        formattedIsk = shortenedAmount.ToString("C") + " M";
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


        public static decimal GetManufacturingStructureMEBonus(Objects.CalculationHelperClass calculationHelperClass)
        {
            decimal bonus = 1;

            if (calculationHelperClass.ManufacturingStructureTypeID > 0)
            {
                bool isLowSec = false;
                bool isNullSec = false;

                if (calculationHelperClass.ManufacturingSolarSystemID > 0)
                {
                    Objects.SolarSystem solarSystem = SolarSystemList.Find(x => x.solarSystemID == calculationHelperClass.ManufacturingSolarSystemID);
                    isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                    isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
                }

                Objects.EngineerngComplex complex = EngineerngComplices.Find(x => x.StructureTypeId == calculationHelperClass.ManufacturingStructureTypeID);

                if (complex != null)
                {
                    bonus -= (Convert.ToDecimal(complex.MatBonus) / 100);
                }

                if (calculationHelperClass.ManufacturingStructureRigBonus != null)
                {
                    decimal rigBonus = 0;
                    if (calculationHelperClass.ManufacturingStructureRigBonus.RigMEBonus == 1)
                    {
                        rigBonus = Convert.ToDecimal(0.02);
                    }
                    else if (calculationHelperClass.ManufacturingStructureRigBonus.RigMEBonus == 2)
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

        public static decimal GetReactionStructureMEBonus(Objects.CalculationHelperClass calculationHelperClass)
        {
            decimal bonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;

            if (calculationHelperClass.ReactionSolarSystemID > 0)
            {
                Objects.SolarSystem solarSystem = SolarSystemList.Find(x => x.solarSystemID == calculationHelperClass.ReactionSolarSystemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (calculationHelperClass.ReactionsStructureTypeID > 0)
            {

                if (calculationHelperClass.ReactionStructureRigBonus != null)
                {
                    decimal rigBonus = 0;
                    if (calculationHelperClass.ReactionStructureRigBonus.RigMEBonus == 1)
                    {
                        rigBonus = Convert.ToDecimal(0.02);
                    }
                    else if (calculationHelperClass.ReactionStructureRigBonus.RigMEBonus == 2)
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

        public static void DisposeAllControlsInCollection(Control.ControlCollection controls)
        {
            EventHandlerList eventHandlerList = null;
            foreach (Control item in controls)
            {
                eventHandlerList =
                        (EventHandlerList)typeof(Control).GetProperty(
                            "Events",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(item, null);
                if (eventHandlerList != null)
                {
                    typeof(EventHandlerList).GetMethod("Dispose").Invoke(eventHandlerList, null);
                }
                if (item.Controls.Count > 0)
                {
                    DisposeAllControlsInCollection(item.Controls);
                }
                item.Dispose();
            }
        }

        public static decimal GetManufacturingStructureCostBonus(Objects.CalculationHelperClass helperClass)
        {
            decimal costBonus = 1;

            if (helperClass.ManufacturingStructureTypeID > 0)
            {
                Objects.EngineerngComplex complex = EngineerngComplices.Find(x => x.StructureTypeId == helperClass.ManufacturingStructureTypeID);
                if (complex != null)
                {
                    costBonus -= (Convert.ToDecimal(complex.IskRequirementBonus) / 100);
                }
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

        public static decimal CalculateManufacturingJobCost(List<Objects.MaterialsWithMarketData> Mats, Objects.CalculationHelperClass helperClass, int runsNeeded)
        {
            decimal baseCost = GetBaseCost(Mats, true, runsNeeded);
            decimal jobCost = 0;
            decimal costIndice = 0;
            double sccSurcharge = Enums.Enums.SCCSurcharge;
            decimal structureBonus = GetManufacturingStructureCostBonus(helperClass);
            decimal jobGrossCost = 0;

            if (helperClass.ManufacturingSolarSystemID > 0)
            {
                costIndice = GetCostIndexForSystemID(helperClass.ManufacturingSolarSystemID, CostIndiceActivity.ActivityManufacturing);
            }

            jobGrossCost = Math.Round(baseCost * costIndice);

            jobGrossCost = Math.Round(jobGrossCost * structureBonus);

            jobCost = jobGrossCost;

            jobCost += Math.Round(baseCost * (Convert.ToDecimal(helperClass.ManufacturingFacilityTax) / 100));

            jobCost += Math.Round(baseCost * (decimal)sccSurcharge);

            return jobCost;
        }

        public static decimal CalculateReactionJobCost(List<Objects.MaterialsWithMarketData> Mats, Objects.CalculationHelperClass helperClass, int runsNeeded)
        {
            decimal baseCost = GetBaseCost(Mats, true, runsNeeded);
            decimal jobCost = 0;
            decimal costIndice = 0;
            double sccSurcharge = Enums.Enums.SCCSurcharge;
            decimal jobGrossCost = 0;

            if (helperClass.ReactionSolarSystemID > 0)
            {
                costIndice = GetCostIndexForSystemID(helperClass.ReactionSolarSystemID, CostIndiceActivity.ACtivityReaction);
            }

            jobGrossCost = Math.Round(baseCost * costIndice);

            jobCost = jobGrossCost;

            jobCost += Math.Round(baseCost * (Convert.ToDecimal(helperClass.ReactionsFacilityTax) / 100));

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

        public static long CalculateManufacturingReactionJobTime(int bpReactionTypeID, long baseTime, CalculationHelperClass helperClass, int TEValue, bool isReaction)
        {
            //The base time passed in should be the numruns * time per run
            decimal totalTime = (decimal)baseTime;
            if (isReaction)
            {
                decimal ReactionSkillBonus = 1 - (((decimal)helperClass.ReactionsSkill * 4) / 100);
                decimal reactionStructureBonus = ReactionStructureTimeBonus(helperClass.ReactionsStructureTypeID);
                decimal reactionRigBonus = StructureRigTimeFactor(helperClass.ReactionStructureRigBonus.RigTEBonus, helperClass.ReactionSolarSystemID);

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
                decimal structureBonus = GetManufacturingStructureTimeBonus(helperClass.ManufacturingStructureTypeID);
                decimal structureRigFactor = StructureRigTimeFactor(helperClass.ManufacturingStructureRigBonus.RigTEBonus, helperClass.ManufacturingSolarSystemID);
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

        private static decimal GetManufacturingStructureTimeBonus(int manuComplexId)
        {
            decimal Factor = 1;

            if (manuComplexId > 0)
            {
                EngineerngComplex engineerngComplex = EngineerngComplices.Find(x => x.StructureTypeId == manuComplexId);
                if (engineerngComplex != null)
                {
                    Factor = 1 - (decimal)engineerngComplex.TimeRequirementBonus / 100;
                }
            }

            return Factor;
        }

        private static decimal StructureRigTimeFactor(int TERigType, long systemID)
        {
            decimal bonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;

            if (systemID > 0)
            {
                Objects.SolarSystem solarSystem = SolarSystemList.Find(x => x.solarSystemID == systemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (TERigType > 0)
            {

                decimal rigBonus = 0;
                if (TERigType == 1)
                {
                    rigBonus = Convert.ToDecimal(0.2);
                }
                else if (TERigType == 2)
                {
                    rigBonus = Convert.ToDecimal(0.24);
                }
                if (isLowSec)
                {
                    rigBonus *= Convert.ToDecimal(1.9);
                }
                if (isNullSec)
                {
                    rigBonus *= Convert.ToDecimal(2.1);
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

        private static decimal ReactionStructureTimeBonus(int reactionStructureTypeId)
        {
            decimal factor = 1;
            BlueprintBrowserHelper.Init();

            RefineryComplex refineryComplex = BlueprintBrowserHelper.RefinerComplices.Find(x => x.StructureTypeID == reactionStructureTypeId);
            if (refineryComplex != null)
            {
                factor -= (decimal)refineryComplex.ReactionTimeBonus / 100;
            }

            return factor;
        }
    }
}
