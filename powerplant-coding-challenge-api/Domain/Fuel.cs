using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Fuel
    {
        [JsonProperty("gas(euro/MWh)")]
        public double GasEuroMWh { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        public double KerosineEuroMWh { get; set; }

        [JsonProperty("co2(euro/ton)")]
        public double Co2EuroTon { get; set; }

        [JsonProperty("wind(%)")]
        public double Wind { get; set; }
    }
}
