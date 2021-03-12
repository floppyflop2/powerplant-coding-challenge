using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IPowerplantManager
    {
        List<Powerplant> SortPowerplantByType(List<Powerplant> powerplants);
    }
}
