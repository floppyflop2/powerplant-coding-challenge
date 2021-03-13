using BusinessLayer;
using BusinessLayer.interfaces;
using Domain;
using Domain.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.TestUtils;

namespace TestProject
{
    [TestClass]
    public class CalculationProcessorTest
    {
        private ProductionPlanManager calculationProcessor;
        private List<IEnergyProducer> energyProcessors;
        [TestInitialize]
        public void Initialize()
        {
            var wind = DummyObjectFactory.GetDummyWindPowerplant();
            var fuel = DummyObjectFactory.GetDummyFuel();
            IEnergyProducer processors = new WindProducer(wind, fuel);

            calculationProcessor = new ProductionPlanManager();
            energyProcessors = new List<IEnergyProducer> ();
        }

        [TestMethod]
        public void ReturnNullWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyWindPowerplant();
            var load = 0;

            //

            var result = calculationProcessor.PerformCalculation(energyProcessors, load);

            //
            Assert.IsNull(result);
            Assert.IsTrue(load == 0);
        }

    }
}
