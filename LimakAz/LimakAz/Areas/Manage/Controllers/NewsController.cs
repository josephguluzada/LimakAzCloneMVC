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
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public NewsController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<News> news = _context.News.ToList();
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(News news)
        {
            if (news.ImageFile != null)
            {
                if (news.ImageFile.ContentType != "image/jpeg" && news.ImageFile.ContentType != "image/png" && news.ImageFile.ContentType != "image/svg+xml")
                {
                    ModelState.AddModelError("ImageFile", "Content type must be jpeg or png");
                    return View();
                }

                if (news.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Image size must be lesser than 2mb");
                    return View();
                }

                string fileName = news.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/news", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    news.ImageFile.CopyTo(stream);
                }

                news.Image = newFileName;

            }

            if (!ModelState.IsValid) return View();

            _context.News.Add(news);
            _context.SaveChanges();

            return RedirectToAction("index", "news");
        }
    }
}
