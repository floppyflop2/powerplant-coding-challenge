using BusinessLayer.interfaces;
using Domain;
using Domain.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class TurboProducer : IEnergyProducer
    {
        Powerplant _powerplant;
        Fuel _fuel;

        public Fuel Fuel { get => _fuel; set => _fuel = value; }
        public Powerplant Powerplant { get => _powerplant; set => _powerplant = value; }

        public TurboProducer(Powerplant powerplant, Fuel fuel)
        {
            _powerplant = powerplant;
            Fuel = fuel;
        }

        public ProductionPlan Perform(ref int load, out double price)
        {
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

            if (load == 0) productionPlan.Power = 0;
            else if (load < _powerplant.Pmax)
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
            var powerForOneUnit = (Constants.KEROSINE_UNITS_FOR_ONE_ELECTRICITY / Powerplant.Efficiency) / Constants.KEROSINE_UNITS_FOR_ONE_ELECTRICITY;
            var priceForOneUnit = powerForOneUnit * Fuel.KerosineEuroMWh;

            if (load < Powerplant.Pmax)
                price = priceForOneUnit * load;
            else price = Powerplant.Pmax * priceForOneUnit;

            return Math.Round(price, 2);
        }
    }
}
