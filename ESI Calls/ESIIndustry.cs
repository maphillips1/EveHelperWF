using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIIndustry
    {
        public const string ActivityManufacturing = "manufacturing";
        public const string ActivityCopying = "copying";
        public const string ActivityInvention = "invention";
        public const string ActivityReaction = "reaction";
        public const string ActivityTEResearch = "researching_time_efficiency";
        public const string ActivityMEResearch = "researching_material_efficiency";

        public const string CachedCostIndicesFileName = @"cost_indicies.json";
        
        private static List<EveHelperWF.Objects.CostIndice> costIndices;

        public static List<EveHelperWF.Objects.CostIndice> GetCostIndices()
        {
            if (costIndices == null)
            {
                costIndices = GetCachedCostIndicies();

                if (costIndices == null || costIndices.Count == 0)
                {
                    string uri = "https://esi.evetech.net/latest/industry/systems/?datasource=tranquility";
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    System.Net.Http.HttpResponseMessage response = client.GetAsync(uri).Result;

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string indices = response.Content.ReadAsStringAsync().Result;
                        costIndices = JsonConvert.DeserializeObject<List<EveHelperWF.Objects.CostIndice>>(indices);
                        CacheCostIndicies(costIndices);
                    }
                }
            }

            return costIndices;
        }

        private static void CacheCostIndicies(List<EveHelperWF.Objects.CostIndice> costIndices)
        {
            EveHelperWF.Objects.CachedCostIndices cachedCostIndices = new EveHelperWF.Objects.CachedCostIndices();
            cachedCostIndices.cachedTime = System.DateTime.Now;
            cachedCostIndices.cost_indices = costIndices;

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(cachedCostIndices);
            string directory = Enums.Enums.CachedCostIndicesDirectory;
            string fileName = string.Concat(directory, CachedCostIndicesFileName);
            FileIO.FileHelper.SaveCachedFile(directory, fileName, content);
        }

        private static List<EveHelperWF.Objects.CostIndice> GetCachedCostIndicies()
        {
            List<EveHelperWF.Objects.CostIndice> costIndices = new List<EveHelperWF.Objects.CostIndice>();

            string directory = Enums.Enums.CachedCostIndicesDirectory;
            string fileName = string.Concat(directory, CachedCostIndicesFileName);
            string cachedContent = FileIO.FileHelper.GetCachedFileContent(directory, fileName);
            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                EveHelperWF.Objects.CachedCostIndices cachedCostIndices = new EveHelperWF.Objects.CachedCostIndices();
                cachedCostIndices = Newtonsoft.Json.JsonConvert.DeserializeObject<EveHelperWF.Objects.CachedCostIndices>(cachedContent);
                if (cachedCostIndices != null)
                {
                    //If the cache is older than 60 minutes, refresh.
                    if (cachedCostIndices.cachedTime > System.DateTime.Now.AddMinutes(-5))
                    {
                        costIndices = cachedCostIndices.cost_indices;
                    }
                    else
                    {
                        costIndices = null;
                    }
                }
            }

            return costIndices;
        }

        public static EveHelperWF.Objects.CostIndice GetCostIndicesForSystem(int solar_system_id)
        {
            EveHelperWF.Objects.CostIndice costIndice = null;

            List<EveHelperWF.Objects.CostIndice> indices = GetCostIndices();

            costIndice = indices.Find(x => x.solar_system_id == solar_system_id);

            return costIndice;
        }

        public static EveHelperWF.Objects.CostIndiceActivity GetIndiceActivity(Int64 solar_system_id, string activity)
        {
            EveHelperWF.Objects.CostIndiceActivity costIndiceActivity = null;

            List<EveHelperWF.Objects.CostIndice> indices = GetCostIndices();

            EveHelperWF.Objects.CostIndice indicie = indices.Find(x => x.solar_system_id == solar_system_id);

            if (indicie != null)
            {
                costIndiceActivity = indicie.cost_indices.Find(x => x.activity == activity);
            }

            return costIndiceActivity;
        }
    }
}
