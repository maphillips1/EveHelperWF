﻿using EveHelperWF.Objects;
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
        public static List<InventoryType> InventoryTypes = new List<InventoryType>();

        public static void Init()
        {

            InventoryTypes = Database.SQLiteCalls.GetInventoryTypes();
        }

        public static void FillInventoryTypeInformation(ref InventoryTypeWIthMarketOrders invType)
        {
            int selectedType = invType.typeId;
            InventoryType baseType = InventoryTypes.Find(x => x.typeId == selectedType);
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

        public static InventoryTypeWIthMarketOrders GetMarketOrders(int selectedTypeID, int regionID, int systemID, bool highSec, bool lowSec, bool nullSec)
        {
            InventoryTypeWIthMarketOrders inventoryTypeWIthMarketOrders = new InventoryTypeWIthMarketOrders();

            inventoryTypeWIthMarketOrders.typeId = selectedTypeID;
            inventoryTypeWIthMarketOrders.BuyOrders = ESI_Calls.ESIMarketData.GetBuyOrderAsync(selectedTypeID, regionID).Result;
            inventoryTypeWIthMarketOrders.SellOrders = ESI_Calls.ESIMarketData.GetSellOrderAsync(selectedTypeID, regionID).Result;

            List<long> systemsToCheck = new List<long>();
            if (inventoryTypeWIthMarketOrders.BuyOrders != null && inventoryTypeWIthMarketOrders.BuyOrders.Count > 0)
            {
                if (systemID > 0)
                {
                    inventoryTypeWIthMarketOrders.BuyOrders = inventoryTypeWIthMarketOrders.BuyOrders.FindAll(x => x.system_id == systemID).ToList();
                }
                inventoryTypeWIthMarketOrders.BuyOrders = inventoryTypeWIthMarketOrders.BuyOrders.OrderByDescending(x => x.price).ToList();
                foreach (MarketOrder order in inventoryTypeWIthMarketOrders.BuyOrders)
                {
                    if (!systemsToCheck.Contains(order.system_id))
                    {
                        systemsToCheck.Add(order.system_id);
                    }
                }
            }

            if (inventoryTypeWIthMarketOrders.SellOrders != null && inventoryTypeWIthMarketOrders.SellOrders.Count > 0)
            {
                if (systemID > 0)
                {
                    inventoryTypeWIthMarketOrders.SellOrders = inventoryTypeWIthMarketOrders.SellOrders.FindAll(x => x.system_id == systemID).ToList();
                }
                inventoryTypeWIthMarketOrders.SellOrders = inventoryTypeWIthMarketOrders.SellOrders.OrderBy(x => x.price).ToList();
                foreach (MarketOrder order in inventoryTypeWIthMarketOrders.SellOrders)
                {
                    if (!systemsToCheck.Contains(order.system_id))
                    {
                        systemsToCheck.Add(order.system_id);
                    }
                }
            }

            if (!highSec || !lowSec || !nullSec)
            {
                SolarSystem solarSystem;
                foreach (long systemId in systemsToCheck)
                {
                    solarSystem = CommonHelper.SolarSystemList.Find(x => x.solarSystemID == systemId);
                    if (solarSystem != null)
                    {
                        if (!highSec && solarSystem.security > (decimal)0.4)
                        {
                            if (inventoryTypeWIthMarketOrders.BuyOrders != null)
                            {
                                inventoryTypeWIthMarketOrders.BuyOrders.RemoveAll(x => x.system_id == systemId);
                            }
                            if (inventoryTypeWIthMarketOrders.SellOrders != null)
                            {
                                inventoryTypeWIthMarketOrders.SellOrders.RemoveAll(x => x.system_id == systemId);
                            }
                        }
                        else if (!lowSec && solarSystem.security > (decimal)0.0 && solarSystem.security < (decimal)0.5)
                        {
                            if (inventoryTypeWIthMarketOrders.BuyOrders != null)
                            {
                                inventoryTypeWIthMarketOrders.BuyOrders.RemoveAll(x => x.system_id == systemId);
                            }
                            if (inventoryTypeWIthMarketOrders.SellOrders != null)
                            {
                                inventoryTypeWIthMarketOrders.SellOrders.RemoveAll(x => x.system_id == systemId);
                            }
                        }
                        else if (!nullSec && solarSystem.security < (decimal)0.1)
                        {
                            if (inventoryTypeWIthMarketOrders.BuyOrders != null)
                            {
                                inventoryTypeWIthMarketOrders.BuyOrders.RemoveAll(x => x.system_id == systemId);
                            }
                            if (inventoryTypeWIthMarketOrders.SellOrders != null)
                            {
                                inventoryTypeWIthMarketOrders.SellOrders.RemoveAll(x => x.system_id == systemId);
                            }
                        }
                    }
                }
            }


            return inventoryTypeWIthMarketOrders;
        }

        #region "Build Tree View"
        public static List<TreeNode> BuildTreeView()
        {
            List<TreeNode> treeViewGroups = new List<TreeNode>();

            List<Objects.InventoryType> invTypes = Database.SQLiteCalls.GetInventoryTypes();
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

        private static bool GroupHasItems(List<Objects.InventoryType> inventoryTypes, List<Objects.InventoryMarketGroups> marketGroups, int startingMarketGroupID)
        {
            bool hasItems = false;
            List<Objects.InventoryType> filteredTypes = inventoryTypes.FindAll(x => x.marketGroupId == startingMarketGroupID);

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
            string directory = Enums.Enums.CachedPriceHistory;
            string fileName = string.Format("PriceHistory_region_{0}_type_{1}.json", regionID, typeID);

            string fullFileName = Path.Combine(directory, fileName);

            string currentHistoryContent = FileIO.FileHelper.GetFileContent(directory, fullFileName);
            if (!string.IsNullOrEmpty(currentHistoryContent))
            {
                currentPriceHistories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ESIPriceHistory>>(currentHistoryContent);
            }
            return currentPriceHistories;
        }

        private static void SaveNewPriceHistory(int regionID, int typeID, List<ESIPriceHistory> priceHistories)
        {
            List<Objects.ESIPriceHistory> currentPriceHistories = null;
            string directory = Enums.Enums.CachedPriceHistory;
            string fileName = string.Format("PriceHistory_region_{0}_type_{1}.json", regionID, typeID);
            string fullFileName = Path.Combine(directory, fileName);
            
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(priceHistories);

            FileIO.FileHelper.SaveFileContent(directory, fullFileName, fileContent);
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

        public static List<TreeNode> SearchInventoryTypes(string searchText)
        {
            string[] splitString = searchText.Split(' ');

            List<Objects.InventoryType> invTypes = CommonHelper.InventoryTypes;
            foreach (string searchPart in splitString)
            {
                invTypes = invTypes.FindAll(x => x.typeName.ToLowerInvariant().Contains(searchPart.ToLowerInvariant()));
            }
            List<TreeNode> foundTypes = new List<TreeNode>();

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

        public static InventoryTypeWIthMarketOrders GetOrdersForAllRegions(int selectedTypeId, List<Objects.Region> regions, bool highSec, bool lowSec, bool nullSec)
        {
            InventoryTypeWIthMarketOrders allRegionType = new InventoryTypeWIthMarketOrders();
            allRegionType.typeId = selectedTypeId;
            allRegionType.BuyOrders = new List<MarketOrder>();
            allRegionType.SellOrders = new List<MarketOrder>();
            InventoryTypeWIthMarketOrders currentOrderType;
            foreach (Objects.Region region in regions)
            {
                currentOrderType = GetMarketOrders(selectedTypeId, region.regionID, 0, highSec, lowSec, nullSec);
                if (currentOrderType != null)
                {
                    if (currentOrderType.BuyOrders != null && currentOrderType.BuyOrders.Count > 0)
                    {
                        allRegionType.BuyOrders.AddRange(currentOrderType.BuyOrders);
                    }
                    if (currentOrderType.SellOrders != null && currentOrderType.SellOrders.Count > 0)
                    {
                        allRegionType.SellOrders.AddRange(currentOrderType.SellOrders);
                    }
                }
            }
            
            allRegionType.BuyOrders = allRegionType.BuyOrders.OrderByDescending(x => x.price).ToList();
            allRegionType.SellOrders = allRegionType.SellOrders.OrderBy(x => x.price).ToList();

            return allRegionType;
        }
    }
}
