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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Privacy privacy)
        {
            if (!ModelState.IsValid) return View();

            _context.Privacies.Add(privacy);
            _context.SaveChanges();

            return RedirectToAction("index","privacy");
        }


        public IActionResult Edit(int id)
        {
            Privacy privacy = _context.Privacies.FirstOrDefault(x => x.Id == id);
            if (privacy == null) RedirectToAction("index", "error");

            return View(privacy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Privacy privacy)
        {
            Privacy existPrivacy = _context.Privacies.FirstOrDefault(x => x.Id == privacy.Id);

            if (existPrivacy == null) RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existPrivacy.Title = privacy.Title;
            existPrivacy.Desc = privacy.Desc;

            _context.SaveChanges();

            return RedirectToAction("index", "privacy");
        }

        public IActionResult DeleteFetch(int id)
        {
            Privacy privacy = _context.Privacies.FirstOrDefault(x => x.Id == id);
            if (privacy == null) return Json(new { status = 404 });

            _context.Privacies.Remove(privacy);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
