using LimakAz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Faq> faqs = _context.Faqs.ToList();
            if (faqs == null) return NotFound();
            return View(faqs);
        }
    }
}
