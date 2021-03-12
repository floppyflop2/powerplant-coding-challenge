using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class TurboPowerplant : IEnergyProcessing
    {
        Powerplant _powerplant;
        Fuel _fuel;
   
        public Fuel Fuel { get => _fuel; set => _fuel = value; }
        public Powerplant Powerplant { get => _powerplant; set => _powerplant = value; }

        public TurboPowerplant(Powerplant powerplant, Fuel fuel)
        {
            _powerplant = powerplant;
            Fuel = fuel;
        }

        public ProductionPlan Perform(Powerplant powerplant)
        {
            throw new NotImplementedException();
        }
    }
}
