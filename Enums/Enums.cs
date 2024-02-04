using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public static class Enums
    {
        public const int ActivityManufacturing = 1;
        public const int ActivityResearchingTimeEfficiency = 3;
        public const int ActivityResearchingMaterialEfficiency = 4;
        public const int ActivityCopying = 5;
        public const int ActivityReverseEngineering = 7;
        public const int ActivityInvention = 8;
        public const int ActivityReactions = 11;

        public const int TheForgeRegionId = 10000002;
        public const int JitaSystemId = 30000142;

        public const int RensSystemID = 30002510;
        public const int HeimatarRegionID = 10000030;

        public const int AmarrSystemID = 30002187;
        public const int DomainRegionID = 10000043;

        public const int DodixieSystemID = 30002659;
        public const int SinqLiason = 10000032;

        public const int TheraRegion = 11000031;
        public const int TheraSystem = 31000005;

        public const int OldManStarSystem = 30005000;

        public static int ResLevel1Modifier = 105;
        public static int ResLevel2Modifier = 250;
        public static int ResLevel3Modifier = 595;
        public static int ResLevel4Modifier = 1414;
        public static int ResLevel5Modifier = 3360;
        public static int ResLevel6Modifier = 8000;
        public static int ResLevel7Modifier = 19000;
        public static int ResLevel8Modifier = 45255;
        public static int ResLevel9Modifier = 107700;
        public static int ResLevel10Modifier = 256000;

        public static decimal ResLevel1CostModifier = 1;
        public static decimal ResLevel2CostModifier = (29 / 21);
        public static decimal ResLevel3CostModifier = (23 / 7);
        public static decimal ResLevel4CostModifier = (39 / 5);
        public static decimal ResLevel5CostModifier = (278 / 15);
        public static decimal ResLevel6CostModifier = (928 / 21);
        public static decimal ResLevel7CostModifier = (2200 / 21);
        public static decimal ResLevel8CostModifier = (5251 / 21);
        public static decimal ResLevel9CostModifier = (4163 / 7);
        public static decimal ResLevel10CostModifier = (29660 / 21);

        public static double SCCSurcharge = 0.04;

        //Directories
        public static string ImagesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\Images\\");
        public static string CachedCostIndicesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\CostIndicies\\"); 
        public static string CachedBuyFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\Market\\buy\\");
        public static string CachedSellFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\Market\\sell\\");
        public static string CachedAdjustedCosts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\Market\\");
        public static string CachedPriceHistory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\Market\\PriceHistory");
        public static string AbyssRunDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\AbyssRuns\\");
        public static string CachedFormValuesDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\FormValues\\");
        public static string TrackedTypeDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\TrackedTypes\\");
        public static string ShoppingListsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\ShoppingLists\\");
        public static string BuildPlanDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         "EveHelper\\BuildPlans\\");
        public enum PlanetMatTierGroupId
        {
            T0_Organic = 1035,
            T0_Solid = 1032,
            T0_Gas = 1033,
            T1 = 1042,
            T2 = 1034,
            T3 = 1040,
            T4 = 1041,
        }

        public enum T0_PlanetTypeIDs
        {
            BaseMetals = 2267,
            NobleMetals = 2270,
            HeavyMetals = 2272,
            NonCSCrystals = 2306,
            FelsicMagma = 2307,
            AqueousLiquids = 2268,
            SuspendedPlasma = 2308,
            IonicSolutions = 2309,
            NobleGas = 2310,
            ReactiveGas = 2311,
            Microorganisms = 2073,
            PlankticColonies = 2286,
            ComplexOrganisms = 2287,
            CarbonCompounds = 2288,
            Autotrophs = 2305
        }

        public enum PlanetTypeID
        {
            Temperate = 11,
            Ice = 12,
            Gas = 13,
            Oceanic = 2014,
            Lava = 2015,
            Barren = 2016,
            Storm = 2017,
            Plasma = 2063,
            Shattered = 30889
        }

        public enum StationFilter
        {
            DoNotFilter = 1,
            HasStation = 2,
            NoStation = 3
        }

        public enum PriceHistoryTimePeriod
        {
            Week = 0,
            ThirtyDays = 1,
            SixtyDays = 2,
            NinetyDays = 3,
            SixMonths = 4,
            OneYear = 5,
            AllTime = 6
        }

        public enum EngineeringStructureType
        {
            Raitaru = 35825,
            Azbel = 35826,
            Sotiyo = 35827
        }

        public enum InvTypeCategory
        {
            Material = 4,
            Ship = 6,
            Commodity = 17,
            Reaction = 24,
            Asteroid = 25,
            PlanetIndustry = 41,
            PlanetResource = 42,
            PlanetCommodity = 43
        }

        public enum OrderType
        {
            Sell = 1,
            Buy = 2
        }
    }
}
