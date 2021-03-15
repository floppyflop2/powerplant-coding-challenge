using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IPowerplantManager
    {
        List<Powerplant> SortPowerplantByType(List<Powerplant> powerplants);
        List<IEnergyProducer> InitializePowerplantProcessers(Payload payload);
        List<Powerplant> SortPowerplantByFuelCost(List<Powerplant> powerplants, Fuel fuel);
        List<Powerplant> SortPowerplantByCo2Emission(List<Powerplant> powerplants, Fuel fuel);
    }
}
