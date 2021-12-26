using LimakAz.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CertificateController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CertificateController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Certificate> certificates = _context.Certificates.ToList();

            return View(certificates);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Certificate certificate)
        {
            if (certificate.ImageFile != null)
            {
                if (certificate.ImageFile.ContentType != "image/jpeg" && certificate.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type must be jpeg or png");
                    return View();
                }

                if (certificate.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Image size must be lesser than 2mb");
                    return View();
                }

                string fileName = certificate.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/certificate", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    certificate.ImageFile.CopyTo(stream);
                }

                certificate.Image = newFileName;

            }

            if (!ModelState.IsValid) return View();

            _context.Certificates.Add(certificate);
            _context.SaveChanges();

            return RedirectToAction("index", "certificate");
        }


    }
}
