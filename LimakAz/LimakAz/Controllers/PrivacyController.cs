using LimakAz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly AppDbContext _context;

        public PrivacyController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Privacy> privacies = _context.Privacies.ToList();
            if (privacies == null) return NotFound();

            return View(privacies);
        }
    }
}
