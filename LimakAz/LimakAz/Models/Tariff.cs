using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Weight { get; set; }
        public double Price { get; set; }
        public bool IsLocal { get; set; }
    }
}
