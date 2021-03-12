using Newtonsoft.Json;

namespace Domain
{
    public class ProductionPlan
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "p")]
        public string Power { get; set; }
    }
}
