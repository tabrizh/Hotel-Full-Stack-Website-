using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context) 
        {
            _context = context;
        }

        // GET: AboutController
        public async Task<IActionResult> Index()
        {
            AboutPageViewModel aboutVM = new AboutPageViewModel
            {
                AboutPageSectionBanner = await _context.AboutPageSectionBanner.FirstOrDefaultAsync(a => !a.IsDeleted),
                AboutPageCEOSection = await _context.AboutPageCEOSection.FirstOrDefaultAsync(c => !c.IsDeleted),
                Features = await _context.Features.Where(f => !f.IsDeleted).Take(8).ToListAsync(),
                AboutPageVideoSection = await _context.AboutPageVideoSections.FirstOrDefaultAsync(v => !v.IsDeleted),
                TeamSection = await _context.TeamSection.FirstOrDefaultAsync(t => !t.IsDeleted),
                TeamMembers = await _context.TeamMembers.Where(t => !t.IsDeleted).ToListAsync()
            };

            return View(aboutVM);
        }

        // GET: AboutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AboutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutController/Create
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

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AboutController/Edit/5
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

        // GET: AboutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AboutController/Delete/5
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
