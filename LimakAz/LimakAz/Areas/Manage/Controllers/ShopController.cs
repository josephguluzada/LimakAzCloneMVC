using LimakAz.Models;
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
            ViewBag.Categories = _context.Categories.ToList();

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

        public IActionResult Edit(int id)
        {
            ShopItem shopItem = _context.ShopItems.FirstOrDefault(x => x.Id == id);
            if (shopItem == null) return NotFound();

            ViewBag.Categories = _context.Categories.ToList();


            return View(shopItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ShopItem shopItem)
        {
            ShopItem existShopItem = _context.ShopItems.FirstOrDefault(x => x.Id == shopItem.Id);

            if (existShopItem == null) return NotFound();

            if (shopItem.ImageFile != null)
            {
                if (shopItem.ImageFile.ContentType != "image/jpeg" && shopItem.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type must be jpeg or png");
                    return View();
                }

                if (shopItem.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Image size must be lesser than 2mb");
                    return View();
                }

                string fileName = shopItem.ImageFile.FileName;

                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/shop", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    shopItem.ImageFile.CopyTo(stream);
                }

                if(existShopItem.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/shop", existShopItem.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                existShopItem.Image = newFileName;

            }
            else if(shopItem.Image == null && existShopItem.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/shop", existShopItem.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                existShopItem.Image = null;
            }

            if (!ModelState.IsValid) return View();

            existShopItem.IsFeatured = shopItem.IsFeatured;
            existShopItem.RedirectUrl = shopItem.RedirectUrl;
            existShopItem.CategoryId = shopItem.CategoryId;

            _context.SaveChanges();

            return RedirectToAction("index", "shop");

        }

        public IActionResult DeleteFetch(int id)
        {
            ShopItem shopItem = _context.ShopItems.FirstOrDefault(x => x.Id == id);
            if (shopItem == null) return Json(new { status = 404 });

            try
            {
                _context.ShopItems.Remove(shopItem);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return Json(new { status = 500 });
            }
            string deletePath = Path.Combine(_env.WebRootPath, "uploads/shop", shopItem.Image);
            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }

            return Json(new { status = 200 });
        }
    }
}
