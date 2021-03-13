using BusinessLayer.interfaces;
using Domain;
using Domain.Enum;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PowerplantManager : IPowerplantManager
    {
        Dictionary<string, List<Powerplant>> standardPowerplantOrderDictionnary = new Dictionary<string, List<Powerplant>> {
                { PowerplantType.WINDTURBINE, new List<Powerplant>() },
                { PowerplantType.GASFIRED, new List<Powerplant>() },
                { PowerplantType.TURBOJET, new List<Powerplant>() },
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

        public List<IEnergyProducer> InitializePowerplantProcesser(List<Powerplant> powerplants, Fuel fuel)
        {
            var powerplantsProcessers = new List<IEnergyProducer>();

            foreach (var powerplant in powerplants)
            {
                var processer = GetProcessing(powerplant, fuel);
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
