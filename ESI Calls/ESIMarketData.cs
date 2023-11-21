using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using EveHelperWF.Objects;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIMarketData
    {
        public const string cachedBuyFolder = @"C:\Temp\EveHelper\Market\buy\";
        public const string cachedSellFolder = @"C:\Temp\EveHelper\Market\sell\";
        public const string cachedAdjustedCosts = @"C:\Temp\EveHelper\Market\";
        public const string cachedPriceHistory = @"C:\Temp\EveHelper\Market\PriceHistory";

        #region "Cache Methods"

        private static List<EveHelperWF.Objects.MarketOrder> GetCachedOrders(bool is_buy_order, int type_id, int region_id)
        {
            List<EveHelperWF.Objects.MarketOrder> marketOrders = null;
            string directory = "";
            if (is_buy_order)
            {
                directory = cachedBuyFolder;
            }
            else
            {
                directory = cachedSellFolder;
            }

            string fileName = string.Concat(directory, region_id.ToString(), "_", type_id.ToString(), ".json");

            string content = FileIO.FileHelper.GetCachedFileContent(directory, fileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                EveHelperWF.Objects.CachedMarketOrders cachedMarketOrders = new EveHelperWF.Objects.CachedMarketOrders();
                cachedMarketOrders = Newtonsoft.Json.JsonConvert.DeserializeObject<EveHelperWF.Objects.CachedMarketOrders>(content);
                if (cachedMarketOrders != null)
                {
                    if (cachedMarketOrders.cachedTime > System.DateTime.Now.AddMinutes(-5) &&
                            cachedMarketOrders.type_id == type_id &&
                            cachedMarketOrders.is_buy_order == is_buy_order)
                    {
                        marketOrders = cachedMarketOrders.orders;
                    }
                }
            }

            return marketOrders;
        }

        private static void CacheMarketOrders(bool is_buy_order, int type_id, int region_id, List<EveHelperWF.Objects.MarketOrder> marketOrders)
        {
            string directory = "";
            string fileName = "";

            if (is_buy_order)
            {
                directory = cachedBuyFolder;
            }
            else
            {
                directory = cachedSellFolder;
            }

            fileName = string.Concat(directory, region_id.ToString(), "_", type_id.ToString(), ".json");

            EveHelperWF.Objects.CachedMarketOrders cachedMarketOrders = new EveHelperWF.Objects.CachedMarketOrders();
            cachedMarketOrders.type_id = type_id;
            cachedMarketOrders.is_buy_order = is_buy_order;
            cachedMarketOrders.cachedTime = System.DateTime.Now;
            cachedMarketOrders.orders = marketOrders;

            string content = JsonConvert.SerializeObject(cachedMarketOrders);

            FileIO.FileHelper.SaveCachedFile(directory, fileName, content);
        }

        private static List<EveHelperWF.Objects.AdjustedCost> GetCachedAdjustedCosts()
        {
            List<EveHelperWF.Objects.AdjustedCost> adjustedCosts = null;
            string directory = cachedAdjustedCosts;

            string fileName = string.Concat(directory, "adjusted_costs.json");

            string content = FileIO.FileHelper.GetCachedFileContent(directory, fileName);
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
            string directory = ESIMarketData.cachedAdjustedCosts;
            string fileName = "adjusted_costs.json";

            EveHelperWF.Objects.CachedAdjustedCost cachedAdjustedCosts = new EveHelperWF.Objects.CachedAdjustedCost();
            cachedAdjustedCosts.cachedTime = System.DateTime.Now;
            cachedAdjustedCosts.costs = adjustedCosts;

            string content = JsonConvert.SerializeObject(cachedAdjustedCosts);

            FileIO.FileHelper.SaveCachedFile(directory, fileName, content);
        }
        #endregion

        public static List<EveHelperWF.Objects.MarketOrder> GetBuyOrSellOrder(int type_id, int region_id, bool isBuyOrder)
        {
            if (isBuyOrder)
            {
                return GetBuyOrder(type_id, region_id);
            }
            else
            {
                return GetSellOrder(type_id, region_id);
            }
        }

        public static List<EveHelperWF.Objects.MarketOrder> GetBuyOrder(int type_id, int region_id)
        {
            List<EveHelperWF.Objects.MarketOrder> marketOrders = new List<EveHelperWF.Objects.MarketOrder>();

            marketOrders = GetCachedOrders(true, type_id, region_id);

            if (marketOrders == null || marketOrders.Count == 0)
            {
                string combinedURI = String.Format("https://esi.evetech.net/latest/markets/{0}/orders/?datasource=tranquility&order_type=buy&page=1&type_id={1}", region_id, type_id);
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync(combinedURI).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                    string orders = response.Content.ReadAsStringAsync().Result;
                    marketOrders = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.MarketOrder>>(orders);
                    CacheMarketOrders(true, type_id, region_id, marketOrders);
                }
            }

            return marketOrders;
        }

        public static List<EveHelperWF.Objects.MarketOrder> GetSellOrder(int type_id, int region_id)
        {
            List<EveHelperWF.Objects.MarketOrder> marketOrders = new List<EveHelperWF.Objects.MarketOrder>();

            marketOrders = GetCachedOrders(false, type_id, region_id);

            if (marketOrders == null || marketOrders.Count == 0)
            {
                string combinedURI = String.Format("https://esi.evetech.net/latest/markets/{0}/orders/?datasource=tranquility&order_type=sell&page=1&type_id={1}", region_id, type_id);
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync(combinedURI).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                    string orders = response.Content.ReadAsStringAsync().Result;
                    marketOrders = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.MarketOrder>>(orders);
                    CacheMarketOrders(false, type_id, region_id, marketOrders);
                }
            }

            return marketOrders;
        }

        public static decimal GetSellOrderPriceForQuantity(int type_id, int region_id, long quantity)
        {
            decimal price = 0;

            List<Objects.MarketOrder> orders = ESI_Calls.ESIMarketData.GetSellOrder(type_id, Enums.Enums.TheForgeRegionId);
            if (orders.Count > 0)
            {
                //order by price low to High
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderBy(x => x.price).ToList();

                long remainingQuantity = quantity;
                int orderCount = 0;

                if (filteredOrders.Count > 0)
                {
                    while (orderCount < filteredOrders.Count && remainingQuantity > 0)
                    {
                        if (filteredOrders[orderCount].volume_remain > remainingQuantity)
                        {
                            price += filteredOrders[orderCount].price * remainingQuantity;
                            remainingQuantity = 0;
                        }
                        else
                        {
                            price += filteredOrders[orderCount].price * filteredOrders[orderCount].volume_remain;
                            remainingQuantity -= filteredOrders[orderCount].volume_remain;
                        }
                        orderCount++;
                    }
                    if (remainingQuantity > 0)
                    {
                        price += (filteredOrders[filteredOrders.Count - 1].price * remainingQuantity);
                        remainingQuantity = 0;
                    }
                }
            }

            return price;
        }

        public static decimal GetBuyOrderPriceForQuantity(int type_id, int region_id, long quantity)
        {
            decimal price = 0;


            List<Objects.MarketOrder> orders = ESI_Calls.ESIMarketData.GetBuyOrder(type_id, Enums.Enums.TheForgeRegionId);

            if (orders.Count > 0)
            {
                //order by price High to Low
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderByDescending(x => x.price).ToList();

                if (filteredOrders.Count > 0)
                {
                    price = filteredOrders[0].price * quantity;
                }
            }

            return price;
        }

        public static List<EveHelperWF.Objects.AdjustedCost> GetAdjustedCosts()
        {
            List<EveHelperWF.Objects.AdjustedCost> adjustedCosts = GetCachedAdjustedCosts();

            if (adjustedCosts == null || adjustedCosts.Count == 0)
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

            return adjustedCosts;
        }

        public static decimal GetBuyOrderPrice(int type_id, int region_id)
        {
            decimal price = 0;


            List<Objects.MarketOrder> orders = ESI_Calls.ESIMarketData.GetBuyOrder(type_id, Enums.Enums.TheForgeRegionId);

            if (orders.Count > 0)
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

        public static decimal GetSellOrderPrice(int type_id, int region_id)
        {
            decimal price = 0;

            List<Objects.MarketOrder> orders = ESI_Calls.ESIMarketData.GetSellOrder(type_id, Enums.Enums.TheForgeRegionId);
            if (orders.Count > 0)
            {
                //order by price low to High
                List<Objects.MarketOrder> filteredOrders = orders.FindAll(x => x.system_id == Enums.Enums.JitaSystemId).OrderBy(x => x.price).ToList();

                if (filteredOrders.Count > 0)
                {
                    price = filteredOrders[0].price;
                }
            }

            return price;
        }

        private static List<ESIPriceHistory> GetCachedPriceHistory(int regionID, int typeID)
        {
            List<ESIPriceHistory> priceHistory = null;
            string directory = cachedPriceHistory;
            string fileName = string.Concat(directory, regionID.ToString(), "_", typeID.ToString(), ".json");

            string content = FileIO.FileHelper.GetCachedFileContent(directory, fileName);
            if (!string.IsNullOrWhiteSpace(content))
            {
                EveHelperWF.Objects.CachedPriceHistory cachedPriceHistory = new EveHelperWF.Objects.CachedPriceHistory();
                cachedPriceHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<EveHelperWF.Objects.CachedPriceHistory>(content);
                if (cachedPriceHistory != null)
                {
                    if (cachedPriceHistory.cachedTime > System.DateTime.Now.AddMinutes(-5))
                    {
                        priceHistory = cachedPriceHistory.priceHistory;
                    }
                }
            }

            return priceHistory;
        }

        private static void CachePriceHistory(int regionID, int typeID, List<ESIPriceHistory> priceHistory)
        {
            string directory = ESIMarketData.cachedPriceHistory;
            string fileName = string.Concat(directory, regionID.ToString(), "_", typeID.ToString(), ".json");

            EveHelperWF.Objects.CachedPriceHistory cachedPriceHistory = new EveHelperWF.Objects.CachedPriceHistory();
            cachedPriceHistory.priceHistory = priceHistory;
            cachedPriceHistory.cachedTime = System.DateTime.Now;

            string content = JsonConvert.SerializeObject(cachedPriceHistory);

            FileIO.FileHelper.SaveCachedFile(directory, fileName, content);
        }

        public static List<Objects.ESIPriceHistory> GetPriceHistoryForRegion(int regionID, int typeID)
        {
            List<ESIPriceHistory> priceHistory = new List<ESIPriceHistory>();

            priceHistory = GetCachedPriceHistory(regionID, typeID);

            if (priceHistory == null || priceHistory.Count <= 0)
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


            return priceHistory;
        }
    }
}
