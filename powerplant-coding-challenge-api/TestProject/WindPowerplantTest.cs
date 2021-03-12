using BusinessLayer;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.TestUtils;

namespace TestProject
{
    [TestClass]
    public class WindPowerplantTest
    {
        private WindPowerplant windPowerplant;
        
        [TestInitialize]
        public void Initialize() {
            var powerplant = DummyObjectFactory.GetDummyWindPowerplant();
            var fuel = DummyObjectFactory.GetDummyFuel();
            windPowerplant = new WindPowerplant(powerplant, fuel);
        }

        [TestMethod]
        public void ReturnNullWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyWindPowerplant();

            //
            var result = windPowerplant.Perform(powerplant, 0);

            //
            Assert.IsNull(result);
        }
    }
}
