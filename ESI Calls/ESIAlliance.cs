using FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIAlliance
    {
        static string baseURL = "https://esi.evetech.net/latest/alliances/";
        static string datasource = "/?datasource=tranquility";

        public static Objects.ESI_Objects.ESI_Alliance LoadAllianceById(long id)
        {
            Objects.ESI_Objects.ESI_Alliance esiAlliance = new Objects.ESI_Objects.ESI_Alliance();
            string fullURL = string.Concat(baseURL, id.ToString(), datasource);

            try
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync(fullURL).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                    string allianceResponse = response.Content.ReadAsStringAsync().Result;
                    esiAlliance = JsonConvert.DeserializeObject<Objects.ESI_Objects.ESI_Alliance>(allianceResponse);
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogError(ex.Message, ex.StackTrace);
            }

            return esiAlliance;
        }
    }
}
