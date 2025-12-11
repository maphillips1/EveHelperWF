using EveHelperWF.ESI_Calls;
using EveHelperWF.Objects;
using EveHelperWF.Objects.ESI_Objects.Market_Objects;

namespace EveHelperWF.ScreenHelper
{
    public static class BuildPlanHelper
    {
        private static int controlCount = 0;

        public static void RunBuildPlanCalcs(ref BuildPlan buildPlan, ref List<MaterialsWithMarketData> _CombinedMats)
        {

            CalculateIndustryValues(ref buildPlan);
            List<MaterialsWithMarketData> allItems = buildPlan.AllItems;
            BuildPlanHelper.BuildAllItems(buildPlan.InputMaterials, ref allItems);
            buildPlan.AllItems = allItems;
            RunOptimumBuildCalc(ref buildPlan);
            EnsurePriceData(ref buildPlan, ref _CombinedMats);
            
        }

        private static void RunOptimumBuildCalc(ref BuildPlan buildPlan)
        {
            BuildPlanHelper.DetermineOptimumBuild(buildPlan.InputMaterials, buildPlan);
        }

        private static void EnsurePriceData(ref BuildPlan buildPlan, ref List<MaterialsWithMarketData> _CombinedMats)
        {
            if (buildPlan != null)
            {
                List<MaterialsWithMarketData> allItemsNoPrice = buildPlan.AllItems.FindAll(x => x.pricePer <= 0);
                List<MaterialsWithMarketData> combinedMats = new List<MaterialsWithMarketData>();
                CombineMatsFromOptimizedBuilds(ref combinedMats, buildPlan.OptimizedBuilds, ref _CombinedMats, true);
                _CombinedMats.AddRange(combinedMats);
                combinedMats = combinedMats.FindAll(x => allItemsNoPrice.Find(y => y.materialTypeID == x.materialTypeID) != null);
                if (combinedMats.Count > 0)
                {
                    List<ESIMarketType> marketTypes = new List<ESIMarketType>();
                    combinedMats.ForEach(x => marketTypes.Add(new ESIMarketType() { typeID = x.materialTypeID, quantity = x.quantityTotal }));
                    int totalMats = combinedMats.Count;
                    decimal progress = 0;
                    marketTypes = ESIMarketData.GetPriceForItemListWithQuantityAsync(marketTypes, buildPlan.IndustrySettings.InputOrderType, Enums.Enums.TheForgeRegionId).Result;
                    foreach (ESIMarketType marketType in marketTypes)
                    {
                        combinedMats.Find(x => x.materialTypeID == marketType.typeID).pricePer = marketType.pricePer;
                        combinedMats.Find(x => x.materialTypeID == marketType.typeID).priceTotal = marketType.priceTotal;
                        buildPlan.AllItems.Find(x => x.materialTypeID == marketType.typeID).pricePer = marketType.pricePer;
                        buildPlan.AllItems.Find(x => x.materialTypeID == marketType.typeID).priceTotal = marketType.priceTotal;
                        progress++;
                    }
                }
                foreach (MaterialsWithMarketData mat in _CombinedMats)
                {
                    mat.pricePer = buildPlan.AllItems.Find(x => x.materialTypeID == mat.materialTypeID).pricePer;
                    mat.priceTotal = mat.pricePer * mat.quantityTotal;
                }
            }
        }

