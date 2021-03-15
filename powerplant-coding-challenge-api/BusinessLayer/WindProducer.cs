using BusinessLayer.interfaces;
using Domain;
using Domain.Const;
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

        public ProductionPlan Perform(ref int load, out double price, out double co2)
        {
            co2 = 0;
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

            //if there is only 60% of wind
            var pMaxEfficiency = Powerplant.Pmax * (Fuel.Wind / 100);

            if (load < pMaxEfficiency)
            {
                productionPlan.Power = load;
                load = 0;
            }
            else
            {
                var roundPmax = (int)Math.Round(pMaxEfficiency);
                productionPlan.Power = roundPmax;
                load = load - roundPmax;
            }

            return productionPlan;
        }

        public double CalculateProductionCost(int load)
        {
            return Constants.WIND_PRODUCER_COST;
        }

        public double calculateCo2ProductionCost(int load)
        {
            if (load == 0) return 0.0;
            var pMaxEfficiency = Powerplant.Pmax * (Fuel.Wind / 100);
            double co2Emission;
            if (load < pMaxEfficiency)
            {
                co2Emission = Constants.CO2EMISSION * load;
            }
            else
            {
                co2Emission = Constants.CO2EMISSION * pMaxEfficiency;
            }
            var co2EmissionPrice = co2Emission * Fuel.Co2EuroTon;
            var totalPrice = co2EmissionPrice + CalculateProductionCost(load);
            return totalPrice;
        }
    }
}
