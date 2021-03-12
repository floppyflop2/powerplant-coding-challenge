using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class CalculationProcessor
    {
        private PowerplantManager _powerplantManager;

        public CalculationProcessor(PowerplantManager powerplantManager)
        {
            _powerplantManager = powerplantManager;
        }

        public List<ProductionPlan> PerformCalculation(List<Powerplant> powerplants)
        {
            var productionPlans = new List<ProductionPlan>();

            return productionPlans;
        }

    }
}
