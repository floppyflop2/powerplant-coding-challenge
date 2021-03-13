using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IProductionPlanManager
    {
        List<ProductionPlan> PerformCalculation(List<IEnergyProducer> processors, int load);
    }
}
