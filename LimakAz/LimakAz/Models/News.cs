using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class News
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        [Required]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public bool  IsFeatured { get; set; }
        public string RedirectUrl { get; set; }
    }
}
