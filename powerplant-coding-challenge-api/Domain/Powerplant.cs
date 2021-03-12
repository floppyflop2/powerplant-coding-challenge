using Domain.Enum;
using Newtonsoft.Json;

namespace Domain
{
    [JsonObject]
    public class Powerplant
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "efficiency")]
        public double Efficency { get; set; }

        [JsonProperty(PropertyName = "pmin")]
        public int Pmin { get; set; }

        [JsonProperty(PropertyName = "pmax")]
        public int Pmax { get; set; }
    }
}
