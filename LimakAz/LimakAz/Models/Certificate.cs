using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsFeatured { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
