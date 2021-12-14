using LimakAz.Models;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class TariffController : Controller
    {
        private readonly AppDbContext _context;

        public TariffController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            TariffViewModel tariffVM = new TariffViewModel
            {
                Contacts = _context.Contacts.ToList(),
                Tariffs = _context.Tariffs.ToList()
            };

            return View(tariffVM);
        }
    }
}
