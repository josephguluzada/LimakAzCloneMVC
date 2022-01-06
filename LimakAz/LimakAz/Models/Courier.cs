using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Courier
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? WareHouseId { get; set; }
        public double? Money { get; set; }
        public WareHouse WareHouse { get; set; }

        public List<Order> Orders { get; set; }
    }
}
