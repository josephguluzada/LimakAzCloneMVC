using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDay { get; set; }
        public double Balance { get; set; }
        public double Bonus { get; set; }
        public double WaitedBonus { get; set; }
        public List<Order> Orders { get; set; }

        public int? WareHouseId { get; set; }
        public WareHouse WareHouse { get; set; }

    }
}
