using LimakAz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.ViewModels
{
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; }
        public List<ShopItem> ShopItems { get; set; }
    }
}
