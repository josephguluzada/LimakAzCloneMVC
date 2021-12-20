using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Faq
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 250)]
        public string Title { get; set; }
        [StringLength(maximumLength: 5000)]
        public string Desc { get; set; }
    }
}
