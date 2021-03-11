using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PowerplantDelivery
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("p")]
        public string Power { get; set; }
    }
}
