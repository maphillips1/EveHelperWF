using EveHelperWF.Objects.ESI_Objects.KillMail;
using EveHelperWF.Objects.ESI_Objects.Market_Objects;
using EveHelperWF.Objects.ZKill_Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESIKillMail
    {
        private static string baseURL = "https://esi.evetech.net/latest/killmails/";
        private static string urlDataSource = "?datasource=tranquility";

        public static async Task<List<ESI_KillMail>> ConvertZkillToESIKillMails(List<Killmail> zKillMails)
        {
            List<ESI_KillMail> killmails = new List<ESI_KillMail>();

            List<Task<ESI_KillMail>> tasks = new List<Task<ESI_KillMail>>();

            foreach (Killmail killmail in zKillMails)
            {
                tasks.Add(LoadKillMail(killmail.killmail_id, killmail.zkb.hash));
            }
            ESI_KillMail[] results = await Task.WhenAll(tasks).ConfigureAwait(false);

            killmails.AddRange(results);

            return killmails;
        }

        public static async Task<ESI_KillMail> LoadKillMail(long killmailId, string hash)
        {
            ESI_KillMail killMail = new ESI_KillMail();

            string fullURL = baseURL + killmailId + "/" + hash + "/" + urlDataSource;

            //10 retries
            for (int i = 0; i < 10; i++)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(fullURL).ConfigureAwait(false);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = responseMessage.Content.ReadAsStringAsync().Result;
                    killMail = Newtonsoft.Json.JsonConvert.DeserializeObject<ESI_KillMail>(content);
                    Debug.WriteLine("Finished Call");
                    break;
                }
            }

            return killMail;
        }
    }
}
