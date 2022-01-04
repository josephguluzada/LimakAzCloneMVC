using LimakAz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class BalanceViewModel
    {
        public double Money { get; set; }
        public AppUser Member { get; set; }
    }
}
