using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsFeatured { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
