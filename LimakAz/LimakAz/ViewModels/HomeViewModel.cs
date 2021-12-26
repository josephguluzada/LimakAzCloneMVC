using LimakAz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class HomeViewModel
    {
        public List<Certificate> Certificates { get; set; }
        public List<News> News { get; set; }
        public List<ShopItem> ShopItems { get; set; }
    }
}
