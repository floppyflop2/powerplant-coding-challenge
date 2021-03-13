﻿using BusinessLayer;
using Domain;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.TestUtils
{
    public class DummyObjectFactory
    {
        public static Fuel GetDummyFuel()
        {
            return new Fuel
            {
                GasEuroMWh = 13.4,
                KerosineEuroMWh = 50.8,
                Co2EuroTon = 20,
                Wind = 60
            };
        }

        public static Powerplant GetDummyWindPowerplant()
        {
            return new Powerplant
            {
                Name = "windpark1",
                Type = PowerplantType.WINDTURBINE,
                Efficiency = 1,
                Pmin = 0,
                Pmax = 150
            };
        }

        public static Powerplant GetDummyGasPowerplant()
        {
            return new Powerplant
            {
                Name = "gasfiredbig1",
                Type = PowerplantType.GASFIRED,
                Efficiency = 0.53,
                Pmin = 100,
                Pmax = 460
            };
        }

        public static Powerplant GetDummyTurboPowerplant()
        {
            return new Powerplant
            {
                Name = "tj1",
                Type = PowerplantType.TURBOJET,
                Efficiency = 0.3,
                Pmin = 0,
                Pmax = 16
            };
        }

        public static WindProducer GetDummyWindPowerplantProcessor()
        {
            var wind = GetDummyWindPowerplant();
            var fuel = GetDummyFuel();
            return new WindProducer(wind, fuel);
        }
    }
}