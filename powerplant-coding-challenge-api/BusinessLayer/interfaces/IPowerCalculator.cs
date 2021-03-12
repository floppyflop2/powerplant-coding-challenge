using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IPowerCalculator
    {
        List<Powerplant> SortPowerPlant(List<Powerplant> powerplants);
    }
}
