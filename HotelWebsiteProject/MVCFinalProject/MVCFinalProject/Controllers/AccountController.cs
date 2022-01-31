using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Data.Roles;
using MVCFinalProject.Models.Account;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var dbUser = await _userManager.FindByNameAsync(model.UserName);
            if (dbUser != null)
            {
                ModelState.AddModelError(nameof(RegisterViewModel.UserName), "This user already exists!");
                return View();
            }

            User user = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email
            };

            if (model.Image != null)
            {
                if (!model.Image.IsImage())
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Image), "File is not supported");
                    return View();
                }

                if (model.Image.IsGreaterThanGivenSize(2000))
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Image), "File size cannot be more than 2mb");
                    return View();
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "faces"), model.Image);
                user.Image = imageName;
            }

           

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _signinManager.SignInAsync(user, true);
            await _userManager.AddToRoleAsync(user, RoleConstants.User);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            var signInResult = await _signinManager.PasswordSignInAsync(user, model.Password, model.Persistent, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
