﻿using Newtonsoft.Json;
using System;

namespace EveHelperWF.Objects.ESI_Objects
{
    public class ESICharacter
    {
        [JsonProperty("alliance_id")]
        public long AllianceId { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("bloodline_id")]
        public int BloodlineId { get; set; }

        [JsonProperty("corporation_id")]
        public long CorporationId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("race_id")]
        public int RaceId { get; set; }

        [JsonProperty("security_status")]
        public double SecurityStatus { get; set; }
    }
}