﻿using BusinessLayer;
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
        private WindProducer windPowerplant;

        [TestInitialize]
        public void Initialize()
        {
            var powerplant = DummyObjectFactory.GetDummyWindPowerplant();
            var fuel = DummyObjectFactory.GetDummyFuel();
            windPowerplant = new WindProducer(powerplant, fuel);
        }

        [TestMethod]
        public void ReturnNullWhenLoadIs0()
        {
            //
            var powerplant = DummyObjectFactory.GetDummyWindPowerplant();
            var load = 0;

            //
            var result = windPowerplant.Perform(powerplant, ref load);

            //
            Assert.IsNull(result);
            Assert.IsTrue(load == 0);
        }
    }
}