using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroszimuláció.Entities
{
    public class DeathProbabilities
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double P { get; set; }
    }
}
