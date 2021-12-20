using LimakAz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class TermController : Controller
    {
        private readonly AppDbContext _context;

        public TermController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Term> terms = _context.Terms.ToList();

            return View(terms);
        }
    }
}
