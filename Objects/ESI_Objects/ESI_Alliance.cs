using Newtonsoft.Json;
using System;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class ESI_Alliance
    {
        [JsonProperty("creator_corporation_id")]
        public long CreatorCorporationId { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("date_founded")]
        public DateTime DateFounded { get; set; }

        [JsonProperty("executor_corporation_id")]
        public long ExecutorCorporationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }
    }
}
