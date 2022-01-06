using LimakAz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Authorize(Roles ="Member")]
    public class UserPanelController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserPanelController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == User.Identity.Name.ToUpper());
            }
            if (member == null) return RedirectToAction("index", "error");

            List<Order> orders = _context.Orders.Where(x => x.AppUserId == member.Id).Where(x=>!x.InPackageStatus).ToList();


            return View(orders);
        }


        public IActionResult Address()
        {
            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == User.Identity.Name.ToUpper());
            }
            if (member == null) return RedirectToAction("index", "error");

            return View(member);
        }


        public IActionResult Package()
        {
            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == User.Identity.Name.ToUpper());
            }
            if (member == null) return RedirectToAction("index", "error");

            List<Order> orders = _context.Orders.Where(x => x.AppUserId == member.Id).Where(x => x.InPackageStatus).Include(x=>x.Courier).Include(x=>x.AppUser).ThenInclude(x=>x.WareHouse).ToList();


            return View(orders);

        }
    }
}
