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
    public class TariffController : Controller
    {
        private readonly AppDbContext _context;

        public TariffController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Tariff> tariffs = _context.Tariffs.ToList();
            return View(tariffs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tariff tariff)
        {
            if (!ModelState.IsValid) return View();

            _context.Tariffs.Add(tariff);
            _context.SaveChanges();

            return RedirectToAction("index", "tariff");
        }

        public IActionResult Edit(int id)
        {
            Tariff tariff = _context.Tariffs.FirstOrDefault(x => x.Id == id);
            if (tariff == null) return RedirectToAction("index", "error");

            return View(tariff);
        }

        [HttpPost]
        public IActionResult Edit(Tariff tariff)
        {
            Tariff existTariff = _context.Tariffs.FirstOrDefault(x => x.Id == tariff.Id);

            if (existTariff == null) return RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existTariff.Weight = tariff.Weight;
            existTariff.Price = tariff.Price;
            existTariff.IsLocal = tariff.IsLocal;

            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult DeleteFetch(int id)
        {
            Tariff tariff = _context.Tariffs.FirstOrDefault(x => x.Id == id);
            if (tariff == null) return Json(new { status = 404});

            _context.Tariffs.Remove(tariff);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
