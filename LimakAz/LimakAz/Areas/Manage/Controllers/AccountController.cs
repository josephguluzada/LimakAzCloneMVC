using LimakAz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async  Task<IActionResult> Index()
        {
            //AppUser admin = new AppUser
            //{
            //    UserName = "SuperAdmin",
            //    FullName = "Yusif Guluzada"
            //};

            //await _userManager.CreateAsync(admin);

            //IdentityRole role1 = new IdentityRole("SuperAdmin");
            //await _roleManager.CreateAsync(role1);
            //IdentityRole role2 = new IdentityRole("Admin");
            //await _roleManager.CreateAsync(role2);
            //IdentityRole role3 = new IdentityRole("Member");
            //await _roleManager.CreateAsync(role3);

            AppUser appUser = await _userManager.FindByNameAsync("SuperAdmin");

            await _userManager.AddToRoleAsync(appUser, "SuperAdmin");


            return View();
        }
    }
}
