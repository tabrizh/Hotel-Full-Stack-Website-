using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Areas.Admin.ViewModels.FeatureViewModels;
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
    [Authorize(Roles = RoleConstants.Admin + "," + RoleConstants.Moderator)]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        public FeatureController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FeatureController
        public async Task<ActionResult> Index()
        {
            var dbFeatures = await _context.Features.Where(f => !f.IsDeleted).ToListAsync();
            List<FeatureViewModel> featuresVM = new List<FeatureViewModel>();
            foreach (var feature in dbFeatures)
            {
                featuresVM.Add(new FeatureViewModel { Id = feature.Id, Image = feature.Image, Text = feature.Text });
            }
            return View(featuresVM);
        }

        // GET: FeatureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeatureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeatureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FeatureCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                Features createdFeature = new Features { Text = model.Text };

                if (model.Image != null)
                {

                    if (!model.Image.IsImage())
                    {
                        ModelState.AddModelError(nameof(FeatureCreateViewModel.Image), "File is not supported");
                        return View();
                    }

                    if (model.Image.IsGreaterThanGivenSize(2000))
                    {
                        ModelState.AddModelError(nameof(FeatureCreateViewModel.Image), "File size cannot be more than 2mb");
                        return View();
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "features"), model.Image);
                    createdFeature.Image = imageName;

                }

                await _context.Features.AddAsync(createdFeature);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index), "Feature");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: FeatureController/Update/5
        public async Task<ActionResult> Update(int id)
        {
            var feature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (feature == null) return NotFound();

            FeatureUpdateViewModel featureVM = new FeatureUpdateViewModel { Text = feature.Text, Image = feature.Image };

            return View(featureVM);
        }

        // POST: FeatureController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, FeatureUpdateViewModel model)
        {
            var dbFeature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (dbFeature == null) return NotFound();

            FeatureUpdateViewModel featureVM = new FeatureUpdateViewModel { Text = dbFeature.Text, Image = dbFeature.Image };

            try
            {
                if (!ModelState.IsValid) return View(featureVM);

                dbFeature.Text = model.Text;

                if (model.File != null)
                {

                    if (!model.File.IsImage())
                    {
                        ModelState.AddModelError(nameof(FeatureUpdateViewModel.File), "File is not supported");
                        return View(featureVM);
                    }

                    if (model.File.IsGreaterThanGivenSize(2000))
                    {
                        ModelState.AddModelError(nameof(FeatureUpdateViewModel.File), "File size cannot be more than 2mb");
                        return View(featureVM);
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "features"), model.File);
                    dbFeature.Image = imageName;
                }

                _context.Features.Update(dbFeature);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(featureVM);
            }
        }

        // GET: FeatureController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var feature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (feature == null) return NotFound();
            FeatureViewModel featureVM = new FeatureViewModel { Text = feature.Text, Image = feature.Image };
            return View(featureVM);
        }

        // POST: FeatureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FeatureViewModel model)
        {
            var dbFeature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (dbFeature == null) return NotFound();
            FeatureViewModel featureVM = new FeatureViewModel { Text = dbFeature.Text, Image = dbFeature.Image };

            try
            {
                if (!ModelState.IsValid) return View(featureVM);

                dbFeature.IsDeleted = true;

                _context.Features.Update(dbFeature);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(featureVM);
            }
        }
    }
}
