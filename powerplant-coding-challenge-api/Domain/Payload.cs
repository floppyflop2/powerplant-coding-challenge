using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain
{
    [JsonObject]
    public class Payload
    {
        [JsonProperty(PropertyName = "load")]
        public int Load { get; set; }

        [JsonProperty(PropertyName = "fuels")]
        public Fuel Fuels { get; set; }

        [JsonProperty(PropertyName = "powerplants")]
        public Powerplant[] Powerplant { get; set; }

    }
}
