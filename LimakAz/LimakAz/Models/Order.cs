using LimakAz.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:120)]
        public string Url { get; set; }
        [Required]
        public double Price { get; set; }
        public int Count { get; set; } = 1;
        public string No { get; set; }
        public string ShopName { get; set; }
        public OrderStatus Status { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
