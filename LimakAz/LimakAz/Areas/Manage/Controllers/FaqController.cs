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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Faq faq)
        {
            if (!ModelState.IsValid) return View();

            _context.Faqs.Add(faq);
            _context.SaveChanges();

            return RedirectToAction("index","faq");
        }

        public IActionResult Edit(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (faq == null) return RedirectToAction("index", "error");

            return View(faq);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Faq faq)
        {
            Faq existFaq = _context.Faqs.FirstOrDefault(x => x.Id == faq.Id);

            if (faq == null) return RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existFaq.Title = faq.Title;
            existFaq.Desc = faq.Desc;

            _context.SaveChanges();

            return RedirectToAction("index", "faq");
        }

        public IActionResult DeleteFetch(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (faq == null) return Json(new { status = 404 });

            _context.Faqs.Remove(faq);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
