using BusinessLayer.interfaces;
using Domain;
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

        public ProductionPlan Perform(ref int load)
        {
            //2TMW for 0.5 
            var power = (2 * Powerplant.Efficiency) * Fuel.GasEuroMWh / 100;
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
            var TMW = (2 * Powerplant.Efficiency) * Fuel.GasEuroMWh / 100;
            var power = Math.Round(TMW, 2);
            double price = power * Fuel.GasEuroMWh;

            return Math.Round(price, 2);
        }
    }
}
