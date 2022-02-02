using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Areas.Admin.ViewModels.PageViewModels.HomePageViewModels;
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
    public class HomePageController : Controller
    {
        private readonly AppDbContext _context;
        public HomePageController(AppDbContext context)
        {
            _context = context;
        }
        // GET: HomePageController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdateBanner()
        {
            var dbSection = await _context.HomePageBannerSection.FirstOrDefaultAsync(hb => !hb.IsDeleted);
            if (dbSection == null) return NotFound();

            HomePageBannerViewModel homePageBannerVM = new HomePageBannerViewModel
            {
                Heading = dbSection.Heading,
                SubHeading = dbSection.SubHeading,
                Image = dbSection.Image
            };

            return View(homePageBannerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("UpdateBanner")]
        public async Task<IActionResult> UpdateBanner(HomePageBannerViewModel model)
        {
            var dbSection = await _context.HomePageBannerSection.FirstOrDefaultAsync(hb => !hb.IsDeleted);
            if (dbSection == null) return NotFound();

            HomePageBannerViewModel homePageBannerVM = new HomePageBannerViewModel
            {
                Heading = dbSection.Heading,
                SubHeading = dbSection.SubHeading,
                Image = dbSection.Image
            };

            if (!ModelState.IsValid) return View(homePageBannerVM);

            dbSection.Heading = model.Heading;
            dbSection.SubHeading = model.SubHeading;

            if (model.File != null)
            {
                if (!model.File.IsImage())
                {
                    ModelState.AddModelError(nameof(HomePageBannerViewModel.File), "File is not supported");
                    return View(homePageBannerVM);
                }

                if (model.File.IsGreaterThanGivenSize(2000))
                {
                    ModelState.AddModelError(nameof(HomePageBannerViewModel.File), "File size cannot be more than 2mb");
                    return View(homePageBannerVM);
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "banners"), model.File);
                dbSection.Image = imageName;
            }

            _context.HomePageBannerSection.Update(dbSection);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateFeatures()
        {
            var dbfeatures = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();
            if (dbfeatures == null) return NotFound();

            HomePageFeaturesViewModel featuresVM = new HomePageFeaturesViewModel { Features = dbfeatures };

            return View(featuresVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFeatures(HomePageFeaturesViewModel model)
        {
            var dbfeatures = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();
            if (dbfeatures == null) return NotFound();

            HomePageFeaturesViewModel featuresVM = new HomePageFeaturesViewModel { Features = dbfeatures };

            if(!ModelState.IsValid) return View(featuresVM);

            if (model.SelectedFeatures.Any())
            {
                foreach (var feature in dbfeatures)
                {
                    feature.Selected = false;

                    foreach (var selectedFeature in model.SelectedFeatures)
                    {
                        if (feature.Id == selectedFeature) feature.Selected = true;
                    }
                }

                _context.Features.UpdateRange(dbfeatures);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateAbout()
        {
            var dbAbout = await _context.AboutSection.Where(a => !a.IsDeleted).ToListAsync();
            if (dbAbout == null) return NotFound();

            List<HomePageAboutViewModel> aboutVM = new List<HomePageAboutViewModel>();

            foreach (var ab in dbAbout)
            {
                aboutVM.Add(new HomePageAboutViewModel { Id = ab.Id, Image = ab.Image, Heading = ab.Heading, Description = ab.Description, BtnText = ab.BtnText });
            }
            
            return View(aboutVM);
        }

        public async Task<IActionResult> UpdateAboutId(int id)
        {
            var dbAbout = await _context.AboutSection.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == id);
            if (dbAbout == null) return NotFound();

            HomePageAboutViewModel aboutVM = new HomePageAboutViewModel 
            { 
                Id = dbAbout.Id, 
                Image = dbAbout.Image, 
                Heading = dbAbout.Heading, 
                Description = dbAbout.Description, 
                BtnText = dbAbout.BtnText 
            };

            return View(aboutVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAboutId(int id, HomePageAboutViewModel model)
        {
            var dbAbout = await _context.AboutSection.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == id);
            if (dbAbout == null) return NotFound();

            HomePageAboutViewModel aboutVM = new HomePageAboutViewModel
            {
                Id = dbAbout.Id,
                Image = dbAbout.Image,
                Heading = dbAbout.Heading,
                Description = dbAbout.Description,
                BtnText = dbAbout.BtnText
            };

            if(!ModelState.IsValid) return View(aboutVM);

            dbAbout.Heading = model.Heading;
            dbAbout.Description = model.Description;
            dbAbout.BtnText = model.BtnText;

            if (model.File != null)
            {
                if (!model.File.IsImage())
                {
                    ModelState.AddModelError(nameof(HomePageAboutViewModel.File), "File is not supported");
                    return View(aboutVM);
                }

                if (model.File.IsGreaterThanGivenSize(2000))
                {
                    ModelState.AddModelError(nameof(HomePageAboutViewModel.File), "File size cannot be more than 2mb");
                    return View(aboutVM);
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "about"), model.File);
                dbAbout.Image = imageName;
            }

            _context.AboutSection.Update(dbAbout);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(UpdateAbout), "HomePage");
        }
    }
}
