using LimakAz.Models;
using LimakAz.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Authorize(Roles ="Member")]
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public OrderController(UserManager<AppUser> userManager,AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == User.Identity.Name.ToUpper() && !x.IsAdmin);
            }

            OrderViewModel orderVM = new OrderViewModel();
            ViewBag.Balance = member.Balance;

            return View(orderVM);
        }


        [HttpPost]
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderItem(OrderViewModel orderVM)
        {

            if (!ModelState.IsValid) return View();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == User.Identity.Name.ToUpper() && !x.IsAdmin);
            }

            ViewBag.Balance = member.Balance;

            if(orderVM.Url == null)
            {
                ModelState.AddModelError("Url", "Məhsulun linkini daxil edin");
                return View("index");
            }

            if (orderVM.Price > member.Balance)
            {
                ModelState.AddModelError("Price", "Balansı artırın");
                return View("index");
            }

            member.Balance = member.Balance - orderVM.Price;

            Order order = new Order
            {
                FullName = member.FullName,
                AppUserId = member.Id,
                CreatedAt = DateTime.UtcNow,
                Url = orderVM.Url,
                Count = orderVM.Count,
                Price = orderVM.Price,
                ShopName = orderVM.ShopName,
                Status = Models.Enums.OrderStatus.Pending,
            };

            await _userManager.UpdateAsync(member);

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("index", "userpanel");
        }
    }
}
