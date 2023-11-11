using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ScreenHelper
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

        
    }
}
