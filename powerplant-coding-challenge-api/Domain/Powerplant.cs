using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Powerplant
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("efficiency")]
        public double Efficency { get; set; }

        [JsonProperty("pmin")]
        public int Pmin { get; set; }

        [JsonProperty("pmax")]
        public int Pmax { get; set; }
    }
}
