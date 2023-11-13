using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ScreenHelper
{
    public static class MarketBrowserHelper
    {
        public static List<InventoryTypes> InventoryTypes = new List<InventoryTypes>();

        public static void Init()
        {

            InventoryTypes = Database.SQLiteCalls.GetInventoryTypes();
        }

        public static void FillInventoryTypeInformation(ref InventoryTypeWIthMarketOrders invType)
        {
            int selectedType = invType.typeId;
            InventoryTypes baseType = InventoryTypes.Find(x => x.typeId == selectedType);
            invType.typeName = baseType.typeName;
            foreach (MarketOrder order in invType.BuyOrders)
            {
                order.LocationName = Database.SQLiteCalls.GetStationNameForStationID(order.location_id);
            }
            foreach (MarketOrder order in invType.SellOrders)
            {
                order.LocationName = Database.SQLiteCalls.GetStationNameForStationID(order.location_id);
            }
        }

        public static InventoryTypeWIthMarketOrders GetMarketOrders(int selectedTypeID, int regionID, int systemID)
        {
            InventoryTypeWIthMarketOrders inventoryTypeWIthMarketOrders = new InventoryTypeWIthMarketOrders();

            inventoryTypeWIthMarketOrders.typeId = selectedTypeID;
            inventoryTypeWIthMarketOrders.BuyOrders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(selectedTypeID, regionID, true);
            inventoryTypeWIthMarketOrders.SellOrders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(selectedTypeID, regionID, false);

            if (inventoryTypeWIthMarketOrders.BuyOrders.Count > 0)
            {
                if (systemID > 0)
                {
                    inventoryTypeWIthMarketOrders.BuyOrders = inventoryTypeWIthMarketOrders.BuyOrders.FindAll(x => x.system_id == systemID).ToList();
                }
                inventoryTypeWIthMarketOrders.BuyOrders = inventoryTypeWIthMarketOrders.BuyOrders.OrderByDescending(x => x.price).ToList();
            }

            if (inventoryTypeWIthMarketOrders.SellOrders.Count > 0)
            {
                if (systemID > 0)
                {
                    inventoryTypeWIthMarketOrders.SellOrders = inventoryTypeWIthMarketOrders.SellOrders.FindAll(x => x.system_id == systemID).ToList();
                }
                inventoryTypeWIthMarketOrders.SellOrders = inventoryTypeWIthMarketOrders.SellOrders.OrderBy(x => x.price).ToList();
            }

            return inventoryTypeWIthMarketOrders;
        }

        #region "Build Tree View"
        public static List<TreeNode> BuildTreeView()
        {
            List<TreeNode> treeViewGroups = new List<TreeNode>();

            List<Objects.InventoryTypes> invTypes = Database.SQLiteCalls.GetInventoryTypes();
            List<Objects.InventoryMarketGroups> marketGroups = Database.SQLiteCalls.GetMarketGroups();

            treeViewGroups = GetTreeViewGroups(ref invTypes, marketGroups);

            return treeViewGroups;
        }

        public static List<TreeNode> GetTreeViewGroups(ref List<Objects.InventoryTypes> invTypes, List<Objects.InventoryMarketGroups> marketGroups)
        {
            List<TreeNode> groups = new List<TreeNode>();

            List<Int32> MarketGroups = new List<Int32>();
            //Change the market group ID first
            foreach (Objects.InventoryTypes inventoryType in invTypes)
            {
                inventoryType.marketGroupId = inventoryType.marketGroupId;
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

        private static List<TreeNode> BuildTreeForMarketGroup(List<Objects.InventoryTypes> inventoryTypes, List<Objects.InventoryMarketGroups> marketGroups, int startingMarketGroupID)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();

            List<Objects.InventoryTypes> filteredTypes = inventoryTypes.FindAll(x => x.marketGroupId > 0 && x.marketGroupId == startingMarketGroupID);
            List<Objects.InventoryMarketGroups> filteredMakretGroups = marketGroups.FindAll(x => x.parentGroupID == startingMarketGroupID);

            foreach (Objects.InventoryTypes inventoryType in filteredTypes)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = inventoryType.typeName;
                treeNode.Tag = string.Concat("typeID_", inventoryType.typeId);
                treeNodes.Add(treeNode);
            }

            foreach (Objects.InventoryMarketGroups marketGroup in filteredMakretGroups)
            {
                if (GroupHasItems(inventoryTypes, marketGroups, marketGroup.marketGroupID))
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

        private static bool GroupHasItems(List<Objects.InventoryTypes> inventoryTypes, List<Objects.InventoryMarketGroups> marketGroups, int startingMarketGroupID)
        {
            bool hasItems = false;
            List<Objects.InventoryTypes> filteredTypes = inventoryTypes.FindAll(x => x.marketGroupId == startingMarketGroupID);

            if (filteredTypes.Count > 0)
            {
                hasItems = true;
            }

            if (!hasItems)
            {

                List<Objects.InventoryMarketGroups> groups = marketGroups.FindAll(x => x.parentGroupID == startingMarketGroupID);
                foreach (Objects.InventoryMarketGroups group in groups)
                {
                    if (GroupHasItems(inventoryTypes, marketGroups, group.marketGroupID))
                    {
                        hasItems = true;
                        break;
                    }
                }
            }

            return hasItems;
        }
        #endregion

        private static List<ESIPriceHistory> GetCurrentPriceHistories(int regionID, int typeID)
        {
            List<Objects.ESIPriceHistory> currentPriceHistories = null;
            string directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                         "PriceHistory\\");
            string fileName = string.Format("PriceHistory_region_{0}_type_{1}.json", regionID, typeID);

            string fullFileName = Path.Combine(directory, fileName);

            string currentHistoryContent = FileIO.FileHelper.GetCachedFileContent(directory, fullFileName);
            if (!string.IsNullOrEmpty(currentHistoryContent))
            {
                currentPriceHistories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ESIPriceHistory>>(currentHistoryContent);
            }
            return currentPriceHistories;
        }

        private static void SaveNewPriceHistory(int regionID, int typeID, List<ESIPriceHistory> priceHistories)
        {
            List<Objects.ESIPriceHistory> currentPriceHistories = null;
            string directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                         "PriceHistory\\");
            string fileName = string.Format("PriceHistory_region_{0}_type_{1}.json", regionID, typeID);
            string fullFileName = Path.Combine(directory, fileName);
            
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(priceHistories);

            FileIO.FileHelper.SaveCachedFile(directory, fullFileName, fileContent);
        }

        private static List<ESIPriceHistory> GetCombinedPriceHistory(int regionID, int typeID)
        {
            List<ESIPriceHistory> currentHistory = GetCurrentPriceHistories(regionID, typeID);
            List<ESIPriceHistory> newPriceHistory = ESI_Calls.ESIMarketData.GetPriceHistoryForRegion(regionID, typeID);

            if (currentHistory != null)
            {
                ESIPriceHistory existingHistory = null;
                foreach (ESIPriceHistory history in newPriceHistory)
                {
                    existingHistory = currentHistory.Find(x => x.date == history.date);
                    if (existingHistory == null)
                    {
                        currentHistory.Add(history);
                    }
                    else
                    {
                        //Update existing values. 
                        //Assume that the data could be out of date. 
                        existingHistory.average = history.average;
                        existingHistory.volume = history.volume;
                        existingHistory.order_count = history.order_count;
                        existingHistory.lowest = history.lowest;
                        existingHistory.highest = history.highest;
                    }
                }
            }
            else
            {
                currentHistory = newPriceHistory;
            }

            return currentHistory;
        }

        public static List<ESIPriceHistory> GetPriceHistoryForRegionAndType(int regionID, int typeID)
        {
            List<ESIPriceHistory> priceHistory = new List<ESIPriceHistory>();

            priceHistory = GetCombinedPriceHistory(regionID, typeID);

            if (priceHistory != null)
            {
                SaveNewPriceHistory(regionID, typeID, priceHistory);
            }

            return priceHistory;
        }
    }
}
