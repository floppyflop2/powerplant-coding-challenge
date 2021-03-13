using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IEnergyProducer
    {
        ProductionPlan Perform(Powerplant powerplant,ref int load);
        ProductionPlan ReduceLoad(ref int load);
    }
}
