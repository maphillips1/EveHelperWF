using EveHelperWF.Database;
using EveHelperWF.Objects;
using EveHelperWF.Objects.ESI_Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.ESI_Calls
{
    public static class ESILoyalty
    {
        public static List<ESILPOffer> GetCorpLPOffers(long npcCorpId)
        {
            List<ESILPOffer> offers = new List<ESILPOffer>();


            string uri = string.Format("https://esi.evetech.net/latest/loyalty/stores/{0}/offers/?datasource=tranquility", npcCorpId.ToString());
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response != null && response.IsSuccessStatusCode)
            {
                string offerResponse = response.Content.ReadAsStringAsync().Result;
                offers = JsonConvert.DeserializeObject<List<ESILPOffer>>(offerResponse);

                foreach (ESILPOffer offer in offers)
                {
                    if (offer.type_id > 0)
                    {
                        offer.typeName = SQLiteCalls.GetTypeNameForTypeID(offer.type_id);
                        if (offer.required_items?.Count > 0)
                        {
                            foreach (ESILPOfferRequiredItem item in offer.required_items)
                            {
                                if (item.type_id > 0)
                                {
                                    item.typeName = SQLiteCalls.GetTypeNameForTypeID(item.type_id);
                                }
                            }
                        }
                    }
                }
            }

            if (offers == null)
            {
                offers = new List<ESILPOffer>();
            }

            return offers;
        }
    }
}
