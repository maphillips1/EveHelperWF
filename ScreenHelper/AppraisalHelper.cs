using EveHelperWF.Database;
using EveHelperWF.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ScreenHelper
{
    public static class AppraisalHelper
    {
        public static List<AppraisedItem> ParseTypeIds(string[] inputTypes)
        {
            List<AppraisedItem> appraisedItems = new List<AppraisedItem>();

            AppraisedItem item = null;
            foreach (string inputType in inputTypes)
            {
                if (!string.IsNullOrWhiteSpace(inputType))
                {
                    item = ParseStringToAppraisedItem(inputType);
                    if (item != null)
                    {
                        AppraisedItem existingItem = appraisedItems.Find(x => x.typeID == item.typeID);
                        if (existingItem != null)
                        {
                            existingItem.quantity += item.quantity;
                        }
                        else
                        {
                            appraisedItems.Add(item);
                        }
                    }
                    else
                    {
                        appraisedItems.Add(new AppraisedItem { typeName = "Could not parse " + inputType });
                    }
                }
            }

            return appraisedItems;
        }

        private static AppraisedItem ParseStringToAppraisedItem(string rawInput)
        {
            AppraisedItem appraisedItem = null;

            string typeName = rawInput;
            if (typeName.Contains("\t"))
            {
                //if it contains the tab character, this is likely copy/pasted from an Eve window. 
                //try to parse it by splitting on the t and then finding a match that way
                string[] splitString = typeName.Split("\t");

                Tuple<int, string> foundType = FindTypeInDB(splitString[0]);
                appraisedItem = new AppraisedItem();
                if (foundType != null && foundType.Item1 > 0 && !string.IsNullOrWhiteSpace(foundType.Item2))
                {
                    appraisedItem.typeID = foundType.Item1;
                    appraisedItem.typeName = foundType.Item2;
                    if (splitString.Length > 1)
                    {
                        int itemCount = 0;
                        if (int.TryParse(splitString[1], out itemCount))
                        {
                            appraisedItem.quantity = itemCount;
                        }
                    }
                }
                else
                {
                    appraisedItem.typeName = "Could not parse : " + rawInput.Trim();
                }
            }
            else
            {
                //manually typed in or other
                typeName = typeName.Trim();
                typeName = typeName.ToLower().Replace(" x ", "").Replace("'", "''");
                Tuple<int, string> foundType = FindTypeInDB(typeName);
                if (foundType != null && foundType.Item1 > 0 && !string.IsNullOrWhiteSpace(foundType.Item2))
                {
                    appraisedItem = new AppraisedItem();
                    appraisedItem.typeID = foundType.Item1;
                    appraisedItem.typeName = foundType.Item2;

                    string remainingString = rawInput.Replace(appraisedItem.typeName, string.Empty);
                    remainingString = RemoveExtraSpaces(remainingString).Trim().Replace(",", "");
                    decimal quant = 0;
                    if (string.IsNullOrWhiteSpace(remainingString))
                    {
                        appraisedItem.quantity = 1;
                    }
                    else
                    {
                        List<string> stringParts = remainingString.Split(" ").ToList();
                        if (stringParts.Count > 1)
                        {

                            if (Decimal.TryParse(stringParts[0], out quant))
                            {
                                if (stringParts[1].ToLower().Contains("m3"))
                                {
                                    quant = 1;
                                }
                                else
                                {
                                    appraisedItem.quantity = (int)quant;
                                }
                            }
                            else if (Decimal.TryParse(stringParts[1], out quant))
                            {
                                if (stringParts.Count > 2)
                                {
                                    if (stringParts[2].ToLower().Contains("m3"))
                                    {
                                        quant = 1;
                                    }
                                    else
                                    {
                                        appraisedItem.quantity = (int)quant;
                                    }
                                }
                                else
                                {
                                    appraisedItem.quantity = (int)quant;
                                }
                            }
                            if (appraisedItem.quantity <= 0) { appraisedItem.quantity = 1; }
                        }
                        else if (Decimal.TryParse(remainingString, out quant))
                        {
                            appraisedItem.quantity = (int)quant;
                        }
                    }
                }
                else
                {
                    appraisedItem = new AppraisedItem();
                    appraisedItem.typeName = "Could not parse : " + rawInput.Trim();
                }
            }
            return appraisedItem;
        }

        public static Decimal GetItemBuyPrice(int typeId)
        {
            decimal price = 0;

            List<MarketOrder> orders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(typeId, Enums.Enums.TheForgeRegionId, true);

            if (orders != null && orders.Count > 0)
            {
                orders = orders.OrderByDescending(x => x.price).ToList();
                price = orders[0].price;
            }

            return price;
        }

        public static Decimal GetItemSellPrice(int typeId)
        {

            decimal price = 0;

            List<MarketOrder> orders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(typeId, Enums.Enums.TheForgeRegionId, false);

            if (orders != null && orders.Count > 0)
            {
                orders = orders.OrderBy(x => x.price).ToList();
                price = orders[0].price;
            }

            return price;
        }

        private static Tuple<int, string> FindTypeInDB(string input)
        {
            Tuple<int, string> result = null;


            List<string> parts = input.Replace("'", "''").Split(" ").ToList();
            int tries = parts.Count;

            string searchString = input.Replace("'", "''");
            bool found = false;
            InventoryType foundType;
            while (tries > 0 && !found)
            {
                searchString = String.Join(" ", parts);
                foundType = SQLiteCalls.InventoryTypeSearch("'" + searchString + "'");
                if (foundType != null)
                {
                    found = true;
                    result = new Tuple<int, string>(foundType.typeId, foundType.typeName);
                    break;
                }
                else
                {
                    parts.RemoveAt(tries - 1);
                }
                tries -= 1;
            }

            return result;
        }

        private static string RemoveExtraSpaces(string input)
        {
            string replacedString = input;
            while (replacedString.Contains("  "))
            {
                replacedString = replacedString.Replace("  ", "");
            }
            return replacedString;
        }
    }
}
