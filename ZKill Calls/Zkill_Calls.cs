using EveHelperWF.Objects.ZKill_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ZKill_Calls
{
    public static class Zkill_Calls
    {
        static string baseUrl = "https://zkillboard.com/api/";

        public static List<Killmail> LoadCharacterKills(long characterId)
        {
            List<Killmail> killmails = new List<Killmail>();

            List<Killmail> tempKillmails = new List<Killmail>();

            for (int i = 1; i < 21; i++)
            {
                string url = baseUrl + "kills/characterID/" + characterId.ToString() + "/page/" + i + "/";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    tempKillmails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Killmail>>(content);
                    if (tempKillmails?.Count > 0)
                    {
                        killmails.AddRange(tempKillmails);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return killmails;
        }

        public static List<Killmail> LoadCharacterLosses(long characterId)
        {
            List<Killmail> killmails = new List<Killmail>();

            List<Killmail> tempKillmails = new List<Killmail>();

            for (int i = 1; i < 21; i++)
            {
                string url = baseUrl + "losses/characterID/" + characterId.ToString() + "/page/" + i + "/";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    tempKillmails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Killmail>>(content);
                    if (tempKillmails?.Count > 0)
                    {
                        killmails.AddRange(tempKillmails);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return killmails;
        }

        public static ZKillStats LoadStats(string entityType, long entityID)
        {
            ZKillStats stats = new ZKillStats();
            string url = baseUrl + "stats/" + entityType + "/" + entityID.ToString() + "/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;


            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                stats = Newtonsoft.Json.JsonConvert.DeserializeObject<ZKillStats>(content);
            }
            return stats;
        }
    }
}
