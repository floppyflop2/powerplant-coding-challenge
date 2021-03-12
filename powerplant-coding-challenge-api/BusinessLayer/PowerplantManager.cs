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
                { PowerPlantType.WINDTURBINE, new List<Powerplant>() },
                { PowerPlantType.GASFIRED, new List<Powerplant>() },
                { PowerPlantType.TURBOJET, new List<Powerplant>() },
            };


        public List<Powerplant> SortPowerplantByType(List<Powerplant> powerplants)
        {
            standardPowerplantOrderDictionnary[PowerPlantType.WINDTURBINE].AddRange(powerplants.Where(p => p.Type == PowerPlantType.WINDTURBINE).ToList());
            standardPowerplantOrderDictionnary[PowerPlantType.GASFIRED].AddRange(powerplants.Where(p => p.Type == PowerPlantType.GASFIRED).ToList());
            standardPowerplantOrderDictionnary[PowerPlantType.TURBOJET].AddRange(powerplants.Where(p => p.Type == PowerPlantType.TURBOJET).ToList());

            var orderedPowerplants = new List<Powerplant>();
            foreach (var p in standardPowerplantOrderDictionnary.Values)
                orderedPowerplants.AddRange(p);

            return orderedPowerplants;
        }

        public List<IEnergyProcessing> InitializePowerplantProcesser(List<Powerplant> powerplants, Fuel fuel)
        {
            var powerplantsProcessers = new List<IEnergyProcessing>();

            foreach (var powerplant in powerplants)
            {
                var processer = GetProcessing(powerplant, fuel);
                if (processer != null) powerplantsProcessers.Add(processer);
            }
            return powerplantsProcessers;
        }

        private IEnergyProcessing GetProcessing(Powerplant powerplant, Fuel fuel)
        {
            switch (powerplant.Type)
            {
                case PowerPlantType.GASFIRED: return new GasPowerplant(powerplant, fuel);
                case PowerPlantType.TURBOJET: return new TurboPowerplant(powerplant, fuel);
                case PowerPlantType.WINDTURBINE: return new WindPowerplant(powerplant, fuel);
                default: break;
            }
            return null;
        }
    }
}
