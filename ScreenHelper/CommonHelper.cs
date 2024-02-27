using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveHelperWF.ScreenHelper
{
    public static class CommonHelper
    {
        public static List<Objects.InventoryType> InventoryTypes = null;
        public static List<Objects.SolarSystem> SolarSystemList = null;
        public static List<Objects.AdjustedCost> AdjustedCosts = null;
        public static List<Objects.CostIndice> CostIndicies = null;
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
                        rigBonus *= Convert.ToDecimal(1.19);
                    }
                    else if (isNullSec)
                    {
                        rigBonus *= Convert.ToDecimal(1.21);
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
                    //    rigBonus *= Convert.ToDecimal(1.19);
                    //}
                    if (isNullSec)
                    {
                        rigBonus *= Convert.ToDecimal(1.21);
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
            AdjustedCost adjustedCost = null;
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
                CostIndice costIndice = CostIndicies.Find(x => x.solar_system_id == solarSystemID);
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

            jobCost += Math.Round(jobGrossCost * (Convert.ToDecimal(helperClass.ManufacturingFacilityTax) / 100));

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
    }
}
