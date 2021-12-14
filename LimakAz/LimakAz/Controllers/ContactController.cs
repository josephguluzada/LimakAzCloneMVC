using LimakAz.Models;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel
            {
                Contacts = _context.Contacts.ToList()
            };

            return View(contactVM);
        }
    }
}
