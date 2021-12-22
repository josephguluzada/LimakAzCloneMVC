using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsFeatured { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
