using LimakAz.Models;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.Where(x => !x.IsDeleted).ToList(),
                ShopItems = _context.ShopItems.Where(x => x.IsFeatured).ToList()
            };


            return View(shopVM);
        }

        public IActionResult Category(int id)
        {
            //ViewBag.ShopItems = _context.ShopItems.Include(x=>x.Category).Where(x => x.CategoryId == id).ToList();
            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.Where(x => !x.IsDeleted).ToList(),
                ShopItems = _context.ShopItems.Where(x => x.IsFeatured).Where(x=>x.CategoryId == id).ToList()
            };

            return View(shopVM);

        }
    }
}
