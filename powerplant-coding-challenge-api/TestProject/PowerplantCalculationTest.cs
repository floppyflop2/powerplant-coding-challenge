using BusinessLayer;
using Domain;
using Domain.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class PowerplantCalculationTest
    {

        PowerCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new PowerCalculator();
        }

        [TestMethod]
        public void PowerplantAreCorrectlyOrderedByType()
        {
            //
            var wind = new Powerplant { Type = PowerPlantType.WINDTURBINE, Name = "wind" };
            var turbo = new Powerplant { Type = PowerPlantType.TURBOJET, Name = "turbo" };
            var gas = new Powerplant { Type = PowerPlantType.GASFIRED, Name = "gas" };
            var input = new List<Powerplant> { turbo, wind, gas };
            var expected = new List<Powerplant> { wind, gas, turbo };

            //
            var result = calculator.SortPowerplantByType(input);

            //
            Assert.AreEqual(expected.Count, result.Count);
            CollectionAssert.AreEqual(result, expected);
        }
    }
}
