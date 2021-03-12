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
        Fuel _fuel;

        public Fuel Fuel { get => _fuel; set => _fuel = value; }
        public Powerplant Powerplant { get => _powerplant; set => _powerplant = value; }

        public WindPowerplant(Powerplant powerplant, Fuel fuel)
        {
            _powerplant = powerplant;
            _fuel = fuel;
        }

        public ProductionPlan Perform(Powerplant powerplant)
        {
            var productionPlan = new ProductionPlan();

            return productionPlan;
        }
    }
}
