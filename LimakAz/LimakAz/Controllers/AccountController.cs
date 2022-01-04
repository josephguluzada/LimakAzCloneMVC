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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(registerVM.UserName);

            if(member != null)
            {
                ModelState.AddModelError("UserName", "İstifadəçi adı hal-hazırda sistemdə mövcuddur");
                return View();
            }

            member = await _userManager.FindByEmailAsync(registerVM.Email);

            if(member != null)
            {
                ModelState.AddModelError("Email", "Email hal-hazırda sistemdə mövcuddur");
                return View();
            }

            member = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(member, "Member");
            await _signInManager.SignInAsync(member, true);

            return RedirectToAction("index", "userpanel");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel memberLoginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser member = _userManager.Users.FirstOrDefault(x => x.NormalizedEmail == memberLoginVM.Email.ToUpper());

            if(member == null)
            {
                ModelState.AddModelError("", "Email və ya şifrə yalnışdır");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(member, memberLoginVM.Password, memberLoginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email və ya şifrə yalnışdır");
                return View();
            }

            return RedirectToAction("index", "userpanel");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.WareHouses = _context.WareHouses.ToList();

            ProfileViewModel profileVM = new ProfileViewModel
            {
                FullName = member.FullName,
                UserName = member.UserName,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                BirthDay = member.BirthDay
            };

            return View(profileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Profile(ProfileViewModel profileVM)
        {
            ViewBag.WareHouses = _context.WareHouses.ToList();

            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!string.IsNullOrWhiteSpace(profileVM.ConfirmNewPassword) && !string.IsNullOrWhiteSpace(profileVM.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(member, profileVM.CurrentPassword, profileVM.NewPassword);

                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var item in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View();
                }

            }
            if (member.UserName != profileVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == profileVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "Bu istifadəçi adı hal-hazırda sistemdə mövcuddur.");
                return View();
            }

            member.FullName = profileVM.FullName;
            member.UserName = profileVM.UserName;
            member.PhoneNumber = profileVM.PhoneNumber;
            member.BirthDay = profileVM.BirthDay;
            member.WareHouseId = profileVM.WareHouse.Id;

            var result = await _userManager.UpdateAsync(member);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

            return RedirectToAction("profile", "account");

        }
    }
}
