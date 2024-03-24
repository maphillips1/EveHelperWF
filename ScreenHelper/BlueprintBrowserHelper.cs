using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.ScreenHelper
{
    public static class BlueprintBrowserHelper
    {
        #region "Static Variables"
        private static bool Loaded = false;
        public static List<Objects.ComboListItem> InputPriceTypeItems = null;
        public static List<Objects.ComboListItem> ManufacturingSolarSystemComboItems = null;
        public static List<Objects.ComboListItem> ReactionSolarSystemComboItems = null;
        public static List<Objects.RefineryComplex> RefinerComplices = null;
        public static List<Objects.ComboListItem> EngineeringComboItems = null;
        public static List<Objects.ComboListItem> RefineryComboItems = null;
        public static List<Objects.IndustryImplant> ManufacturingImplants = null;
        public static List<Objects.IndustryImplant> MEImplants = null;
        public static List<Objects.IndustryImplant> TEImplants = null;
        public static List<Objects.IndustryImplant> CopyImplants = null;
        public static List<Objects.ComboListItem> ManufacturingImplantItems = null;
        public static List<Objects.ComboListItem> MEImplantItems = null;
        public static List<Objects.ComboListItem> TEImplantItems = null;
        public static List<Objects.ComboListItem> CopyImplantItems = null;
        public static List<Objects.ComboListItem> StructureManufacturingMERigs = null;
        public static List<Objects.Decryptor> Decryptors = null;

        #endregion

        #region "Init Functions"
        public static void Init()
        {
            if (!Loaded)
            {
                LoadRefineryComplices();
                LoadImplants();
            }
            Loaded = true;
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

        public static void LoadImplants()
        {
            LoadManufacturingImplants();
            LoadMeImplants();
            LoadTEImplants();
            LoadCopyImplants();
        }

        private static void LoadManufacturingImplants()
        {
            ManufacturingImplants = new List<Objects.IndustryImplant>();

            Objects.IndustryImplant indy1Implant = new Objects.IndustryImplant();
            indy1Implant.ImplantTypeID = 27170;
            indy1Implant.ImplantName = "Industry BX-01";
            indy1Implant.ImplantType = Objects.IndustryImplant.ImplantTypeManufacturing;
            indy1Implant.ImplantBonus = 1;
            ManufacturingImplants.Add(indy1Implant);

            Objects.IndustryImplant indy2Implant = new Objects.IndustryImplant();
            indy2Implant.ImplantTypeID = 27167;
            indy2Implant.ImplantName = "Industry BX-02";
            indy2Implant.ImplantType = Objects.IndustryImplant.ImplantTypeManufacturing;
            indy2Implant.ImplantBonus = 2;
            ManufacturingImplants.Add(indy2Implant);

            Objects.IndustryImplant indy4Implant = new Objects.IndustryImplant();
            indy4Implant.ImplantTypeID = 27171;
            indy4Implant.ImplantName = "Industry BX-04";
            indy4Implant.ImplantType = Objects.IndustryImplant.ImplantTypeManufacturing;
            indy4Implant.ImplantBonus = 4;
            ManufacturingImplants.Add(indy4Implant);
        }

        private static void LoadTEImplants()
        {
            TEImplants = new List<Objects.IndustryImplant>();

            Objects.IndustryImplant TE1Implant = new Objects.IndustryImplant();
            TE1Implant.ImplantTypeID = 27180;
            TE1Implant.ImplantName = "Research RR-01";
            TE1Implant.ImplantType = Objects.IndustryImplant.ImplantTypeTEREsearch;
            TE1Implant.ImplantBonus = 1;
            TEImplants.Add(TE1Implant);

            Objects.IndustryImplant TE2Implant = new Objects.IndustryImplant();
            TE2Implant.ImplantTypeID = 27177;
            TE2Implant.ImplantName = "Research RR-03";
            TE2Implant.ImplantType = Objects.IndustryImplant.ImplantTypeTEREsearch;
            TE2Implant.ImplantBonus = 3;
            TEImplants.Add(TE2Implant);

            Objects.IndustryImplant TE4Implant = new Objects.IndustryImplant();
            TE4Implant.ImplantTypeID = 27179;
            TE4Implant.ImplantName = "Research RR-05";
            TE4Implant.ImplantType = Objects.IndustryImplant.ImplantTypeTEREsearch;
            TE4Implant.ImplantBonus = 5;
            TEImplants.Add(TE4Implant);
        }

        private static void LoadMeImplants()
        {
            MEImplants = new List<Objects.IndustryImplant>();

            Objects.IndustryImplant ME1Implant = new Objects.IndustryImplant();
            ME1Implant.ImplantTypeID = 27182;
            ME1Implant.ImplantName = "Metallurgy MY-01";
            ME1Implant.ImplantType = Objects.IndustryImplant.ImplantTypeMEResearch;
            ME1Implant.ImplantBonus = 1;
            MEImplants.Add(ME1Implant);

            Objects.IndustryImplant ME2Implant = new Objects.IndustryImplant();
            ME2Implant.ImplantTypeID = 27176;
            ME2Implant.ImplantName = "Metallurgy MY-03";
            ME2Implant.ImplantType = Objects.IndustryImplant.ImplantTypeMEResearch;
            ME2Implant.ImplantBonus = 3;
            MEImplants.Add(ME2Implant);

            Objects.IndustryImplant ME4Implant = new Objects.IndustryImplant();
            ME4Implant.ImplantTypeID = 27181;
            ME4Implant.ImplantName = "Metallurgy MY-05";
            ME4Implant.ImplantType = Objects.IndustryImplant.ImplantTypeMEResearch;
            ME4Implant.ImplantBonus = 5;
            MEImplants.Add(ME4Implant);
        }

        private static void LoadCopyImplants()
        {
            CopyImplants = new List<Objects.IndustryImplant>();

            Objects.IndustryImplant Copy1Implant = new Objects.IndustryImplant();
            Copy1Implant.ImplantTypeID = 27185;
            Copy1Implant.ImplantName = "Science SC-01";
            Copy1Implant.ImplantType = Objects.IndustryImplant.ImplantTypeCopy;
            Copy1Implant.ImplantBonus = 1;
            CopyImplants.Add(Copy1Implant);

            Objects.IndustryImplant Copy2Implant = new Objects.IndustryImplant();
            Copy2Implant.ImplantTypeID = 27178;
            Copy2Implant.ImplantName = "Science SC-03";
            Copy2Implant.ImplantType = Objects.IndustryImplant.ImplantTypeCopy;
            Copy2Implant.ImplantBonus = 3;
            CopyImplants.Add(Copy2Implant);

            Objects.IndustryImplant Copy4Implant = new Objects.IndustryImplant();
            Copy4Implant.ImplantTypeID = 27184;
            Copy4Implant.ImplantName = "Science SC-05";
            Copy4Implant.ImplantType = Objects.IndustryImplant.ImplantTypeCopy;
            Copy4Implant.ImplantBonus = 5;
            CopyImplants.Add(Copy4Implant);
        }

        #endregion 

        #region "Drop Down Load Helpers"
        public static List<Objects.ComboListItem> GetPriceTypeComboItems()
        {
            if (InputPriceTypeItems == null)
            {
                InputPriceTypeItems = new List<Objects.ComboListItem>();
                Objects.ComboListItem SellItem = new Objects.ComboListItem();
                SellItem.key = (int)(Enums.Enums.OrderType.Sell);
                SellItem.value = "Sell";
                InputPriceTypeItems.Add(SellItem);

                Objects.ComboListItem BuyItem = new Objects.ComboListItem();
                BuyItem.key = (int)(Enums.Enums.OrderType.Buy);
                BuyItem.value = "Buy";
                InputPriceTypeItems.Add(BuyItem);
            }

            return InputPriceTypeItems;
        }

        public static List<Objects.ComboListItem> GetAllSolarSystemComboItems()
        {
            if (ManufacturingSolarSystemComboItems == null)
            {
                ManufacturingSolarSystemComboItems = new List<Objects.ComboListItem>();

                foreach (Objects.SolarSystem system in CommonHelper.SolarSystemList)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = system.solarSystemID;
                    comboListItem.value = system.solarSystemName;
                    ManufacturingSolarSystemComboItems.Add(comboListItem);
                }
            }
            return ManufacturingSolarSystemComboItems;
        }

        public static List<Objects.ComboListItem> GetLowAndNullSecComboItems()
        {
            if (ReactionSolarSystemComboItems == null)
            {
                ReactionSolarSystemComboItems = new List<Objects.ComboListItem>();
                //Reactions can only occurr in Low, null, wormholes. 
                List<Objects.SolarSystem> filteredSystems = CommonHelper.SolarSystemList.FindAll(x => Math.Round(x.security, 1) < Convert.ToDecimal(0.5));
                foreach (Objects.SolarSystem system in filteredSystems)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = system.solarSystemID;
                    comboListItem.value = system.solarSystemName;
                    ReactionSolarSystemComboItems.Add(comboListItem);
                }
            }
            return ReactionSolarSystemComboItems;
        }

        public static List<Objects.ComboListItem> GetEngineeringStructureItems()
        {
            if (EngineeringComboItems == null)
            {
                EngineeringComboItems = new List<Objects.ComboListItem>();

                Objects.ComboListItem npcStation = new Objects.ComboListItem();
                npcStation.value = "NPC Station";
                npcStation.key = 0;
                EngineeringComboItems.Add(npcStation);

                foreach (Objects.EngineerngComplex complex in CommonHelper.EngineerngComplices)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = complex.StructureTypeId;
                    comboListItem.value = complex.StructureName;
                    EngineeringComboItems.Add(comboListItem);
                }
            }

            return EngineeringComboItems;
        }

        public static List<Objects.ComboListItem> GetRefineryComboItems()
        {
            if (RefineryComboItems == null)
            {
                RefineryComboItems = new List<Objects.ComboListItem>();

                foreach (Objects.RefineryComplex complex in RefinerComplices)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = complex.StructureTypeID;
                    comboListItem.value = complex.StructureName;
                    RefineryComboItems.Add(comboListItem);
                }
            }
            return RefineryComboItems;
        }

        public static List<Objects.ComboListItem> GetManufacturingImplantItems()
        {
            if (ManufacturingImplantItems == null)
            {
                ManufacturingImplantItems = new List<Objects.ComboListItem>();

                Objects.ComboListItem noneItem = new Objects.ComboListItem();
                noneItem.value = "None";
                noneItem.key = 0;
                ManufacturingImplantItems.Add(noneItem);

                foreach (Objects.IndustryImplant implant in ManufacturingImplants)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = implant.ImplantTypeID;
                    comboListItem.value = implant.ImplantName;
                    ManufacturingImplantItems.Add(comboListItem);
                }
            }
            return ManufacturingImplantItems;
        }

        public static List<Objects.ComboListItem> GetTEImplantItems()
        {
            if (TEImplantItems == null)
            {
                TEImplantItems = new List<Objects.ComboListItem>();

                Objects.ComboListItem noneItem = new Objects.ComboListItem();
                noneItem.value = "None";
                noneItem.key = 0;
                TEImplantItems.Add(noneItem);

                foreach (Objects.IndustryImplant implant in TEImplants)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = implant.ImplantTypeID;
                    comboListItem.value = implant.ImplantName;
                    TEImplantItems.Add(comboListItem);
                }
            }
            return TEImplantItems;
        }

        public static List<Objects.ComboListItem> GetMEIMplentItems()
        {
            if (MEImplantItems == null)
            {
                MEImplantItems = new List<Objects.ComboListItem>();

                Objects.ComboListItem noneItem = new Objects.ComboListItem();
                noneItem.value = "None";
                noneItem.key = 0;
                MEImplantItems.Add(noneItem);

                foreach (Objects.IndustryImplant implant in MEImplants)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = implant.ImplantTypeID;
                    comboListItem.value = implant.ImplantName;
                    MEImplantItems.Add(comboListItem);
                }
            }
            return MEImplantItems;
        }

        public static List<Objects.ComboListItem> GetCopyImplantItems()
        {
            if (CopyImplantItems == null)
            {
                CopyImplantItems = new List<Objects.ComboListItem>();

                Objects.ComboListItem noneItem = new Objects.ComboListItem();
                noneItem.value = "None";
                noneItem.key = 0;
                CopyImplantItems.Add(noneItem);

                foreach (Objects.IndustryImplant implant in CopyImplants)
                {
                    Objects.ComboListItem comboListItem = new Objects.ComboListItem();
                    comboListItem.key = implant.ImplantTypeID;
                    comboListItem.value = implant.ImplantName;
                    CopyImplantItems.Add(comboListItem);
                }
            }
            return CopyImplantItems;
        }

        public static List<Objects.Decryptor> GetDecryptors()
        {
            Decryptors = new List<Objects.Decryptor>();

            Objects.Decryptor noneDecryptor = new Objects.Decryptor();
            noneDecryptor.typeID = 0;
            noneDecryptor.typeName = "None";
            Decryptors.Add(noneDecryptor);

            foreach (Objects.InventoryType inventoryType in CommonHelper.InventoryTypes.FindAll(x => x.groupId == 1304))
            {
                Objects.Decryptor decryptor = new Objects.Decryptor();
                decryptor.typeID = inventoryType.typeId;
                decryptor.typeName = inventoryType.typeName;
                switch (inventoryType.typeId)
                {
                    case 34201:
                        decryptor.probMultiplier = Convert.ToDecimal(0.2);
                        decryptor.runModifier = 1;
                        decryptor.meModifier = 2;
                        decryptor.teModifier = 10;
                        break;
                    case 34202:
                        decryptor.probMultiplier = Convert.ToDecimal(0.8);
                        decryptor.runModifier = 4;
                        decryptor.meModifier = -1;
                        decryptor.teModifier = 4;
                        break;
                    case 34203:
                        decryptor.probMultiplier = Convert.ToDecimal(-0.4);
                        decryptor.runModifier = 9;
                        decryptor.meModifier = -2;
                        decryptor.teModifier = 2;
                        break;
                    case 34204:
                        decryptor.probMultiplier = Convert.ToDecimal(0.5);
                        decryptor.runModifier = 3;
                        decryptor.meModifier = 1;
                        decryptor.teModifier = -2;
                        break;
                    case 34205:
                        decryptor.probMultiplier = Convert.ToDecimal(0.1);
                        decryptor.runModifier = 0;
                        decryptor.meModifier = 3;
                        decryptor.teModifier = 6;
                        break;
                    case 34206:
                        decryptor.probMultiplier = Convert.ToDecimal(0.0);
                        decryptor.runModifier = 2;
                        decryptor.meModifier = 1;
                        decryptor.teModifier = 8;
                        break;
                    case 34207:
                        decryptor.probMultiplier = Convert.ToDecimal(0.9);
                        decryptor.runModifier = 2;
                        decryptor.meModifier = 1;
                        decryptor.teModifier = -2;
                        break;
                    case 34208:
                        decryptor.probMultiplier = Convert.ToDecimal(-0.1);
                        decryptor.runModifier = 7;
                        decryptor.meModifier = 2;
                        decryptor.teModifier = 0;
                        break;
                }
                Decryptors.Add(decryptor);
            }

            return Decryptors;
        }

        public static List<Objects.ComboListItem> GetInventionProductItems(List<Objects.IndustryActivityProduct> invProducts)
        {
            List<Objects.ComboListItem> comboListItems = new List<Objects.ComboListItem>();

            if (invProducts != null && invProducts.Count > 0)
            {
                foreach (Objects.IndustryActivityProduct product in invProducts)
                {
                    Objects.InventoryType invType = CommonHelper.InventoryTypes.Find(x => x.typeId == product.productTypeID);
                    if (invType != null)
                    {
                        Objects.ComboListItem item = new Objects.ComboListItem();
                        item.key = invType.typeId;
                        item.value = invType.typeName;
                        comboListItems.Add(item);
                    }
                }
            }

            return comboListItems;
        }
        #endregion

        public static List<TreeNode> SearchBlueprints(string searchText)
        {
            List<Objects.InventoryType> invTypes = CommonHelper.InventoryTypes.FindAll(x => x.categoryID == 9); //Blueprint
            List<TreeNode> foundTypes = new List<TreeNode>();

            string[] splitstring = searchText.Trim().Split(' ');

            foreach (string searchPart in splitstring)
            {
                invTypes = invTypes.FindAll(x => x.typeName.ToLowerInvariant().Contains(searchPart.ToLowerInvariant()));
            }

            if (invTypes.Count > 0)
            {
                invTypes = invTypes.OrderBy(x => x.typeName).ToList();

                foreach (InventoryType type in invTypes)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = type.typeName;
                    treeNode.Tag = string.Concat("typeID_", type.typeId);
                    foundTypes.Add(treeNode);
                }
            }

            return foundTypes;
        }

        #region "Build Tree View"
        public static List<TreeNode> BuildBlueprintTreeView()
        {
            List<TreeNode> treeViewGroups = new List<TreeNode>();

            List<Objects.InventoryType> invTypes = CommonHelper.InventoryTypes.FindAll(x => x.categoryID == 9); //Blueprint
            List<Objects.InventoryMarketGroups> marketGroups = Database.SQLiteCalls.GetMarketGroups();


            treeViewGroups = GetTreeViewGroups(ref invTypes, marketGroups);

            return treeViewGroups;
        }

        public static List<TreeNode> GetTreeViewGroups(ref List<Objects.InventoryType> invTypes, List<Objects.InventoryMarketGroups> marketGroups)
        {
            List<TreeNode> groups = new List<TreeNode>();

            List<Int32> MarketGroups = new List<Int32>();
            //Change the market group ID first
            foreach (Objects.InventoryType inventoryType in invTypes)
            {
                inventoryType.marketGroupId = Database.SQLiteCalls.GetMarketGroupForBlueprintTypeID(inventoryType.typeId);
                if (inventoryType.marketGroupId > 0)
                {
                    inventoryType.marketGroupName = marketGroups.Find(x => x.marketGroupID == inventoryType.marketGroupId).marketGroupName;
                }
                else
                {
                    inventoryType.marketGroupName = "";
                }
                if (!MarketGroups.Contains(inventoryType.marketGroupId))
                {
                    MarketGroups.Add(inventoryType.marketGroupId);
                }
            }

            List<Int32> MarketGroupsCopy = new List<int>();
            MarketGroupsCopy.AddRange(MarketGroups);

            foreach (Int32 groupID in MarketGroupsCopy)
            {
                GetParentMarketGroupIDs(groupID, ref MarketGroups, marketGroups);
            }

            groups.AddRange(BuildTreeForMarketGroup(invTypes, marketGroups, 0));

            return groups;
        }

        private static void GetParentMarketGroupIDs(Int32 marketGroupId, ref List<Int32> marketGroupIDs, List<Objects.InventoryMarketGroups> marketGroups)
        {
            if (marketGroupId > 0)
            {
                Objects.InventoryMarketGroups group = marketGroups.Find(x => x.marketGroupID == marketGroupId);
                if (!marketGroupIDs.Contains(group.parentGroupID))
                {
                    marketGroupIDs.Add(group.parentGroupID);
                    GetParentMarketGroupIDs(group.parentGroupID, ref marketGroupIDs, marketGroups);
                }
            }
        }

        private static List<TreeNode> BuildTreeForMarketGroup(List<Objects.InventoryType> inventoryTypes, List<Objects.InventoryMarketGroups> marketGroups, int startingMarketGroupID)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();

            List<Objects.InventoryType> filteredTypes = inventoryTypes.FindAll(x => x.marketGroupId > 0 && x.marketGroupId == startingMarketGroupID);
            List<Objects.InventoryMarketGroups> filteredMakretGroups = marketGroups.FindAll(x => x.parentGroupID == startingMarketGroupID);

            foreach (Objects.InventoryType inventoryType in filteredTypes)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = inventoryType.typeName;
                treeNode.Tag = string.Concat("typeID_", inventoryType.typeId);
                treeNodes.Add(treeNode);
            }

            foreach (Objects.InventoryMarketGroups marketGroup in filteredMakretGroups)
            {
                if (GroupHasBlueprint(inventoryTypes, marketGroups, marketGroup.marketGroupID))
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = marketGroup.marketGroupName;
                    treeNode.Tag = string.Concat("groupID_", marketGroup.marketGroupID);
                    treeNode.Nodes.AddRange(BuildTreeForMarketGroup(inventoryTypes, marketGroups, marketGroup.marketGroupID).ToArray());
                    treeNodes.Add(treeNode);
                }
            }

            return treeNodes;
        }

        private static bool GroupHasBlueprint(List<Objects.InventoryType> inventoryTypes, List<Objects.InventoryMarketGroups> marketGroups, int startingMarketGroupID)
        {
            bool hasBlueprint = false;
            List<Objects.InventoryType> filteredTypes = inventoryTypes.FindAll(x => x.marketGroupId == startingMarketGroupID);

            if (filteredTypes.Count > 0)
            {
                hasBlueprint = true;
            }

            if (!hasBlueprint)
            {

                List<Objects.InventoryMarketGroups> groups = marketGroups.FindAll(x => x.parentGroupID == startingMarketGroupID);
                foreach (Objects.InventoryMarketGroups group in groups)
                {
                    if (GroupHasBlueprint(inventoryTypes, marketGroups, group.marketGroupID))
                    {
                        hasBlueprint = true;
                        break;
                    }
                }
            }

            return hasBlueprint;
        }
        #endregion

        #region "Generic Methods"
        public static void GetMatsForTypeAndActivity(List<Objects.IndustryActivityTypes> industryActivityTypes, int type_id, int activity_id, ref List<Objects.MaterialsWithMarketData> mats, bool buildComponents)
        {
            if (industryActivityTypes.Find(x => x.activityID == activity_id) != null)
            {
                mats = new List<Objects.MaterialsWithMarketData>();
                List<Objects.IndustryActivityMaterials> baseMats = baseMats = Database.SQLiteCalls.GetIndustryActivityMaterials(type_id, activity_id);
                foreach (Objects.IndustryActivityMaterials mat in baseMats)
                {
                    Objects.MaterialsWithMarketData newMat = new Objects.MaterialsWithMarketData();

                    newMat.materialName = mat.materialName;
                    newMat.quantity = mat.quantity;
                    newMat.materialTypeID = mat.materialTypeID;
                    newMat.Buildable = mat.isManufacturable;
                    newMat.Reactable = mat.isReactable;
                    mats.Add(newMat);
                }
                mats.OrderByDescending(x => x.quantity);
            }
        }

        public static void GetPriceForProduct(int outputPriceType, ref List<Objects.IndustryActivityProduct> products)
        {
            if (products != null)
            {
                bool isBuyOrder = (outputPriceType == 2);
                foreach (Objects.IndustryActivityProduct prod in products)
                {
                    if (isBuyOrder)
                    {
                        prod.pricePer = ESI_Calls.ESIMarketData.GetBuyOrderPrice(prod.productTypeID, Enums.Enums.TheForgeRegionId);
                        prod.priceTotal = ESI_Calls.ESIMarketData.GetBuyOrderPriceForQuantity(prod.productTypeID, Enums.Enums.TheForgeRegionId, prod.quantity);
                    }
                    else
                    {
                        prod.pricePer = ESI_Calls.ESIMarketData.GetSellOrderPrice(prod.productTypeID, Enums.Enums.TheForgeRegionId);
                        prod.priceTotal = prod.pricePer * prod.quantity;
                    }
                }
            }
        }

        public static void GetMatPriceForActivity(int inputPriceType, ref List<Objects.MaterialsWithMarketData> mats, bool buildComponetns)
        {
            if (mats != null)
            {
                bool isBuyOrder = (inputPriceType == 2);
                foreach (Objects.MaterialsWithMarketData mat in mats)
                {
                    if ( (mat.Buildable) && buildComponetns)
                    {
                        mat.priceTotal = 0;
                        continue;
                    }
                    if (isBuyOrder)
                    {
                        mat.pricePer = ESI_Calls.ESIMarketData.GetBuyOrderPrice(mat.materialTypeID, Enums.Enums.TheForgeRegionId);
                        mat.priceTotal = ESI_Calls.ESIMarketData.GetBuyOrderPriceForQuantity(mat.materialTypeID, Enums.Enums.TheForgeRegionId, mat.quantityTotal);
                    }
                    else
                    {
                        mat.pricePer = ESI_Calls.ESIMarketData.GetSellOrderPrice(mat.materialTypeID, Enums.Enums.TheForgeRegionId);
                        mat.priceTotal = ESI_Calls.ESIMarketData.GetSellOrderPriceForQuantity(mat.materialTypeID, Enums.Enums.TheForgeRegionId, mat.quantityTotal);
                    }
                }
            }
        }

        public static string FormatTimeAsString(Int64 time)
        {
            string formattedTime = "";

            int years = Convert.ToInt32(Math.Floor(Convert.ToDecimal(time) / 31536000));
            if (years > 0)
            {
                time -= (31536000 * years);
                formattedTime = String.Format("{0}y ", years.ToString());
            }
            int months = Convert.ToInt32(Math.Floor(Convert.ToDecimal(time) / 2592000));
            if (months > 0)
            {
                time -= (2592000 * months);
                formattedTime = String.Concat(formattedTime, string.Format("{0}mo ", months));
            }
            int days = Convert.ToInt32(Math.Floor(Convert.ToDecimal(time) / 86400));
            if (days > 0)
            {
                time -= (86400 * days);
                formattedTime = String.Concat(formattedTime, string.Format("{0}d ", days));
            }
            int hours = Convert.ToInt32(Math.Floor(Convert.ToDecimal(time) / 3600));
            if (hours > 0)
            {
                time -= (3600 * hours);
                formattedTime = String.Concat(formattedTime, string.Format("{0}h ", hours));
            }
            int minutes = Convert.ToInt32(Math.Floor(Convert.ToDecimal(time) / 60));
            if (minutes > 0)
            {
                time -= (60 * minutes);
                formattedTime = String.Concat(formattedTime, string.Format("{0}mi ", minutes));
            }
            Int64 seconds = time;

            formattedTime = String.Concat(formattedTime, string.Format("{0}s ", seconds));



            return formattedTime;
        }

        public static string FormatNumber(Int64 number)
        {
            string text = number.ToString("N");
            text = text.Replace(".00", "");
            return text;
        }

        public static string FormatNumber(decimal number)
        {
            string text = number.ToString("N");
            text = text.Replace(".00", "");
            return text;
        }

        public static decimal CalculateTotalVolume(List<Objects.MaterialsWithMarketData> mats, Objects.CalculationHelperClass helperClass, bool buildComponents)
        {
            decimal totalVolume = 0;

            foreach (Objects.MaterialsWithMarketData mat in mats)
            {
                if (helperClass.BuildComponents)
                {
                    if (mat.ParentMaterialTypeID > 0 || !buildComponents)
                    {
                        Objects.InventoryType matType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                        totalVolume += mat.quantityTotal * matType.volume;
                        mat.volumeTotal = mat.quantityTotal * matType.volume;
                    }
                    else
                    {
                        mat.volumeTotal = 0;
                    }
                }
                else
                {
                    Objects.InventoryType matType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                    totalVolume += mat.quantityTotal * matType.volume;
                    mat.volumeTotal = mat.quantityTotal * matType.volume;
                }
            }

            return totalVolume;
        }

        public static decimal CalculateOutputTotalVolume(List<Objects.IndustryActivityProduct> products, int runs, int activityID)
        {
            decimal totalVolume = 0;

            foreach (Objects.IndustryActivityProduct product in products)
            {
                if (product.activityID == activityID)
                {
                    Objects.InventoryType prodType = CommonHelper.InventoryTypes.Find(x => x.typeId == product.productTypeID);
                    if (prodType != null)
                    {
                        totalVolume += (runs * prodType.volume * product.quantity);
                    }
                }
            }

            return totalVolume;
        }

        public static decimal CalculateTotalOutputPrice(List<Objects.IndustryActivityProduct> products, int runs, int activityID)
        {
            decimal price = 0;
            int totalQuantity = 0;
            foreach (Objects.IndustryActivityProduct prod in products)
            {
                if (prod.activityID == activityID)
                {
                    totalQuantity += (prod.quantity * runs);
                    price += (prod.pricePer * totalQuantity);
                }
            }
            return price;
        }

        public static int CalculateTotalOutputQuantity(List<Objects.IndustryActivityProduct> products, int runs, int activityID)
        {
            int totalQuantity = 0;
            foreach (Objects.IndustryActivityProduct prod in products)
            {
                if (prod.activityID == activityID)
                {
                    totalQuantity += (prod.quantity * runs);
                }
            }
            return totalQuantity;
        }

        public static List<Objects.MaterialsWithMarketData> CombinedInputMats(List<Objects.MaterialsWithMarketData> inputMats)
        {
            List<Objects.MaterialsWithMarketData> combinedMats = new List<Objects.MaterialsWithMarketData>();

            foreach (Objects.MaterialsWithMarketData mat in inputMats)
            {
                //We are excluding the parts we are building/reacting.
                if (mat.priceTotal > 0)
                {
                    Objects.MaterialsWithMarketData comboMat = combinedMats.Find(x => x.materialTypeID == mat.materialTypeID);
                    if (comboMat == null)
                    {
                        combinedMats.Add(mat);
                    }
                    else
                    {
                        comboMat.quantity += mat.quantity;
                        comboMat.quantityTotal += mat.quantityTotal;
                        comboMat.priceTotal += mat.priceTotal;
                        comboMat.volumeTotal += mat.volumeTotal;
                    }
                }
            }

            return combinedMats;
        }
        #endregion

        #region "Manufacturing Methods"
        public static void CalculateManufacturingInputQuantAndPrice(ref List<Objects.MaterialsWithMarketData> inputMats, Objects.CalculationHelperClass calculationHelperClass)
        {
            decimal totalStructureMEBonus = 1;
            decimal MEBonus = (100m - Convert.ToDecimal(calculationHelperClass.ME)) / 100;
            List<Int32> buildableMats = new List<int>();
            decimal quantityTotal = 0;
            if (calculationHelperClass.ManufacturingStructureTypeID > 0)
            {
                totalStructureMEBonus = CommonHelper.GetManufacturingStructureMEBonus(calculationHelperClass);
            }
            foreach (Objects.MaterialsWithMarketData mat in inputMats)
            {
                //Calculation
                //Base Blueprint Input Quantity * ME. = new base quantity. 
                //Total = BaseQuantity * runs * (Bonus Percentage total (rigs, structure bonuses, etc) )

                //Step 1 = Set quantity Total to Base Blueprint * ME.
                quantityTotal = mat.quantity * MEBonus;

                //Step 2 = Quantity Total * runs Ceiling
                quantityTotal *= calculationHelperClass.Runs;

                //If the blueprint requires 1 of each item the next ME calc does not apply because
                //it will always require 1 item per run./
                if (quantityTotal > calculationHelperClass.Runs)
                {
                    //Step 3 = Apply the structure ME Bonuses
                    mat.quantityTotal = Convert.ToInt64(Math.Ceiling(quantityTotal * totalStructureMEBonus));
                }
                else
                {
                    mat.quantityTotal = Convert.ToInt64(Math.Ceiling(quantityTotal));
                }

                //Set Price Total. 
                mat.priceTotal = mat.pricePer * mat.quantityTotal;

                if (calculationHelperClass.BuildComponents && mat.Buildable)
                {
                    mat.priceTotal = 0;
                    buildableMats.Add(mat.materialTypeID);
                }
            }


            if (calculationHelperClass.BuildComponents)
            {
                foreach (Int32 buildableTypeID in buildableMats)
                {
                    Objects.MaterialsWithMarketData parentMat = inputMats.Find(x => x.materialTypeID == buildableTypeID);
                    List<Objects.MaterialsWithMarketData> childMats = GetComponentMaterials(parentMat, calculationHelperClass);
                    inputMats.AddRange(childMats);
                }
            }
        }

        public static Int64 CalculateManufacturingTime(List<Objects.IndustryActivityTypes> activityTypes, Objects.CalculationHelperClass helperClass)
        {
            Int64 time = 0;
            decimal structureTEBonus = GetManufacturingStructureTEBonus(helperClass);
            decimal implantsSkillsTEBonus = GetManufacturingImplantAndSkillBonus(helperClass);

            Objects.IndustryActivityTypes industryActivity = activityTypes.Find(x => x.activityID == Enums.Enums.ActivityManufacturing);
            if (industryActivity != null)
            {
                time = industryActivity.time;

                //Step 1 Manufacturing TE Base.
                time = Convert.ToInt64(time * (1 - Convert.ToDecimal(helperClass.TE) / Convert.ToDecimal(100)));

                //Runs
                time *= helperClass.Runs;

                //Step 2 SKills & Implants
                time = Convert.ToInt64(time * implantsSkillsTEBonus);

                //Step 3 Structure
                time = Convert.ToInt64(time * structureTEBonus);
            }

            return time;
        }

        public static decimal GetManufacturingStructureTEBonus(Objects.CalculationHelperClass helperClass)
        {
            Decimal teBonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;

            if (helperClass.ManufacturingSolarSystemID > 0)
            {
                Objects.SolarSystem solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == helperClass.ManufacturingSolarSystemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (helperClass.ManufacturingStructureTypeID > 0)
            {
                Objects.EngineerngComplex complex = CommonHelper.EngineerngComplices.Find(x => x.StructureTypeId == helperClass.ManufacturingStructureTypeID);

                if (complex != null)
                {
                    teBonus -= Convert.ToDecimal(complex.TimeRequirementBonus) / 100;

                    if (helperClass.ManufacturingStructureRigBonus != null)
                    {
                        decimal rigTEBonus = 0;
                        if (helperClass.ManufacturingStructureRigBonus.RigTEBonus == 1)
                        {
                            rigTEBonus = Convert.ToDecimal(0.2);
                        }
                        else if (helperClass.ManufacturingStructureRigBonus.RigTEBonus == 2)
                        {
                            rigTEBonus = Convert.ToDecimal(0.24);
                        }
                        if (isLowSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.19);
                        }
                        else if (isNullSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.21);
                        }
                        rigTEBonus = 1 - (rigTEBonus);

                        teBonus *= rigTEBonus;
                    }
                }
            }

            return teBonus;
        }

        public static decimal GetManufacturingImplantAndSkillBonus(Objects.CalculationHelperClass helperClass)
        {
            decimal teBonus = 1;

            decimal indySkillLevel = 5; //Change to get skill level
            decimal IndySkillBonus = 1;

            decimal advancedIndySkillLevel = 5; //change to get skill level
            decimal advancedIndySkillBonus = 1;

            decimal implantBonus = 1;

            if (helperClass.ManufacturingImplantTypeID > 0)
            {
                Objects.IndustryImplant industryImplant = ManufacturingImplants.Find(x => x.ImplantTypeID == helperClass.ManufacturingImplantTypeID);

                implantBonus -= (Convert.ToDecimal(industryImplant.ImplantBonus) / 100);
            }

            IndySkillBonus -= ((indySkillLevel * 4) / 100);

            advancedIndySkillBonus -= ((advancedIndySkillLevel * 3) / 100);


            teBonus = (teBonus * IndySkillBonus * advancedIndySkillBonus * implantBonus);

            return teBonus;
        }

        #region "Build Components Methods"
        private static List<Objects.MaterialsWithMarketData> GetComponentMaterials(Objects.MaterialsWithMarketData parentMat, Objects.CalculationHelperClass helperClass)
        {
            List<Objects.MaterialsWithMarketData> childMaterials = new List<Objects.MaterialsWithMarketData>();

            int blueprintTypeID = Database.SQLiteCalls.GetBlueprintByProductTypeID(parentMat.materialTypeID);

            if (blueprintTypeID > 0)
            {
                int originalME = helperClass.ME;
                int originalTE = helperClass.TE;

                helperClass.ME = helperClass.CompME;
                helperClass.TE = helperClass.CompTE;

                List<Objects.IndustryActivityTypes> bpActivityTypes = Database.SQLiteCalls.GetIndustryActivityTypes(blueprintTypeID);
                GetMatsForTypeAndActivity(bpActivityTypes, blueprintTypeID, Enums.Enums.ActivityManufacturing, ref childMaterials, false);
                List<Objects.IndustryActivityProduct> bpProducts = Database.SQLiteCalls.GetIndustryActivityProducts(blueprintTypeID, Enums.Enums.ActivityManufacturing);
                int runsNeeded = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(parentMat.quantityTotal) / Convert.ToDecimal(bpProducts[0].quantity)));

                //Save current state of helper class variables
                int originalRuns = helperClass.Runs;

                helperClass.BuildComponents = false;
                helperClass.Runs = runsNeeded;
                CalculateManufacturingInputQuantAndPrice(ref childMaterials, helperClass);

                //reset helper class variabls
                helperClass.Runs = originalRuns;
                helperClass.BuildComponents = true;

                foreach (Objects.MaterialsWithMarketData childMat in childMaterials)
                {
                    childMat.ParentMaterialTypeID = parentMat.materialTypeID;
                }

                helperClass.ME = originalME;
                helperClass.TE = originalTE;

            }

            return childMaterials;
        }

        public static Int64 GetComponentManufacturingTime(List<Objects.MaterialsWithMarketData> mats, Objects.CalculationHelperClass helperClass)
        {
            Int64 time = 0;
            List<Int32> handledMats = new List<int>();

            foreach (Objects.MaterialsWithMarketData childMat in mats)
            {
                if (childMat.ParentMaterialTypeID > 0)
                {
                    if (!handledMats.Contains(childMat.ParentMaterialTypeID))
                    {
                        //Set this so we don't process it twice. 
                        handledMats.Add(childMat.ParentMaterialTypeID);

                        Objects.MaterialsWithMarketData parentMat = mats.Find(x => x.materialTypeID == childMat.ParentMaterialTypeID && x.ParentMaterialTypeID == 0);
                        if (parentMat != null)
                        {
                            int blueprintTypeID = Database.SQLiteCalls.GetBlueprintByProductTypeID(parentMat.materialTypeID);

                            if (blueprintTypeID > 0)
                            {
                                List<Objects.IndustryActivityTypes> bpActivityTypes = Database.SQLiteCalls.GetIndustryActivityTypes(blueprintTypeID);
                                List<Objects.IndustryActivityProduct> bpProducts = Database.SQLiteCalls.GetIndustryActivityProducts(blueprintTypeID, Enums.Enums.ActivityManufacturing);
                                int runsNeeded = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(parentMat.quantityTotal) / Convert.ToDecimal(bpProducts[0].quantity)));

                                int originalRuns = helperClass.Runs;
                                //set build components to false
                                helperClass.BuildComponents = false;
                                helperClass.Runs = runsNeeded;

                                time += CalculateManufacturingTime(bpActivityTypes, helperClass);

                                //set it back to true.
                                helperClass.BuildComponents = true;
                                helperClass.Runs = originalRuns;
                            }
                        }
                    }
                }
            }


            return time;
        }
        #endregion
        #endregion

        #region "Reaction Methods"
        public static void CalculateReactionInputQuantAndPrice(ref List<Objects.MaterialsWithMarketData> inputMats, Objects.CalculationHelperClass calculationHelperClass)
        {
            decimal totalStructureMEBonus = 1;
            if (calculationHelperClass.ReactionsStructureTypeID > 0)
            {
                totalStructureMEBonus = CommonHelper.GetReactionStructureMEBonus(calculationHelperClass);
            }
            foreach (Objects.MaterialsWithMarketData mat in inputMats)
            {
                //Calculation
                //Total = BaseQuantity * runs * (Bonus Percentage total (rigs, structure bonuses, etc) )

                //Step 1 = Quantity Total * runs Ceiling
                mat.quantityTotal = Convert.ToInt64((mat.quantity * calculationHelperClass.Runs));

                //If the blueprint requires 1 of each item the next ME calc does not apply because
                //it will always require 1 item per run.
                if (mat.quantityTotal != calculationHelperClass.Runs)
                {
                    //Step 3 = Apply the structure ME Bonuses
                    mat.quantityTotal = Convert.ToInt64(Math.Ceiling(mat.quantityTotal * totalStructureMEBonus));
                }

                //Set Price Total. 
                mat.priceTotal = mat.pricePer * mat.quantityTotal;
            }
        }


        public static Int64 CalculateReactionTime(List<Objects.IndustryActivityTypes> activityTypes, Objects.CalculationHelperClass helperClass)
        {
            Int64 time = 0;
            decimal structureTEBonus = GetReactionStructureTEBonus(helperClass);
            decimal skillsBonus = GetReactionSkillBonus(helperClass);

            Objects.IndustryActivityTypes industryActivity = activityTypes.Find(x => x.activityID == Enums.Enums.ActivityReactions);
            if (industryActivity != null)
            {
                time = industryActivity.time;
                //Runs
                time *= helperClass.Runs;

                //Step 2 SKills
                time = Convert.ToInt64(time * skillsBonus);

                //Step 3 Structure
                time = Convert.ToInt64(time * structureTEBonus);
            }

            return time;
        }

        public static decimal GetReactionStructureTEBonus(Objects.CalculationHelperClass helperClass)
        {
            Decimal teBonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;

            if (helperClass.ReactionSolarSystemID > 0)
            {
                Objects.SolarSystem solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == helperClass.ReactionSolarSystemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (helperClass.ReactionsStructureTypeID > 0)
            {
                Objects.RefineryComplex complex = RefinerComplices.Find(x => x.StructureTypeID == helperClass.ReactionsStructureTypeID);

                if (complex != null)
                {
                    teBonus -= Convert.ToDecimal(complex.ReactionTimeBonus) / 100;

                    if (helperClass.ReactionStructureRigBonus != null)
                    {
                        decimal rigTEBonus = 0;
                        if (helperClass.ReactionStructureRigBonus.RigTEBonus == 1)
                        {
                            rigTEBonus = Convert.ToDecimal(0.2);
                        }
                        else if (helperClass.ReactionStructureRigBonus.RigTEBonus == 2)
                        {
                            rigTEBonus = Convert.ToDecimal(0.24);
                        }
                        if (isNullSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.21);
                        }
                        rigTEBonus = 1 - (rigTEBonus);

                        teBonus *= rigTEBonus;
                    }
                }
            }

            return teBonus;
        }

        public static decimal GetReactionSkillBonus(Objects.CalculationHelperClass helperClass)
        {
            decimal teBonus = 1;

            decimal reactions = 5; //Change to get skill level
            decimal reactionsSkillBonus = 1;

            reactionsSkillBonus -= ((reactions * 4) / 100);


            teBonus = (teBonus * reactionsSkillBonus);

            return teBonus;
        }
        #endregion

        #region "Invention Methods"
        private static decimal GetInventionStructureCostBonus(Objects.CalculationHelperClass helperClass)
        {
            decimal costBonus = 1;

            if (helperClass.ManufacturingStructureTypeID > 0)
            {
                Objects.EngineerngComplex complex = CommonHelper.EngineerngComplices.Find(x => x.StructureTypeId == helperClass.InventionStructureTypeID);
                if (complex != null)
                {
                    costBonus -= (Convert.ToDecimal(complex.IskRequirementBonus) / 100);
                }
            }

            return costBonus;
        }

        public static void CalculateInventionInputQuantAndPrice(ref List<Objects.MaterialsWithMarketData> inputMats, Objects.CalculationHelperClass calculationHelperClass)
        {
            foreach (Objects.MaterialsWithMarketData mat in inputMats)
            {
                //Calculation
                //Total = BaseQuantity * runs * (Bonus Percentage total (rigs, structure bonuses, etc) )

                //Step 1 = Quantity Total * runs Ceiling
                mat.quantityTotal = Convert.ToInt64((mat.quantity * calculationHelperClass.Runs));

                //Set Price Total. 
                mat.priceTotal = mat.pricePer * mat.quantityTotal;
            }

            if (calculationHelperClass.InventionDecryptorId > 0)
            {
                Objects.Decryptor decryptor = Decryptors.Find(x => x.typeID == calculationHelperClass.InventionDecryptorId);
                if (decryptor != null)
                {
                    Objects.MaterialsWithMarketData materialsWithMarketData = new Objects.MaterialsWithMarketData();
                    materialsWithMarketData.materialTypeID = decryptor.typeID;
                    materialsWithMarketData.materialName = decryptor.typeName;
                    materialsWithMarketData.Buildable = false;
                    materialsWithMarketData.Reactable = false;
                    materialsWithMarketData.quantity = 1;
                    materialsWithMarketData.quantityTotal = calculationHelperClass.Runs;
                    inputMats.Add(materialsWithMarketData);
                }
            }
        }

        public static Int64 CalculateInventionTime(List<Objects.IndustryActivityTypes> activityTypes, Objects.CalculationHelperClass helperClass)
        {
            Int64 time = 0;
            decimal structureTEBonus = GetInventionStructureTEBonus(helperClass);
            decimal skillBonus = Convert.ToDecimal(0.85);

            Objects.IndustryActivityTypes industryActivity = activityTypes.Find(x => x.activityID == Enums.Enums.ActivityInvention);
            if (industryActivity != null)
            {
                time = industryActivity.time;

                //Runs
                time *= helperClass.Runs;

                //Skills
                time = Convert.ToInt64(time * skillBonus);

                //Step 3 Structure
                time = Convert.ToInt64(time * structureTEBonus);
            }

            return time;
        }

        public static decimal GetInventionStructureTEBonus(Objects.CalculationHelperClass helperClass)
        {
            Decimal teBonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;

            if (helperClass.InventionSolarSystemID > 0)
            {
                Objects.SolarSystem solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == helperClass.InventionSolarSystemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (helperClass.InventionStructureTypeID > 0)
            {
                Objects.EngineerngComplex complex = CommonHelper.EngineerngComplices.Find(x => x.StructureTypeId == helperClass.InventionStructureTypeID);

                if (complex != null)
                {
                    teBonus -= Convert.ToDecimal(complex.TimeRequirementBonus) / 100;

                    if (helperClass.ReactionStructureRigBonus != null)
                    {
                        decimal rigTEBonus = 0;
                        if (helperClass.InventionStructureRigBonus.RigTEBonus == 1)
                        {
                            rigTEBonus = Convert.ToDecimal(0.2);
                        }
                        else if (helperClass.InventionStructureRigBonus.RigTEBonus == 2)
                        {
                            rigTEBonus = Convert.ToDecimal(0.24);
                        }
                        if (isLowSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.19);
                        }
                        else if (isNullSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.21);
                        }
                        rigTEBonus = 1 - (rigTEBonus);

                        teBonus *= rigTEBonus;
                    }
                }
            }

            return teBonus;
        }

        public static decimal CalculateInventionJobCost(List<MaterialsWithMarketData> manuMats, Objects.CalculationHelperClass helperClass)
        {
            decimal jobCost = 0;
            decimal baseJobCost = 0;
            decimal costIndice = 0;
            decimal estimatedItemValue = GetEstimatedItemValueForBlueprintInvention(helperClass);
            decimal structureBonus = GetInventionStructureCostBonus(helperClass);
            double sccSurcharge = Enums.Enums.SCCSurcharge;

            if (helperClass.InventionSolarSystemID > 0)
            {
                costIndice = CommonHelper.GetCostIndexForSystemID(helperClass.InventionSolarSystemID, CostIndiceActivity.ActivityInvention);
            }

            baseJobCost = Math.Round(estimatedItemValue * Convert.ToDecimal(0.02));

            jobCost = Math.Round(baseJobCost * costIndice);

            jobCost = Math.Round(jobCost * structureBonus);

            jobCost += Math.Round(jobCost * (Convert.ToDecimal(helperClass.InventionFacilityTax) / 100));

            jobCost += Math.Round(baseJobCost * (decimal)sccSurcharge);

            return jobCost;
        }

        public static decimal GetEstimatedItemValueForBlueprintInvention(Objects.CalculationHelperClass helperClass)
        {
            decimal estimatedItemValue = 0;

            if (helperClass.InventionProductTypeId > 0)
            {
                List<Objects.IndustryActivityProduct> products = Database.SQLiteCalls.GetIndustryActivityProducts(helperClass.InventionProductTypeId, Enums.Enums.ActivityManufacturing);
                if (products != null && products.Count > 0)
                {
                    int productTypeId = products[0].productTypeID;
                    if (productTypeId > 0)
                    {
                        Objects.AdjustedCost adjustedCost = CommonHelper.AdjustedCosts.Find(x => x.type_id == productTypeId);
                        if (adjustedCost != null)
                        {
                            if (adjustedCost.adjusted_price > 0)
                            {
                                estimatedItemValue = adjustedCost.adjusted_price;
                            }
                            else
                            {
                                estimatedItemValue = adjustedCost.average_price;
                            }
                        }
                    }
                }
            }

            return Math.Round(estimatedItemValue * helperClass.Runs);
        }

        private static decimal GetStructureCostRigBonus(Objects.CalculationHelperClass helperClass)
        {
            decimal bonus = 1;
            bool isLowSec = false;
            bool isNullSec = false;

            if (helperClass.InventionSolarSystemID > 0)
            {
                Objects.SolarSystem solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == helperClass.InventionSolarSystemID);
                isLowSec = (Math.Round(solarSystem.security, 1) < Convert.ToDecimal(0.5) && Math.Round(solarSystem.security, 1) > 0);
                isNullSec = (Math.Round(solarSystem.security, 1) <= 0);
            }

            if (helperClass.InventionStructureTypeID > 0)
            {
                Objects.EngineerngComplex complex = CommonHelper.EngineerngComplices.Find(x => x.StructureTypeId == helperClass.InventionStructureTypeID);

                if (complex != null)
                {
                    bonus -= Convert.ToDecimal(complex.IskRequirementBonus) / 100;

                    if (helperClass.ReactionStructureRigBonus != null)
                    {
                        decimal rigTEBonus = 0;
                        if (helperClass.InventionStructureRigBonus.RigTEBonus == 1)
                        {
                            rigTEBonus = Convert.ToDecimal(0.1);
                        }
                        else if (helperClass.InventionStructureRigBonus.RigTEBonus == 2)
                        {
                            rigTEBonus = Convert.ToDecimal(0.12);
                        }
                        if (isLowSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.19);
                        }
                        else if (isNullSec)
                        {
                            rigTEBonus *= Convert.ToDecimal(1.21);
                        }
                        rigTEBonus = 1 - (rigTEBonus);

                        bonus *= rigTEBonus;
                    }
                }
            }
            return bonus;
        }

        public static decimal CalculateInventionProbability(Objects.CalculationHelperClass helperClass)
        {
            decimal probability = 0;
            decimal encryptionSkillLevel = 5;
            decimal dataCoreSkill1Level = 5;
            decimal dataCoreSkillLevel2 = 5;

            decimal baseChance = 0;
            decimal skillBonus = 1 + Convert.ToDecimal(encryptionSkillLevel / Convert.ToDecimal(40)) + ((dataCoreSkill1Level + dataCoreSkillLevel2) / 30);
            decimal decryptorBonus = 1;

            List<Objects.InventionProbability> probabilities = Database.SQLiteCalls.GetInventionProbabilities(helperClass.SelectedTypeID, Enums.Enums.ActivityInvention);
            if (probabilities != null && probabilities.Count > 0 && helperClass.InventionProductTypeId > 0)
            {
                Objects.InventionProbability prob = probabilities.Find(x => x.productTypeID == helperClass.InventionProductTypeId);
                if (prob != null)
                {
                    baseChance = prob.probability;
                }
                if (helperClass.InventionDecryptorId > 0)
                {
                    Objects.Decryptor decryptor = Decryptors.Find(x => x.typeID == helperClass.InventionDecryptorId);
                    if (decryptor != null)
                    {
                        decryptorBonus = (1 + decryptor.probMultiplier);
                    }
                }
            }

            probability = baseChance * skillBonus * decryptorBonus;

            return Math.Round(probability, 4);
        }

        public static int GetInventionRuns(Objects.CalculationHelperClass helperClass, List<Objects.IndustryActivityProduct> products)
        {
            int runs = 0;

            if (helperClass.InventionProductTypeId > 0)
            {
                Objects.IndustryActivityProduct product = products.Find(x => x.productTypeID == helperClass.InventionProductTypeId);
                if (product != null)
                {
                    if (helperClass.InventionDecryptorId > 0)
                    {
                        Objects.Decryptor decryptor = Decryptors.Find(x => x.typeID == helperClass.InventionDecryptorId);
                        if (decryptor != null)
                        {
                            runs = (product.quantity + decryptor.runModifier) * helperClass.Runs;
                        }
                        else
                        {
                            runs = product.quantity * helperClass.Runs;
                        }
                    }
                    else
                    {
                        runs = product.quantity * helperClass.Runs;
                    }
                }
            }

            return runs;
        }

        public static int GetInventionME(Objects.CalculationHelperClass helperClass)
        {
            int ME = 2;

            if (helperClass.InventionDecryptorId > 0)
            {
                Objects.Decryptor decryptor = Decryptors.Find(x => x.typeID == helperClass.InventionDecryptorId);
                if (decryptor != null)
                {
                    ME += decryptor.meModifier;
                }
            }

            return ME;
        }

        public static int GetInventionTE(Objects.CalculationHelperClass helperClass)
        {
            int TE = 4;

            if (helperClass.InventionDecryptorId > 0)
            {
                Objects.Decryptor decryptor = Decryptors.Find(x => x.typeID == helperClass.InventionDecryptorId);
                if (decryptor != null)
                {
                    TE += decryptor.teModifier;
                }
            }

            return TE;
        }

        #endregion

        #region "ME and TE Research Methods"
        public static Int64 GetMeResearchTime(long baseTime, CalculationHelperClass helperClass)
        {
            Int64 seconds = 0;
            double implantBonus = 1;
            double skillBonus = (1 * .75 * .85);
            int levelModifier = 0;

            if (helperClass.METoLevel > helperClass.MEFromLevel)
            {
                if (helperClass.MEImplantTypeID > 0)
                {
                    Objects.IndustryImplant industryImplant = MEImplants.Find(x => x.ImplantTypeID == helperClass.MEImplantTypeID);

                    implantBonus -= (Convert.ToDouble(industryImplant.ImplantBonus) / 100);
                }
                levelModifier = GetMETELevelTime(helperClass.METoLevel);

                seconds = Convert.ToInt64(baseTime * (1 * skillBonus * implantBonus) * levelModifier);
                seconds = seconds / 105;
            }

            return seconds;
        }
        public static Int64 GetTEResearchTime(long baseTime, CalculationHelperClass helperClass)
        {
            Int64 seconds = 0;
            double implantBonus = 1;
            double skillBonus = (1 * .75 * .85);
            int levelModifier = 0;

            if (helperClass.TEToLevel > helperClass.TEFromLevel)
            {
                if (helperClass.MEImplantTypeID > 0)
                {
                    Objects.IndustryImplant industryImplant = TEImplants.Find(x => x.ImplantTypeID == helperClass.TEImplantTypeID);

                    implantBonus -= (Convert.ToDouble(industryImplant.ImplantBonus) / 100);
                }
                levelModifier = GetMETELevelTime(helperClass.TEToLevel / 2);

                seconds = Convert.ToInt64(baseTime * (1 * skillBonus * implantBonus) * levelModifier);
                seconds = seconds / 105;
            }

            return seconds;
        }

        private static int GetMETELevelTime(int toLevelId)
        {
            int levelModifier = 0;
            switch (toLevelId)
            {
                case 1:
                    levelModifier = Enums.Enums.ResLevel1Modifier;
                    break;
                case 2:
                    levelModifier = Enums.Enums.ResLevel2Modifier;
                    break;
                case 3:
                    levelModifier = Enums.Enums.ResLevel3Modifier;
                    break;
                case 4:
                    levelModifier = Enums.Enums.ResLevel4Modifier;
                    break;
                case 5:
                    levelModifier = Enums.Enums.ResLevel5Modifier;
                    break;
                case 6:
                    levelModifier = Enums.Enums.ResLevel6Modifier;
                    break;
                case 7:
                    levelModifier = Enums.Enums.ResLevel7Modifier;
                    break;
                case 8:
                    levelModifier = Enums.Enums.ResLevel8Modifier;
                    break;
                case 9:
                    levelModifier = Enums.Enums.ResLevel9Modifier;
                    break;
                case 10:
                    levelModifier = Enums.Enums.ResLevel10Modifier;
                    break;
            }
            return levelModifier;
        }

        public static decimal GetMEJobCost(CalculationHelperClass calculationHelperClass, List<MaterialsWithMarketData> manuMats)
        {
            decimal cost = 0;
            decimal baseCost = CommonHelper.GetBaseCost(manuMats, false, calculationHelperClass.METoLevel - calculationHelperClass.MEFromLevel);
            decimal processTimeValue = GetProcessTimeValue(baseCost, calculationHelperClass.MEFromLevel, calculationHelperClass.METoLevel);
            decimal costIndex = CommonHelper.GetCostIndexForSystemID(calculationHelperClass.MESolarSystemID, Objects.CostIndiceActivity.ActivityME);
            decimal facilityTax = calculationHelperClass.MEFacilityTax / 100;
            decimal sccSurcharge = (decimal)Enums.Enums.SCCSurcharge;
            baseCost = processTimeValue;

            cost = Math.Ceiling(baseCost * costIndex);
            cost += Math.Ceiling(processTimeValue * facilityTax);
            cost += Math.Ceiling(processTimeValue * sccSurcharge);
            cost = Math.Ceiling(cost);

            return cost;
        }

        public static decimal GetTEJobCost(CalculationHelperClass calculationHelperClass, List<MaterialsWithMarketData> manuMats)
        {
            decimal cost = 0;
            decimal baseCost = CommonHelper.GetBaseCost(manuMats, false, calculationHelperClass.METoLevel - calculationHelperClass.MEFromLevel);
            decimal processTimeValue = GetProcessTimeValue(baseCost, calculationHelperClass.TEFromLevel / 2, calculationHelperClass.TEToLevel / 2);
            decimal costIndex = CommonHelper.GetCostIndexForSystemID(calculationHelperClass.TESolarSystemID, Objects.CostIndiceActivity.ActivityTE);
            decimal facilityTax = calculationHelperClass.TEFacilityTax / 100;
            decimal sccSurcharge = (decimal)Enums.Enums.SCCSurcharge;
            baseCost = processTimeValue;

            cost = Math.Ceiling(baseCost * costIndex);
            cost += Math.Ceiling(processTimeValue * facilityTax);
            cost += Math.Ceiling(processTimeValue * sccSurcharge);
            cost = Math.Ceiling(cost);

            return cost;
        }

        private static decimal GetProcessTimeValue(decimal baseCost, int fromLevel, int toLevel)
        {
            decimal processTimeValue = 0;

            if (toLevel > fromLevel)
            {
                int counter = fromLevel;
                decimal modifier = 0;
                while (counter < toLevel)
                {
                    counter += 1;
                    modifier = GetMETECostModifier(counter);
                    processTimeValue += (baseCost * (decimal).02 * modifier);
                }
            }

            return processTimeValue;
        }

        private static decimal GetMETECostModifier(int level)
        {
            decimal levelModifier = 0;
            switch (level)
            {
                case 1:
                    levelModifier = Enums.Enums.ResLevel1CostModifier;
                    break;
                case 2:
                    levelModifier = Enums.Enums.ResLevel2CostModifier;
                    break;
                case 3:
                    levelModifier = Enums.Enums.ResLevel3CostModifier;
                    break;
                case 4:
                    levelModifier = Enums.Enums.ResLevel4CostModifier;
                    break;
                case 5:
                    levelModifier = Enums.Enums.ResLevel5CostModifier;
                    break;
                case 6:
                    levelModifier = Enums.Enums.ResLevel6CostModifier;
                    break;
                case 7:
                    levelModifier = Enums.Enums.ResLevel7CostModifier;
                    break;
                case 8:
                    levelModifier = Enums.Enums.ResLevel8CostModifier;
                    break;
                case 9:
                    levelModifier = Enums.Enums.ResLevel9CostModifier;
                    break;
                case 10:
                    levelModifier = Enums.Enums.ResLevel10CostModifier;
                    break;
            }
            return levelModifier;
        }

        public static decimal GetMETETotalInputMats(ref List<MaterialsWithMarketData> inputMats, int fromLevel, int toLevel)
        {
            decimal multipler = (toLevel - fromLevel);
            decimal totalVolume = 0;
            foreach (MaterialsWithMarketData mat in  inputMats)
            {
                mat.quantityTotal = (mat.quantity * (toLevel - fromLevel));
                Objects.InventoryType matType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                totalVolume += mat.quantityTotal * matType.volume;
                mat.volumeTotal = mat.quantityTotal * matType.volume;
            }
            return totalVolume;
        }
        #endregion

        #region "Copying"

        public static decimal GetCopyingTotalMats(ref List<MaterialsWithMarketData> inputMats, CalculationHelperClass helperClass)
        {
            decimal multipler = (helperClass.NumCopies * helperClass.RunsPerCopy);
            decimal totalVolume = 0;
            foreach (MaterialsWithMarketData mat in inputMats)
            {
                mat.quantityTotal = (long)(mat.quantity * multipler);
                Objects.InventoryType matType = CommonHelper.InventoryTypes.Find(x => x.typeId == mat.materialTypeID);
                totalVolume += mat.quantityTotal * matType.volume;
                mat.volumeTotal = mat.quantityTotal * matType.volume;
            }
            return totalVolume;
        }

        public static Int64 GetCopyingTime(long baseTime, CalculationHelperClass helperClass)
        {
            Int64 seconds = 0;
            double implantBonus = 1;
            double skillBonus = (1 * .75 * .85);
            int levelModifier = 0;

            if (helperClass.CopyImplantTypeID > 0)
            {
                Objects.IndustryImplant industryImplant = CopyImplants.Find(x => x.ImplantTypeID == helperClass.CopyImplantTypeID);

                implantBonus -= (Convert.ToDouble(industryImplant.ImplantBonus) / 100);
            }

            seconds = Convert.ToInt64(baseTime * (1 * skillBonus * implantBonus) * helperClass.NumCopies * helperClass.RunsPerCopy);

            return seconds;
        }

        public static decimal GetCopyJobCost(CalculationHelperClass calculationHelperClass, List<MaterialsWithMarketData> manuMats)
        {
            decimal cost = 0;
            decimal baseCost = CommonHelper.GetBaseCost(manuMats, false, calculationHelperClass.RunsPerCopy);
            decimal jobCostBase = Math.Round(baseCost * (decimal).02 * calculationHelperClass.NumCopies * calculationHelperClass.RunsPerCopy);
            decimal costIndex = CommonHelper.GetCostIndexForSystemID(calculationHelperClass.CopyingSolarSystemID, Objects.CostIndiceActivity.ActivityCOPY);
            decimal facilityTax = calculationHelperClass.CopyingFacilityTax / 100;
            decimal sccSurcharge = (decimal)Enums.Enums.SCCSurcharge;

            cost = Math.Ceiling(jobCostBase * costIndex);
            cost += Math.Ceiling(jobCostBase * facilityTax);
            cost += Math.Ceiling(jobCostBase * sccSurcharge);            

            return cost;
        }
        #endregion
    }


}
