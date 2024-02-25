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
            sb.AppendLine("FROM mapRegions MR");
            sb.AppendLine("ORDER BY regionName");

            return sb.ToString();
        }

        private static string GetSolarSystemJumpsCommand(int solarsystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT MSS.solarSystemName,");
            sb.AppendLine("CASE");
            sb.AppendLine("WHEN mssj.fromRegionID<> mssj.toRegionID THEN 1");
            sb.AppendLine("ELSE 0");
            sb.AppendLine("END AS is_regionalJump,");
            sb.AppendLine("MSS.security,");
            sb.AppendLine("mssj.toSolarSystemID");
            sb.AppendLine("from mapSolarSystemJumps mssj");
            sb.AppendLine("INNER JOIN mapSolarSystems MSS");
            sb.AppendLine("ON MSS.solarSystemID = MSSJ.toSolarSystemID");
            sb.AppendLine("WHERE mssj.fromSolarSystemID = " + solarsystemID.ToString());

            return sb.ToString();
        }

        private static string GetSolarSystemFactionCommand(int solarsystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT factionName");
            sb.AppendLine("FROM mapSolarSystems MSS");
            sb.AppendLine("INNER JOIN chrFactions F");
            sb.AppendLine("ON F.factionID = MSS.factionID");
            sb.AppendLine("WHERE MSS.solarSystemID = " + solarsystemID.ToString());

            return sb.ToString();
        }

        private static string GetMoonCountCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT count(*) as moon_count");
            sb.AppendLine("FROM mapDenormalize");
            sb.AppendLine("WHERE solarSystemID = " + solarSystemID.ToString());
            sb.AppendLine("and groupID = 8");

            return sb.ToString();
        }

        private static string GetAsteroidBeltCountCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT count(*) as belt_count");
            sb.AppendLine("FROM mapDenormalize");
            sb.AppendLine("WHERE solarSystemID = " + solarSystemID.ToString());
            sb.AppendLine("and groupID = 9");


            return sb.ToString();
        }

        private static string GetStationsForSystemCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("    ss.stationName,");
            sb.AppendLine("    fact.factionName");
            sb.AppendLine("FROM staStations SS");
            sb.AppendLine("    Inner join crpNPCCorporations Corp");
            sb.AppendLine("        on Corp.corporationID = ss.corporationID");
            sb.AppendLine("    inner join chrFactions Fact");
            sb.AppendLine("        on Fact.factionID = Corp.factionID");
            sb.AppendLine("WHERE ss.solarSystemID = " + solarSystemID.ToString());
            return sb.ToString();
        }

        private static string GetPlanetsForSystemCommand(int solarSystemID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    md.itemName,");
            sb.AppendLine("    it.typeName,");
            sb.AppendLine("    ig.groupName");
            sb.AppendLine("FROM mapDenormalize md");
            sb.AppendLine("    INNER JOIN invTypes IT");
            sb.AppendLine("        ON IT.typeID = MD.typeID");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("    INNER JOIN invGroups IG");
            sb.AppendLine("        ON IG.groupID = IT.groupID");
            sb.AppendLine("WHERE solarSystemID = " + solarSystemID.ToString());
            sb.AppendLine("AND ig.groupID = 7");
            return sb.ToString();
        }

        private static string InventoryTypeSearchCommand(string searchText)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT typeID, typeName");
            sb.AppendLine("FROM invTypes");
            sb.AppendLine("WHERE UPPER(typeName) LIKE '%' || " + searchText.ToUpperInvariant());
            sb.AppendLine("AND published = 1");
            sb.AppendLine("order by length(typeName)");

            return sb.ToString();
        }

        private static string InventoryTypeSearchForMarketCommand(string searchText)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT typeID, typeName");
            sb.AppendLine("FROM invTypes");
            sb.AppendLine("WHERE UPPER(typeName) LIKE '%' || " + searchText.ToUpperInvariant());
            sb.AppendLine("AND marketGroupID > 0");
            sb.AppendLine("AND published = 1");
            sb.AppendLine("order by length(typeName)");

            return sb.ToString();
        }

        private static string SolarSystemSearchCommand(List<int> solarSystemIDs)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select MSS.regionID, mss.constellationID, mss.solarSystemID, mss.solarSystemName, mc.constellationName, mr.regionName, mss.security");
            sb.AppendLine("from mapSolarSystems MSS");
            sb.AppendLine("    inner join mapRegions MR");
            sb.AppendLine("        on MR.regionID = MSS.regionID");
            sb.AppendLine("    inner join mapConstellations MC");
            sb.AppendLine("        on MC.constellationID = MSS.constellationId");
            sb.AppendLine("where solarSystemID in (");
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

            sb.AppendLine("select PSOut.schematicID");
            sb.AppendLine("from planetSchematics PSOut");
            sb.AppendLine("inner join planetSchematicsTypeMap PSTM");
            sb.AppendLine("    on PSTM.schematicID = PSOut.schematicID");
            sb.AppendLine("        and isInput = 0");
            sb.AppendLine("inner join invTypes IT");
            sb.AppendLine("    on IT.typeID = PSTM.typeID");
            sb.AppendLine("        AND IT.published = 1");
            sb.AppendLine("where IT.typeID = " + typeID.ToString());
            sb.AppendLine("order by PSOut.schematicName, IT.typeName");

            return sb.ToString();
        }

        private static string GetPlanetSchematicInputCommand(int schematicID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select PSOut.schematicID,");
            sb.AppendLine("        PSOut.schematicName,");
            sb.AppendLine("        PSOut.cycleTime,");
            sb.AppendLine("        PSTM.quantity,");
            sb.AppendLine("        PSTM.isInput,");
            sb.AppendLine("        IT.typeName,");
            sb.AppendLine("        IT.typeID,");
            sb.AppendLine("        IT.volume,");
            sb.AppendLine("        IG.groupID,");
            sb.AppendLine("        IG.groupName");
            sb.AppendLine("from planetSchematics PSOut");
            sb.AppendLine("inner join planetSchematicsTypeMap PSTM");
            sb.AppendLine("    on PSTM.schematicID = PSOut.schematicID");
            sb.AppendLine("        and isInput = 1");
            sb.AppendLine("inner join invTypes IT");
            sb.AppendLine("    on IT.typeID = PSTM.typeID");
            sb.AppendLine("        AND IT.published = 1");
            sb.AppendLine("inner join invGroups IG");
            sb.AppendLine("    on IG.groupID = IT.groupID");
            sb.AppendLine("where PSOut.schematicID = " + schematicID.ToString());
            sb.AppendLine("order by PSOut.schematicName, IT.typeName");

            return sb.ToString();
        }

        private static string GetPlanetOutputsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select PSOut.schematicID,");
            sb.AppendLine("        PSOut.schematicName,");
            sb.AppendLine("        PSOut.cycleTime,");
            sb.AppendLine("        PSTM.quantity,");
            sb.AppendLine("        PSTM.isInput,");
            sb.AppendLine("        IT.typeName,");
            sb.AppendLine("        IT.typeID,");
            sb.AppendLine("        IT.volume,");
            sb.AppendLine("        IG.groupID,");
            sb.AppendLine("        IG.groupName");
            sb.AppendLine("from planetSchematics PSOut");
            sb.AppendLine("inner join planetSchematicsTypeMap PSTM");
            sb.AppendLine("    on PSTM.schematicID = PSOut.schematicID");
            sb.AppendLine("        and isInput = 0");
            sb.AppendLine("inner join invTypes IT");
            sb.AppendLine("    on IT.typeID = PSTM.typeID");
            sb.AppendLine("        AND IT.published = 1");
            sb.AppendLine("inner join invGroups IG");
            sb.AppendLine("    on IG.groupID = IT.groupID");
            sb.AppendLine("order by PSOut.schematicName, IT.typeName");

            return sb.ToString();
        }

        private static string GetPlanetOutputBySchematicIdCommand(int schematicID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select PSOut.schematicID,");
            sb.AppendLine("        PSOut.schematicName,");
            sb.AppendLine("        PSOut.cycleTime,");
            sb.AppendLine("        PSTM.quantity,");
            sb.AppendLine("        PSTM.isInput,");
            sb.AppendLine("        IT.typeName,");
            sb.AppendLine("        IT.typeID,");
            sb.AppendLine("        IT.volume,");
            sb.AppendLine("        IG.groupID,");
            sb.AppendLine("        IG.groupName");
            sb.AppendLine("from planetSchematics PSOut");
            sb.AppendLine("inner join planetSchematicsTypeMap PSTM");
            sb.AppendLine("    on PSTM.schematicID = PSOut.schematicID");
            sb.AppendLine("        and isInput = 0");
            sb.AppendLine("inner join invTypes IT");
            sb.AppendLine("    on IT.typeID = PSTM.typeID");
            sb.AppendLine("        AND IT.published = 1");
            sb.AppendLine("inner join invGroups IG");
            sb.AppendLine("    on IG.groupID = IT.groupID");
            sb.AppendLine("where PSOut.schematicID = " + schematicID.ToString());
            sb.AppendLine("order by PSOut.schematicName, IT.typeName");

            return sb.ToString();
        }

        private static string GetInventoryTypesCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IT.typeID,");
            sb.AppendLine("    IT.typeName,");
            sb.AppendLine("    IT.[description],");
            sb.AppendLine("    IT.volume,");
            sb.AppendLine("    IT.portionSize,");
            sb.AppendLine("    IT.raceID,");
            sb.AppendLine("    IT.basePrice,");
            sb.AppendLine("    IT.marketGroupID,");
            sb.AppendLine("    IT.iconID,");
            sb.AppendLine("    IT.soundID,");
            sb.AppendLine("    IG.groupID,");
            sb.AppendLine("    IG.groupName,");
            sb.AppendLine("    IC.categoryID,");
            sb.AppendLine("    IC.categoryName,");
            sb.AppendLine("    Coalesce(IMG.parentGroupID, 0) as parentGroupID,");
            sb.AppendLine("    IMG.marketGroupName");
            sb.AppendLine("from invTypes IT");
            sb.AppendLine("inner join invGroups IG");
            sb.AppendLine("    on IG.groupID = IT.groupID");
            sb.AppendLine("inner join invCategories IC");
            sb.AppendLine("    on IC.categoryID = IG.categoryID");
            sb.AppendLine("left outer join invMarketGroups IMG");
            sb.AppendLine("    on IMG.marketGroupID = iT.marketGroupID");
            sb.AppendLine("where IT.published = 1");

            return sb.ToString();
        }

        private static string GetIndustryActivityTypesCommand(int type_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IA.typeID,");
            sb.AppendLine("        IA.activityID,");
            sb.AppendLine("        IA.time,");
            sb.AppendLine("        RA.activityName,");
            sb.AppendLine("        Coalesce(IAP.productTypeID, 0) as productTypeID,");
            sb.AppendLine("        Coalesce(pIT.typeName, '') as typeName");
            sb.AppendLine("from industryActivity IA");
            sb.AppendLine("Inner");
            sb.AppendLine("join ramActivities RA");
            sb.AppendLine("    on RA.activityID = IA.activityID");
            sb.AppendLine("LEFT OUTER join industryActivityProducts IAP");
            sb.AppendLine("    on IAP.typeID = IA.typeID");
            sb.AppendLine("        and IAP.activityID = IA.activityID");
            sb.AppendLine("LEFT OUTER join invTypes pIT");
            sb.AppendLine("    on pIT.typeID = IAP.productTypeID");
            sb.AppendLine("            AND pIT.published = 1");
            sb.AppendLine("where ia.typeID = " + type_id.ToString());
            sb.AppendLine("and Ra.published = 1");

            return sb.ToString();
        }

        private static string GetIndustryActivityMaterialsCommand(int type_id, int activity_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IAM.typeID,");
            sb.AppendLine("    IAM.activityID,");
            sb.AppendLine("    IAM.materialTypeID,");
            sb.AppendLine("    IT.typeName,");
            sb.AppendLine("    IAM.quantity,");
            sb.AppendLine("    RA.activityName,");
            sb.AppendLine("    case");
            sb.AppendLine("        when IAP.productTypeID IS NOT NULL Then 1 ");
            sb.AppendLine("        else 0");
            sb.AppendLine("    end as isManufacturable,");
            sb.AppendLine("    case");
            sb.AppendLine("        when IAP2.productTypeID IS NOT NULL Then 1");
            sb.AppendLine("        else 0");
            sb.AppendLine("    end as isReactable");
            sb.AppendLine("from industryActivityMaterials IAM");
            sb.AppendLine("Inner join invTypes IT");
            sb.AppendLine("    on IT.typeID = IAM.materialTypeID");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("Inner join ramActivities RA");
            sb.AppendLine("    on RA.activityID = IAM.activityID");
            sb.AppendLine("LEFT OUTER JOIN industryActivityProducts IAP");
            sb.AppendLine("    on IAP.productTypeID = IAM.materialTypeID");
            sb.AppendLine("        and IAP.activityID = 1");
            sb.AppendLine("LEFT OUTER JOIN industryActivityProducts IAP2");
            sb.AppendLine("    on IAP2.productTypeID = IAM.materialTypeID");
            sb.AppendLine("        and IAP2.activityID = 11");
            sb.AppendLine("where IAM.typeID = " + type_id.ToString());
            sb.AppendLine("and IAM.activityID = " + activity_id.ToString());

            return sb.ToString();
        }

        private static string GetMarketGroupsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select marketGroupID, coalesce(parentGroupID, 0) as parentGroupID, marketGroupName, description");
            sb.AppendLine("from invMarketGroups");

            return sb.ToString();
        }

        private static string GetIndustryActivitySkillsCommand(int type_id, int activity_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IAS.typeID,");
			sb.AppendLine("        IAS.activityID,");
			sb.AppendLine("        IAS.skillID,");
			sb.AppendLine("        IT.typeName,");
			sb.AppendLine("        IAS.level,");
			sb.AppendLine("        RA.activityName");
            sb.AppendLine("from industryActivitySkills IAS");
            sb.AppendLine("Inner join invTypes IT");
            sb.AppendLine("    on IT.typeID = IAS.skillID");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("Inner join ramActivities RA");
            sb.AppendLine("    on RA.activityID = IAS.activityID");
            sb.AppendLine("where IAS.typeID = " + type_id.ToString());
            sb.AppendLine("and IAS.activityID = " + activity_id.ToString());

            return sb.ToString();
        }

        private static string GetIndustryActivityProductsCommand(int type_id, int activity_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IAP.typeID,");
		    sb.AppendLine("    IAP.activityID,");
		    sb.AppendLine("    IAP.productTypeID,");
		    sb.AppendLine("    IT.typeName,");
		    sb.AppendLine("    IAP.quantity,");
		    sb.AppendLine("    RA.activityName");
	        sb.AppendLine("from industryActivityProducts IAP");
	        sb.AppendLine("Inner join invTypes IT");
		    sb.AppendLine("    on IT.typeID = IAP.productTypeID");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("Inner join ramActivities RA");
		    sb.AppendLine("    on RA.activityID = IAP.activityID");
	        sb.AppendLine("where IAP.typeID = " + type_id);
	        sb.AppendLine("and IAP.activityID = " + activity_id);

            return sb.ToString();
        }

        private static string GetSolarSystemsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select");
		    sb.AppendLine("    mss.regionID,");
		    sb.AppendLine("    mss.constellationID,");
		    sb.AppendLine("    mss.solarSystemID,");
		    sb.AppendLine("    mss.solarSystemName,");
		    sb.AppendLine("    mc.constellationName,");
		    sb.AppendLine("    mr.regionName,");
		    sb.AppendLine("    round(mss.security, 1)");
	        sb.AppendLine("from mapSolarSystems MSS");
	        sb.AppendLine("inner join mapRegions MR");
	        sb.AppendLine("on MR.regionID = MSS.regionID");
	        sb.AppendLine("inner join mapConstellations MC");
	        sb.AppendLine("on MC.constellationID = MSS.constellationID");
            sb.AppendLine("order by solarSystemName");

            return sb.ToString();
        }

        private static string GetTechIBlueprintTypeIdCommand(int type_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select typeID");
            sb.AppendLine("from industryActivityProducts");
            sb.AppendLine("where productTypeID = " + type_id.ToString());
            sb.AppendLine("and activityID = 8");
            
            return sb.ToString();
        }

        private static string GetBlueprintByProductTypeIDCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IAP.typeID");
            sb.AppendLine("from industryActivityProducts IAP");
            sb.AppendLine("INNER JOIN invTypes IT ");
            sb.AppendLine("    ON IT.typeID = IAP.typeID ");
            sb.AppendLine("        AND IT.published = 1");
            sb.AppendLine("where productTypeID = " + typeID.ToString());

            return sb.ToString();
        }

        private static string GetInventionProbabilitiesCommand(int typeID, int activityID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select IAP.typeID, IAP.productTypeID, IAP.probability");
            sb.AppendLine("from industryActivityProbabilities IAP");
            sb.AppendLine("Inner join invTypes IT	");
            sb.AppendLine("    on IT.typeID = IAP.productTypeID");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("where IAP.typeID = " + typeID.ToString());
            sb.AppendLine("and IAP.activityID = " + activityID.ToString());

            return sb.ToString();
        }

        private static string IsBlueprintInventedCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select 1 as invented");
            sb.AppendLine("from industryActivityProducts");
            sb.AppendLine("where productTypeID = " + typeID);
            sb.AppendLine("and activityID = 8");

            return sb.ToString();
        }

        private static string GetMarketGroupForBlueprintTypeIDCommand(int typeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select Coalesce(IT.marketGroupID, 0) as marketGroupID from industryActivityProducts IAP");
            sb.AppendLine("Inner join invTypes IT");
            sb.AppendLine("on IT.typeID = IAP.productTypeID");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("where IAP.typeID = " + typeID.ToString());
            sb.AppendLine("and (IAP.activityID = 1 or IAP.activityID = 11)");

            return sb.ToString();
        }

        private static string GetSolarSystemsForRegionIDCommand(int regionID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT solarSystemName, solarSystemID");
            sb.AppendLine("FROM mapSolarSystems");
	        sb.AppendLine("WHERE regionID = " + regionID.ToString());
            sb.AppendLine("ORDER BY solarSystemName");

            return sb.ToString();
        }

        private static string GetStationNameFromStationIDCommand(long stationID)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select stationID, stationName");
            sb.AppendLine("from staStations");
            sb.AppendLine("where stationID = " + stationID.ToString());

            return  sb.ToString();
        }

        private static string GetFilamentTypesForDropDownCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select typeID, typeName from invTypes");
            sb.AppendLine("where groupID = 1979");
            sb.AppendLine("            AND published = 1");
            sb.AppendLine("order by typeName");

            return sb.ToString();
        }

        private static string LoadIndustryProductsCommand()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("select it.typeID, it.typeName");
            sb.AppendLine("from invTypes IT");
            sb.AppendLine("inner join industryActivityProducts IAP");
            sb.AppendLine("on IAP.productTypeID = it.typeID");
            sb.AppendLine("where IAP.activityID in (1, 7, 11)");
            sb.AppendLine("            AND IT.published = 1");
            sb.AppendLine("order by it.typeName");

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
                    activityType.activityID = query.GetInt32(1);
                    activityType.time = query.GetInt64(2);
                    activityType.activityName = query.GetString(3);
                    activityType.productTypeId = query.GetInt32(4);
                    activityType.productName = query.GetString(5);
                    industryActivityTypes.Add(activityType);
                }
            }

            return industryActivityTypes;
        }

        public static List<EveHelperWF.Objects.IndustryActivityMaterials> GetIndustryActivityMaterials(int type_id, int activity_id)
        {
            List<EveHelperWF.Objects.IndustryActivityMaterials> industryActivityMaterials = new List<Objects.IndustryActivityMaterials>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivityMaterialsCommand(type_id, activity_id), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivityMaterials activityMaterial;
                while (query.Read())
                {
                    activityMaterial = new IndustryActivityMaterials();
                    activityMaterial.typeID = query.GetInt32(0);
                    activityMaterial.activityID = query.GetInt32(1);
                    activityMaterial.materialTypeID = query.GetInt32(2);
                    activityMaterial.materialName = query.GetString(3);
                    activityMaterial.quantity = query.GetInt32(4);
                    activityMaterial.activityName = query.GetString(5);
                    activityMaterial.isManufacturable = query.GetBoolean(6);
                    activityMaterial.isReactable = query.GetBoolean(7);
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

        public static List<Objects.IndustryActivitySkill> GetINdustryActivitySkills(int type_id, int activity_id)
        {
            List<EveHelperWF.Objects.IndustryActivitySkill> activitySkills = new List<Objects.IndustryActivitySkill>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivitySkillsCommand(type_id, activity_id), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivitySkill activitySkill;
                while (query.Read())
                {
                    activitySkill = new IndustryActivitySkill();
                    activitySkill.typeID = query.GetInt32(0);
                    activitySkill.activityID = query.GetInt32(1);
                    activitySkill.skillID = query.GetInt32(2);
                    activitySkill.skillName = query.GetString(3);
                    activitySkill.level = query.GetInt32(4);
                    activitySkill.activityName = query.GetString(5);
                    activitySkills.Add(activitySkill);
                }
            }

            return activitySkills;
        }

        public static List<Objects.IndustryActivityProduct> GetIndustryActivityProducts(int type_id, int activity_id)
        {
            List<EveHelperWF.Objects.IndustryActivityProduct> activityProducts = new List<Objects.IndustryActivityProduct>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetIndustryActivityProductsCommand(type_id, activity_id), db);

                SqliteDataReader query = command.ExecuteReader();

                IndustryActivityProduct activityProduct;
                while (query.Read())
                {
                    activityProduct = new IndustryActivityProduct();
                    activityProduct.typeID = query.GetInt32(0);
                    activityProduct.activityID = query.GetInt32(1);
                    activityProduct.productTypeID = query.GetInt32(2);
                    activityProduct.productName = query.GetString(3);
                    activityProduct.quantity =  query.GetInt32(4);
                    activityProduct.activityName = query.GetString(5);
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

        public static List<Objects.InventionProbability> GetInventionProbabilities(int type_id, int activity_id)
        {
            List<Objects.InventionProbability> probabilityList = new List<Objects.InventionProbability>();

            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetInventionProbabilitiesCommand(type_id, activity_id), db);

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

        public static int GetMarketGroupForBlueprintTypeID(int type_id)
        {
            int marketGroupID = 0;


            string dbpath = GetSQLitePath();
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand command = new SqliteCommand(GetMarketGroupForBlueprintTypeIDCommand(type_id), db);

                SqliteDataReader query = command.ExecuteReader();

                while (query.Read())
                {
                    marketGroupID = query.GetInt32(0);
                    break;
                }
            }

            return marketGroupID;
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

            string queryCommand = "select solarSystemID from mapSolarSystems mss inner join mapRegions mr on mr.regionID = mss.regionID where regionName NOT like 'ADR0%'";

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

            string queryCommand = "SELECT solarSystemID FROM mapDenormalize WHERE typeID = " + planetTypeID.ToString();

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

            sb.AppendLine("select solarSystemID from mapSolarSystems mss");
            sb.AppendLine("    inner join mapRegions MR");
            sb.AppendLine("        on MR.regionId = mss.regionID");
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

            string queryCommand = "select solarSystemID from mapSolarSystems where regionID = 10000070";

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

            string queryCommand = "select solarSystemID from staStations";

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

            string queryCommand = "select solarSystemID from mapSolarSystems\r\nwhere round(security, 1) >= " + min_security.ToString() + "\r\nand round(security, 1) <= " + max_security.ToString();

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

            string queryCommand = "select solarSystemID from mapSolarSystems where regionID = " + regionId.ToString();

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

            string queryCommand = "select solarSystemID from mapSolarSystems where solarSystemName like '%' ||" + systemName + "|| '%'";

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
