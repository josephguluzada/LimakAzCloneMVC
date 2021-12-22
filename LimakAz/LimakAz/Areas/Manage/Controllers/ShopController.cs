﻿using LimakAz.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]

    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ShopController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<ShopItem> shopItems = _context.ShopItems.Include(x=>x.Category).ToList();

            return View(shopItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShopItem shopItem)
        {
            if(shopItem.ImageFile != null)
            {
                if(shopItem.ImageFile.ContentType != "image/jpeg" && shopItem.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type must be jpeg or png");
                    return View();
                }

                if(shopItem.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Image size must be lesser than 2mb");
                    return View();
                }

                string fileName = shopItem.ImageFile.FileName;

                if(fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/shop", newFileName);

                using(FileStream stream = new FileStream(path, FileMode.Create))
                {
                    shopItem.ImageFile.CopyTo(stream);
                }

                shopItem.Image = newFileName;

            }

            if (!ModelState.IsValid) return View();

            _context.ShopItems.Add(shopItem);
            _context.SaveChanges();

            return RedirectToAction("index", "shop");
        }
    }
}
