using BusinessLayer.interfaces;
using Domain;
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
            var power = (Powerplant.Pmax * Fuel.KerosineEuroMWh) / 100;
            power = Math.Round(power);
            var remainingLoad = load - power;

            if (remainingLoad < 0) return null;
            load = (int)remainingLoad;

            var productionPlan = new ProductionPlan
            {
                Name = Powerplant.Name,
                Power = Convert.ToInt32(power)
            };

            return productionPlan;
        }

        public ProductionPlan ReduceLoad(ref int load)
        {
            ProductionPlan productionPlan = new ProductionPlan
            {
                Name = Powerplant.Name
            };

            //if (load == 0) productionPlan.Power = 0;
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
            var TMW = (2 * Powerplant.Efficiency);
            var power = Math.Round(TMW, 2);
            double price = power * Fuel.KerosineEuroMWh;

            return Math.Round(price, 2);
        }
    }
}
