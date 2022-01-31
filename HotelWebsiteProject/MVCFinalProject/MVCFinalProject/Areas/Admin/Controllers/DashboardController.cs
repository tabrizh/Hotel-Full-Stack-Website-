using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCFinalProject.Models.Account;
using MVCFinalProject.Areas.Admin.ViewModels;
using MVCFinalProject.Data.Roles;

namespace MVCFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConstants.Admin+","+RoleConstants.Moderator+","+RoleConstants.Hotel)]
    public class DashboardController : Controller
    {
        private readonly UserManager<User> _userManager;
        public DashboardController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated) return BadRequest();
            var user = await _userManager.GetUserAsync(User);

            UserViewModel userVM = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
            };

            ViewBag.UserFullName = user.FullName;


            return View(userVM);
        }
    }
}
