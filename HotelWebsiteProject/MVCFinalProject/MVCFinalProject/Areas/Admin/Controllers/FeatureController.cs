using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.ViewModels;
using MVCFinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public ActionResult Create(IFormCollection collection)
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

        // GET: FeatureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeatureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: FeatureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeatureController/Delete/5
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
