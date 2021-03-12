using BusinessLayer.interfaces;
using Domain;
using Domain.Enum;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PowerCalculator : IPowerCalculator
    {
        Dictionary<string, List<Powerplant>> standardPowerplantOrderDictionnary = new Dictionary<string, List<Powerplant>> {
                { PowerPlantType.WINDTURBINE, new List<Powerplant>() },
                { PowerPlantType.GASFIRED, new List<Powerplant>() },
                { PowerPlantType.TURBOJET, new List<Powerplant>() },
            };

        //The priority order depending of the type is hardcoded I should find a better way 
        public List<Powerplant> SortPowerPlant(List<Powerplant> powerplants)
        {
            standardPowerplantOrderDictionnary[PowerPlantType.WINDTURBINE].AddRange(powerplants.Where(p => p.Type == PowerPlantType.WINDTURBINE).ToList());
            standardPowerplantOrderDictionnary[PowerPlantType.GASFIRED].AddRange(powerplants.Where(p => p.Type == PowerPlantType.GASFIRED).ToList());
            standardPowerplantOrderDictionnary[PowerPlantType.TURBOJET].AddRange(powerplants.Where(p => p.Type == PowerPlantType.TURBOJET).ToList());

            var orderedPowerplants = new List<Powerplant>();
            foreach (var p in standardPowerplantOrderDictionnary.Values)
                orderedPowerplants.AddRange(p);

            return orderedPowerplants;
        }
    }
}
