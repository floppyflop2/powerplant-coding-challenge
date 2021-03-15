using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class ProductionPlanManager : IProductionPlanManager
    {
        private PowerplantManager _powerplantManager;

        public ProductionPlanManager()
        {

        }

        //public CalculationProcessor(PowerplantManager powerplantManager)
        //{
        //    _powerplantManager = powerplantManager;
        //}

        public List<ProductionPlan> PerformCalculation(List<IEnergyProducer> processors, int load)
        {
            var productionPlans = new List<ProductionPlan>();
            if (load == 0) return productionPlans;

            foreach (var processor in processors)
            {
                productionPlans.Add(processor.ReduceLoad(ref load));
            }

            return productionPlans;
        }

        public List<ProductionPlan> PerformCalculationPricing(List<IEnergyProducer> processors, int load)
        {
            var productionPlans = new List<ProductionPlan>();
            if (load == 0) return productionPlans;
            var costs = new List<double>();
            var costDictionary = new Dictionary<IEnergyProducer, double>();
            costDictionary = SortProducerByCost(processors, load);
            var initialLoad = load;
            productionPlans = PerformCalculation(costDictionary.Keys.ToList(), initialLoad);
            return productionPlans;
        }

        public List<ProductionPlan> PerformCo2CalculationPricing(List<IEnergyProducer> processors, int load)
        {
            var productionPlans = new List<ProductionPlan>();
            if (load == 0) return productionPlans;
            var costs = new List<double>();
            var costDictionary = new Dictionary<IEnergyProducer, double>();

            foreach (var processor in processors)
            {
                var price = processor.calculateCo2ProductionCost(load);
                processor.ReduceLoad(ref load);
                costDictionary.Add(processor, price);
            }
            costDictionary = costDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var initialLoad = load;
            productionPlans = PerformCalculation(costDictionary.Keys.ToList(), initialLoad);

            return productionPlans;
        }

        private static Dictionary<IEnergyProducer, double> SortProducerByCost(List<IEnergyProducer> processors, int load)
        {
            var costDictionary = new Dictionary<IEnergyProducer, double>();

            foreach (var processor in processors)
            {
                var price = processor.CalculateProductionCost(load);
                processor.ReduceLoad(ref load);
                costDictionary.Add(processor, price);
            }
            costDictionary = costDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return costDictionary;
        }

    }
}
