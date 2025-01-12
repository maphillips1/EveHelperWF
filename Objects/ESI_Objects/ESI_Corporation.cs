using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class ESI_Corporation
    {
        [JsonProperty("alliance_id")]
        public long AllianceId { get; set; }

        [JsonProperty("ceo_id")]
        public long CeoId { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("date_founded")]
        public DateTime DateFounded { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("home_station_id")]
        public long HomeStationId { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shares")]
        public int Shares { get; set; }

        [JsonProperty("tax_rate")]
        public double TaxRate { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("war_eligible")]
        public bool WarEligible { get; set; }
    }
}
