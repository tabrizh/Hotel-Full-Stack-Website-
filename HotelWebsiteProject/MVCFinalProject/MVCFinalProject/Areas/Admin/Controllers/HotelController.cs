using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Areas.Admin.ViewModels.HotelViewModels;
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
    [Authorize(Roles = RoleConstants.Admin + "," + RoleConstants.Moderator + "," + RoleConstants.Hotel)]
    public class HotelController : Controller
    {
        private readonly AppDbContext _context;
        public HotelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HotelController
        public async Task<ActionResult> Index()
        {
            var hotels = await _context.Hotels.Where(h => !h.IsDeleted).Include(h => h.Rooms).ToListAsync();

            List<HotelViewModel> hotelsVM = new List<HotelViewModel>();

            foreach (var hotel in hotels)
            {
                hotelsVM.Add(new HotelViewModel
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Image = hotel.Image,
                    Description = hotel.Description,
                    StarCount = hotel.StarCount,
                    Popular = hotel.Popular,
                    Rooms = hotel.Rooms
                });
            }

            return View(hotelsVM);
        }

        // GET: HotelController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var contextHotel = await _context.Hotels.Include(h => h.Rooms.Where(r => r!.IsDeleted)).FirstOrDefaultAsync(hh => hh.Id == id && !hh.IsDeleted);
            if (contextHotel == null) return NotFound();

            HotelViewModel hotelVM = new HotelViewModel
            {
                Id = contextHotel.Id,
                Name = contextHotel.Name,
                Image = contextHotel.Image,
                Description = contextHotel.Description,
                StarCount = contextHotel.StarCount,
                Popular = contextHotel.Popular,
                Rooms = await _context.Rooms.Where(r => r.HotelId == contextHotel.Id && !r.IsDeleted).ToListAsync()
            };

            return View(hotelVM);
        }

        // GET: HotelController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HotelCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                if (model.File == null)
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.File), "Please select an Image");
                    return View();
                }
                if (!model.File.IsImage())
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.File), "File is not supported");
                    return View();
                }

                if (model.File.IsGreaterThanGivenSize(1000))
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.File), "File size cannot be more than 1mb");
                    return View();
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "HOTEL"), model.File);
                Hotel newHotel = new Hotel
                {
                    Name = model.Name,
                    Image = imageName,
                    Description = model.Description,
                    StarCount = model.StarCount
                };

                await _context.Hotels.AddAsync(newHotel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Gözlənilməz xəta baş verdi");
                return View();
            }
        }

        // GET: HotelController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var contextHotel = await _context.Hotels.FindAsync(id);
            if (contextHotel == null) return NotFound();

            HotelCreateViewModel hotelVM = new HotelCreateViewModel
            {
                Name = contextHotel.Name,
                Description = contextHotel.Description,
                StarCount = contextHotel.StarCount
            };

            return View(hotelVM);
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, HotelCreateViewModel model)
        {
            try
            {
                var contextHotel = await _context.Hotels.FindAsync(id);
                if (contextHotel == null) return NotFound();

                if (!ModelState.IsValid) return NotFound();
                if (id != contextHotel.Id) return BadRequest();

                if (model.File == null)
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.File), "Please select an Image");
                    return View();
                }
                if (!model.File.IsImage())
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.File), "File is not supported");
                    return View();
                }

                if (model.File.IsGreaterThanGivenSize(1000))
                {
                    ModelState.AddModelError(nameof(HotelCreateViewModel.File), "File size cannot be more than 1mb");
                    return View();
                }

                FileUtility.DeleteFile(Path.Combine(FileConstants.ImagePath, contextHotel.Image));
                contextHotel.Image = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "HOTEL"), model.File);
                contextHotel.Name = model.Name;
                contextHotel.Description = model.Description;
                contextHotel.StarCount = model.StarCount;
                contextHotel.Popular = model.Popular;

                 _context.Hotels.Update(contextHotel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Gözlənilməz xəta baş verdi");
                return View();
            }
        }

        // GET: HotelController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var contextHotel = await _context.Hotels.FindAsync(id);
            if (contextHotel == null) return NotFound();

            HotelViewModel hotelVM = new HotelViewModel
            {
                Name = contextHotel.Name,
                Description = contextHotel.Description,
                Image = contextHotel.Image,
                StarCount = contextHotel.StarCount
            };

            return View(hotelVM);
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, HotelViewModel model)
        {
            try
            {
                var contextHotel = await _context.Hotels.FindAsync(id);
                if (contextHotel == null) return NotFound();

                contextHotel.IsDeleted = true;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Gözlənilməz xəta baş verdi");
                return View();
            }
        }
    }
}
