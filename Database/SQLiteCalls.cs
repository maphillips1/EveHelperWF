using EveHelperWF.Objects;
using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace EveHelperWF.Database
{
    public static class SQLiteCalls
    {

        public static string GetSQLiteDirectory()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                         "SQLite FIles\\");
        }

        public static string GetSQLitePath()
        {
            string dbpath = Path.Combine(GetSQLiteDirectory(), "sqlite-latest.sqlite");

            return dbpath;
        }

        #region "Query Command Functions"
        private static string LoadRegionCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Select");
            sb.AppendLine("regionID, regionName");
            sb.AppendLine("FROM Region");
            sb.AppendLine("ORDER BY regionName");

            return sb.ToString();
        }

        private static string GetSolarSystemJumpsCommand(int solarsystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT SS.solarSystemName,");
            sb.AppendLine("CASE");
            sb.AppendLine("WHEN SS_Source.regionID <> SS.regionID THEN 1");
            sb.AppendLine("ELSE 0");
            sb.AppendLine("END AS is_regionalJump,");
            sb.AppendLine("SS.security,");
            sb.AppendLine("SS.solarSystemID");
            sb.AppendLine("from SolarSystemStargate SSS");
            sb.AppendLine("INNER JOIN SolarSystemStargate SSS_Dest");
            sb.AppendLine("    on SSS_Dest.stargateID = SSS.destination");
            sb.AppendLine("INNER JOIN SolarSystem SS");
            sb.AppendLine("    ON SS.solarSystemID = SSS_Dest.solarSystemID");
            sb.AppendLine("INNER JOIN SolarSystem SS_Source");
            sb.AppendLine("    ON SS_Source.solarSystemID = SSS.solarSystemID");
            sb.AppendLine("WHERE SSS.solarSystemID = " + solarsystemID.ToString());

            return sb.ToString();
        }

        private static string GetSolarSystemFactionCommand(int solarsystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT en");
            sb.AppendLine("FROM SolarSystem SS");
            sb.AppendLine("INNER JOIN FactionName FN");
            sb.AppendLine("ON FN.parentTypeID = SS.factionID");
            sb.AppendLine("WHERE SS.solarSystemID = " + solarsystemID.ToString());

            return sb.ToString();
        }

        private static string GetMoonCountCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT count(*) as moon_count");
            sb.AppendLine("FROM SolarSystemPlanet SSP");
            sb.AppendLine("    Inner Join PlanetMoon PM");
            sb.AppendLine("        on PM.planetID = SSP.planetID");
            sb.AppendLine("WHERE SSP.solarSystemID = " + solarSystemID.ToString());

            return sb.ToString();
        }

        private static string GetAsteroidBeltCountCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT count(*) as belt_count");
            sb.AppendLine("FROM SolarSystemPlanet SSP");
            sb.AppendLine("    Inner Join PlanetAsteroidBelt PAB");
            sb.AppendLine("        on PAB.planetID = SSP.planetID");
            sb.AppendLine("WHERE SSP.solarSystemID = " + solarSystemID.ToString());


            return sb.ToString();
        }

        private static string GetStationsForSystemCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("    ss.stationName,");
            sb.AppendLine("    fact.en");
            sb.AppendLine("FROM StaStation SS");
            sb.AppendLine("    Inner join NPCCorporation Corp");
            sb.AppendLine("        on Corp.npcCorporationID = ss.corporationID");
            sb.AppendLine("    inner join FactionName Fact");
            sb.AppendLine("        on Fact.parentTypeId = Corp.factionID");
            sb.AppendLine("WHERE ss.solarSystemID = " + solarSystemID.ToString());
            return sb.ToString();
        }

        private static string GetPlanetsForSystemCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    IUN.itemName,");
            sb.AppendLine("    ETN.en,");
            sb.AppendLine("    GN.en");
            sb.AppendLine("FROM SolarSystemPlanet SSP");
            sb.AppendLine("    INNER JOIN InvUniqueName IUN");
            sb.AppendLine("        ON IUN.itemID = SSP.planetID");
            sb.AppendLine("    INNER JOIN EveType ET");
            sb.AppendLine("        ON SSP.typeID = ET.typeID");
            sb.AppendLine("    INNER JOIN EveTypeName ETN");
            sb.AppendLine("        ON ETN.parentTypeId = ET.typeID");
            sb.AppendLine("    INNER JOIN GroupName GN");
            sb.AppendLine("        ON GN.parentTypeId = ET.groupID");
            sb.AppendLine("WHERE SSP.solarSystemID = " + solarSystemID.ToString());
            return sb.ToString();
        }

        private static string InventoryTypeSearchCommand(string searchText)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT parentTypeId, ETN.en");
            sb.AppendLine("FROM EveTypeName  ETN");
            sb.AppendLine("    INNER JOIN EveType ET");
            sb.AppendLine("        on ET.typeID = ETN.parentTypeID");
            sb.AppendLine("WHERE UPPER(en) LIKE '%' || " + searchText.ToUpperInvariant());
            sb.AppendLine("AND published = 1");
            sb.AppendLine("order by length(ETN.en)");

            return sb.ToString();
        }

        private static string InventoryTypeSearchForMarketCommand(string searchText)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT ET.typeID, ETN.en");
            sb.AppendLine("FROM EveTypeName  ETN");
            sb.AppendLine("    INNER JOIN EveType ET");
            sb.AppendLine("        on ET.typeID = ETN.parentTypeID");
            sb.AppendLine("WHERE UPPER(en) LIKE '%' || " + searchText.ToUpperInvariant());
            sb.AppendLine("    AND published = 1");
            sb.AppendLine("    AND ET.marketGroupID > 0");
            sb.AppendLine("order by length(ETN.en)");

            return sb.ToString();
        }

        private static string SolarSystemSearchCommand(List<int> solarSystemIDs)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select SS.regionID, SS.constellationID, SS.solarSystemID, SS.solarSystemName, C.constellationName, R.regionName, SS.security");
            sb.AppendLine("from SolarSystem SS");
            sb.AppendLine("    inner join Region R");
            sb.AppendLine("        on R.regionID = SS.regionID");
            sb.AppendLine("    inner join Constellation C");
            sb.AppendLine("        on C.constellationID = SS.constellationId");
            sb.AppendLine("where SS.solarSystemID in (");
            int count = 0;
            foreach (int solarSystemID in solarSystemIDs)
            {
                if (count > 0)
                {
                    sb.Append(",");
                }
                sb.AppendLine(solarSystemID.ToString());
                count++;
            }
            sb.AppendLine("    )");

            return sb.ToString();
        }

        private static string GetSchematicIDByTypeIDCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select planetSchematicID");
            sb.AppendLine("from PlanetSchematicType");
            sb.AppendLine("where planetSchematicTypeID = " + typeID.ToString());
            sb.AppendLine("    and isInput = 0");

            return sb.ToString();
        }

        private static string GetPlanetSchematicInputCommand(int schematicID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select PS.planetSchematicID,");
            sb.AppendLine("        PSN.en,");
            sb.AppendLine("        PS.cycleTime,");
            sb.AppendLine("        PST.quantity,");
            sb.AppendLine("        PST.isInput,");
            sb.AppendLine("        ETN.en,");
            sb.AppendLine("        ET.typeID,");
            sb.AppendLine("        ET.volume,");
            sb.AppendLine("        ET.groupID,");
            sb.AppendLine("        GN.en");
            sb.AppendLine("from PlanetSchematic PS");
            sb.AppendLine("    inner join PlanetSchematicName PSN");
            sb.AppendLine("        on PSN.parentTypeId = PS.planetSchematicID");
            sb.AppendLine("    inner join PlanetSchematicType PST");
            sb.AppendLine("        on PST.planetSchematicID = PS.planetSchematicID");
            sb.AppendLine("            and isInput = 1");
            sb.AppendLine("    inner join EveType ET");
            sb.AppendLine("        on ET.typeID = PST.planetSchematicTypeID");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("    inner join EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeId = ET.typeID");
            sb.AppendLine("    inner join GroupName GN");
            sb.AppendLine("        on GN.parentTypeId = ET.groupID");
            sb.AppendLine("where PS.planetSchematicID = " + schematicID.ToString());
            sb.AppendLine("order by PSN.en, ETN.en");

            return sb.ToString();
        }

        private static string GetPlanetOutputsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select PS.planetSchematicID,");
            sb.AppendLine("        PSN.en,");
            sb.AppendLine("        PS.cycleTime,");
            sb.AppendLine("        PST.quantity,");
            sb.AppendLine("        PST.isInput,");
            sb.AppendLine("        ETN.en,");
            sb.AppendLine("        ET.typeID,");
            sb.AppendLine("        ET.volume,");
            sb.AppendLine("        ET.groupID,");
            sb.AppendLine("        GN.en");
            sb.AppendLine("from PlanetSchematic PS");
            sb.AppendLine("    inner join PlanetSchematicName PSN");
            sb.AppendLine("        on PSN.parentTypeId = PS.planetSchematicID");
            sb.AppendLine("    inner join PlanetSchematicType PST");
            sb.AppendLine("        on PST.planetSchematicID = PS.planetSchematicID");
            sb.AppendLine("            and isInput = 0");
            sb.AppendLine("    inner join EveType ET");
            sb.AppendLine("        on ET.typeID = PST.planetSchematicTypeID");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("    inner join EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeId = ET.typeID");
            sb.AppendLine("    inner join GroupName GN");
            sb.AppendLine("        on GN.parentTypeId = ET.groupID");
            sb.AppendLine("order by PSN.en, ETN.en");

            return sb.ToString();
        }

        private static string GetPlanetOutputBySchematicIdCommand(int schematicID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select PS.planetSchematicID,");
            sb.AppendLine("        PSN.en,");
            sb.AppendLine("        PS.cycleTime,");
            sb.AppendLine("        PST.quantity,");
            sb.AppendLine("        PST.isInput,");
            sb.AppendLine("        ETN.en,");
            sb.AppendLine("        ET.typeID,");
            sb.AppendLine("        ET.volume,");
            sb.AppendLine("        ET.groupID,");
            sb.AppendLine("        GN.en");
            sb.AppendLine("from PlanetSchematic PS");
            sb.AppendLine("    inner join PlanetSchematicName PSN");
            sb.AppendLine("        on PSN.parentTypeId = PS.planetSchematicID");
            sb.AppendLine("    inner join PlanetSchematicType PST");
            sb.AppendLine("        on PST.planetSchematicID = PS.planetSchematicID");
            sb.AppendLine("            and isInput = 0");
            sb.AppendLine("    inner join EveType ET");
            sb.AppendLine("        on ET.typeID = PST.planetSchematicTypeID");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("    inner join EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeId = ET.typeID");
            sb.AppendLine("    inner join GroupName GN");
            sb.AppendLine("        on GN.parentTypeId = ET.groupID");
            sb.AppendLine("where PS.planetSchematicID = " + schematicID.ToString());
            sb.AppendLine("order by PSN.en, ETN.en");

            return sb.ToString();
        }

        private static string GetInventoryTypesCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select ET.typeID,");
            sb.AppendLine("    ETN.en,");
            sb.AppendLine("    Coalesce(ETD.en, '') as d_en,");
            sb.AppendLine("    ET.volume,");
            sb.AppendLine("    ET.portionSize,");
            sb.AppendLine("    ET.raceID,");
            sb.AppendLine("    ET.basePrice,");
            sb.AppendLine("    ET.marketGroupID,");
            sb.AppendLine("    0 as iconID,");
            sb.AppendLine("    0 as soundID,");
            sb.AppendLine("    ET.groupID,");
            sb.AppendLine("    GN.en,");
            sb.AppendLine("    EG.categoryID,");
            sb.AppendLine("    CN.en,");
            sb.AppendLine("    Coalesce(MG.parentGroupID, 0) as parentGroupID,");
            sb.AppendLine("    MGN.en");
            sb.AppendLine("from EveType ET");
            sb.AppendLine("    inner join EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeId = ET.typeId");
            sb.AppendLine("    LEFT OUTER JOIN EveTypeDescription ETD");
            sb.AppendLine("        on ETD.parentTypeId = ET.typeID");
            sb.AppendLine("    inner join EveGroup EG");
            sb.AppendLine("        on EG.groupID = ET.groupID");
            sb.AppendLine("    inner join GroupName GN");
            sb.AppendLine("        on GN.parentTypeId = EG.groupID");
            sb.AppendLine("    inner join CategoryName CN");
            sb.AppendLine("        on CN.parentTypeId = EG.categoryID");
            sb.AppendLine("    left outer join MarketGroup MG");
            sb.AppendLine("        on MG.marketGroupID = ET.marketGroupID");
            sb.AppendLine("    left outer join MarketGroupName MGN");
            sb.AppendLine("        on MGN.parentTypeId = ET.marketGroupID");
            sb.AppendLine("where ET.published = 1");

            return sb.ToString();
        }

        private static string GetIndustryActivityTypesCommand(int type_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select BAT.blueprintTypeId,");
            sb.AppendLine("        BAT.time,");
            sb.AppendLine("        BAT.activityName,");
            sb.AppendLine("        Coalesce(BP.typeID, 0) as productTypeID,");
            sb.AppendLine("        Coalesce(ETN.en, '') as typeName");
            sb.AppendLine("from BlueprintActivityType BAT");
            sb.AppendLine("LEFT OUTER join BlueprintProduct BP");
            sb.AppendLine("    on BP.blueprintTYpeID = BAT.blueprintTypeID");
            sb.AppendLine("        and BP.activityName = BAT.activityName");
            sb.AppendLine("LEFT OUTER join EveType ET");
            sb.AppendLine("    on ET.typeID = BP.typeId");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("LEFT OUTER join EveTypeName ETN");
            sb.AppendLine("    on ETN.parentTypeID = ET.typeID");
            sb.AppendLine("where BAT.blueprintTypeId = " + type_id.ToString());

            return sb.ToString();
        }

        private static string GetIndustryActivityMaterialsCommand(int type_id, string activityName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select BAM.blueprintTypeId,");
            sb.AppendLine("    BAM.typeId,");
            sb.AppendLine("    ETN.en,");
            sb.AppendLine("    BAM.quantity,");
            sb.AppendLine("    BAM.activityName,");
            sb.AppendLine("    case");
            sb.AppendLine("        when manuProd.typeID IS NOT NULL Then 1 ");
            sb.AppendLine("        else 0");
            sb.AppendLine("    end as isManufacturable,");
            sb.AppendLine("    case");
            sb.AppendLine("        when reactProd.typeID IS NOT NULL Then 1");
            sb.AppendLine("        else 0");
            sb.AppendLine("    end as isReactable");
            sb.AppendLine("from BlueprintActivityMaterial BAM");
            sb.AppendLine("Inner join EveType ET");
            sb.AppendLine("    on ET.typeID = BAM.typeId");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("Inner join EveTypeName ETN");
            sb.AppendLine("    on ETN.parentTypeId = ET.typeID");
            sb.AppendLine("LEFT OUTER JOIN BlueprintProduct manuProd");
            sb.AppendLine("    on manuProd.typeId = BAM.typeId");
            sb.AppendLine("        and manuProd.activityName = 'manufacturing'");
            sb.AppendLine("LEFT OUTER JOIN BlueprintProduct reactProd");
            sb.AppendLine("    on reactProd.typeId = BAM.typeId");
            sb.AppendLine("        and reactProd.activityName = 'reaction'");
            sb.AppendLine("where BAM.blueprintTypeId = " + type_id.ToString());
            sb.AppendLine("and BAM.activityName = '" + activityName + "'");

            return sb.ToString();
        }

        private static string GetMarketGroupsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select mg.marketGroupID, coalesce(mg.parentGroupID, 0) as parentGroupID, MGN.en, Coalesce(MGD.en, '')");
            sb.AppendLine("from MarketGroup MG");
            sb.AppendLine("    LEFT OUTER JOIN MarketGroupDescription MGD");
            sb.AppendLine("        on MGD.parentTypeID = MG.marketGroupID");
            sb.AppendLine("    INNER JOIN MarketGroupName MGN");
            sb.AppendLine("        on MGN.parentTypeID = MG.marketGroupID");

            return sb.ToString();
        }

        private static string GetIndustryActivitySkillsCommand(int type_id, string activityName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select BPS.parentTypeId,");
			sb.AppendLine("        BPS.typeId,");
			sb.AppendLine("        ETN.en,");
			sb.AppendLine("        BPS.level,");
			sb.AppendLine("        BPS.activityName");
            sb.AppendLine("from BlueprintSkill BPS");
            sb.AppendLine("Inner join EveType ET");
            sb.AppendLine("    on ET.typeID = BPS.typeID");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("Inner join EveTypeName ETN");
            sb.AppendLine("    on ETN.parentTypeId = ET.typeID");
            sb.AppendLine("where BPS.parentTypeID = " + type_id.ToString());
            sb.AppendLine("and BPS.activityName = '" + activityName + "'");

            return sb.ToString();
        }

        private static string GetIndustryActivityProductsCommand(int type_id, string activityName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select BP.blueprintTypeID,");
		    sb.AppendLine("    BP.typeID,");
		    sb.AppendLine("    ETN.en,");
		    sb.AppendLine("    BP.quantity,");
		    sb.AppendLine("    BP.activityName");
	        sb.AppendLine("from BlueprintProduct BP");
	        sb.AppendLine("Inner join EveType ET");
		    sb.AppendLine("    on ET.typeID = BP.typeID");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("    INNER JOIN EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeId = ET.typeID");
	        sb.AppendLine("where bp.blueprintTypeId = " + type_id);
	        sb.AppendLine("and BP.activityName = '" + activityName + "'");

            return sb.ToString();
        }

        private static string GetSolarSystemsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select");
		    sb.AppendLine("    SS.regionID,");
		    sb.AppendLine("    SS.constellationID,");
		    sb.AppendLine("    SS.solarSystemID,");
		    sb.AppendLine("    SS.solarSystemName,");
		    sb.AppendLine("    C.constellationName,");
		    sb.AppendLine("    R.regionName,");
		    sb.AppendLine("    round(SS.security, 1)");
	        sb.AppendLine("from SolarSystem SS");
	        sb.AppendLine("    inner join Region R");
	        sb.AppendLine("        on R.regionID = SS.regionID");
	        sb.AppendLine("    inner join Constellation C");
	        sb.AppendLine("        on C.constellationID = SS.constellationID");
            sb.AppendLine("order by SS.solarSystemName");

            return sb.ToString();
        }

        private static string GetTechIBlueprintTypeIdCommand(int type_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select blueprintTypeID");
            sb.AppendLine("from BlueprintProduct");
            sb.AppendLine("where typeID = " + type_id.ToString());
            sb.AppendLine("and activityName = 'invention'");
            
            return sb.ToString();
        }

        private static string GetBlueprintByProductTypeIDCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select BP.blueprintTypeID");
            sb.AppendLine("from BlueprintProduct BP");
            sb.AppendLine("    INNER JOIN EveType ET ");
            sb.AppendLine("        ON ET.typeID = BP.blueprintTypeID ");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("where BP.typeID = " + typeID.ToString());

            return sb.ToString();
        }

        private static string GetInventionProbabilitiesCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select BP.blueprintTypeID, BP.typeID, BP.probability");
            sb.AppendLine("from BlueprintProduct BP");
            sb.AppendLine("Inner join EveType ET");
            sb.AppendLine("    on ET.typeID = BP.blueprintTypeID");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("where BP.blueprintTypeID = " + typeID.ToString());
            sb.AppendLine("and BP.activityName = 'invention'");

            return sb.ToString();
        }

        private static string IsBlueprintInventedCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select 1 as invented");
            sb.AppendLine("from BlueprintProduct");
            sb.AppendLine("where typeID = " + typeID);
            sb.AppendLine("and activityName = 'invention'");

            return sb.ToString();
        }

        private static string GetSolarSystemsForRegionIDCommand(int regionID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT solarSystemName, solarSystemID");
            sb.AppendLine("FROM SolarSystem");
	        sb.AppendLine("WHERE regionID = " + regionID.ToString());
            sb.AppendLine("ORDER BY solarSystemName");

            return sb.ToString();
        }

        private static string GetStationNameFromStationIDCommand(long stationID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select stationID, stationName");
            sb.AppendLine("from StaStation");
            sb.AppendLine("where stationID = " + stationID.ToString());

            return  sb.ToString();
        }

        private static string GetFilamentTypesForDropDownCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select ET.typeID, ETN.en from EveType ET");
            sb.AppendLine("    INNER JOIN EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeID = ET.typeID");
            sb.AppendLine("where groupID = 1979");
            sb.AppendLine("            AND published = 1");
            sb.AppendLine("order by ETN.en");

            return sb.ToString();
        }

        private static string LoadIndustryProductsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select ET.typeID, ETN.en");
            sb.AppendLine("from EveType ET");
            sb.AppendLine("    inner join EveTypeName ETN");
            sb.AppendLine("        on ETN.parentTypeId = ET.typeID");
            sb.AppendLine("    inner join BlueprintProduct BP");
            sb.AppendLine("        on BP.typeId = ET.typeID");
            sb.AppendLine("where BP.activityName in ('manufacturing', 'reaction')");
            sb.AppendLine("            AND ET.published = 1");
            sb.AppendLine("order by ETN.en");

            return sb.ToString();
        }
        #endregion

        #region "Public Functions"
        public static List<Objects.Region> LoadRegions()
        {
            List<Objects.Region> regions = new List<Objects.Region>();
            regions.Add(new Objects.Region());

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string commandString = LoadRegionCommand();
                SqliteCommand selectCommand = new SqliteCommand(commandString, db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                Objects.Region region;
                while (query.Read())
                {
                    region = new Objects.Region();
                    region.regionID = Convert.ToInt32(query.GetString(0));
                    region.regionName = query.GetString(1);
                    regions.Add(region);
                }
            }

            return regions;
        }

        public static List<Objects.SolarSystemJump> GetSolarSystemJumps(int solarSystemID)
        {
            List<SolarSystemJump> solarSystemJumps = new List<SolarSystemJump>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand command = new SqliteCommand(GetSolarSystemJumpsCommand(solarSystemID), db);
                SqliteDataReader query = command.ExecuteReader();

                Objects.SolarSystemJump jump;
                while (query.Read())
                {
                    jump = new Objects.SolarSystemJump();
                    jump.solarSystemName = query.GetString(0);
                    jump.isRegional = Convert.ToBoolean(Convert.ToInt32(query.GetString(1)));
                    jump.security = Math.Round(query.GetDecimal(2), 1);
                    jump.toSolarSystemId = query.GetInt64(3);
                    solarSystemJumps.Add(jump);
                }
            }

            return solarSystemJumps;
        }

        public static string GetSolarSystemFaction(int solarSystemID)
        {
            string factionName = string.Empty;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetSolarSystemFactionCommand(solarSystemID), db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    factionName = query.GetString(0);
                }
            }

            return factionName;
        }

        public static int GetMoonCount(int solarSystemID)
        {
            int moonCount = 0;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetMoonCountCommand(solarSystemID), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    moonCount = Convert.ToInt32(query.GetString(0));
                }
            }

            return moonCount;
        }

        public static int GetAsteroidBeltCount(int solarSystemID)
        {
            int beltCount = 0;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetAsteroidBeltCountCommand(solarSystemID), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    beltCount = Convert.ToInt32(query.GetString(0));
                }
            }

            return beltCount;
        }

        public static List<StationInfo> GetStationsForSystem(int solarSystemID)
        {
            List<StationInfo> stations = new List<StationInfo>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetStationsForSystemCommand(solarSystemID), db);

                SqliteDataReader query = command.ExecuteReader();

                StationInfo stationInfo;
                while (query.Read())
                {
                    stationInfo = new StationInfo();
                    stationInfo.stationName = query.GetString(0);
                    stationInfo.factionName = query.GetString(1);
                    stations.Add(stationInfo);
                }
            }

            return stations;
        }

        public static List<Planet> GetPlanetsForSystem(int solarSystemID)
        {
            List<Planet> planets = new List<Planet>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetPlanetsForSystemCommand(solarSystemID), db);

                SqliteDataReader query = command.ExecuteReader();

                Planet planet;
                while (query.Read())
                {
                    planet = new Planet();
                    planet.itemName = query.GetString(0);
                    planet.typeName = query.GetString(1);
                    planet.groupName = query.GetString(2);
                    planets.Add(planet);
                }
            }

            return planets;
        }

        public static Objects.InventoryType InventoryTypeSearch(string searchText)
        {
            Objects.InventoryType foundType = null;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(InventoryTypeSearchCommand(searchText), db);

                SqliteDataReader query = command.ExecuteReader();


                while (query.Read())
                {
                    foundType = new InventoryType();
                    foundType.typeId = Convert.ToInt32(query.GetString(0));
                    foundType.typeName = query.GetString(1);
                    break;
                }
            }

            return foundType;
        }

        public static List<InventoryType> InventoryTypeSearchLoadAll(string searchText)
        {
            List<InventoryType> inventoryTypes = new List<InventoryType>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(InventoryTypeSearchCommand(searchText), db);

                SqliteDataReader query = command.ExecuteReader();

                InventoryType type = null;
                while (query.Read())
                {
                    type = new InventoryType();
                    type.typeId = Convert.ToInt32(query.GetString(0));
                    type.typeName = query.GetString(1);
                    inventoryTypes.Add(type);
                }
            }

            return inventoryTypes;
        }

        public static List<SolarSystem> SolarSystemSearch(bool temperate,
                                                                bool ice,
                                                                bool gas,
                                                                bool oceanic,
                                                                bool lava,
                                                                bool barren,
                                                                bool storm,
                                                                bool plasma,
                                                                bool wormholes,
                                                                bool pochven,
                                                                int stationFilter,
                                                                decimal min_security,
                                                                decimal max_security,
                                                                int regionID,
                                                                string systemName)
        {
            List<SolarSystem> solarSystems = new List<SolarSystem>();
            systemName = systemName.Replace("'", "");

            if (min_security <= 0) { min_security = -1; }

            List<int> solarSystemIDs = AllSolarSystemIDs();
            List<int> solarSystemsToRemove = new List<int>();

            if (!string.IsNullOrWhiteSpace(systemName))
            {
                systemName = "'" + systemName + "'";
                solarSystemIDs = SystemsWithName(systemName);
            }

            if (regionID > 0)
            {
                List<int> systemsInRegion = SystemsInRegion(regionID);

                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!systemsInRegion.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (temperate)
            {
                List<int> tempSystems = GetSolarySystemsWithPlanetType(11);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!tempSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (ice)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(12);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (gas)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(13);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (oceanic)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(2014);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (lava)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(2015);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (barren)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(2016);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (storm)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(2017);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (plasma)
            {
                List<int> iceSystems = GetSolarySystemsWithPlanetType(2063);
                foreach (int solarSystemID in solarSystemIDs)
                {
                    if (!iceSystems.Contains(solarSystemID))
                    {
                        solarSystemsToRemove.Add(solarSystemID);
                    }
                }
            }

            if (!wormholes)
            {
                List<int> wormholeSystems = WormholeSystems();
                foreach (int solarSystemID in wormholeSystems)
                {
                    if (solarSystemIDs.Contains(solarSystemID))
                    {
                        solarSystemIDs.Remove(solarSystemID);
                    }
                }
            }

            if (!pochven)
            {
                List<int> pochvenSystems = PochvenSystems();
                foreach (int solarSystemID in pochvenSystems)
                {
                    if (solarSystemIDs.Contains(solarSystemID))
                    {
                        solarSystemIDs.Remove(solarSystemID);
                    }
                }
            }

            if (stationFilter > 1)
            {
                List<int> stationSystem = StationSystems();
                if (stationFilter == (int)(Enums.Enums.StationFilter.HasStation))
                {
                    foreach (int solarSystemID in solarSystemIDs)
                    {
                        if (!stationSystem.Contains(solarSystemID))
                        {
                            solarSystemsToRemove.Add(solarSystemID);
                        }
                    }
                }
                else if (stationFilter == (int)(Enums.Enums.StationFilter.NoStation))
                {
                    foreach (int solarSystemID in solarSystemIDs)
                    {
                        if (stationSystem.Contains(solarSystemID))
                        {
                            solarSystemsToRemove.Add(solarSystemID);
                        }
                    }
                }
            }

            List<int> systemsWithSec = SystemsWithSecurity(min_security, max_security);

            foreach (int solarSystemID in solarSystemIDs)
            {
                if (!systemsWithSec.Contains(solarSystemID))
                {
                    solarSystemsToRemove.Add(solarSystemID);
                }
            }

            foreach (int systemToRemove in solarSystemsToRemove)
            {
                if (solarSystemIDs.Contains(systemToRemove))
                {
                    solarSystemIDs.Remove(systemToRemove);
                }
            }

            if (solarSystemIDs.Count > 0)
            {
                string queryCommand = SolarSystemSearchCommand(solarSystemIDs);

                string dbpath = GetSQLitePath();
                using (var db = new SqliteConnection($"Filename={dbpath}"))
                {
                    db.Open();

                    SqliteCommand command = new SqliteCommand(queryCommand, db);
                    SqliteDataReader query = command.ExecuteReader();

                    SolarSystem solarSystem;
                    while (query.Read())
                    {
                        solarSystem = new SolarSystem();
                        solarSystem.regionID = query.GetInt32(0);
                        solarSystem.constellationID = query.GetInt32(1);
                        solarSystem.solarSystemID = query.GetInt32(2);
                        solarSystem.solarSystemName = query.GetString(3);
                        solarSystem.constellationName = query.GetString(4);
                        solarSystem.regionName = query.GetString(5);
                        solarSystem.security = Math.Round(query.GetDecimal(6), 1);
                        solarSystems.Add(solarSystem);
                    }
                }
            }

            return solarSystems.OrderBy(x => x.regionName).ThenBy(x => x.solarSystemName).ToList<SolarSystem>();
        }

        public static int GetSchematicIDByTypeID(int typeID)
        {
            //assp_PLanetSchematics_GetSchematicIDByTypeId
            int schematicID = 0;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetSchematicIDByTypeIDCommand(typeID), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    schematicID = query.GetInt32(0);
                }
            }

            return schematicID;
        }

        public static List<PlanetMaterial> GetPlanetSchematicInput(int schematicID)
        {
            List<PlanetMaterial> schematicInputs = new List<PlanetMaterial>();


            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetPlanetSchematicInputCommand(schematicID), db);

                SqliteDataReader query = command.ExecuteReader();

                PlanetMaterial planetMaterial;
                while (query.Read())
                {
                    planetMaterial = new PlanetMaterial();
                    planetMaterial.schematicID = query.GetInt32(0);
                    planetMaterial.schematicName = query.GetString(1);
                    planetMaterial.cycleTime = query.GetInt32(2);
                    planetMaterial.quantity = query.GetInt32(3);
                    planetMaterial.isInput = query.GetBoolean(4);
                    planetMaterial.typeName = query.GetString(5);
                    planetMaterial.typeID = query.GetInt32(6);
                    planetMaterial.volume = query.GetDecimal(7);
                    planetMaterial.groupID = query.GetInt32(8);
                    planetMaterial.groupName = query.GetString(9);
                    schematicInputs.Add(planetMaterial);
                }
            }

            return schematicInputs;
        }

        public static List<PlanetMaterial> GetPlanetOutputs(int groupId = -1)
        {
            List<PlanetMaterial> planetOutputTypes = new List<PlanetMaterial>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetPlanetOutputsCommand(), db);

                SqliteDataReader query = command.ExecuteReader();

                PlanetMaterial planetMaterial;
                while (query.Read())
                {
                    planetMaterial = new PlanetMaterial();
                    planetMaterial.schematicID = query.GetInt32(0);
                    planetMaterial.schematicName = query.GetString(1);
                    planetMaterial.cycleTime = query.GetInt32(2);
                    planetMaterial.quantity = query.GetInt32(3);
                    planetMaterial.isInput = query.GetBoolean(4);
                    planetMaterial.typeName = query.GetString(5);
                    planetMaterial.typeID = query.GetInt32(6);
                    planetMaterial.volume = query.GetDecimal(7);
                    planetMaterial.groupID = query.GetInt32(8);
                    planetMaterial.groupName = query.GetString(9);
                    planetOutputTypes.Add(planetMaterial);
                }
            }

            return planetOutputTypes;
        }

        public static PlanetMaterial GetPlanetOutputBySchematicId(int schematicID)
        {
            PlanetMaterial output = new PlanetMaterial();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetPlanetOutputBySchematicIdCommand(schematicID), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    output = new PlanetMaterial();
                    output.schematicID = query.GetInt32(0);
                    output.schematicName = query.GetString(1);
                    output.cycleTime = query.GetInt32(2);
                    output.quantity = query.GetInt32(3);
                    output.isInput = query.GetBoolean(4);
                    output.typeName = query.GetString(5);
                    output.typeID = query.GetInt32(6);
                    output.volume = query.GetDecimal(7);
                    output.groupID = query.GetInt32(8);
                    output.groupName = query.GetString(9);
                    break;
                }
            }

            return output;
        }

        public static List<Objects.InventoryType> GetInventoryTypes()
        {
            List<Objects.InventoryType> inventoryTypes = new List<Objects.InventoryType>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetInventoryTypesCommand(), db);

                SqliteDataReader query = command.ExecuteReader();

                InventoryType invType;
                while (query.Read())
                {
                    invType = new InventoryType();
                    if (query[0] != DBNull.Value) { invType.typeId = query.GetInt32(0); }
                    if (query[1] != DBNull.Value) { invType.typeName = query.GetString(1); }
                    if (query[3] != DBNull.Value) { invType.volume = query.GetDecimal(3); }
                    if (query[6] != DBNull.Value) { invType.basePrice = query.GetDecimal(6); }
                    if (query[7] != DBNull.Value) { invType.marketGroupId = query.GetInt32(7); }
                    if (query[10] != DBNull.Value) { invType.groupId = query.GetInt32(10); }
                    if (query[11] != DBNull.Value) { invType.groupName = query.GetString(11); }
                    if (query[12] != DBNull.Value) { invType.categoryID = query.GetInt32(12); }
                    if (query[13] != DBNull.Value) { invType.categoryName = query.GetString(13); }
                    if (query[14] != DBNull.Value) { invType.parentMarketGroupId = query.GetInt32(14); }
                    if (query[15] != DBNull.Value) { invType.marketGroupName = query.GetString(15); }
                    inventoryTypes.Add(invType);
                }
            }

            return inventoryTypes;
        }

        public static List<Objects.IndustryActivityTypes> GetIndustryActivityTypes(int type_id)
        {
            List<Objects.IndustryActivityTypes> industryActivityTypes = new List<Objects.IndustryActivityTypes>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivityTypesCommand(type_id), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivityTypes activityType;
                while (query.Read())
                {
                    activityType = new IndustryActivityTypes();
                    activityType.typeID = query.GetInt32(0);
                    activityType.time = query.GetInt64(1);
                    activityType.activityName = query.GetString(2);
                    activityType.productTypeId = query.GetInt32(3);
                    activityType.productName = query.GetString(4);
                    industryActivityTypes.Add(activityType);
                }
            }

            return industryActivityTypes;
        }

        public static List<EveHelperWF.Objects.IndustryActivityMaterials> GetIndustryActivityMaterials(int type_id, string activityName)
        {
            List<EveHelperWF.Objects.IndustryActivityMaterials> industryActivityMaterials = new List<Objects.IndustryActivityMaterials>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivityMaterialsCommand(type_id, activityName), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivityMaterials activityMaterial;
                while (query.Read())
                {
                    activityMaterial = new IndustryActivityMaterials();
                    activityMaterial.typeID = query.GetInt32(0);
                    activityMaterial.materialTypeID = query.GetInt32(1);
                    activityMaterial.materialName = query.GetString(2);
                    activityMaterial.quantity = query.GetInt32(3);
                    activityMaterial.activityName = query.GetString(4);
                    activityMaterial.isManufacturable = query.GetBoolean(5);
                    activityMaterial.isReactable = query.GetBoolean(6);
                    industryActivityMaterials.Add(activityMaterial);
                }
            }

            return industryActivityMaterials;
        }

        public static List<Objects.InventoryMarketGroups> GetMarketGroups()
        {
            List<EveHelperWF.Objects.InventoryMarketGroups> marketGroups = new List<Objects.InventoryMarketGroups>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetMarketGroupsCommand(), db);

                SqliteDataReader query = command.ExecuteReader();

                InventoryMarketGroups marketGroup;
                while (query.Read())
                {
                    marketGroup = new InventoryMarketGroups();
                    marketGroup.marketGroupID = query.GetInt32(0);
                    marketGroup.parentGroupID = query.GetInt32(1);
                    marketGroup.marketGroupName = query.GetString(2);
                    marketGroup.description = query.GetString(3);
                    marketGroups.Add(marketGroup);
                }
            }

            return marketGroups;
        }

        public static List<Objects.IndustryActivitySkill> GetINdustryActivitySkills(int type_id, string activityName)
        {
            List<EveHelperWF.Objects.IndustryActivitySkill> activitySkills = new List<Objects.IndustryActivitySkill>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivitySkillsCommand(type_id, activityName), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivitySkill activitySkill;
                while (query.Read())
                {
                    activitySkill = new IndustryActivitySkill();
                    activitySkill.typeID = query.GetInt32(0);
                    activitySkill.skillID = query.GetInt32(1);
                    activitySkill.skillName = query.GetString(2);
                    activitySkill.level = query.GetInt32(3);
                    activitySkill.activityName = query.GetString(4);
                    activitySkills.Add(activitySkill);
                }
            }

            return activitySkills;
        }

        public static List<Objects.IndustryActivityProduct> GetIndustryActivityProducts(int type_id, string activityName)
        {
            List<EveHelperWF.Objects.IndustryActivityProduct> activityProducts = new List<Objects.IndustryActivityProduct>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivityProductsCommand(type_id, activityName), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivityProduct activityProduct;
                while (query.Read())
                {
                    activityProduct = new IndustryActivityProduct();
                    activityProduct.typeID = query.GetInt32(0);
                    activityProduct.productTypeID = query.GetInt32(1);
                    activityProduct.productName = query.GetString(2);
                    activityProduct.quantity =  query.GetInt32(3);
                    activityProduct.activityName = query.GetString(4);
                    activityProducts.Add(activityProduct);
                }
            }
            return activityProducts;
        }

        public static List<Objects.SolarSystem> GetSolarSystems()
        {
            List<Objects.SolarSystem> systemList = new List<Objects.SolarSystem>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetSolarSystemsCommand(), db);

                SqliteDataReader query = command.ExecuteReader();

                SolarSystem solarSystem;
                while (query.Read())
                {
                    solarSystem = new SolarSystem();
                    solarSystem.regionID = query.GetInt32(0);
                    solarSystem.constellationID = query.GetInt32(1);
                    solarSystem.solarSystemID = query.GetInt32(2);
                    solarSystem.solarSystemName = query.GetString(3);
                    solarSystem.constellationName = query.GetString(4);
                    solarSystem.regionName = query.GetString(5);
                    solarSystem.security = query.GetDecimal(6);
                    systemList.Add(solarSystem);
                }
            }

            return systemList.OrderBy(x => x.solarSystemName).ToList();
        }

        public static int GetTech1BlueprintTypeId(int type_id)
        {
            int tech1BlueprintTypeId = 0;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetTechIBlueprintTypeIdCommand(type_id), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    tech1BlueprintTypeId = query.GetInt32(0);
                    break;
                }
            }

            return tech1BlueprintTypeId;
        }

        public static int GetBlueprintByProductTypeID(int typeID)
        {
            int blueprintTypeID = 0;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetBlueprintByProductTypeIDCommand(typeID), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    blueprintTypeID = query.GetInt32(0);
                    break;
                }
            }
            return blueprintTypeID;
        }

        public static List<Objects.InventionProbability> GetInventionProbabilities(int type_id)
        {
            List<Objects.InventionProbability> probabilityList = new List<Objects.InventionProbability>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetInventionProbabilitiesCommand(type_id), db);

                SqliteDataReader query = command.ExecuteReader();

                InventionProbability probability;
                while (query.Read())
                {
                    probability = new InventionProbability();
                    probability.typeID = query.GetInt32(0);
                    probability.productTypeID = query.GetInt32(1);
                    probability.probability = query.GetDecimal(2);
                    probabilityList.Add(probability);
                }
            }

            return probabilityList;
        }

        public static bool IsBlueprintInvented(int type_id)
        {
            bool isInvented = false;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(IsBlueprintInventedCommand(type_id), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    isInvented = query.GetBoolean(0);
                    break;
                }
            }

            return isInvented;
        }

        public static List<Objects.SolarSystem> GetSolarSystemsForRegionID(int regionID)
        {
            List<Objects.SolarSystem> solarSystems = new List<Objects.SolarSystem>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetSolarSystemsForRegionIDCommand(regionID), db);

                SqliteDataReader query = command.ExecuteReader();

                SolarSystem solarSystem = null;
                while (query.Read())
                {
                    solarSystem = new SolarSystem();
                    solarSystem.solarSystemName = query.GetString(0);
                    solarSystem.solarSystemID = query.GetInt32(1);
                    solarSystems.Add(solarSystem);
                }
            }

            return solarSystems;
        }

        public static string GetStationNameForStationID(long stationID)
        {
            string stationName = string.Empty;

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetStationNameFromStationIDCommand(stationID), db);

                SqliteDataReader query = command.ExecuteReader();

                SolarSystem solarSystem = null;
                while (query.Read())
                {
                    stationName = query.GetString(1);
                    break;
                }
            }

            return stationName;
        }

        public static List<InventoryType> GetFilamentTypesForDropDown()
        {
            List<InventoryType> filamentTypes = new List<InventoryType>();
            filamentTypes.Add(new InventoryType());

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetFilamentTypesForDropDownCommand(), db);

                SqliteDataReader query = command.ExecuteReader();

                InventoryType filamentType = null;
                while (query.Read())
                {
                    filamentType = new InventoryType();
                    filamentType.typeId = query.GetInt32(0);
                    filamentType.typeName = query.GetString(1);
                    filamentTypes.Add(filamentType);
                }
            }

            return filamentTypes;
        }

        public static List<InventoryType> InventoryTypeSearchForMarket(string searchText)
        {
            List<InventoryType> inventoryTypes = new List<InventoryType>();

            searchText = searchText.Trim().Replace(" ", "%");

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(InventoryTypeSearchForMarketCommand(searchText), db);

                SqliteDataReader query = command.ExecuteReader();

                InventoryType type = null;
                while (query.Read())
                {
                    type = new InventoryType();
                    type.typeId = Convert.ToInt32(query.GetString(0));
                    type.typeName = query.GetString(1);
                    inventoryTypes.Add(type);
                }
            }

            return inventoryTypes;
        }

        public static List<ComboListItem> LoadProductsCombo()
        {
            List<ComboListItem> comboItems = new List<ComboListItem>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(LoadIndustryProductsCommand(), db);

                SqliteDataReader query = command.ExecuteReader();

                ComboListItem comboItem = null;
                while (query.Read())
                {
                    comboItem = new ComboListItem();
                    comboItem.key = Convert.ToInt32(query.GetString(0));
                    comboItem.value = query.GetString(1);
                    comboItems.Add(comboItem);
                }
            }

            return comboItems;
        }
        #endregion

        #region "Support Functions"
        private static List<int> AllSolarSystemIDs()
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "select solarSystemID from SolarSystem SS inner join Region R on R.regionID = SS.regionID where regionName NOT like 'ADR0%'";

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> GetSolarySystemsWithPlanetType(int planetTypeID)
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "SELECT solarSystemID FROM SolarSystemPlanet WHERE typeID = " + planetTypeID.ToString();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> WormholeSystems()
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select solarSystemID from SolarSystem SS");
            sb.AppendLine("    inner join Region R");
            sb.AppendLine("        on R.regionId = SS.regionID");
            sb.AppendLine("where regionName like '%-%'");

            queryCommand = sb.ToString();


            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> PochvenSystems()
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "select solarSystemID from SolarSystem where regionID = 10000070";

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> StationSystems()
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "select solarSystemID from staStation";

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> SystemsWithSecurity(decimal min_security, decimal max_security)
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "select solarSystemID from SolarSystem\r\nwhere round(security, 1) >= " + min_security.ToString() + "\r\nand round(security, 1) <= " + max_security.ToString();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> SystemsInRegion(int regionId)
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "select solarSystemID from SolarSystem where regionID = " + regionId.ToString();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        private static List<int> SystemsWithName(string systemName)
        {
            List<int> solarSystemIDs = new List<int>();

            string queryCommand = "select solarSystemID from SolarSystem where solarSystemName like '%' ||" + systemName + "|| '%'";

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(queryCommand, db);
                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    solarSystemIDs.Add(query.GetInt32(0));
                }
            }

            return solarSystemIDs;
        }

        #endregion
    }
}
