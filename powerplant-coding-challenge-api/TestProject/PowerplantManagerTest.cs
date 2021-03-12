using BusinessLayer;
using Domain;
using Domain.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var wind = new Powerplant { Type = PowerplantType.WINDTURBINE, Name = "wind" };
            var turbo = new Powerplant { Type = PowerplantType.TURBOJET, Name = "turbo" };
            var gas = new Powerplant { Type = PowerplantType.GASFIRED, Name = "gas" };
            var input = new List<Powerplant> { turbo, wind, gas };
            var expected = new List<Powerplant> { wind, gas, turbo };

            //
            var result = calculator.SortPowerplantByType(input);

            //
            Assert.AreEqual(expected.Count, result.Count);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PowerplantProcesserAreTheCorrectType()
        {
            //
            var wind = new Powerplant { Type = PowerplantType.WINDTURBINE, Name = "wind" };
            var turbo = new Powerplant { Type = PowerplantType.TURBOJET, Name = "turbo" };
            var gas = new Powerplant { Type = PowerplantType.GASFIRED, Name = "gas" };
            var input = new List<Powerplant> { wind, gas, turbo };
            var fuel = new Fuel();

            //
            var result = calculator.InitializePowerplantProcesser(input,fuel);

            //
            Assert.AreEqual(input.Count, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(WindPowerplant));
            Assert.IsInstanceOfType(result[1], typeof(GasPowerplant));
            Assert.IsInstanceOfType(result[2], typeof(TurboPowerplant));
        }
    }
}
