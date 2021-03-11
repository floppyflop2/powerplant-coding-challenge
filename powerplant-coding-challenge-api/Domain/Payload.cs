using System;
using System.Collections.Generic;

namespace Domain
{
    public class Payload
    {
        public Load EnergyAmount { get; set; }

        public List<Fuel> Fuels { get; set; }

        public List<Powerplant> Powerplant { get; set; }

    }
}
