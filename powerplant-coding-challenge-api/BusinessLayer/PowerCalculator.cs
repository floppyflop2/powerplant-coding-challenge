using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class PowerCalculator : IPowerCalculator
    {

        public List<Powerplant> SortPowerPlant(List<Powerplant> powerplants)
        {
            Dictionary<string, Powerplant> powerplantDictionnary = new Dictionary<string, Powerplant>();
        }
    }
}
