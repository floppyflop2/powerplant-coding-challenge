using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IProductionPlanManager
    {
        List<ProductionPlan> PerformCalculation(List<IEnergyProducer> processors, int load);
        List<ProductionPlan> PerformCalculationPricing(List<IEnergyProducer> processors, int load);
        List<ProductionPlan> PerformCo2CalculationPricing(List<IEnergyProducer> processors, int load);
    }
}
