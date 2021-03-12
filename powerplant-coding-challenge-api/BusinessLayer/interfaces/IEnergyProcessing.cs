using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.interfaces
{
    public interface IEnergyProcessing
    {
        void Perform(Powerplant powerplant);
    }
}
