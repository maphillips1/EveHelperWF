using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIUniverse
    {

        public static string SearchUniverseFindIDs(string searchText)
        {
            string responseString = "";
            List<string> searchStringList = new List<string> { searchText };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(searchStringList);

            string url = "https://esi.evetech.net/latest/universe/ids/?datasource=tranquility&language=en";

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            return responseString;
        }
    }
}