using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class WareHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<AppUser> AppUsers { get; set; }
        public List<Courier> Couriers { get; set; }
    }
}
