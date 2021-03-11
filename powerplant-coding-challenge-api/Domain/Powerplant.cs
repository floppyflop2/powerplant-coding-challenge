using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Powerplant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Efficency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }
    }
}
