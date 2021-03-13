using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;
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

    }
}
