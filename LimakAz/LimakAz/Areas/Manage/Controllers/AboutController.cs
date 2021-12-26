using LimakAz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<About> abouts = _context.Abouts.ToList();
            if (abouts == null) return NotFound();

            return View(abouts);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(About about)
        {
            if (!ModelState.IsValid) return View();

            _context.Abouts.Add(about);
            _context.SaveChanges();

            return RedirectToAction("index", "about");
        }

        public IActionResult Edit(int id)
        {
            About about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null) return RedirectToAction("index", "error");

            return View(about);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(About about)
        {
            About existAbout = _context.Abouts.FirstOrDefault(x => x.Id == about.Id);

            if (existAbout == null) return RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existAbout.Title = about.Title;
            existAbout.Desc = about.Desc;

            _context.SaveChanges();

            return RedirectToAction("index", "about");
        }

        public IActionResult DeleteFetch(int id)
        {
            About about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null) return Json(new { status = 404 });

            _context.Abouts.Remove(about);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