        public static void CombineMatsFromOptimizedBuilds(ref List<MaterialsWithMarketData> outputList, List<OptimizedBuild> optimizedBuilds, ref List<MaterialsWithMarketData> _CombinedMats, bool ignoreCompletedBuilds = false)
        {
            if (_CombinedMats.Count <= 0)
            {
                MaterialsWithMarketData existingMat;
                OptimizedBuild buildPlan;
                foreach (OptimizedBuild build in optimizedBuilds)
                {
                    if (ignoreCompletedBuilds && build.TotalQuantityNeeded == 0)
                    {
                        continue;
                    }
                    foreach (MaterialsWithMarketData input in build.InputMaterials)
                    {
                        buildPlan = optimizedBuilds.Find(x => x.BuiltOrReactedTypeId == input.materialTypeID);
                        if (buildPlan == null)
                        {
                            existingMat = outputList.Find(x => x.materialTypeID == input.materialTypeID);
                            if (existingMat == null)
                            {
                                existingMat = new MaterialsWithMarketData();
                                existingMat.materialTypeID = input.materialTypeID;
                                existingMat.quantityTotal = input.quantityTotal;
                                existingMat.materialName = input.materialName;
                                existingMat.pricePer = input.pricePer;
                                existingMat.Buildable = input.Buildable;
                                existingMat.Reactable = input.Reactable;
                                outputList.Add(existingMat);
                            }
                            else
                            {
                                existingMat.quantityTotal += input.quantityTotal;
                            }
                            existingMat.priceTotal = existingMat.pricePer * existingMat.quantityTotal;
                        }
                    }
                }
            }
            else
            {
                outputList.Clear();
                outputList.AddRange(_CombinedMats);
            }
        }

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
            int parentBPTypeId = buildPlan.parentBlueprintOrReactionTypeID;
            IndustryActivityProduct baseProductInformation =
                    Database.SQLiteCalls.GetIndustryActivityProducts(parentBPTypeId, Enums.Enums.ActivityManufacturing)[0];
            List<IndustryActivityMaterials> baseMaterials =
                    Database.SQLiteCalls.GetIndustryActivityMaterials(parentBPTypeId, Enums.Enums.ActivityManufacturing);
            BlueprintInfo bpInfo = buildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == parentBPTypeId);
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
                CommonHelper.PerformManufacturingMECalculations(ref outputMaterials, buildPlan.IndustrySettings, buildPlan.RunsPerCopy, bpInfo.ME);
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
                ResetBuildReactPricePer(buildPlan.InputMaterials, outputMaterials, buildPlan.BlueprintStore);

