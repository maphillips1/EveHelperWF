using FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESICorporation
    {
        static string baseURL = "https://esi.evetech.net/latest/corporations/";
        static string datasource = "/?datasource=tranquility";

        public static Objects.ESI_Objects.ESI_Corporation LoadCorporationById(long id)
        {
            Objects.ESI_Objects.ESI_Corporation esiCorporation = new Objects.ESI_Objects.ESI_Corporation();
            string fullURL = string.Concat(baseURL, id.ToString(), datasource);

            try
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync(fullURL).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                    string corpResponse = response.Content.ReadAsStringAsync().Result;
                    esiCorporation = JsonConvert.DeserializeObject < Objects.ESI_Objects.ESI_Corporation>(corpResponse);
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogError(ex.Message, ex.StackTrace);
            }

            return esiCorporation;
        }
    }
}
