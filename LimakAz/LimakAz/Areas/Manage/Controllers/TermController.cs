using LimakAz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Term term)
        {
            if (!ModelState.IsValid) return View();

            _context.Terms.Add(term);
            _context.SaveChanges();

            return RedirectToAction("index","term");
        }

        public IActionResult Edit(int id)
        {
            Term term = _context.Terms.FirstOrDefault(x => x.Id == id);
            if (term == null) return RedirectToAction("index", "error");

            return View(term);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Term term)
        {
            Term existTerm = _context.Terms.FirstOrDefault(x => x.Id == term.Id);

            if (existTerm == null) return RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existTerm.Title = term.Title;
            existTerm.Desc = term.Desc;

            _context.SaveChanges();

            return RedirectToAction("index", "term");
        }

        public IActionResult DeleteFetch(int id)
        {
            Term term = _context.Terms.FirstOrDefault(x => x.Id == id);
            if (term == null) return Json (new {status = 404 });

            _context.Terms.Remove(term);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
