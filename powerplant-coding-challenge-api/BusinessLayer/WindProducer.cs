using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class WindProducer : IEnergyProducer
    {
        Powerplant _powerplant;
        Fuel _fuel;

        public Fuel Fuel { get => _fuel; set => _fuel = value; }
        public Powerplant Powerplant { get => _powerplant; set => _powerplant = value; }

        public WindProducer(Powerplant powerplant, Fuel fuel)
        {
            _powerplant = powerplant;
            _fuel = fuel;
        }

        public ProductionPlan Perform(Powerplant powerplant, ref int load)
        {
            var power = (powerplant.Pmax * Fuel.Wind) / 100;
            power = Math.Round(power);
            var remainingLoad = load - power;

            if (remainingLoad < 0) return null;
            load = (int)remainingLoad;

            var productionPlan = new ProductionPlan
            {
                Name = powerplant.Name,
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
    }
}
