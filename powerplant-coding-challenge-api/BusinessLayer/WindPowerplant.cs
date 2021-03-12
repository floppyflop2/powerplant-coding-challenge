using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class WindPowerplant : IEnergyProcessing
    {
        Powerplant _powerplant;
        public Powerplant Powerplant { get => _powerplant; set => _powerplant = value; }

        public WindPowerplant(Powerplant powerplant)
        {
            _powerplant = powerplant;
        }

        public ProductionPlan Perform(Powerplant powerplant)
        {
            throw new NotImplementedException();
        }
    }
}
