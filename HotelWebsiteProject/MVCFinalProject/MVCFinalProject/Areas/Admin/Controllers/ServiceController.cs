using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Areas.Admin.ViewModels.ServiceViewModels;
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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ServiceController
        public async Task<ActionResult> Index()
        {
            var dbServices = await _context.Services.Where(s => !s.IsDeleted).ToListAsync();
            List<ServiceViewModel> servicesVM = new List<ServiceViewModel>();
            foreach (var service in dbServices)
            {
                servicesVM.Add(new ServiceViewModel { Id = service.Id, Image = service.Image, Name = service.Name, Description = service.Description });
            }
            return View(servicesVM);
        }

        // GET: ServiceController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                Service createdService = new Service { Name = model.Name, Description = model.Description };

                if (model.Image != null)
                {
                    if (!model.Image.IsImage())
                    {
                        ModelState.AddModelError(nameof(ServiceCreateViewModel.Image), "File is not supported");
                        return View();
                    }

                    if (model.Image.IsGreaterThanGivenSize(2000))
                    {
                        ModelState.AddModelError(nameof(ServiceCreateViewModel.Image), "File size cannot be more than 2mb");
                        return View();
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "services"), model.Image);
                    createdService.Image = imageName;
                }

                await _context.Services.AddAsync(createdService);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "Service");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (service == null) return NotFound();

            return View(new ServiceUpdateViewModel
            {
                Name = service.Name,
                Description = service.Description,
                Image = service.Image
            });
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ServiceUpdateViewModel model)
        {
            var dbService = await _context.Services.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (dbService == null) return NotFound();

            ServiceUpdateViewModel serviceVM = new ServiceUpdateViewModel { Name = dbService.Name, Image = dbService.Image, Description = dbService.Description };

            try
            {
                if (!ModelState.IsValid) return View(serviceVM);

                dbService.Name = model.Name;
                dbService.Description = model.Description;

                if (model.File != null)
                {

                    if (!model.File.IsImage())
                    {
                        ModelState.AddModelError(nameof(ServiceUpdateViewModel.File), "File is not supported");
                        return View(serviceVM);
                    }

                    if (model.File.IsGreaterThanGivenSize(2000))
                    {
                        ModelState.AddModelError(nameof(ServiceUpdateViewModel.File), "File size cannot be more than 2mb");
                        return View(serviceVM);
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "services"), model.File);
                    dbService.Image = imageName;
                }

                _context.Services.Update(dbService);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(serviceVM);
            }
        }

        // GET: ServiceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (service == null) return NotFound();

            return View(new ServiceViewModel { Name = service.Name, Description = service.Description, Image = service.Image });
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ServiceViewModel model)
        {
            var dbService = await _context.Services.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (dbService == null) return NotFound();
            ServiceViewModel serviceVM = new ServiceViewModel { Name = dbService.Name, Image = dbService.Image, Description = dbService.Description };

            try
            {
                if (!ModelState.IsValid) return View(serviceVM);

                dbService.IsDeleted = true;

                _context.Services.Update(dbService);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(serviceVM);
            }
        }
    }
}
