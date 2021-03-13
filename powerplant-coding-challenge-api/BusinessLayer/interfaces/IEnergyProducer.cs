using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IEnergyProducer
    {
        ProductionPlan Perform(ref int load);
        ProductionPlan ReduceLoad(ref int load);
        double CalculateProductionCost(int load);
    }
}
