using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Term
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string Title { get; set; }
        [StringLength(maximumLength:2500)]
        public string Desc { get; set; }
    }
}
