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
    public class TurboProducerTest
    {
        private TurboProducer turboProducer;
        private Fuel fuel;
        private Powerplant powerplant;

        [TestInitialize]
        public void Initialize()
        {
            powerplant = DummyObjectFactory.GetDummyTurboPowerplant();
            fuel = DummyObjectFactory.GetDummyFuel();
            turboProducer = new TurboProducer(powerplant, fuel);
        }
        [TestMethod]
        public void ReturnProductionPlanWith0PowerWhenLoadIs0()
        {
            //
            var load = 0;

            //
            var result = turboProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == 0);
            Assert.IsTrue(load == 0);
        }


        [TestMethod]
        public void ReturnProductionPlanWithCorrectPowerWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyTurboPowerplant();
            powerplant.Pmax = 10;
            turboProducer.Powerplant = powerplant;
            var load = 5;

            //
            var result = turboProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == 5);
            Assert.IsTrue(load == 0);
        }

        [TestMethod]
        public void ReturnProductionPlanWithBiggerPowerWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyTurboPowerplant();
            powerplant.Pmax = 10;
            turboProducer.Powerplant = powerplant;
            var load = 15;
            var expectedPower = 10;
            var expectedLoad = 15 - expectedPower;

            //
            var result = turboProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == expectedPower);
            Assert.IsTrue(load == expectedLoad);
        }

        [TestMethod]
        public void ReturnProductionPlanWithPowerWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyTurboPowerplant();
            powerplant.Pmax = 10;
            turboProducer.Powerplant = powerplant;
            var load = 0;

            //
            var result = turboProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == 0);
            Assert.IsTrue(load == 0);
        }

    }
}
