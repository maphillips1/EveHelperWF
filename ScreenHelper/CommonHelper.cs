using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ScreenHelper
{
    public static class CommonHelper
    {
        public static List<Objects.InventoryTypes> InventoryTypes = null;
        public static List<Objects.SolarSystem> SolarSystemList = null;
        public static List<Objects.AdjustedCost> AdjustedCosts = null;
        public static List<Objects.CostIndice> CostIndicies = null;


        public static void Init()
        {
            LoadInventoryTypes();
            LoadSolarSystems();
        }

        public static void InitLongLoading()
        {
            LoadAdjustedCosts();
            LoadCostIndicies();
        }

        private static void LoadInventoryTypes()
        {
            InventoryTypes = Database.SQLiteCalls.GetInventoryTypes();
        }

        private static void LoadAdjustedCosts()
        {
            AdjustedCosts = ESI_Calls.ESIMarketData.GetAdjustedCosts();
        }

        private static void LoadCostIndicies()
        {
            CostIndicies = ESI_Calls.ESIIndustry.GetCostIndices();
        }

        private static void LoadSolarSystems()
        {
            SolarSystemList = Database.SQLiteCalls.GetSolarSystems();
        }
    }
}
