using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _context;
        public HotelController(AppDbContext context)
        {
            _context = context;
        }
        // GET: HotelController
        public async Task<IActionResult> Index()
        {
            HotelPageViewModel hotelVM = new HotelPageViewModel
            {
                HotelPageBanner = await _context.HotelPageBanner.FirstOrDefaultAsync(h => !h.IsDeleted),
                Hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync()
            };

            return View(hotelVM);
        }

        // GET: HotelController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HotelRoomViewModel hotelRoomVM = new HotelRoomViewModel
            {
                RoomPageViewModel = new RoomPageViewModel 
                {
                    Rooms = await _context.Rooms.Where(r => !r.IsDeleted && r.HotelId == id && r.IsAvailable && r.HowManyAvailable > 0).ToListAsync(), 
                    RoomPageBanner = await _context.RoomPageBanner.FirstOrDefaultAsync(r => !r.IsDeleted) 
                },
                Hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id)
            };

            if (hotelRoomVM == null) return NotFound();

            return View(hotelRoomVM);
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelController/Create
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

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HotelController/Edit/5
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

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelController/Delete/5
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
