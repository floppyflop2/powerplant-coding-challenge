using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IEnergyProducer
    {
        ProductionPlan Perform(ref int load, out double price, out double co2);
        ProductionPlan ReduceLoad(ref int load);
        double CalculateProductionCost(int load);
        double calculateCo2ProductionCost(int load);
    }
}
