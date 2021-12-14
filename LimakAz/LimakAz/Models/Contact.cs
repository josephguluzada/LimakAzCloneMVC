using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string WeekDays { get; set; }
        public string Hours { get; set; }
        public string InfoMail { get; set; }
    }
}
