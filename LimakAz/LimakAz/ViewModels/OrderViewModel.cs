using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class OrderViewModel
    {
        public string Url { get; set; }
        [Required]
        public double Price { get; set; }
        public int Count { get; set; } = 1;
        public string ShopName { get; set; }


    }
}
