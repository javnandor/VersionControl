﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Harmadik_LINQ
{
    class Ramen
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public int CountryFK { get; set; }
        public Country Country { get; set; }
        public Double Rating { get; set; }

    }
}
