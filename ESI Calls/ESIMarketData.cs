using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using EveHelperWF.Objects;
using System.Diagnostics;
using FileIO;
using EveHelperWF.Objects.ESI_Objects.Market_Objects;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIMarketData
    {
        private static Dictionary<Int64, DateTime> cachedRegions = new Dictionary<Int64, DateTime>();

        #region "Cache Methods"

        private static List<EveHelperWF.Objects.MarketOrder> GetCachedOrders(bool is_buy_order, int type_id, long region_id)
        {
            List<EveHelperWF.Objects.MarketOrder> marketOrders = null;
            string directory = "";
            if (is_buy_order)
            {
                directory = Enums.Enums.CachedBuyFolder;
            }
            else
            {
                directory = Enums.Enums.CachedSellFolder;
            }

            string fileName = string.Concat(directory, region_id.ToString(), "_", type_id.ToString(), ".json");

            string content = FileIO.FileHelper.GetFileContent(directory, fileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                EveHelperWF.Objects.CachedMarketOrders cachedMarketOrders = new EveHelperWF.Objects.CachedMarketOrders();
                cachedMarketOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<EveHelperWF.Objects.CachedMarketOrders>(content);
                if (cachedMarketOrders != null)
                {
                    if (cachedMarketOrders.cachedTime > System.DateTime.Now.AddMinutes(-15) &&
                            cachedMarketOrders.type_id == type_id &&
                            cachedMarketOrders.is_buy_order == is_buy_order)
                    {
                        marketOrders = cachedMarketOrders.orders;
                    }
                }
            }

            return marketOrders;
        }

        private static void CacheMarketOrders(bool is_buy_order, int type_id, long region_id, List<EveHelperWF.Objects.MarketOrder> marketOrders)
        {
            string directory = "";
            string fileName = "";

            if (is_buy_order)
            {
                directory = Enums.Enums.CachedBuyFolder;
            }
            else
            {
                directory = Enums.Enums.CachedSellFolder;
            }

            fileName = string.Concat(directory, region_id.ToString(), "_", type_id.ToString(), ".json");

            EveHelperWF.Objects.CachedMarketOrders cachedMarketOrders = new EveHelperWF.Objects.CachedMarketOrders();
            cachedMarketOrders.type_id = type_id;
            cachedMarketOrders.is_buy_order = is_buy_order;
            cachedMarketOrders.cachedTime = System.DateTime.Now;
            cachedMarketOrders.orders = marketOrders;

            string content = JsonConvert.SerializeObject(cachedMarketOrders);

            FileIO.FileHelper.SaveFileContent(directory, fileName, content);
        }

        private static List<EveHelperWF.Objects.AdjustedCost> GetCachedAdjustedCosts()
        {
            List<EveHelperWF.Objects.AdjustedCost> adjustedCosts = null;
            string directory = Enums.Enums.CachedAdjustedCosts;

            string fileName = string.Concat(directory, "adjusted_costs.json");

            string content = FileIO.FileHelper.GetFileContent(directory, fileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                EveHelperWF.Objects.CachedAdjustedCost cachedAdjustedCosts = new EveHelperWF.Objects.CachedAdjustedCost();
                cachedAdjustedCosts = Newtonsoft.Json.JsonConvert.DeserializeObject<EveHelperWF.Objects.CachedAdjustedCost>(content);
                if (cachedAdjustedCosts != null)
                {
                    if (cachedAdjustedCosts.cachedTime > System.DateTime.Now.AddMinutes(-60))
                    {
                        adjustedCosts = cachedAdjustedCosts.costs;
                    }
                }
            }

            return adjustedCosts;
        }

        private static void CacheAdjustedCosts(List<EveHelperWF.Objects.AdjustedCost> adjustedCosts)
        {
            string directory = Enums.Enums.CachedAdjustedCosts;
            string fileName = Path.Combine(directory, "adjusted_costs.json");

            EveHelperWF.Objects.CachedAdjustedCost cachedAdjustedCosts = new EveHelperWF.Objects.CachedAdjustedCost();
            cachedAdjustedCosts.cachedTime = System.DateTime.Now;
            cachedAdjustedCosts.costs = adjustedCosts;

            string content = JsonConvert.SerializeObject(cachedAdjustedCosts);

            FileIO.FileHelper.SaveFileContent(directory, fileName, content);
        }
        #endregion

        public static List<EveHelperWF.Objects.AdjustedCost> GetAdjustedCosts()
        {
            List<EveHelperWF.Objects.AdjustedCost> adjustedCosts = GetCachedAdjustedCosts();

            if (adjustedCosts == null || adjustedCosts.Count == 0)
            {
                try
                {
                    string combinedURI = "https://esi.evetech.net/latest/markets/prices/?datasource=tranquility";
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage response = client.GetAsync(combinedURI).Result;

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string costs = response.Content.ReadAsStringAsync().Result;
                        adjustedCosts = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.AdjustedCost>>(costs);
                        CacheAdjustedCosts(adjustedCosts);
                    }
                }
                catch (Exception ex)
                {
                    FileHelper.LogError(ex.Message, ex.StackTrace);
                }
            }

            return adjustedCosts;
        }

        private static List<ESIPriceHistory> GetCachedPriceHistory(int regionID, int typeID)
        {
            List<ESIPriceHistory> priceHistory = null;
            string directory = Enums.Enums.CachedPriceHistory;
            string fileName = string.Concat(directory, regionID.ToString(), "_", typeID.ToString(), ".json");

            string content = FileIO.FileHelper.GetFileContent(directory, fileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                EveHelperWF.Objects.CachedPriceHistory cachedPriceHistory = new EveHelperWF.Objects.CachedPriceHistory();
                cachedPriceHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<EveHelperWF.Objects.CachedPriceHistory>(content);
                if (cachedPriceHistory != null)
                {
                    if (cachedPriceHistory.cachedTime > System.DateTime.Now.AddMinutes(-15))
                    {
                        priceHistory = cachedPriceHistory.priceHistory;
                    }
                }
            }

            return priceHistory;
        }

        private static void CachePriceHistory(int regionID, int typeID, List<ESIPriceHistory> priceHistory)
        {
            string directory = Enums.Enums.CachedPriceHistory;
            string fileName = string.Concat(directory, regionID.ToString(), "_", typeID.ToString(), ".json");

            EveHelperWF.Objects.CachedPriceHistory cachedPriceHistory = new EveHelperWF.Objects.CachedPriceHistory();
            cachedPriceHistory.priceHistory = priceHistory;
            cachedPriceHistory.cachedTime = System.DateTime.Now;

            string content = JsonConvert.SerializeObject(cachedPriceHistory);

            FileIO.FileHelper.SaveFileContent(directory, fileName, content);
        }

        public static List<Objects.ESIPriceHistory> GetPriceHistoryForRegion(int regionID, int typeID)
        {
            List<ESIPriceHistory> priceHistory = new List<ESIPriceHistory>();

            priceHistory = GetCachedPriceHistory(regionID, typeID);

            if (priceHistory == null || priceHistory.Count <= 0)
            {
                try
                {
                    string url = string.Format("https://esi.evetech.net/latest/markets/{0}/history/?datasource=tranquility&type_id={1}", regionID, typeID);
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage response = client.GetAsync(url).Result;

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string priceHistoryContent = response.Content.ReadAsStringAsync().Result;
                        priceHistory = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.ESIPriceHistory>>(priceHistoryContent);
                        if (priceHistory != null)
                        {
                            CachePriceHistory(regionID, typeID, priceHistory);
                        }
                    }
                }
                catch (Exception ex)
                {
                    FileHelper.LogError(ex.Message, ex.StackTrace);
                }
            }


            return priceHistory;
        }

        #region "Async Methods"
        public async static Task<List<ESIMarketType>> GetPriceForItemListWithQuantityAsync(List<ESIMarketType> materials, int orderType, long regionID)
        {
            List<ESIMarketType> returnList = new List<ESIMarketType>();
            List<Task<ESIMarketType>> orderTasks = new List<Task<ESIMarketType>>();
            foreach (ESIMarketType material in materials)
            {
                ESIMarketType copyMat = material;
                orderTasks.Add(GetPriceForITemAndQuantityAsync(copyMat, orderType, regionID));
            }

            Debug.WriteLine("Waiting for all tasks to finish");
            ESIMarketType[] results = await Task.WhenAll(orderTasks).ConfigureAwait(false);
            Debug.WriteLine("All tasks are finished");
            foreach (ESIMarketType material in results)
            {
                returnList.Add(material);
            }
            Debug.WriteLine("Returning all materials");
            return materials;
        }

        public static async Task<ESIMarketType> GetPriceForITemAndQuantityAsync(ESIMarketType material, int orderType, long regionID)
        {
            if (orderType == (int)Enums.Enums.OrderType.Buy)
            {
                Debug.WriteLine("Waiting for " + material.typeID.ToString());
                material = await GetBuyOrderPriceForQuantityAsync(material, regionID).ConfigureAwait(false);
                Debug.WriteLine("Got price for " + material.typeID.ToString());
            }
            else
            {
                Debug.WriteLine("Waiting for " + material.typeID.ToString());
                material = await GetSellOrderPriceForQuantityAsync(material, regionID).ConfigureAwait(false);
                Debug.WriteLine("Got price for " + material.typeID.ToString());
            }
            Debug.WriteLine("Calling Return material for " + material.typeID.ToString());
            return material;
        }

        public async static Task<decimal> GetBuyOrderPriceAsync(int type_id, long region_id)
        {
            decimal price = 0;


            List<Objects.MarketOrder> orders = await ESI_Calls.ESIMarketData.GetBuyOrderAsync(type_id, Enums.Enums.TheForgeRegionId).ConfigureAwait(false);

            if (orders != null && orders.Count > 0)
            {
                //order by price High to Low
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderByDescending(x => x.price).ToList();

                if (filteredOrders.Count > 0)
                {
                    price = filteredOrders[0].price;
                }
            }

            return price;
        }

        public async static Task<List<EveHelperWF.Objects.MarketOrder>> GetBuyOrderAsync(int type_id, long region_id)
        {
            List<EveHelperWF.Objects.MarketOrder> marketOrders = new List<EveHelperWF.Objects.MarketOrder>();

            marketOrders = GetCachedOrders(true, type_id, region_id);

            if (marketOrders == null || marketOrders.Count == 0)
            {
                try
                {
                    string combinedURI = String.Format("https://esi.evetech.net/latest/markets/{0}/orders/?datasource=tranquility&order_type=buy&page=1&type_id={1}", region_id, type_id);
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage response = null;
                    //retry 10 times
                    for (int i = 0; i < 10; i++)
                    {
                        response = await client.GetAsync(combinedURI).ConfigureAwait(false);
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            break;
                        }
                    }

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string orders = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        marketOrders = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.MarketOrder>>(orders);
                        CacheMarketOrders(true, type_id, region_id, marketOrders);
                    }
                }
                catch (Exception ex)
                {
                    FileHelper.LogError(ex.Message, ex.StackTrace);
                }
            }

            return marketOrders;
        }

        public async static Task<decimal> GetSellOrderPriceAsync(int type_id, long region_id)
        {
            decimal price = 0;


            List<Objects.MarketOrder> orders = await ESI_Calls.ESIMarketData.GetSellOrderAsync(type_id, Enums.Enums.TheForgeRegionId).ConfigureAwait(false);

            if (orders != null && orders.Count > 0)
            {
                Debug.WriteLine("Order count for" + type_id.ToString() + " is " + orders.Count);
                //order by price low to High
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderBy(x => x.price).ToList();

                if (filteredOrders.Count > 0)
                {
                    price = filteredOrders[0].price;
                }
            }
            Debug.WriteLine("Leaving Get Sell Order Price Async for " + type_id.ToString());

            return price;
        }

        public async static Task<List<EveHelperWF.Objects.MarketOrder>> GetSellOrderAsync(int type_id, long region_id)
        {
            List<EveHelperWF.Objects.MarketOrder> marketOrders = new List<EveHelperWF.Objects.MarketOrder>();

            marketOrders = GetCachedOrders(false, type_id, region_id);

            if (marketOrders == null || marketOrders.Count == 0)
            {
                try
                {
                    string combinedURI = String.Format("https://esi.evetech.net/latest/markets/{0}/orders/?datasource=tranquility&order_type=sell&page=1&type_id={1}", region_id, type_id);
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    Debug.WriteLine("Calling ESI For " + type_id + " with " + combinedURI);
                    System.Net.Http.HttpResponseMessage response = null;
                    //retry 10 times
                    for (int i = 0; i < 10; i++)
                    {
                        response = await client.GetAsync(combinedURI).ConfigureAwait(false);
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            break;
                        }
                    }
                    Debug.WriteLine("ESI finished For " + type_id);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string orders = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        marketOrders = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.MarketOrder>>(orders);
                        CacheMarketOrders(false, type_id, region_id, marketOrders);
                    }
                    else if (response != null)
                    {
                        Debug.WriteLine("Response for " + type_id.ToString() + " Failed with " + response?.StatusCode.ToString());
                    }
                }
                catch (Exception ex)
                {
                    FileHelper.LogError(ex.Message, ex.StackTrace);
                }
            }

            return marketOrders;
        }


        public async static Task<ESIMarketType> GetSellOrderPriceForQuantityAsync(ESIMarketType marketType, long region_id)
        {
            List<Objects.MarketOrder> orders = await ESI_Calls.ESIMarketData.GetSellOrderAsync(marketType.typeID, Enums.Enums.TheForgeRegionId).ConfigureAwait(false);
            Debug.WriteLine("Sell order list count for " + marketType.typeID.ToString() + " is " + orders?.Count().ToString());
            if (orders != null && orders.Count > 0)
            {
                //order by price low to High
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderBy(x => x.price).ToList();

                long remainingQuantity = marketType.quantity;
                int orderCount = 0;

                if (filteredOrders.Count > 0)
                {
                    marketType.pricePer = filteredOrders[0].price;
                    while (orderCount < filteredOrders.Count && remainingQuantity > 0)
                    {
                        if (filteredOrders[orderCount].volume_remain > remainingQuantity)
                        {
                            marketType.priceTotal += filteredOrders[orderCount].price * remainingQuantity;
                            remainingQuantity = 0;
                        }
                        else
                        {
                            marketType.priceTotal += filteredOrders[orderCount].price * filteredOrders[orderCount].volume_remain;
                            remainingQuantity -= filteredOrders[orderCount].volume_remain;
                        }
                        orderCount++;
                    }
                    if (remainingQuantity > 0)
                    {
                        marketType.priceTotal += (filteredOrders[filteredOrders.Count - 1].price * remainingQuantity);
                        remainingQuantity = 0;
                    }
                }
            }

            return marketType;
        }

        public async static Task<ESIMarketType> GetBuyOrderPriceForQuantityAsync(ESIMarketType marketType, long region_id)
        {
            List<Objects.MarketOrder> orders = await ESI_Calls.ESIMarketData.GetBuyOrderAsync(marketType.typeID, Enums.Enums.TheForgeRegionId).ConfigureAwait(false);

            if (orders != null && orders.Count > 0)
            {
                //order by price High to Low
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderByDescending(x => x.price).ToList();

                long remainingQuantity = marketType.quantity;
                int orderCount = 0;

                if (filteredOrders.Count > 0)
                {
                    marketType.pricePer = filteredOrders[0].price;
                    while (orderCount < filteredOrders.Count && remainingQuantity > 0)
                    {
                        if (filteredOrders[orderCount].volume_remain > remainingQuantity)
                        {
                            marketType.priceTotal += filteredOrders[orderCount].price * remainingQuantity;
                            remainingQuantity = 0;
                        }
                        else
                        {
                            marketType.priceTotal += filteredOrders[orderCount].price * filteredOrders[orderCount].volume_remain;
                            remainingQuantity -= filteredOrders[orderCount].volume_remain;
                        }
                        orderCount++;
                    }
                    if (remainingQuantity > 0)
                    {
                        marketType.priceTotal += (filteredOrders[filteredOrders.Count - 1].price * remainingQuantity);
                        remainingQuantity = 0;
                    }
                }
            }

            return marketType;
        }
        #endregion
    }
}
