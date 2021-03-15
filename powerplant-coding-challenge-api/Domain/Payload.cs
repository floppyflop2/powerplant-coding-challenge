using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain
{
    [JsonObject]
    public class Payload
    {
        [JsonProperty(PropertyName = "load", Required= Required.Always)]
        public int Load { get; set; }

        [JsonProperty(PropertyName = "fuels", Required = Required.Always)]
        public Fuel Fuels { get; set; }

        [JsonProperty(PropertyName = "powerplants", Required = Required.Always)]
        public Powerplant[] Powerplants { get; set; }

    }
}
