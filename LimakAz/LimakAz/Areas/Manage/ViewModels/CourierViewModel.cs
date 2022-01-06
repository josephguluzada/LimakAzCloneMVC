using LimakAz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.ViewModels
{
    public class CourierViewModel
    {
        public int CourierId { get; set; }
        public Order Order { get; set; }
    }
}
