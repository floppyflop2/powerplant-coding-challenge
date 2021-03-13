using BusinessLayer.interfaces;
using Domain;
using Domain.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class GasProducer : IEnergyProducer
    {
        Powerplant _powerplant;
        Fuel _fuel;

        public Fuel Fuel { get => _fuel; set => _fuel = value; }
        public Powerplant Powerplant { get => _powerplant; set => _powerplant = value; }

        public GasProducer(Powerplant powerplant, Fuel fuel)
        {
            _powerplant = powerplant;
            _fuel = fuel;
        }

        public ProductionPlan Perform(ref int load, out double price)
        {
            //2Gas for 1 electricity
            price = CalculateProductionCost(load);
            var productionPlan = ReduceLoad(ref load);
            return productionPlan;
        }

        public ProductionPlan ReduceLoad(ref int load)
        {
            ProductionPlan productionPlan = new ProductionPlan
            {
                Name = Powerplant.Name
            };

            if (load < _powerplant.Pmax)
            {
                productionPlan.Power = load;
                load = 0;
            }
            else
            {
                productionPlan.Power = Powerplant.Pmax;
                load = load - Powerplant.Pmax;
            }

            return productionPlan;
        }

        public double CalculateProductionCost(int load)
        {
            double price;
            if (load == 0) return 0;
            var powerForOneUnit = (Constants.GAS_UNITS_FOR_ONE_ELECTRICITY / Powerplant.Efficiency) / Constants.GAS_UNITS_FOR_ONE_ELECTRICITY;
            var priceForOneUnit = powerForOneUnit * Fuel.GasEuroMWh;

            if (load < Powerplant.Pmax)
                price = priceForOneUnit * load;
            else price = Powerplant.Pmax * priceForOneUnit;

            return Math.Round(price, 2);
        }
    }
}
