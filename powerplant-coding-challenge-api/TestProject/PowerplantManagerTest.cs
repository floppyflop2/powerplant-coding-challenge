using BusinessLayer;
using Domain;
using Domain.Const;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestProject.TestUtils;

namespace TestProject
{
    [TestClass]
    public class PowerplantManagerTest
    {

        PowerplantManager calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new PowerplantManager();
        }

        [TestMethod]
        public void PowerplantAreCorrectlyOrderedByType()
        {
            //
            var wind = DummyObjectFactory.GetDummyWindPowerplant();
            var turbo = DummyObjectFactory.GetDummyTurboPowerplant();
            var gas = DummyObjectFactory.GetDummyGasPowerplant();
            var input = new List<Powerplant> { turbo, wind, gas };
            var expected = new List<Powerplant> { wind, gas, turbo };

            //
            var result = calculator.SortPowerplantByType(input);


            //
            Assert.AreEqual(expected.Count, result.Count);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PowerplantAreCorrectlyOrderedByFuelCost()
        {
            //
            var wind = DummyObjectFactory.GetDummyWindPowerplant();
            var turbo = DummyObjectFactory.GetDummyTurboPowerplant();
            var gas = DummyObjectFactory.GetDummyGasPowerplant();
            var input = new List<Powerplant> { turbo, wind, gas };
            var expected = new List<Powerplant> { wind, turbo, gas };
            var fuelPrice = new Fuel
            {
                Wind = 0,
                KerosineEuroMWh = 1,
                GasEuroMWh = 2
            };

            //
            var result = calculator.SortPowerplantByFuelCost(input, fuelPrice);

            //
            Assert.AreEqual(expected.Count, result.Count);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PowerplantProcesserAreTheCorrectType()
        {
            //
            var payload = DummyObjectFactory.GetDummyPayload();

            //
            var result = calculator.InitializePowerplantProcessers(payload);

            //
            Assert.AreEqual(payload.Powerplants.Length, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(WindProducer));
            Assert.IsInstanceOfType(result[1], typeof(GasProducer));
            Assert.IsInstanceOfType(result[2], typeof(TurboProducer));
        }
    }
}
