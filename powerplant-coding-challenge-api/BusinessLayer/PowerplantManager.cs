using BusinessLayer.interfaces;
using Domain;
using Domain.Const;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PowerplantManager : IPowerplantManager
    {
        Dictionary<string, List<Powerplant>> standardPowerplantOrderDictionnary = new Dictionary<string, List<Powerplant>> {
                { PowerplantType.WINDTURBINE, new List<Powerplant>() },
                { PowerplantType.GASFIRED, new List<Powerplant>() },
                { PowerplantType.TURBOJET, new List<Powerplant>() }
            };

        public List<Powerplant> SortPowerplantByType(List<Powerplant> powerplants)
        {
            standardPowerplantOrderDictionnary[PowerplantType.WINDTURBINE].AddRange(powerplants.Where(p => p.Type == PowerplantType.WINDTURBINE).ToList());
            standardPowerplantOrderDictionnary[PowerplantType.GASFIRED].AddRange(powerplants.Where(p => p.Type == PowerplantType.GASFIRED).ToList());
            standardPowerplantOrderDictionnary[PowerplantType.TURBOJET].AddRange(powerplants.Where(p => p.Type == PowerplantType.TURBOJET).ToList());

            var orderedPowerplants = new List<Powerplant>();
            foreach (var p in standardPowerplantOrderDictionnary.Values)
                orderedPowerplants.AddRange(p);

            return orderedPowerplants;
        }

        public List<Powerplant> SortPowerplantByFuelCost(List<Powerplant> powerplants, Fuel fuel)
        {
            Dictionary<string, List<Powerplant>> fuels = new Dictionary<string, List<Powerplant>>();
            Dictionary<string, double> fuelByPrice = new Dictionary<string, double>
            {
                { PowerplantType.WINDTURBINE, (double)Constants.WIND_PRODUCER_COST },
                { PowerplantType.GASFIRED,fuel.GasEuroMWh },
                { PowerplantType.TURBOJET, fuel.KerosineEuroMWh }
            };
             fuelByPrice = fuelByPrice.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var key in fuelByPrice.Keys)
            {
                fuels.Add(key, powerplants.Where(p => p.Type == key).ToList());
            }

            var orderedPowerplants = new List<Powerplant>();
            foreach (var p in fuels.Values)
                orderedPowerplants.AddRange(p);

            return orderedPowerplants;
        }

        public List<Powerplant> SortPowerplantByCo2Emission(List<Powerplant> powerplants, Fuel fuel)
        {
            Dictionary<string, List<Powerplant>> fuels = new Dictionary<string, List<Powerplant>>();
            Dictionary<string, double> fuelByPrice = new Dictionary<string, double>
            {
                { PowerplantType.WINDTURBINE, (double)Constants.WIND_PRODUCER_COST },
                { PowerplantType.GASFIRED,fuel.GasEuroMWh },
                { PowerplantType.TURBOJET, fuel.KerosineEuroMWh }
            };
            fuelByPrice = fuelByPrice.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var key in fuelByPrice.Keys)
            {
                fuels.Add(key, powerplants.Where(p => p.Type == key).ToList());
            }

            var orderedPowerplants = new List<Powerplant>();
            foreach (var p in fuels.Values)
                orderedPowerplants.AddRange(p);

            return orderedPowerplants;
        }


        public List<IEnergyProducer> InitializePowerplantProcessers(Payload payload)
        {
            if (payload == null) return null;
            if (payload.Fuels == null) return null;
            if (payload.Powerplants == null) return null;

            var powerplantsProcessers = new List<IEnergyProducer>();
            var orderedPowerplants = SortPowerplantByFuelCost(new List<Powerplant>(payload.Powerplants), payload.Fuels);

            foreach (var powerplant in orderedPowerplants)
            {
                var processer = GetProcessing(powerplant, payload.Fuels);
                if (processer != null) powerplantsProcessers.Add(processer);
            }
            return powerplantsProcessers;
        }

        private IEnergyProducer GetProcessing(Powerplant powerplant, Fuel fuel)
        {
            switch (powerplant.Type)
            {
                case PowerplantType.GASFIRED: return new GasProducer(powerplant, fuel);
                case PowerplantType.TURBOJET: return new TurboProducer(powerplant, fuel);
                case PowerplantType.WINDTURBINE: return new WindProducer(powerplant, fuel);
                default: break;
            }
            return null;
        }

    }
}
