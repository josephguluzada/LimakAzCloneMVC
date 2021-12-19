using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string Address { get; set; }
        [Required]
        public string WeekDays { get; set; }
        public string Hours { get; set; }
        public string InfoMail { get; set; }
    }
}
