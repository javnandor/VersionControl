using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadandó_8.Entities
{
    class RateData
    {
        public DateTime Date { get; set; }
        public string Curency { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; internal set; }
    }
}
