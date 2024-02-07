using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.UI_Controls.Support_Screens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace EveHelperWF.ScreenHelper
{
    public static class BuildPlanHelper
    {
        private static int controlCount = 0;

        public static void SetControlNames(List<MaterialsWithMarketData> materials)
        {
            controlCount = 0;
            SetControlNamesRecursive(materials);
        }

        private static void SetControlNamesRecursive(List<MaterialsWithMarketData> materials)
        {
            foreach (MaterialsWithMarketData inputmat in materials)
            {
                inputmat.controlName = "ControlNum_" + controlCount.ToString();
                controlCount++;
                if (inputmat.ChildMaterials.Count > 0)
                {
                    SetControlNamesRecursive(inputmat.ChildMaterials);
                }
            }
        }

        public static Color GetForeColorForMaterialCategory(MaterialsWithMarketData material)
        {
            Color foreColor = Color.White;

            if (material.Buildable)
            {
                foreColor = Color.Cyan;
            }
            else if (material.Reactable)
            {
                foreColor = Color.MediumPurple;
            }
            else
            {
                InventoryType invType = CommonHelper.InventoryTypes.Find(x => x.typeId == material.materialTypeID);
                switch (invType.categoryID)
                {
                    case (int)Enums.Enums.InvTypeCategory.PlanetResource:
                    case (int)Enums.Enums.InvTypeCategory.PlanetIndustry:
                    case (int)Enums.Enums.InvTypeCategory.PlanetCommodity:
                        foreColor = Color.DarkOrange;
                        break;
                    default:
                        foreColor = Color.Chartreuse;
                        break;
                }
            }

            return foreColor;
        }

        public static Color GetForeColorForMaterialCategory(OptimizedBuild build)
        {
            Color foreColor = Color.White;

            if (build.isBuilt)
            {
                foreColor = Color.Cyan;
            }
            else if (build.isReacted)
            {
                foreColor = Color.MediumPurple;
            }
            else
            {
                foreColor = Color.Chartreuse;
            }

            return foreColor;
        }

        public static void CalculateIndustryValues(ref BuildPlan buildPlan)
        {
            //reset quantity total before calcs
            ZeroOutQuantityTotalRecursive(buildPlan.InputMaterials);

            int bpReactionTypeId = buildPlan.parentBlueprintOrReactionTypeID;
            InventoryType blueprintOrReactionType = CommonHelper.InventoryTypes.Find(x => x.typeId == bpReactionTypeId);

            if (blueprintOrReactionType != null)
            {
                if (IsMaterialReacted(bpReactionTypeId))
                {
                    CalculateReactionTotals(ref buildPlan);
                }
                else if (IsMaterialManufactured(bpReactionTypeId))
                {
                    CalculateManufacturingTotals(ref buildPlan);
                }
            }
        }

        private static bool IsMaterialReacted(int materialTypeID)
        {
            bool reacted = false;

            List<IndustryActivityProduct> products = Database.SQLiteCalls.GetIndustryActivityProducts(materialTypeID, Enums.Enums.ActivityReactions);

            if (products.Count > 0)
            {
                reacted = true;
            }

            return reacted;
        }

        private static bool IsMaterialManufactured(int materialTypeID)
        {
            bool manufactured = false;

            List<IndustryActivityProduct> products = Database.SQLiteCalls.GetIndustryActivityProducts(materialTypeID, Enums.Enums.ActivityManufacturing);

            if (products.Count > 0)
            {
                manufactured = true;
            }

            return manufactured;
        }

        private static void CalculateManufacturingTotals(ref BuildPlan buildPlan)
        {
            IndustryActivityProduct baseProductInformation =
                    Database.SQLiteCalls.GetIndustryActivityProducts(buildPlan.parentBlueprintOrReactionTypeID, Enums.Enums.ActivityManufacturing)[0];
            List<IndustryActivityMaterials> baseMaterials =
                    Database.SQLiteCalls.GetIndustryActivityMaterials(buildPlan.parentBlueprintOrReactionTypeID, Enums.Enums.ActivityManufacturing);

            if (baseProductInformation != null)
            {
                buildPlan.TotalOutcome = baseProductInformation.quantity * buildPlan.RunsPerCopy * buildPlan.NumOfCopies;

                //This sets the base materials that we need. for each copy of the BP. 
                //So if Runs Per Copy is 5 and Num of Copies is 10, this will set the value of base quantity * 5
                //We then run ME calculations on that number. 
                //Once we have ME calcs done, we then multiple final numbers after ME * number of copies. 
                //This becomes our quantity total. 
                //We also set quantity per run to the adjusted ME value.
                List<MaterialsWithMarketData> outputMaterials = new List<MaterialsWithMarketData>();
                //Base Calcs
                SetBaseInputValues(buildPlan.RunsPerCopy, ref outputMaterials, baseMaterials);
                //ME Calculations
                PerformManufacturingMECalculations(ref outputMaterials, buildPlan, buildPlan.RunsPerCopy, buildPlan.IndustrySettings.ME);
                //Next, Set the total quantity needed = QuantityFor Runs * Num of Copies
                //Basically, once we set the blueprints ME values, we now need to know the total of all 
                //inputs needed BEFORE we do any child costs. 
                //Child costs should be calculated AFTER this. 
                MultiplyAllMaterialsByNumCopies(ref outputMaterials, buildPlan);
                //handle any child Materials calculations here. 
                //So if a child is built or reacted, we need to do the child logic AFTER we multiply all materials by num of copies.
                CalculateChildMaterialCosts(ref outputMaterials, buildPlan);
                //Finally, recurisvel multiply all inputs times the number of copies.
                //Reset the Build and React values from the current build plan
                ResetBuildReactPricePer(buildPlan.InputMaterials, outputMaterials);

                //Set this at the end with all the updated info.
                buildPlan.InputMaterials = outputMaterials;
            }
        }

        private static void ResetBuildReactPricePer(List<MaterialsWithMarketData> originalItems, List<MaterialsWithMarketData> newItems)
        {
            MaterialsWithMarketData newMat;
            foreach (MaterialsWithMarketData originalMat in originalItems)
            {
                newMat = newItems.Find(x => x.materialTypeID == originalMat.materialTypeID);
                if (newMat != null)
                {
                    newMat.Build = originalMat.Build;
                    newMat.React = originalMat.React;

                    if (!newMat.Build && !newMat.React)
                    {
                        newMat.pricePer = originalMat.pricePer;
                        newMat.priceTotal = newMat.pricePer * newMat.quantityTotal;
                    }
                    if (originalMat.ChildMaterials.Count > 0)
                    {
                        ResetBuildReactPricePer(originalMat.ChildMaterials, newMat.ChildMaterials);
                    }
                }
                //else: Nothing to do. Move on
            }
        }

        private static void SetBaseInputValues(int runsNeeded, ref List<MaterialsWithMarketData> outputMaterials, List<IndustryActivityMaterials> baseMaterialInformation)
        {
            MaterialsWithMarketData outputMat;
            foreach (IndustryActivityMaterials baseMat in baseMaterialInformation)
            {
                outputMat = outputMaterials.Find(x => x.materialTypeID == baseMat.materialTypeID);
                if (outputMat == null)
                {
                    outputMat = new MaterialsWithMarketData();
                    outputMat.materialTypeID = baseMat.materialTypeID;
                    outputMat.materialName = baseMat.materialName;
                    outputMaterials.Add(outputMat);
                }
                outputMat.quantity = baseMat.quantity;
                outputMat.RunsNeeded = runsNeeded;
                outputMat.Buildable = baseMat.isManufacturable;
                outputMat.Reactable = baseMat.isReactable;
                outputMat.quantityPerRun = baseMat.quantity; //This will be adjusted later by the ME calculations. For now, set it to base mat quantity
            }
        }

        private static void PerformManufacturingMECalculations(ref List<MaterialsWithMarketData> outputMaterials, BuildPlan buildPlan, int runsNeeded, int bpME)
        {
            decimal totalStructureMEBonus = 1;
            decimal MEBonus = (100m - Convert.ToDecimal(bpME)) / 100;
            long quantityTotal = 0;
            List<Int32> buildableMats = new List<int>();
            if (buildPlan.IndustrySettings.ManufacturingStructureTypeID > 0)
            {
                totalStructureMEBonus = CommonHelper.GetManufacturingStructureMEBonus(buildPlan.IndustrySettings);
            }
            foreach (Objects.MaterialsWithMarketData mat in outputMaterials)
            {
                //Calculation
                //QuantityTotal = BaseMat * Num Runs. Completed in SetBaseInputValues. 
                //
                //QuantityTotal = Math.Ceiling(QuantityTotal * (Bonus Percentage total (rigs, structure bonuses, etc) )
                quantityTotal = mat.quantity * runsNeeded;

                //Step 1 = Set quantity Total to Base Blueprint * ME.
                quantityTotal = (long)(quantityTotal * MEBonus);

                //If the blueprint requires 1 of each item the next ME calc does not apply because
                //it will always require 1 item per run.
                //Step 3 = Apply the structure ME Bonuses
                quantityTotal = (long)(Math.Ceiling(quantityTotal * totalStructureMEBonus));

                //You always need at least 1 item per run
                if (quantityTotal < runsNeeded) { quantityTotal = runsNeeded; }

                mat.quantityTotal += quantityTotal;
                mat.quantityPerRun = quantityTotal / runsNeeded;
            }
        }

        private static void CalculateChildMaterialCosts(ref List<MaterialsWithMarketData> outputMaterials, BuildPlan buildPlan)
        {
            foreach (MaterialsWithMarketData mat in outputMaterials)
            {
                //Always setup these values.
                //That way, we don't have to recalculate every time someone checks the checkbox
                if (mat.Buildable)
                {
                    List<MaterialsWithMarketData> childMats = CalculateChildManufacturingCostRecursive(mat, buildPlan);
                    mat.ChildMaterials = childMats;
                }
                else if (mat.Reactable)
                {
                    List<MaterialsWithMarketData> childMats = CalculateChildReactionCostRecursive(mat, buildPlan);
                    mat.ChildMaterials = childMats;
                }
            }
        }

        private static List<MaterialsWithMarketData> CalculateChildManufacturingCostRecursive(MaterialsWithMarketData matToBuild, BuildPlan buildPlan)
        {
            List<MaterialsWithMarketData> childMats = matToBuild.ChildMaterials;

            if (childMats == null) { childMats = new List<MaterialsWithMarketData>(); }

            int blueprintTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(matToBuild.materialTypeID);

            if (blueprintTypeId > 0)
            {
                List<IndustryActivityProduct> manufacturingProducts =
                    Database.SQLiteCalls.GetIndustryActivityProducts(blueprintTypeId, Enums.Enums.ActivityManufacturing);
                BlueprintInfo bpInfo = buildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == blueprintTypeId);
                if (manufacturingProducts.Count > 0)
                {
                    IndustryActivityProduct manuProd = manufacturingProducts[0];
                    int runsNeeded = (int)Math.Ceiling((decimal)matToBuild.quantityTotal / (decimal)manuProd.quantity);
                    if (runsNeeded > 0)
                    {
                        List<IndustryActivityMaterials> baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(blueprintTypeId, Enums.Enums.ActivityManufacturing);
                        //Base Calcs
                        SetBaseInputValues(runsNeeded, ref childMats, baseMaterials);
                        //ME Calculations
                        PerformManufacturingMECalculations(ref childMats, buildPlan, runsNeeded, bpInfo.ME);
                        //Recursively call CalculateChildMaterialCosts
                        CalculateChildMaterialCosts(ref childMats, buildPlan);
                        //set child materials on object. 
                        matToBuild.RunsNeeded = runsNeeded;
                    }
                }
            }

            return childMats;
        }

        private static List<MaterialsWithMarketData> CalculateChildReactionCostRecursive(MaterialsWithMarketData matToReact, BuildPlan buildPlan)
        {
            List<MaterialsWithMarketData> childMats = matToReact.ChildMaterials;

            if (childMats == null) { childMats = new List<MaterialsWithMarketData>(); }

            int reactionBPTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(matToReact.materialTypeID);

            if (reactionBPTypeId > 0)
            {
                List<IndustryActivityProduct> reactionProducts =
                    Database.SQLiteCalls.GetIndustryActivityProducts(reactionBPTypeId, Enums.Enums.ActivityReactions);
                if (reactionProducts.Count > 0)
                {
                    IndustryActivityProduct reactionProd = reactionProducts[0];
                    int runsNeeded = (int)Math.Ceiling((decimal)matToReact.quantityTotal / (decimal)reactionProd.quantity);
                    if (runsNeeded > 0)
                    {
                        List<IndustryActivityMaterials> baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(reactionBPTypeId, Enums.Enums.ActivityReactions);
                        //Base Calcs
                        SetBaseInputValues(runsNeeded, ref childMats, baseMaterials);
                        //ME Calculations
                        PerformReactionMECalculations(ref childMats, buildPlan, runsNeeded);
                        //Recursively call CalculateChildMaterialCosts
                        CalculateChildMaterialCosts(ref childMats, buildPlan);
                        //set child materials on object. 
                        matToReact.RunsNeeded = runsNeeded;
                    }
                }
            }

            return childMats;
        }

        private static void PerformReactionMECalculations(ref List<MaterialsWithMarketData> childMats, BuildPlan buildPlan, int runsNeeded)
        {
            decimal totalStructureMEBonus = 1;
            long quantityTotal = 0;
            if (buildPlan.IndustrySettings.ReactionsStructureTypeID > 0)
            {
                totalStructureMEBonus = CommonHelper.GetReactionStructureMEBonus(buildPlan.IndustrySettings);
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

        private static void MultiplyAllMaterialsByNumCopies(ref List<MaterialsWithMarketData> outputMaterials, BuildPlan buildPlan)
        {
            List<MaterialsWithMarketData> childMaterials;
            List<IndustryActivityProduct> products;
            int blueprintOrReactionTypeId;
            int activityID = 0;
            foreach (MaterialsWithMarketData mat in outputMaterials)
            {
                mat.quantityTotal = mat.quantityTotal * buildPlan.NumOfCopies;
                activityID = 0;
                if (mat.Buildable)
                {
                    activityID = (int)Enums.Enums.ActivityManufacturing;
                }
                if (mat.Reactable)
                {
                    activityID = (int)Enums.Enums.ActivityReactions;
                }

                if (activityID > 0)
                {
                    blueprintOrReactionTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(mat.materialTypeID);
                    products = Database.SQLiteCalls.GetIndustryActivityProducts(blueprintOrReactionTypeId, activityID);
                    mat.RunsNeeded = (int)Math.Ceiling((decimal)mat.quantityTotal / (decimal)products[0].quantity);
                }
            }
        }

        private static void CalculateReactionTotals(ref BuildPlan buildPlan)
        {
            IndustryActivityProduct baseProductInformation =
                    Database.SQLiteCalls.GetIndustryActivityProducts(buildPlan.parentBlueprintOrReactionTypeID, Enums.Enums.ActivityReactions)[0];
            List<IndustryActivityMaterials> baseMaterials =
                    Database.SQLiteCalls.GetIndustryActivityMaterials(buildPlan.parentBlueprintOrReactionTypeID, Enums.Enums.ActivityReactions);

            if (baseProductInformation != null)
            {
                buildPlan.TotalOutcome = baseProductInformation.quantity * buildPlan.RunsPerCopy * buildPlan.NumOfCopies;

                //This sets the base materials that we need. for each copy of the BP. 
                //So if Runs Per Copy is 5 and Num of Copies is 10, this will set the value of base quantity * 5
                //We then run ME calculations on that number. 
                //Once we have ME calcs done, we then multiple final numbers after ME * number of copies. 
                //This becomes our quantity total. 
                //We also set quantity per run to the adjusted ME value.
                List<MaterialsWithMarketData> outputMaterials = new List<MaterialsWithMarketData>();
                //Base Calcs
                SetBaseInputValues(buildPlan.RunsPerCopy, ref outputMaterials, baseMaterials);
                //ME Calculations
                PerformReactionMECalculations(ref outputMaterials, buildPlan, buildPlan.RunsPerCopy);
                //Next, Set the total quantity needed = QuantityFor Runs * Num of Copies
                //Basically, once we set the blueprints ME values, we now need to know the total of all 
                //inputs needed BEFORE we do any child costs. 
                //Child costs should be calculated AFTER this. 
                MultiplyAllMaterialsByNumCopies(ref outputMaterials, buildPlan);
                //handle any child Materials calculations here. 
                //So if a child is built or reacted, we need to do the child logic AFTER we multiply all materials by num of copies.
                CalculateChildMaterialCosts(ref outputMaterials, buildPlan);
                //Finally, recurisvel multiply all inputs times the number of copies.
                //Reset the Build and React values from the current build plan
                ResetBuildReactPricePer(buildPlan.InputMaterials, outputMaterials);

                //Set this at the end with all the updated info.
                buildPlan.InputMaterials = outputMaterials;
            }
        }

        public static void SetBuildReactAllRecursive(List<MaterialsWithMarketData> materials, bool value)
        {
            if (materials == null) { return; }
            foreach (MaterialsWithMarketData mat in materials)
            {
                if (mat.Buildable) { mat.Build = value; }
                if (mat.Reactable) { mat.React = value; }
                SetBuildReactAllRecursive(mat.ChildMaterials, value);
            }
        }

        public static bool IsAllMaterialsBuildOrReacted(List<MaterialsWithMarketData> materials)
        {
            bool allBuildReact = true;

            foreach (MaterialsWithMarketData mat in materials)
            {
                if ((mat.Buildable || mat.Reactable) &&
                    (!mat.Build && !mat.React))
                {
                    allBuildReact = false;
                    break;
                }

                if (mat.ChildMaterials != null)
                {
                    if (!IsAllMaterialsBuildOrReacted(mat.ChildMaterials))
                    {
                        allBuildReact = false;
                        break;
                    }
                }
            }

            return allBuildReact;
        }

        public static List<OptimizedBuild> DetermineOptimumBuild(List<MaterialsWithMarketData> materials, BuildPlan buildPlan)
        {
            List<OptimizedBuild> optimumBuilds = new List<OptimizedBuild>();
            List<MaterialsWithMarketData> allItemsBuiltReactedLumpedTogether = new List<MaterialsWithMarketData>();
            GetAllItemsBuiltReacted(materials, ref allItemsBuiltReactedLumpedTogether);

            foreach (MaterialsWithMarketData mat in allItemsBuiltReactedLumpedTogether)
            {
                optimumBuilds.Add(GetOptimumBuildInformation(mat, buildPlan, false));
            }

            MaterialsWithMarketData finalProductMat = BuildFinalProductMat(buildPlan);
            optimumBuilds.Add(GetOptimumBuildInformation(finalProductMat, buildPlan, true));

            return optimumBuilds;
        }

        private static List<MaterialsWithMarketData> AddIndepentsToOutput(ref Dictionary<int, List<MaterialsWithMarketData>> output, List<MaterialsWithMarketData> inputs, int batchCount)
        {
            List<MaterialsWithMarketData> itemsToRemove = new List<MaterialsWithMarketData>();
            if (!output.Keys.Contains(batchCount))
            {
                output.Add(batchCount, new List<MaterialsWithMarketData>());
            }

            foreach (MaterialsWithMarketData inputMat in inputs)
            {
                if (inputMat.Buildable || inputMat.Reactable)
                {
                    if (inputMat.Build || inputMat.React)
                    {
                        if (inputMat.ChildMaterials.Count > 0)
                        {
                            itemsToRemove.AddRange(AddIndepentsToOutput(ref output, inputMat.ChildMaterials, batchCount));
                        }
                        else
                        {
                            output[batchCount].Add(inputMat);
                        }
                    }
                    else
                    {
                        output[batchCount].Add(inputMat);
                    }
                }
                else
                {
                    output[batchCount].Add(inputMat);
                    itemsToRemove.Add(inputMat);
                }
            }
            return itemsToRemove;
        }

        private static bool RemoveChildRecursive(MaterialsWithMarketData itemToRemove, ref List<MaterialsWithMarketData> listToRemoveFrom)
        {
            bool removed = false;
            if (listToRemoveFrom.Contains(itemToRemove))
            {
                removed = true;
                listToRemoveFrom.Remove(itemToRemove);
            }
            else
            {
                int i = 0;
                while (i < listToRemoveFrom.Count && !removed)
                {
                    if (RemoveChildRecursive(itemToRemove, ref listToRemoveFrom))
                    {
                        removed = true;
                    }
                    i++;
                }

            }
            return removed;
        }

        private static MaterialsWithMarketData BuildFinalProductMat(BuildPlan buildPlan)
        {
            InventoryType finalProductType = CommonHelper.InventoryTypes.Find(x => x.typeId == buildPlan.finalProductTypeID);
            MaterialsWithMarketData finalProductMat = new MaterialsWithMarketData();
            finalProductMat.materialTypeID = buildPlan.finalProductTypeID;
            finalProductMat.materialName = finalProductType.typeName;
            finalProductMat.quantityTotal = buildPlan.TotalOutcome;
            finalProductMat.Buildable = IsMaterialManufactured(buildPlan.parentBlueprintOrReactionTypeID);
            finalProductMat.Reactable = IsMaterialReacted(buildPlan.parentBlueprintOrReactionTypeID);
            finalProductMat.Build = finalProductMat.Buildable;
            finalProductMat.React = finalProductMat.Reactable;
            return finalProductMat;
        }

        private static void GetAllItemsBuiltReacted(List<MaterialsWithMarketData> inputMaterials, ref List<MaterialsWithMarketData> outputAllItems)
        {
            MaterialsWithMarketData existingMat = null;
            foreach (MaterialsWithMarketData mat in inputMaterials)
            {
                if (
                    (mat.Buildable || mat.Reactable) &&
                    (mat.Build || mat.React)
                    )
                {
                    existingMat = outputAllItems.Find(x => x.materialTypeID == mat.materialTypeID);
                    if (existingMat == null)
                    {
                        existingMat = new MaterialsWithMarketData();
                        existingMat.materialTypeID = mat.materialTypeID;
                        existingMat.quantity = mat.quantity;
                        existingMat.quantityTotal = mat.quantityTotal;
                        existingMat.Build = mat.Build;
                        existingMat.React = mat.React;
                        existingMat.Buildable = mat.Buildable;
                        existingMat.Reactable = mat.Reactable;
                        existingMat.materialName = mat.materialName;
                        existingMat.ParentMaterialTypeID = mat.ParentMaterialTypeID;
                        existingMat.quantityPerRun = mat.quantityPerRun;
                        outputAllItems.Add(existingMat);
                    }
                    else
                    {
                        existingMat.quantityTotal += mat.quantityTotal;
                    }
                    GetAllItemsBuiltReacted(mat.ChildMaterials, ref outputAllItems);
                }
            }
        }

        private static OptimizedBuild GetOptimumBuildInformation(MaterialsWithMarketData matToBuildReact, BuildPlan buildPlan, bool isFinalProduct)
        {
            OptimizedBuild optimizedBuild = new OptimizedBuild();
            optimizedBuild.BuiltOrReactedTypeId = matToBuildReact.materialTypeID;
            optimizedBuild.BuiltOrReactedName = matToBuildReact.materialName;
            optimizedBuild.TotalQuantityNeeded = matToBuildReact.quantityTotal;
            optimizedBuild.BlueprintOrReactionTypeID = Database.SQLiteCalls.GetBlueprintByProductTypeID(matToBuildReact.materialTypeID);
            optimizedBuild.isBuilt = matToBuildReact.Buildable;
            optimizedBuild.isReacted = matToBuildReact.Reactable;
            optimizedBuild.isFinalProduct = isFinalProduct;

            if (matToBuildReact.Buildable)
            {
                PerformOptimumManufacturingCalcs(ref optimizedBuild, buildPlan, isFinalProduct);
            }
            else
            {
                PerformOptimumReactionCalcs(ref optimizedBuild, buildPlan);
            }

            return optimizedBuild;
        }

        private static void PerformOptimumManufacturingCalcs(ref OptimizedBuild optimizedBuild, BuildPlan buildPlan, bool isFinalProduct)
        {

            
            int blueprintOrReactionTypeID = optimizedBuild.BlueprintOrReactionTypeID;
            List<MaterialsWithMarketData> inputMaterials = new List<MaterialsWithMarketData>();
            List<IndustryActivityProduct> manufacturingProducts =
                    Database.SQLiteCalls.GetIndustryActivityProducts(optimizedBuild.BlueprintOrReactionTypeID, Enums.Enums.ActivityManufacturing);
            if (manufacturingProducts.Count > 0)
            {
                IndustryActivityProduct manuProd = manufacturingProducts[0];
                optimizedBuild.RunsNeeded = (int)Math.Ceiling((decimal)optimizedBuild.TotalQuantityNeeded / (decimal)manuProd.quantity);
                BlueprintInfo bpInfo = buildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == blueprintOrReactionTypeID);

                int ME;
                int TE;
                if (bpInfo == null)
                {
                    if (isFinalProduct)
                    {
                        ME = buildPlan.IndustrySettings.ME;
                        TE = buildPlan.IndustrySettings.TE;
                    }
                    else
                    {
                        ME = buildPlan.IndustrySettings.CompME;
                        TE = buildPlan.IndustrySettings.CompTE;
                    }
                }
                else
                {
                    ME = bpInfo.ME;
                    TE = bpInfo.TE;
                }
                if (optimizedBuild.RunsNeeded > 0)
                {
                    SetBatchRunInformation(ref optimizedBuild, TE, Enums.Enums.ActivityManufacturing, bpInfo);
                    List<IndustryActivityMaterials> baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(optimizedBuild.BlueprintOrReactionTypeID, Enums.Enums.ActivityManufacturing);
                    if (optimizedBuild.BatchesNeeded > 1)
                    {
                        int totalRuns = optimizedBuild.RunsNeeded;
                        int currentRuns;
                        optimizedBuild.JobCost = 0;
                        while (totalRuns > 0)
                        {
                            if (totalRuns > optimizedBuild.MaxRunsPerBatch)
                            {
                                currentRuns = optimizedBuild.MaxRunsPerBatch;
                            }
                            else
                            {
                                currentRuns = totalRuns;
                            }
                            //Base Calcs
                            SetBaseInputValues(currentRuns, ref inputMaterials, baseMaterials);
                            //ME Calculations
                            PerformManufacturingMECalculations(ref inputMaterials, buildPlan, currentRuns, ME);
                            optimizedBuild.JobCost = CommonHelper.CalculateManufacturingJobCost(inputMaterials, buildPlan.IndustrySettings, currentRuns);
                            totalRuns -= optimizedBuild.MaxRunsPerBatch;
                        }
                        optimizedBuild.InputMaterials = inputMaterials;
                    }
                    else
                    {
                        //Base Calcs
                        SetBaseInputValues(optimizedBuild.RunsNeeded, ref inputMaterials, baseMaterials);
                        //ME Calculations
                        PerformManufacturingMECalculations(ref inputMaterials, buildPlan, optimizedBuild.RunsNeeded, ME);
                        optimizedBuild.JobCost = CommonHelper.CalculateManufacturingJobCost(inputMaterials, buildPlan.IndustrySettings, optimizedBuild.RunsNeeded);
                        optimizedBuild.InputMaterials = inputMaterials;
                    }

                    long waste = (optimizedBuild.RunsNeeded * manuProd.quantity) - optimizedBuild.TotalQuantityNeeded;
                    optimizedBuild.ExtraOutput = (int)waste;
                }
            }
        }

        private static void SetBatchRunInformation(ref OptimizedBuild optimizedBuild, int teValue, int activityID, BlueprintInfo bpInfo)
        {
            List<IndustryActivityTypes> activities =
                    Database.SQLiteCalls.GetIndustryActivityTypes(optimizedBuild.BlueprintOrReactionTypeID);

            IndustryActivityTypes manuActivity = activities.Find(x => x.activityID == activityID);

            long timePerRun = GetTimePerRun(manuActivity, teValue);
            long maxTime = (30 * 24 * 60 * 60);
            long totalTime = timePerRun * optimizedBuild.RunsNeeded;
            int batchesNeeded;
            int maxRunsPerBatch;
            maxRunsPerBatch = (int)Math.Floor((decimal)maxTime / (decimal)(timePerRun));
            if (maxRunsPerBatch <= 0) { maxRunsPerBatch = 1; }
            if (bpInfo != null && bpInfo.MaxRuns > 0 && bpInfo.MaxRuns < maxRunsPerBatch)
            {
                maxRunsPerBatch = bpInfo.MaxRuns;
            }
            if (optimizedBuild.RunsNeeded > maxRunsPerBatch)
            {
                batchesNeeded = (int)Math.Ceiling((decimal)optimizedBuild.RunsNeeded / (decimal)maxRunsPerBatch);
            }
            else
            {
                batchesNeeded = 1;
            }
            if (maxRunsPerBatch <= 0)
            {
                maxRunsPerBatch = 1;
            }
            if (batchesNeeded <= 0)
            {
                batchesNeeded = 1;
            }
            else if (batchesNeeded > optimizedBuild.RunsNeeded)
            {
                batchesNeeded = optimizedBuild.RunsNeeded;
            }
            optimizedBuild.MaxRunsPerBatch = maxRunsPerBatch;
            optimizedBuild.BatchesNeeded = batchesNeeded;
            optimizedBuild.TimePerRun = timePerRun;
        }

        private static long GetTimePerRun(IndustryActivityTypes activity, int TE)
        {
            long time = 0;
            if (activity != null)
            {
                time = activity.time;
                time *= (long)Math.Ceiling((decimal)(100 - TE) / (decimal)100);
            }
            return time;
        }

        private static void PerformOptimumReactionCalcs(ref OptimizedBuild optimizedBuild, BuildPlan buildPlan)
        {
            List<MaterialsWithMarketData> childMats = optimizedBuild.InputMaterials;

            if (childMats == null) { childMats = new List<MaterialsWithMarketData>(); }

            if (optimizedBuild.BlueprintOrReactionTypeID > 0)
            {
                int blueprintOrReactionTypeID = optimizedBuild.BlueprintOrReactionTypeID;
                List<IndustryActivityProduct> reactionProducts =
                    Database.SQLiteCalls.GetIndustryActivityProducts(optimizedBuild.BlueprintOrReactionTypeID, Enums.Enums.ActivityReactions);
                if (reactionProducts.Count > 0)
                {
                    IndustryActivityProduct reactionProd = reactionProducts[0];
                    optimizedBuild.RunsNeeded = (int)Math.Ceiling((decimal)optimizedBuild.TotalQuantityNeeded / (decimal)reactionProd.quantity);
                    BlueprintInfo bpInfo = buildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == blueprintOrReactionTypeID);
                    if (optimizedBuild.RunsNeeded > 0)
                    {
                        SetBatchRunInformation(ref optimizedBuild, 0, Enums.Enums.ActivityReactions, bpInfo);
                        List<IndustryActivityMaterials> baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(optimizedBuild.BlueprintOrReactionTypeID, Enums.Enums.ActivityReactions);

                        if (optimizedBuild.BatchesNeeded > 1)
                        {
                            int totalRuns = optimizedBuild.RunsNeeded;
                            int currentRuns;
                            optimizedBuild.JobCost = 0;
                            while (totalRuns > 0)
                            {
                                if (totalRuns > optimizedBuild.MaxRunsPerBatch)
                                {
                                    currentRuns = optimizedBuild.MaxRunsPerBatch;
                                }
                                else
                                {
                                    currentRuns = totalRuns;
                                }

                                //Base Calcs
                                SetBaseInputValues(currentRuns, ref childMats, baseMaterials);
                                //ME Calculations
                                PerformReactionMECalculations(ref childMats, buildPlan, currentRuns);
                                optimizedBuild.JobCost += CommonHelper.CalculateReactionJobCost(childMats, buildPlan.IndustrySettings, currentRuns);
                                totalRuns -= optimizedBuild.MaxRunsPerBatch;
                            }
                            //set child materials on object. 
                            optimizedBuild.InputMaterials = childMats;
                        }
                        else
                        {
                            //Base Calcs
                            SetBaseInputValues(optimizedBuild.RunsNeeded, ref childMats, baseMaterials);
                            //ME Calculations
                            PerformReactionMECalculations(ref childMats, buildPlan, optimizedBuild.RunsNeeded);
                            optimizedBuild.JobCost = CommonHelper.CalculateReactionJobCost(childMats, buildPlan.IndustrySettings, optimizedBuild.RunsNeeded);
                            //set child materials on object. 
                            optimizedBuild.InputMaterials = childMats;
                        }

                        long waste = (optimizedBuild.RunsNeeded * reactionProd.quantity) - optimizedBuild.TotalQuantityNeeded;
                        optimizedBuild.ExtraOutput = (int)waste;
                    }
                }
            }
        }

        private static void ZeroOutQuantityTotalRecursive(List<MaterialsWithMarketData> materials)
        {
            foreach (MaterialsWithMarketData mat in materials)
            {
                mat.quantityTotal = 0;
                if (mat.ChildMaterials.Count > 0)
                {
                    ZeroOutQuantityTotalRecursive(mat.ChildMaterials);
                }
            }
        }

        public static Dictionary<int, List<OptimizedBuild>> GetOptimumBuildGroups(List<OptimizedBuild> optimizedBuilds)
        {
            List<OptimizedBuild> copyOfOptimumBuilds = new List<OptimizedBuild>();
            copyOfOptimumBuilds.AddRange(optimizedBuilds);
            List<OptimizedBuild> itemsToRemove;

            Dictionary<int, List<OptimizedBuild>> optimumBuildGroups = new Dictionary<int, List<OptimizedBuild>>();

            int currentBatch = 1;
            while (copyOfOptimumBuilds.Count > 0)
            {
                itemsToRemove = new List<OptimizedBuild>();
                foreach (OptimizedBuild optBuild in copyOfOptimumBuilds)
                {
                    if (!BuildPlanHelper.IsDependentOnOtherBuild(copyOfOptimumBuilds, optBuild))
                    {
                        if (optimumBuildGroups.ContainsKey(currentBatch))
                        {
                            optimumBuildGroups[currentBatch].Add(optBuild);
                        }
                        else
                        {
                            optimumBuildGroups.Add(currentBatch, new List<OptimizedBuild>() { optBuild });
                        }
                        itemsToRemove.Add(optBuild);
                    }
                }
                foreach (OptimizedBuild optBuild in itemsToRemove)
                {
                    copyOfOptimumBuilds.Remove(optBuild);
                }

                currentBatch++;
            }
            return optimumBuildGroups;
        }

        public static bool IsDependentOnOtherBuild(List<OptimizedBuild> optimizedBuilds, OptimizedBuild buildToCheck)
        {
            bool isDependentOn = false;

            OptimizedBuild dependentBuild;
            foreach (MaterialsWithMarketData inputMat in buildToCheck.InputMaterials)
            {
                dependentBuild = optimizedBuilds.Find(x => x.BuiltOrReactedTypeId == inputMat.materialTypeID);
                if (dependentBuild != null)
                {
                    isDependentOn = true;
                    break;
                }
            }

            return isDependentOn;
        }

        public static void SetPriceInformationOnOptimizedBuilds(List<OptimizedBuild> optimizedBuilds, List<MaterialsWithMarketData> pricedMats, int finalProductTypeId, decimal additionalCost)
        {
            Dictionary<int, List<OptimizedBuild>> buildGroups = GetOptimumBuildGroups(optimizedBuilds);

            MaterialsWithMarketData pricedMat;
            decimal matCost;
            OptimizedBuild previousSetBuild;
            OptimizedBuild currentBuild;
            //the .order call orders by ascending. Since this is an int
            //it should count up. 
            //we need to process this in order. 
            foreach (int key in buildGroups.Keys.Order())
            {
                foreach (OptimizedBuild build in buildGroups[key])
                {
                    currentBuild = optimizedBuilds.Find(x => x.BuiltOrReactedTypeId == build.BuiltOrReactedTypeId);
                    matCost = 0;
                    foreach (MaterialsWithMarketData mat in currentBuild.InputMaterials)
                    {
                        pricedMat = pricedMats.Find(x => x.materialTypeID == mat.materialTypeID);
                        if (pricedMat != null)
                        {
                            mat.pricePer = pricedMat.pricePer;
                            mat.priceTotal = mat.pricePer * mat.quantityTotal;
                            matCost += mat.priceTotal;
                        }
                        else
                        {
                            //we should have previously set this earlier in the loop unless I'm crazy. 
                            previousSetBuild = optimizedBuilds.Find(x => x.BuiltOrReactedTypeId == mat.materialTypeID);
                            if (previousSetBuild != null)
                            {
                                mat.pricePer = previousSetBuild.PricePerItem;
                                mat.priceTotal = previousSetBuild.PricePerItem * mat.quantityTotal;
                                matCost += mat.priceTotal;
                            }
                            else
                            {
                                //We should never end up here. if you hit this break point, something went wrong.
                                matCost += 0;
                            }
                        }
                    }
                    currentBuild.MaterialCost = matCost;
                    if (build.BuiltOrReactedTypeId == finalProductTypeId)
                    {
                        currentBuild.AdditionalCost = additionalCost;
                    }
                    currentBuild.TotalBuildCost = currentBuild.MaterialCost + currentBuild.JobCost + currentBuild.AdditionalCost;
                    currentBuild.PricePerItem = currentBuild.TotalBuildCost / currentBuild.TotalQuantityNeeded;
                }
            }
        }

        public static void SetPricePerRecursive(List<MaterialsWithMarketData> matsToSet, List<MaterialsWithMarketData> matPrices)
        {
            MaterialsWithMarketData pricedMat;
            foreach (MaterialsWithMarketData mat in matsToSet)
            {
                if (!mat.Build && !mat.React)
                {
                    pricedMat = matPrices.Find(x => x.materialTypeID == mat.materialTypeID);
                    if (pricedMat != null)
                    {
                        mat.pricePer = pricedMat.pricePer;
                    }
                }
                if (mat.ChildMaterials.Count > 0)
                {
                    SetPricePerRecursive(mat.ChildMaterials, matPrices);
                }
            }
        }

        public static void EnsurePricePer(MaterialsWithMarketData mat, CalculationHelperClass industrySettings)
        {
            if (!mat.Build && !mat.React)
            {
                if (mat.pricePer <= 0)
                {
                    if (industrySettings.InputOrderType == (int)Enums.Enums.OrderType.Sell)
                    {
                        mat.pricePer = ESIMarketData.GetSellOrderPrice(mat.materialTypeID, Enums.Enums.TheForgeRegionId);
                    }
                    else
                    {
                        mat.pricePer = ESIMarketData.GetBuyOrderPrice(mat.materialTypeID, Enums.Enums.TheForgeRegionId);
                    }
                }
            }
        }

        public static decimal GetTotalInputPrice(List<MaterialsWithMarketData> inputs)
        {
            decimal totalPrice = 0;
            foreach (MaterialsWithMarketData mat in inputs)
            {
                if (mat.Build || mat.React)
                {
                    totalPrice += (GetTotalInputPrice(mat.ChildMaterials));
                }
                else
                {
                    totalPrice += mat.priceTotal;
                }
            }
            return totalPrice;
        }

        public static void SetPriceForMaterialRecursive(decimal price, int typeID, List<MaterialsWithMarketData> materialList)
        {
            foreach (MaterialsWithMarketData mat in materialList)
            {
                if (!mat.Build && !mat.React)
                {
                    if (mat.materialTypeID == typeID)
                    {
                        mat.pricePer = price;
                    }
                }
                else
                {
                    SetPriceForMaterialRecursive(price, typeID, mat.ChildMaterials);
                }
            }
        }

        public static bool SetBuildOrReactRecurisve(string controlName, bool value, List<MaterialsWithMarketData> mats)
        {
            if (!string.IsNullOrEmpty(controlName))
            {
                foreach (MaterialsWithMarketData mat in mats)
                {
                    if (mat.controlName.ToLowerInvariant().Equals(controlName.ToLowerInvariant()))
                    {
                        if (mat.Buildable) { mat.Build = value; return true; }
                        if (mat.Reactable) { mat.React = value; return true; }
                    }
                    else
                    {
                        if (mat.ChildMaterials.Count > 0)
                        {
                            if (SetBuildOrReactRecurisve(controlName, value, mat.ChildMaterials))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static MaterialsWithMarketData GetMaterialByControlName(string controlName, List<MaterialsWithMarketData> matList)
        {
            MaterialsWithMarketData foundMat = null;
            foreach (MaterialsWithMarketData mat in matList)
            {
                if(mat.controlName.ToLowerInvariant() == controlName.ToLowerInvariant())
                {
                    foundMat = mat;
                    break;
                }
                else
                {
                    if (mat.Build || mat.React)
                    {
                        foundMat = GetMaterialByControlName(controlName, mat.ChildMaterials);
                        if (foundMat != null)
                        {
                            break;
                        }
                    }
                }
            }
            return foundMat;
        }

        public static bool BuildBlueprintStore(List<MaterialsWithMarketData> childMats, ref List<BlueprintInfo> blueprintStore)
        {
            bool addedBlueprint = false;
            int blueprintTypeId = 0;
            BlueprintInfo bpInfo;
            InventoryType invType;
            foreach (MaterialsWithMarketData mat in childMats)
            {
                if (mat.Buildable ||mat.Reactable)
                {
                    blueprintTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(mat.materialTypeID);
                    if (blueprintTypeId > 0)
                    {
                        bpInfo = blueprintStore.Find(x => x.BlueprintTypeId == blueprintTypeId);
                        if (bpInfo == null)
                        {
                            bpInfo = new BlueprintInfo();
                            invType = CommonHelper.InventoryTypes.Find(x => x.typeId == blueprintTypeId);
                            bpInfo.BlueprintTypeId = blueprintTypeId;
                            bpInfo.ProductTypeId = mat.materialTypeID;
                            bpInfo.BlueprintName = invType.typeName;
                            bpInfo.IsManufactured = mat.Buildable;
                            bpInfo.IsReacted = mat.Reactable;
                            bpInfo.MaxRuns = 9999;
                            if (mat.Buildable)
                            {
                                bpInfo.ME = 10;
                                bpInfo.TE = 20;
                            }
                            blueprintStore.Add(bpInfo);
                            addedBlueprint = true;
                        }
                    }
                    if (BuildBlueprintStore(mat.ChildMaterials, ref blueprintStore))
                    {
                        addedBlueprint = true;
                    }
                }
            }
            return addedBlueprint;
        }
    }
}