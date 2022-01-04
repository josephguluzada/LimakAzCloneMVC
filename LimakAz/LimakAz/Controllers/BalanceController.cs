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
    public class BalanceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BalanceController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (member == null) return RedirectToAction("index", "error");

            BalanceViewModel balanceVM = new BalanceViewModel
            {
                Member = member
            };

            return View(balanceVM);
        }

        [HttpPost]
        [Authorize(Roles ="Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncreaseBalance(BalanceViewModel balanceVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

            if (balanceVM.Money != null)
            {
                member.Balance = member.Balance + balanceVM.Money;
            }

            var result = await _userManager.UpdateAsync(member);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }


            return RedirectToAction("index", "balance");
        }

    }
}
