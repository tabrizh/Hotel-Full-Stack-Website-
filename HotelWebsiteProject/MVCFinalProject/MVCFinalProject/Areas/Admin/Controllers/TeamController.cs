using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Areas.Admin.ViewModels.TeamViewModels;
using MVCFinalProject.Data;
using MVCFinalProject.Data.Roles;
using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConstants.Admin+","+RoleConstants.Moderator)]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        public TeamController(AppDbContext context)
        {
            _context = context;
        }
        // GET: TeamController
        public async Task<IActionResult> Index()
        {
            var teamMembers = await _context.TeamMembers.Where(tm => !tm.IsDeleted).ToListAsync();
            List<TeamViewModel> teamsVM = new List<TeamViewModel>();
            foreach (var teamMember in teamMembers)
            {
                teamsVM.Add(new TeamViewModel
                {
                    Id = teamMember.Id,
                    Name = teamMember.Name,
                    JobTitle = teamMember.JobTitle,
                    Image = teamMember.Image,
                    FacebookLink = teamMember.FacebookLink,
                    InstagramLink = teamMember.InstagramLink,
                    TwitterLink = teamMember.TwitterLink,
                    YoutubeLink = teamMember.YoutubeLink
                });
            }

            return View(teamsVM);
        }

        // GET: TeamController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(tm => !tm.IsDeleted && tm.Id == id);
            if (teamMember == null) return NotFound();

            TeamViewModel teamVM = new TeamViewModel
            {
                Id = teamMember.Id,
                Name = teamMember.Name,
                JobTitle = teamMember.JobTitle,
                Image = teamMember.Image,
                FacebookLink = teamMember.FacebookLink,
                InstagramLink = teamMember.InstagramLink,
                TwitterLink = teamMember.TwitterLink,
                YoutubeLink = teamMember.YoutubeLink
            };

            return View(teamVM);
        }

        // GET: TeamController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                TeamMembers teamMember = new TeamMembers
                {
                    Name = model.Name,
                    JobTitle = model.JobTitle,
                    FacebookLink = model.FacebookLink,
                    InstagramLink = model.InstagramLink,
                    TwitterLink = model.TwitterLink,
                    YoutubeLink = model.YoutubeLink
                };

                if (model.Image != null)
                {
                    if (!model.Image.IsImage())
                    {
                        ModelState.AddModelError(nameof(TeamCreateViewModel.Image), "File is not supported");
                        return View();
                    }

                    if (model.Image.IsGreaterThanGivenSize(2000))
                    {
                        ModelState.AddModelError(nameof(TeamCreateViewModel.Image), "File size cannot be more than 2mb");
                        return View();
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "team"), model.Image);
                    teamMember.Image = imageName;
                }

                await _context.TeamMembers.AddAsync(teamMember);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var dbTeam = await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.Id == id && !tm.IsDeleted);
            if (dbTeam == null) return NotFound();

            return View(new TeamUpdateViewModel
            {
                Name = dbTeam.Name,
                JobTitle = dbTeam.JobTitle ,
                Image = dbTeam.Image,
                FacebookLink = dbTeam.FacebookLink,
                TwitterLink = dbTeam.TwitterLink,
                InstagramLink = dbTeam.InstagramLink,
                YoutubeLink = dbTeam.YoutubeLink
            });
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TeamUpdateViewModel model)
        {
            var dbTeam = await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.Id == id && !tm.IsDeleted);
            if (dbTeam == null) return NotFound();

            TeamUpdateViewModel teamVM = new TeamUpdateViewModel
            {
                Name = dbTeam.Name,
                JobTitle = dbTeam.JobTitle,
                Image = dbTeam.Image,
                FacebookLink = dbTeam.FacebookLink,
                TwitterLink = dbTeam.TwitterLink,
                InstagramLink = dbTeam.InstagramLink,
                YoutubeLink = dbTeam.YoutubeLink
            };


            if (!ModelState.IsValid) return View(teamVM);

            dbTeam.Name = model.Name;
            dbTeam.JobTitle = model.JobTitle;
            dbTeam.FacebookLink = model.FacebookLink;
            dbTeam.InstagramLink = model.InstagramLink;
            dbTeam.TwitterLink = model.TwitterLink;
            dbTeam.YoutubeLink = model.YoutubeLink;

            if (model.File != null)
            {

                if (!model.File.IsImage())
                {
                    ModelState.AddModelError(nameof(TeamUpdateViewModel.File), "File is not supported");
                    return View(teamVM);
                }

                if (model.File.IsGreaterThanGivenSize(2000))
                {
                    ModelState.AddModelError(nameof(TeamUpdateViewModel.File), "File size cannot be more than 2mb");
                    return View(teamVM);
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "team"), model.File);
                dbTeam.Image = imageName;
            }

            _context.TeamMembers.Update(dbTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
