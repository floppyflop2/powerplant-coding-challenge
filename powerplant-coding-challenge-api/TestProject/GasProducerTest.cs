using BusinessLayer;
using Domain;
using Domain.Const;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.TestUtils;

namespace TestProject
{
    [TestClass]
    public class GasProducerTest
    {
        private GasProducer gasProducer;
        private Fuel fuel;
        private Powerplant powerplant;

        [TestInitialize]
        public void Initialize()
        {
            powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            fuel = DummyObjectFactory.GetDummyFuel();
            gasProducer = new GasProducer(powerplant, fuel);
        }

        [TestMethod]
        public void ReturnProductionPlanWith0PowerWhenLoadIs0()
        {
            //
            var load = 0;

            //
            var result = gasProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == 0);
            Assert.IsTrue(load == 0);
        }


        [TestMethod]
        public void ReturnProductionPlanWithCorrectPowerWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            powerplant.Pmax = 10;
            gasProducer.Powerplant = powerplant;
            var load = 5;

            //
            var result = gasProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == 5);
            Assert.IsTrue(load == 0);
        }

        [TestMethod]
        public void ReturnProductionPlanWithBiggerPowerWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            powerplant.Pmax = 10;
            gasProducer.Powerplant = powerplant;
            var load = 15;
            var expectedPower = 10;
            var expectedLoad = 15 - expectedPower;

            //
            var result = gasProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == expectedPower);
            Assert.IsTrue(load == expectedLoad);
        }

        [TestMethod]
        public void ReturnProductionPlanWithPowerWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            powerplant.Pmax = 10;
            gasProducer.Powerplant = powerplant;
            var load = 0;

            //
            var result = gasProducer.ReduceLoad(ref load);

            //
            Assert.IsTrue(result.Power == 0);
            Assert.IsTrue(load == 0);
        }

        [TestMethod]
        public void ReturnCorrectAmountBasedOnFuelCost()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            var fuel = DummyObjectFactory.GetDummyFuel();
            int load = 1;
            powerplant.Efficiency = 0.3;
            powerplant.Pmax = 10;
            fuel.GasEuroMWh = 5;
            gasProducer.Powerplant = powerplant;
            gasProducer.Fuel = fuel;
            var expectedPrice = (Constants.GAS_UNITS_FOR_ONE_ELECTRICITY/powerplant.Efficiency)* load * fuel.GasEuroMWh;

            //
            var result = gasProducer.CalculateProductionCost(load);

            //
            //round result cause issues so I round it 
            Assert.IsTrue(Math.Round(result) == Math.Round(expectedPrice));
            Assert.IsTrue(load == 1);
        }

        [TestMethod]
        public void ReturnCost0WhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            powerplant.Pmax = 10;
            gasProducer.Powerplant = powerplant;
            int load = 0;

            //
            var result = gasProducer.CalculateProductionCost(load);

            //
            Assert.IsTrue(result == 0);
            Assert.IsTrue(load == 0);
        }

        [TestMethod]
        public void ReturnCorrectAmountBasedOnCo2Cost()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            var fuel = DummyObjectFactory.GetDummyFuel();
            int load = 1;
            powerplant.Efficiency = 1;
            powerplant.Pmax = 10;
            fuel.Co2EuroTon = 1;
            fuel.GasEuroMWh = 5;
            gasProducer.Powerplant = powerplant;
            gasProducer.Fuel = fuel;

            var expectedPrice = Constants.GAS_UNITS_FOR_ONE_ELECTRICITY * fuel.GasEuroMWh + 0.3;

            //
            var result = gasProducer.calculateCo2ProductionCost(load);

            //
            //round result cause issues so I round it 
            Assert.IsTrue(Math.Round(result, 1) == Math.Round(expectedPrice, 1));
            Assert.IsTrue(load == 1);
        }

        [TestMethod]
        public void ReturnCo2Cost0WhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyGasPowerplant();
            powerplant.Pmax = 10;
            gasProducer.Powerplant = powerplant;
            int load = 0;

            //
            var result = gasProducer.calculateCo2ProductionCost(load);

            //
            Assert.IsTrue(result == 0);
            Assert.IsTrue(load == 0);
        }
    }
}
