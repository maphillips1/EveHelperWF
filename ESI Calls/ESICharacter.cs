using EveHelperWF.Objects;
using FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESICharacter
    {
        static string baseURL = "https://esi.evetech.net/latest/characters/";
        static string datasource = "/?datasource=tranquility";

        public static Objects.ESI_Objects.ESICharacter LoadCharacterForId(long characterId)
        {
            Objects.ESI_Objects.ESICharacter eSICharacter = new Objects.ESI_Objects.ESICharacter();
            string fullURL = string.Concat(baseURL, characterId.ToString(), datasource);

            try
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync(fullURL).Result;

                if (response != null && response.IsSuccessStatusCode)
                {
                    string charResponse = response.Content.ReadAsStringAsync().Result;
                    eSICharacter = JsonConvert.DeserializeObject<Objects.ESI_Objects.ESICharacter>(charResponse);
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogError(ex.Message, ex.StackTrace);
            }

            return eSICharacter;
        }
    }
}
