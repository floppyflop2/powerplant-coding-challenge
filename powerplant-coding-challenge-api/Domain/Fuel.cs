using Newtonsoft.Json;

namespace Domain
{
    [JsonObject]
    public class Fuel
    {
        [JsonProperty(PropertyName = "gas(euro/MWh)")]
        public double GasEuroMWh { get; set; }

        [JsonProperty(PropertyName = "kerosine(euro/MWh)")]
        public double KerosineEuroMWh { get; set; }

        [JsonProperty(PropertyName = "co2(euro/ton)")]
        public double Co2EuroTon { get; set; }

        [JsonProperty(PropertyName = "wind(%)")]
        public double Wind { get; set; }
    }
}
