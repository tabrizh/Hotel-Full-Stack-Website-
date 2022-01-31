using MVCFinalProject.Areas.Admin.ViewModels;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Account;
using MVCFinalProject.Data.Roles;
using Microsoft.AspNetCore.Authorization;

namespace MVCFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConstants.Admin + "," + RoleConstants.Moderator)]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            var usersList = new List<UserViewModel>();

            foreach (var user in users)
            {
                usersList.Add(new UserViewModel
                {
                    Id = user.Id,
                    Image = user.Image,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                });
            }

            return View(usersList);
        }

        public async Task<IActionResult> ChangeRole(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            var userVM = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
            };

            ViewBag.Roles = await _context.Roles.ToListAsync();

            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ChangeRole")]
        public async Task<IActionResult> ChangeRolePost(string id, UserViewModel model)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            var userRole = await _context.UserRoles.Where(u => u.UserId == id).FirstOrDefaultAsync();

            if (model.RoleId == "0") return NotFound();
            if (model.RoleId == null) return NotFound();
            if (model.RoleId == userRole.RoleId) return BadRequest();

            var existRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existRoles);

            IdentityRole role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == model.RoleId);


            await _userManager.AddToRoleAsync(user, role.Name);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userVM = new ChangePasswordViewModel
            {
                Id = user.Id,
                Username = user.UserName
            };
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userVM = new ChangePasswordViewModel
            {
                Id = user.Id,
                Username = user.UserName
            };

            if (!ModelState.IsValid) return View(userVM);
            

            if (!await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                ModelState.AddModelError(nameof(ChangePasswordViewModel.OldPassword), "Old Password is not correct!");
                return View();
            }

            var identityResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (await _userManager.IsLockedOutAsync(user))
            {
                return BadRequest();
            }
            await _userManager.SetLockoutEnabledAsync(user, true);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete (string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "User", new { area = "Admin" });
        }
    }
}


