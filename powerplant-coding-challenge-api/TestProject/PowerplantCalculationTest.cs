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
        public void PowerplantAreCorrectlyOrder()
        {
            //
            var input = new List<Powerplant>
            {
                new Powerplant{Type = PowerPlantType.TURBOJET},
                new Powerplant{Type = PowerPlantType.WINDTURBINE},
                new Powerplant{Type = PowerPlantType.GASFIRED},
            };

            var expected = new List<Powerplant>
            {
                new Powerplant{Type = PowerPlantType.WINDTURBINE},
                new Powerplant{Type = PowerPlantType.GASFIRED},
                new Powerplant{Type = PowerPlantType.TURBOJET},
            };
            //
            var result = calculator.SortPowerPlant(input);

            //
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