                //Set this at the end with all the updated info.
                buildPlan.InputMaterials = outputMaterials;
            }
        }

        public static bool IsItemMade(List<BlueprintInfo> blueprints, int materialTypeId)
        {
            bool isMade = false;
            BlueprintInfo bpInfo = blueprints.Find(x => x.ProductTypeId == materialTypeId);
            if (bpInfo != null)
            {
                isMade = bpInfo.Manufacture || bpInfo.React;
            }
            return isMade;
        }

        private static void ResetBuildReactPricePer(List<MaterialsWithMarketData> originalItems, List<MaterialsWithMarketData> newItems, List<BlueprintInfo> blueprints)
        {
            MaterialsWithMarketData newMat;
            foreach (MaterialsWithMarketData originalMat in originalItems)
            {
                newMat = newItems.Find(x => x.materialTypeID == originalMat.materialTypeID);
                if (newMat != null)
                {
                    if (IsItemMade(blueprints, newMat.materialTypeID))
                    {
                        ResetBuildReactPricePer(originalMat.ChildMaterials, newMat.ChildMaterials, blueprints);
                    }
                    else
                    {
                        newMat.pricePer = originalMat.pricePer;
                        newMat.priceTotal = newMat.pricePer * newMat.quantityTotal;
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
                        CommonHelper.PerformManufacturingMECalculations(ref childMats, buildPlan.IndustrySettings, runsNeeded, bpInfo.ME);
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
                        CommonHelper.PerformReactionMECalculations(ref childMats, buildPlan.IndustrySettings, runsNeeded);
                        //Recursively call CalculateChildMaterialCosts
                        CalculateChildMaterialCosts(ref childMats, buildPlan);
                        //set child materials on object. 
                        matToReact.RunsNeeded = runsNeeded;
                    }
                }
            }

            return childMats;
        }

        private static void MultiplyAllMaterialsByNumCopies(ref List<MaterialsWithMarketData> outputMaterials, BuildPlan buildPlan)
        {
            List<MaterialsWithMarketData> childMaterials;
            List<IndustryActivityProduct> products;
            int blueprintOrReactionTypeId;
            string activityName = "";
            foreach (MaterialsWithMarketData mat in outputMaterials)
            {
                mat.quantityTotal = mat.quantityTotal * buildPlan.NumOfCopies;
                activityName = "";
                if (mat.Buildable)
                {
                    activityName = Enums.Enums.ActivityManufacturing;
                }
                if (mat.Reactable)
                {
                    activityName = Enums.Enums.ActivityReactions;
                }

                if (!string.IsNullOrWhiteSpace(activityName))
                {
                    blueprintOrReactionTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(mat.materialTypeID);
                    products = Database.SQLiteCalls.GetIndustryActivityProducts(blueprintOrReactionTypeId, activityName);
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
                CommonHelper.PerformReactionMECalculations(ref outputMaterials, buildPlan.IndustrySettings, buildPlan.RunsPerCopy);
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
                ResetBuildReactPricePer(buildPlan.InputMaterials, outputMaterials, buildPlan.BlueprintStore);

                //Set this at the end with all the updated info.
                buildPlan.InputMaterials = outputMaterials;
            }
        }

        public static void DetermineOptimumBuild(List<MaterialsWithMarketData> materials, BuildPlan buildPlan)
        {
            List<OptimizedBuild> optimumBuilds = GetOptimumBuildList(materials, buildPlan);

            buildPlan.OptimumBuildGroups = GetOptimumBuildGroups(optimumBuilds);
            CalcForOptimumBuildGroups(buildPlan);
            OptimizedBuild currentBuild;
            foreach (int key in buildPlan.OptimumBuildGroups.Keys)
            {
                foreach (OptimizedBuild build in buildPlan.OptimumBuildGroups[key])
                {
                    currentBuild = optimumBuilds.Find(x => x.BuiltOrReactedTypeId == build.BuiltOrReactedTypeId);
                    currentBuild.TotalQuantityNeeded = build.TotalQuantityNeeded;
                }
            }
            buildPlan.OptimizedBuilds = optimumBuilds;
        }

        private static List<OptimizedBuild> GetOptimumBuildList(List<MaterialsWithMarketData> materials, BuildPlan buildPlan)
        {
            List<OptimizedBuild> optimumBuilds = new List<OptimizedBuild>();
            List<MaterialsWithMarketData> allItemsBuiltReactedLumpedTogether = new List<MaterialsWithMarketData>();
            GetAllItemsBuiltReacted(materials,buildPlan.BlueprintStore, ref allItemsBuiltReactedLumpedTogether);

            MaterialsWithMarketData finalProductMat = BuildFinalProductMat(buildPlan);
            optimumBuilds.Add(ConvertMatToOptimumBuild(finalProductMat, buildPlan, true));

            foreach (MaterialsWithMarketData mat in allItemsBuiltReactedLumpedTogether)
            {
                optimumBuilds.Add(ConvertMatToOptimumBuild(mat, buildPlan, false));
            }
            return optimumBuilds;
        }

        private static void CalcForOptimumBuildGroups(BuildPlan buildPlan)
        {

            bool isFinal = true;
            OptimizedBuild currentBuild;
            InventoryTypeWithQuantity currentInventory;
            foreach (int key in buildPlan.OptimumBuildGroups.Keys.OrderByDescending(x => x))
            {
                for (int i = 0; i < buildPlan.OptimumBuildGroups[key].Count(); i++)
                {
                    currentBuild = buildPlan.OptimumBuildGroups[key][i];
                    currentInventory = buildPlan.CurrentInventory.Find(x => x.typeID == currentBuild.BuiltOrReactedTypeId);
                    if (currentInventory != null)
                    {
                        currentBuild.TotalQuantityNeeded -= currentInventory.quantity;
                        if (currentBuild.TotalQuantityNeeded < 0) { currentBuild.TotalQuantityNeeded = 0; }
                    }
                    if (buildPlan.OptimumBuildGroups[key][i].isBuilt)
                    {
                        PerformOptimumManufacturingCalcs(ref currentBuild, buildPlan, isFinal);
                    }
                    else
                    {
                        PerformOptimumReactionCalcs(ref currentBuild, buildPlan, isFinal);
                    }
                    foreach (MaterialsWithMarketData inputMat in currentBuild.InputMaterials)
                    {
                        foreach (int matKey in buildPlan.OptimumBuildGroups.Keys)
                        {
                            if (matKey < key)
                            {
                                foreach (OptimizedBuild dependentBuild in buildPlan.OptimumBuildGroups[matKey])
                                {
                                    if (dependentBuild.BuiltOrReactedTypeId == inputMat.materialTypeID)
                                    {
                                        dependentBuild.TotalQuantityNeeded += inputMat.quantityTotal;
                                    }
                                }
                            }
                        }
                    }
                }
                isFinal = false;
            }
        }

        private static List<MaterialsWithMarketData> AddIndepentsToOutput(ref Dictionary<int, List<MaterialsWithMarketData>> output, List<MaterialsWithMarketData> inputs, int batchCount, List<BlueprintInfo> blueprints)
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
                    if (IsItemMade(blueprints, inputMat.materialTypeID))
                    {
                        if (inputMat.ChildMaterials.Count > 0)
                        {
                            itemsToRemove.AddRange(AddIndepentsToOutput(ref output, inputMat.ChildMaterials, batchCount, blueprints));
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
            return finalProductMat;
        }

        private static void GetAllItemsBuiltReacted(List<MaterialsWithMarketData> inputMaterials, List<BlueprintInfo> blueprints, ref List<MaterialsWithMarketData> outputAllItems)
        {
            MaterialsWithMarketData existingMat = null;
            foreach (MaterialsWithMarketData mat in inputMaterials)
            {
                if (mat.Buildable || mat.Reactable)
                {
                    BlueprintInfo bpInfo = blueprints.Find(x => x.ProductTypeId == mat.materialTypeID);
                    if (bpInfo.Manufacture || bpInfo.React)
                    {
                        existingMat = outputAllItems.Find(x => x.materialTypeID == mat.materialTypeID);
                        if (existingMat == null)
                        {
                            existingMat = new MaterialsWithMarketData();
                            existingMat.materialTypeID = mat.materialTypeID;
                            existingMat.quantity = mat.quantity;
                            existingMat.quantityTotal = mat.quantityTotal;
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
                        GetAllItemsBuiltReacted(mat.ChildMaterials, blueprints, ref outputAllItems);
                    }
                }
            }
        }

        private static OptimizedBuild ConvertMatToOptimumBuild(MaterialsWithMarketData matToBuildReact, BuildPlan buildPlan, bool isFinalProduct)
        {
            OptimizedBuild optimizedBuild = new OptimizedBuild();
            optimizedBuild.BuiltOrReactedTypeId = matToBuildReact.materialTypeID;
            optimizedBuild.BuiltOrReactedName = matToBuildReact.materialName;
            optimizedBuild.BlueprintOrReactionTypeID = Database.SQLiteCalls.GetBlueprintByProductTypeID(matToBuildReact.materialTypeID);
            optimizedBuild.isBuilt = matToBuildReact.Buildable;
            optimizedBuild.isReacted = matToBuildReact.Reactable;
            optimizedBuild.isFinalProduct = isFinalProduct;
            optimizedBuild.InputMaterials = new List<MaterialsWithMarketData>();
            if (isFinalProduct)
            {
                optimizedBuild.TotalQuantityNeeded = matToBuildReact.quantityTotal;
            }
            string activityName = "";
            if (matToBuildReact.Buildable)
            {
                activityName = Enums.Enums.ActivityManufacturing;
            }
            else
            {
                activityName = Enums.Enums.ActivityReactions;
            }
            List<IndustryActivityMaterials> baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(optimizedBuild.BlueprintOrReactionTypeID, activityName);
            MaterialsWithMarketData outputMat;
            foreach (IndustryActivityMaterials baseMat in baseMaterials)
            {
                outputMat = new MaterialsWithMarketData();
                outputMat.materialTypeID = baseMat.materialTypeID;
                outputMat.materialName = baseMat.materialName;
                optimizedBuild.InputMaterials.Add(outputMat);
                outputMat.quantity = baseMat.quantity;
                outputMat.Buildable = baseMat.isManufacturable;
                outputMat.Reactable = baseMat.isReactable;
                outputMat.quantityPerRun = baseMat.quantity;
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

                int ME = bpInfo.ME;
                int TE = bpInfo.TE;

                if (optimizedBuild.RunsNeeded > 0)
                {
                    SetBatchRunInformation(ref optimizedBuild, TE, Enums.Enums.ActivityManufacturing, bpInfo, isFinalProduct, buildPlan);
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
                            CommonHelper.PerformManufacturingMECalculations(ref inputMaterials, buildPlan.IndustrySettings, currentRuns, ME);
                            optimizedBuild.JobCost += CommonHelper.CalculateManufacturingJobCost(inputMaterials, buildPlan.IndustrySettings, currentRuns);
                            totalRuns -= optimizedBuild.MaxRunsPerBatch;
                        }
                        optimizedBuild.InputMaterials = inputMaterials;
                    }
                    else
                    {
                        //Base Calcs
                        SetBaseInputValues(optimizedBuild.RunsNeeded, ref inputMaterials, baseMaterials);
                        //ME Calculations
                        CommonHelper.PerformManufacturingMECalculations(ref inputMaterials, buildPlan.IndustrySettings, optimizedBuild.RunsNeeded, ME);
                        optimizedBuild.JobCost = CommonHelper.CalculateManufacturingJobCost(inputMaterials, buildPlan.IndustrySettings, optimizedBuild.RunsNeeded);
                        optimizedBuild.InputMaterials = inputMaterials;
                    }

                    long waste = (optimizedBuild.RunsNeeded * manuProd.quantity) - optimizedBuild.TotalQuantityNeeded;
                    optimizedBuild.ExtraOutput = (int)waste;
                }
            }
        }

        private static void SetBatchRunInformation(ref OptimizedBuild optimizedBuild, int teValue, string activityName, BlueprintInfo bpInfo, bool isFinalProduct, BuildPlan buildPlan)
        {
            List<IndustryActivityTypes> activities =
                    Database.SQLiteCalls.GetIndustryActivityTypes(optimizedBuild.BlueprintOrReactionTypeID);

            IndustryActivityTypes manuActivity = activities.Find(x => x.activityName == activityName);


            long timePerRun = CommonHelper.CalculateManufacturingReactionJobTime(bpInfo.BlueprintTypeId, manuActivity.time, buildPlan.IndustrySettings, teValue, bpInfo.IsReacted);
            //days * hours * minutes * seconds;
            long maxTime = (30 * 24 * 60 * 60);
            //If Max Manufactuting/reaction time is set, use that as the max instead.
            if (!isFinalProduct)
            {
                if (bpInfo.IsManufactured)
                {
                    if (buildPlan.IndustrySettings.MaxManufacturingTime > 0)
                    {
                        maxTime = buildPlan.IndustrySettings.MaxManufacturingTime * 3600;
                    }
                }
                else
                {
                    if (buildPlan.IndustrySettings.MaxReactionTime > 0)
                    {
                        maxTime = buildPlan.IndustrySettings.MaxReactionTime * 3600;
                    }
                }
            }
            long totalTime = manuActivity.time * optimizedBuild.RunsNeeded;
            totalTime = CommonHelper.CalculateManufacturingReactionJobTime(bpInfo.BlueprintTypeId, totalTime, buildPlan.IndustrySettings, teValue, bpInfo.IsReacted);
            int batchesNeeded;
            int maxRunsPerBatch;
            maxRunsPerBatch = (int)Math.Floor((decimal)maxTime / (decimal)(timePerRun));
            if (isFinalProduct && buildPlan.RunsPerCopy <= maxRunsPerBatch)
            {
                maxRunsPerBatch = buildPlan.RunsPerCopy;
            }
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

        private static void PerformOptimumReactionCalcs(ref OptimizedBuild optimizedBuild, BuildPlan buildPlan, bool isFinalProduct)
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
                        SetBatchRunInformation(ref optimizedBuild, 0, Enums.Enums.ActivityReactions, bpInfo, isFinalProduct, buildPlan);
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
                                CommonHelper.PerformReactionMECalculations(ref childMats, buildPlan.IndustrySettings, currentRuns);
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
                            CommonHelper.PerformReactionMECalculations(ref childMats, buildPlan.IndustrySettings, optimizedBuild.RunsNeeded);
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

        public static void SetPriceInformationOnOptimizedBuilds(List<OptimizedBuild> optimizedBuilds, List<MaterialsWithMarketData> pricedMats, int finalProductTypeId, decimal additionalCost, BuildPlan buildPlan)
        {
            Dictionary<int, List<OptimizedBuild>> buildGroups = buildPlan.OptimumBuildGroups;
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
                        //we should have previously set this earlier in the loop unless I'm crazy. 
                        previousSetBuild = optimizedBuilds.Find(x => x.BuiltOrReactedTypeId == mat.materialTypeID);
                        if (previousSetBuild == null)
                        {
                            pricedMat = pricedMats.Find(x => x.materialTypeID == mat.materialTypeID);
                            mat.pricePer = pricedMat.pricePer;
                            mat.priceTotal = mat.pricePer * mat.quantityTotal;
                            matCost += mat.priceTotal;
                        }
                        else
                        {
                            mat.pricePer = previousSetBuild.PricePerItem;
                            mat.priceTotal = mat.pricePer * mat.quantityTotal;
                            matCost += mat.priceTotal;
                        }
                    }
                    currentBuild.MaterialCost = matCost;
                    if (build.BuiltOrReactedTypeId == finalProductTypeId)
                    {
                        currentBuild.AdditionalCost = additionalCost;
                    }
                    currentBuild.TotalBuildCost = currentBuild.MaterialCost + currentBuild.JobCost + currentBuild.AdditionalCost;
                    if (currentBuild.TotalQuantityNeeded > 0)
                    {
                        currentBuild.PricePerItem = currentBuild.TotalBuildCost / currentBuild.TotalQuantityNeeded;
                    }
                }
            }
        }

        public static void SetPricePerRecursive(List<MaterialsWithMarketData> matsToSet, List<MaterialsWithMarketData> matPrices, List<BlueprintInfo> blueprints)
        {
            MaterialsWithMarketData pricedMat;
            foreach (MaterialsWithMarketData mat in matsToSet)
            {
                if (!IsItemMade(blueprints, mat.materialTypeID))
                {
                    pricedMat = matPrices.Find(x => x.materialTypeID == mat.materialTypeID);
                    if (pricedMat != null)
                    {
                        mat.pricePer = pricedMat.pricePer;
                    }
                }
                if (mat.ChildMaterials.Count > 0)
                {
                    SetPricePerRecursive(mat.ChildMaterials, matPrices, blueprints);
                }
            }
        }

        public static void SetPriceForMaterialRecursive(decimal price, int typeID, List<MaterialsWithMarketData> materialList, List<BlueprintInfo> blueprints)
        {
            foreach (MaterialsWithMarketData mat in materialList)
            {
                if (mat.Buildable || mat.Reactable)
                {
                    BlueprintInfo bpInfo = blueprints.Find(x => x.ProductTypeId == mat.materialTypeID);
                    if (bpInfo.Manufacture || bpInfo.React)
                    {
                        SetPriceForMaterialRecursive(price, typeID, mat.ChildMaterials, blueprints);
                    }
                    else
                    {
                        mat.pricePer = price;
                    }
                }
                else
                {
                    mat.pricePer = price;
                }
            }
        }

        public static bool BuildBlueprintStore(ref BuildPlan currentBuildPlan, List<MaterialsWithMarketData> currentMats)
        {
            bool addedBlueprint = false;
            int blueprintTypeId = 0;
            BlueprintInfo bpInfo;
            InventoryType invType;
            foreach (MaterialsWithMarketData mat in currentMats)
            {
                if (mat.Buildable || mat.Reactable)
                {
                    blueprintTypeId = Database.SQLiteCalls.GetBlueprintByProductTypeID(mat.materialTypeID);
                    if (blueprintTypeId > 0)
                    {
                        bpInfo = currentBuildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == blueprintTypeId);
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
                            currentBuildPlan.BlueprintStore.Add(bpInfo);
                            addedBlueprint = true;
                        }
                    }
                    List<MaterialsWithMarketData> inputMats = new List<MaterialsWithMarketData>();
                    List<IndustryActivityMaterials> baseMaterials;
                    if (mat.Buildable)
                    {
                        baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(blueprintTypeId, Enums.Enums.ActivityManufacturing);
                    }
                    else
                    {
                        baseMaterials = Database.SQLiteCalls.GetIndustryActivityMaterials(blueprintTypeId, Enums.Enums.ActivityReactions);
                    }

                    MaterialsWithMarketData outputMat;
                    foreach (IndustryActivityMaterials baseMat in baseMaterials)
                    {
                        outputMat = inputMats.Find(x => x.materialTypeID == baseMat.materialTypeID);
                        if (outputMat == null)
                        {
                            outputMat = new MaterialsWithMarketData();
                            outputMat.materialTypeID = baseMat.materialTypeID;
                            outputMat.materialName = baseMat.materialName;
                            mat.ChildMaterials.Add(outputMat);
                        }
                        outputMat.quantity = baseMat.quantity;
                        outputMat.Buildable = baseMat.isManufacturable;
                        outputMat.Reactable = baseMat.isReactable;
                        outputMat.quantityPerRun = baseMat.quantity; //This will be adjusted later by the ME calculations. For now, set it to base mat quantity
                    }

                    if (BuildBlueprintStore(ref currentBuildPlan, mat.ChildMaterials))
                    {
                        addedBlueprint = true;
                    }
                }
            }
            int finalProdBPId = currentBuildPlan.parentBlueprintOrReactionTypeID;
            int finalProdId = currentBuildPlan.finalProductTypeID;
            bpInfo = currentBuildPlan.BlueprintStore.Find(x => x.BlueprintTypeId == finalProdBPId);
            if (bpInfo == null)
            {
                invType = CommonHelper.InventoryTypes.Find(x => x.typeId == finalProdId);
                bpInfo = new BlueprintInfo();
                bpInfo.BlueprintTypeId = finalProdBPId;
                bpInfo.ProductTypeId = finalProdId;
                bpInfo.BlueprintName = invType.typeName;
                bpInfo.IsManufactured = IsMaterialManufactured(finalProdBPId);
                bpInfo.IsReacted = IsMaterialReacted(finalProdBPId);
                bpInfo.MaxRuns = 9999;
                bpInfo.Manufacture = true;
                bpInfo.React = true;
                if (bpInfo.IsManufactured)
                {
                    bpInfo.ME = 10;
                    bpInfo.TE = 20;
                }
                currentBuildPlan.BlueprintStore.Add(bpInfo);
                addedBlueprint = true;
            }
            return addedBlueprint;
        }

        public static void BuildAllItems(List<MaterialsWithMarketData> inputMaterialsInTreeform, ref List<MaterialsWithMarketData> allItems)
        {
            if (allItems == null) { allItems = new List<MaterialsWithMarketData>(); }
            foreach (MaterialsWithMarketData inputMaterial in inputMaterialsInTreeform)
            {
                if (allItems.Find(x => x.materialTypeID == inputMaterial.materialTypeID) == null)
                {
                    allItems.Add(inputMaterial);
                }
                if (inputMaterial.ChildMaterials.Count > 0)
                {
                    BuildAllItems(inputMaterial.ChildMaterials, ref allItems);
                }
            }
        }

        public static Dictionary<string, List<MaterialsWithMarketData>> GroupInputMaterials(List<MaterialsWithMarketData> itemsToGroup)
        {
            Dictionary<string, List<MaterialsWithMarketData>> groupedOutPut = new Dictionary<string, List<MaterialsWithMarketData>>();
            List<Objects.InventoryMarketGroups> marketGroups = Database.SQLiteCalls.GetMarketGroups();
            foreach (MaterialsWithMarketData item in itemsToGroup)
            {
                string groupName = CommonHelper.InventoryTypes.Find(x => x.typeId == item.materialTypeID).groupName;
                

                if (groupedOutPut.Keys.Contains(groupName))
                {
                    groupedOutPut[groupName].Add(item);
                }
                else
                {
                    groupedOutPut.Add(groupName, new List<MaterialsWithMarketData>() { item });
                }
            }
            return groupedOutPut;
        }
    }
}