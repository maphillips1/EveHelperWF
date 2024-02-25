using EveHelperWF.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ScreenHelper
{
    public static class PlanetSchematicsHelper
    {
        public static Dictionary<int, string> PlanetsForTypeID = new Dictionary<int, string>();

        public static void Init()
        {
            PlanetsForTypeID.Clear();
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.BaseMetals, "Lava,Plasma,Barren,Storm,Gas");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.NobleMetals, "Barren,Plasma");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.HeavyMetals, "Lava,Plasma,Ice");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.NonCSCrystals, "Lava,Plasma");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.FelsicMagma, "Lava");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.AqueousLiquids, "Barren,Temperate,Storm,Oceanic,Ice,Gas");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.SuspendedPlasma, "Plasma,Lava,Storm");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.IonicSolutions, "Storm,Gas");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.NobleGas, "Ice,Storm,Gas");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.ReactiveGas, "Gas");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.Microorganisms, "Ice,Barren,Temperate,Oceanic");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.PlankticColonies, "Ice,Oceanic");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.ComplexOrganisms, "Temperate,Oceanic");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.CarbonCompounds, "Barren,Temperate,Oceanic");
            PlanetsForTypeID.Add((int)Enums.Enums.T0_PlanetTypeIDs.Autotrophs, "Temperate");
        }

        public static List<Objects.PlanetMaterial> GetAllOutputs()
        {
            List<Objects.PlanetMaterial> planetOutputTypes = new List<Objects.PlanetMaterial>();

            planetOutputTypes = Database.SQLiteCalls.GetPlanetOutputs();

            return planetOutputTypes;
        }

        public static void GetInputsForSchematicRecurseive(PlanetMaterial material)
        {
            if (!material.groupName.ToLower().Contains("raw"))
            {
                int schematicID = Database.SQLiteCalls.GetSchematicIDByTypeID(material.typeID);
                
                PlanetMaterial output = Database.SQLiteCalls.GetPlanetOutputBySchematicId(schematicID);
                int runsNeeded = (int)Math.Ceiling((decimal)material.quantity / (decimal)output.quantity);

                material.Inputs = Database.SQLiteCalls.GetPlanetSchematicInput(schematicID);

                foreach (PlanetMaterial input in material.Inputs)
                {
                    input.quantity *= runsNeeded;
                    GetInputsForSchematicRecurseive(input);
                }
            }
        }

        public static void GetPrices(PlanetMaterial planetOutputType)
        {

            List<Objects.MarketOrder> buyOrders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(planetOutputType.typeID, Enums.Enums.TheForgeRegionId, true);
            List<Objects.MarketOrder> sellOrders = ESI_Calls.ESIMarketData.GetBuyOrSellOrder(planetOutputType.typeID, Enums.Enums.TheForgeRegionId, false);

            if (buyOrders != null && buyOrders.Count > 0)
            {
                List<Objects.MarketOrder> filteredBuyOrders = buyOrders.FindAll(x => x.system_id == 30000142).OrderByDescending(x => x.price).ToList();
                planetOutputType.buyPricePer = filteredBuyOrders[0].price;
            }
            if (sellOrders != null && sellOrders.Count > 0)
            {
                List<Objects.MarketOrder> filteredSellOrders = sellOrders.FindAll(x => x.system_id == 30000142).OrderBy(x => x.price).ToList();
                planetOutputType.sellPricePer = filteredSellOrders[0].price;
            }

        }

        public static List<string> GetPerfectPlanetsForType(PlanetMaterial planetMaterial)
        {
            List<string> perfectPlanets = new List<string>();
            if (planetMaterial.Inputs.Count == 1)
            {
                string[] planetsForInput = PlanetSchematicsHelper.PlanetsForTypeID[planetMaterial.Inputs[0].typeID].Split(",");
                perfectPlanets.AddRange(planetsForInput);
            }
            else
            {
                List<int> neededT0 = GetNeededT0sRecursive(planetMaterial).Distinct().ToList();
                Dictionary<int, string[]> planetsForT0Dict = new Dictionary<int, string[]>();
                Dictionary<string, int> inputsForPlanet = new Dictionary<string, int>();
                List<int> handledT0 = new List<int>();

                foreach (int t0 in neededT0)
                {
                    planetsForT0Dict.Add(t0, PlanetSchematicsHelper.PlanetsForTypeID[t0].Split(","));
                }

                List<KeyValuePair<int, string[]>> planetsForT0 = planetsForT0Dict.OrderBy(x => x.Value.Count()).ToList();

                bool handled = false;
                foreach (KeyValuePair<int, string[]> kvp in planetsForT0)
                {
                    if (kvp.Value.Count() == 1)
                    {
                        if (!perfectPlanets.Contains(kvp.Value[0]))
                        {
                            perfectPlanets.Add(kvp.Value[0]);
                        }
                        handledT0.Add(kvp.Key);
                    }
                    else
                    {
                        foreach (string value in kvp.Value)
                        {
                            if (perfectPlanets.Contains(value))
                            {
                                handled = true;
                                handledT0.Add(kvp.Key);
                                break;
                            }
                        }
                        if (!handled)
                        {
                            foreach (string value in kvp.Value)
                            {
                                if (inputsForPlanet.Keys.Contains(value))
                                {
                                    inputsForPlanet[value] += 1;
                                }
                                else
                                {
                                    inputsForPlanet.Add(value, 1);
                                }
                            }
                        }
                    }
                    handled = false;
                }
                if (handledT0.Count != neededT0.Count)
                {
                    List<KeyValuePair<string, int>> inputsForPLanetsList = inputsForPlanet.OrderByDescending(x => x.Value).ToList();
                    foreach (KeyValuePair<string, int> kvp in inputsForPLanetsList)
                    {
                        if (handledT0.Count != neededT0.Count)
                        {
                            if (!perfectPlanets.Contains(kvp.Key))
                            {
                                perfectPlanets.Add(kvp.Key);
                            }
                            foreach (int key in planetsForT0Dict.Keys)
                            {
                                if (!handledT0.Contains(key))
                                {
                                    if (planetsForT0Dict[key].Contains(kvp.Key))
                                    {
                                        handledT0.Add(key);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return perfectPlanets;
        }

        private static List<int> GetNeededT0sRecursive(PlanetMaterial selectedType)
        {
            List<int> neededT0 = new List<int>();

            foreach (PlanetMaterial input in selectedType.Inputs)
            {
                if (input.groupID == (int)Enums.Enums.PlanetMatTierGroupId.T0_Gas ||
                    input.groupID == (int)Enums.Enums.PlanetMatTierGroupId.T0_Solid ||
                    input.groupID == (int)Enums.Enums.PlanetMatTierGroupId.T0_Organic)
                {
                    neededT0.Add(input.typeID);
                }
                else
                {
                    neededT0.AddRange(GetNeededT0sRecursive(input));
                }
            }

            return neededT0;
        }
        public static string GetLevelFromGroupName(string typeName)
        {
            string level = typeName.Split("-")[1].Trim();

            if (level.ToLower().Contains("raw"))
            {
                level = "T0";
            }
            return level;
        }

    }
}
