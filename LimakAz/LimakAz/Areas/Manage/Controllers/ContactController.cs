using LimakAz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{   
    [Area("manage")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();


            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid) return View();

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("index","contact");
        }

        public IActionResult Edit(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null) return RedirectToAction("index", "error");

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            Contact existContact = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (existContact == null) return RedirectToAction("index", "error");
            if (!ModelState.IsValid) return View();

            existContact.Address = contact.Address;
            existContact.CityName = contact.CityName;
            existContact.Hours = contact.Hours;
            existContact.InfoMail = contact.InfoMail;
            existContact.WeekDays = contact.WeekDays;

            _context.SaveChanges();

            return RedirectToAction("index", "contact");
        }

        public IActionResult DeleteFetch(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null) return Json(new { status = 404 });

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
