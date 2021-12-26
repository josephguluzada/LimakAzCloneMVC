using LimakAz.Models;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Certificates = _context.Certificates.Where(x => x.IsFeatured).ToList(),
                News = _context.News.Where(x=>x.IsFeatured).Take(3).ToList(),
                ShopItems = _context.ShopItems.Where(x=>x.IsFeatured).Take(12).ToList()
            };


            return View(homeVM);
        }
    }
}
