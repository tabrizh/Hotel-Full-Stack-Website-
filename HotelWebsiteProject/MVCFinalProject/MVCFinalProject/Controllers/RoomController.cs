using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.Models.Account;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using identityPath = Microsoft.AspNetCore.Identity;

namespace MVCFinalProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly identityPath.UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public RoomController(AppDbContext context, identityPath.UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: RoomController
        public async Task<IActionResult> Index()
        {
            RoomPageViewModel roomVM = new RoomPageViewModel
            {
                RoomPageBanner = await _context.RoomPageBanner.FirstOrDefaultAsync(r => !r.IsDeleted),
                Rooms = await _context.Rooms.Where(r => !r.IsDeleted && r.IsAvailable && r.HowManyAvailable > 0).OrderBy(rr => rr.HotelId).ToListAsync(),
                Hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync()
            };

            return View(roomVM);
        }

        // GET: RoomController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var dbRoom = await _context.Rooms.Include(r => r.Images.Where(i => !i.IsDeleted)).Include(r => r.RoomFeatures.Where(rff => !rff.IsDeleted)).Include(r => r.RoomServices.Where(rss => !rss.IsDeleted))
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted && r.IsAvailable && r.HowManyAvailable > 0);
            
            if (dbRoom == null) return NotFound();

            RoomBookingViewModel roomVM = new RoomBookingViewModel();
            roomVM.RoomDetailsViewModel = (new RoomDetailsViewModel
            {
                Name = dbRoom.Name,
                Description = dbRoom.Description,
                PersonCapacity = dbRoom.PersonCapacity,
                Size = dbRoom.Size,
                Price = dbRoom.Price,
                Popular = dbRoom.Popular,
                IsAvailable = dbRoom.IsAvailable,
                HowManyAvailable = dbRoom.HowManyAvailable,
                Hotel = await _context.Hotels.FindAsync(dbRoom.HotelId),
                Images = await _context.RoomImages.Where(i => i.RoomId == dbRoom.Id && !i.IsDeleted).ToListAsync(),
                Comments = await _context.Comments.Where(c => c.RoomId == dbRoom.Id).ToListAsync(),
                Features = await _context.RoomFeatures.Where(rf => rf.RoomId == dbRoom.Id && !rf.IsDeleted).Select(f => f.Features).ToListAsync(),
                Services = await _context.RoomServices.Where(rs => rs.RoomId == dbRoom.Id && !rs.IsDeleted).Select(s => s.Service).ToListAsync(),
            });

            return View(roomVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(RoomBookingViewModel model, int id)
        {
            var dbRoom = await _context.Rooms.Include(r => r.Images.Where(i => !i.IsDeleted)).Include(r => r.RoomFeatures.Where(rff => !rff.IsDeleted)).Include(r => r.RoomServices.Where(rss => !rss.IsDeleted))
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted && r.IsAvailable && r.HowManyAvailable > 0);

            if (dbRoom == null) return NotFound();

            RoomBookingViewModel roomVM = new RoomBookingViewModel();
            roomVM.RoomDetailsViewModel = (new RoomDetailsViewModel
            {
                Name = dbRoom.Name,
                Description = dbRoom.Description,
                PersonCapacity = dbRoom.PersonCapacity,
                Size = dbRoom.Size,
                Price = dbRoom.Price,
                Popular = dbRoom.Popular,
                IsAvailable = dbRoom.IsAvailable,
                HowManyAvailable = dbRoom.HowManyAvailable,
                Hotel = await _context.Hotels.FindAsync(dbRoom.HotelId),
                Images = await _context.RoomImages.Where(i => i.RoomId == dbRoom.Id).ToListAsync(),
                Comments = await _context.Comments.Where(c => c.RoomId == dbRoom.Id).ToListAsync(),
                Features = await _context.RoomFeatures.Where(rf => rf.RoomId == dbRoom.Id && !rf.IsDeleted).Select(f => f.Features).ToListAsync(),
                Services = await _context.RoomServices.Where(rs => rs.RoomId == dbRoom.Id && !rs.IsDeleted).Select(s => s.Service).ToListAsync(),
            });

            TempData["Fail"] = $"Hörmətli {User.Identity.Name}, Rezervasiyanız ilə xəta baş vermişdi. Zəhmət olmasa yenidən təkrar edin.";
            if (!ModelState.IsValid) return View(roomVM);

            CultureInfo ci = new CultureInfo("az-Latn-AZ");
            var start = DateTime.ParseExact(model.BookingsViewModel.StartDate, "MM/dd/yyyy", ci);
            var end = DateTime.ParseExact(model.BookingsViewModel.EndDate, "MM/dd/yyyy", ci);
            if (DateTime.Compare(start, DateTime.Now) < 0)
            {
                ModelState.AddModelError("BookingsViewModel.EndDate", "The End Date Cannot Be Earlier Than Current Date");
                return View(roomVM);
            }
            if (DateTime.Compare(end, start) <= 0)
            {
                ModelState.AddModelError("BookingsViewModel.EndDate", "The End Date Cannot Be Earlier Than The Start Date and The Minimum Stay is 1 Night");
                return View(roomVM);
            }
            if (start > DateTime.Now.AddYears(1) && end > DateTime.Now.AddYears(1))
            {
                ModelState.AddModelError(nameof(BookingsViewModel.StartDate), "The longest peroid to book in advance is 1 year");
                ModelState.AddModelError("BookingsViewModel.EndDate", "The longest peroid to book in advance is 1 year");
                return View(roomVM);
            }
            var daysBooked = end.Day - start.Day;

            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted && r.IsAvailable);
            if (room == null) return NotFound();

            if (!User.Identity.IsAuthenticated) return BadRequest();

            Reservations reservations = new Reservations
            {
                RoomId = room.Id,
                UserId = _userManager.GetUserId(User),
                StartDate = start,
                EndDate = end,
                Price = daysBooked * room.Price
            };

            await _context.Reservations.AddAsync(reservations);
            await _context.SaveChangesAsync();

            var startDateAZ = start.ToString("dd MMMM yyyy", ci);
            var endDateAZ = end.ToString("dd MMMM yyyy", ci);

            TempData["Success"] = $"Hörmətli {User.Identity.Name} sizin {startDateAZ} tarixindən {endDateAZ} tarixinədək Reservasiyanız uğurla tamamlandı. Reservasiyanızın ümumi qiyməti: ₼{reservations.Price}";
            TempData["Fail"] = null;
            return RedirectToAction(nameof(Details));
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
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

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomController/Edit/5
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

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
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
