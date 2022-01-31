using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Areas.Admin.Constants;
using MVCFinalProject.Areas.Admin.Utilities;
using MVCFinalProject.Areas.Admin.ViewModels.RoomViewModels;
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
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RoomController
        public async Task<IActionResult> Index()
        {
            var contextRooms = await _context.Rooms.Where(r => !r.IsDeleted && r.IsAvailable).OrderBy(rr => rr.HotelId).ToListAsync();

            List<RoomViewModel> roomsVM = new List<RoomViewModel>();
            foreach (var room in contextRooms)
            {
                roomsVM.Add(new RoomViewModel
                {
                    Id = room.Id,
                    Name = room.Name,
                    Description = room.Description,
                    Image = room.Image,
                    Number = room.Number,
                    PersonCapacity = room.PersonCapacity,
                    Size = room.Size,
                    Price = room.Price,
                    Popular = room.Popular,
                    IsAvailable = room.IsAvailable,
                    Hotel = await _context.Hotels.FindAsync(room.HotelId)
                });
            }

            return View(roomsVM);
        }

        // GET: RoomController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contextRoom = await _context.Rooms.Include(rf => rf.RoomFeatures).Include(rs => rs.RoomServices)
                .FirstOrDefaultAsync(rr => rr.Id == id && !rr.IsDeleted);
            if (contextRoom == null) return NotFound();

            RoomViewModel roomVM = new RoomViewModel
            {
                Id = contextRoom.Id,
                Name = contextRoom.Name,
                Description = contextRoom.Description,
                Image = contextRoom.Image,
                Number = contextRoom.Number,
                PersonCapacity = contextRoom.PersonCapacity,
                Size = contextRoom.Size,
                Price = contextRoom.Price,
                Popular = contextRoom.Popular,
                Hotel = await _context.Hotels.FindAsync(contextRoom.HotelId),
                Features = await _context.RoomFeatures.Where(rf => rf.RoomId == contextRoom.Id && !rf.IsDeleted).Select(f => f.Features).ToListAsync(),
                Services = await _context.RoomServices.Where(rs => rs.RoomId == contextRoom.Id && !rs.IsDeleted).Select(s => s.Service).ToListAsync(),
                Images = await _context.RoomImages.Where(i => i.RoomId == contextRoom.Id && !i.IsDeleted).ToListAsync()
            };

            return View(roomVM);
        }

        // GET: RoomController/Create
        public async Task<IActionResult> Create()
        {
            RoomCreateViewModel roomVM = new RoomCreateViewModel
            {
                Hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync(),
                Features = await _context.Features.Where(f => !f.IsDeleted).ToListAsync(),
                Services = await _context.Services.Where(s => !s.IsDeleted).ToListAsync()
            };

            return View(roomVM);
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateViewModel model)
        {
            RoomCreateViewModel roomVM = new RoomCreateViewModel
            {
                Hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync(),
                Features = await _context.Features.Where(f => !f.IsDeleted).ToListAsync(),
                Services = await _context.Services.Where(s => !s.IsDeleted).ToListAsync()
            };

            if (!ModelState.IsValid) return View(roomVM);

            Room createdRoom = new Room
            {
                Name = model.Name,
                Description = model.Description,
                Size = model.Size,
                Price = model.Price,
                Number = model.Number,
                HotelId = model.HotelId,
                IsAvailable = model.IsAvailable,
                PersonCapacity = model.PersonCapacity,
                Popular = model.Popular
            };

            if (model.Image != null)
            {
                if (!model.Image.IsImage())
                {
                    ModelState.AddModelError(nameof(RoomCreateViewModel.Image), "File is not supported");
                    return View(roomVM);
                }

                if (model.Image.IsGreaterThanGivenSize(2000))
                {
                    ModelState.AddModelError(nameof(RoomCreateViewModel.Image), "File size cannot be more than 2mb");
                    return View(roomVM);
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "rooms"), model.Image);
                createdRoom.Image = imageName;
            }

            await _context.Rooms.AddAsync(createdRoom);
            await _context.SaveChangesAsync();

            if (model.Images != null)
            {
                List<RoomImage> newImages = new List<RoomImage>();
                foreach (var image in model.Images)
                {
                    if (!image.IsImage())
                    {
                        ModelState.AddModelError(nameof(RoomCreateViewModel.Images), "File is not supported");
                        return View(roomVM);
                    }

                    if (image.IsGreaterThanGivenSize(2000))
                    {
                        ModelState.AddModelError(nameof(RoomCreateViewModel.Images), "File size cannot be more than 2mb");
                        return View(roomVM);
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "rooms", "room"), image);
                    newImages.Add(new RoomImage { RoomId = createdRoom.Id, ImageURL = imageName });
                }
                await _context.RoomImages.AddRangeAsync(newImages);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Room");


            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    ModelState.AddModelError("", "Gözlənilməz xəta baş verdi");
            //    return View();
            //}
        }

        // GET: RoomController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var dbRoom = await _context.Rooms.Include(rf => rf.RoomFeatures).Include(rs => rs.RoomServices).Include(rh => rh.Hotel)
                .FirstOrDefaultAsync(rr => rr.Id == id && !rr.IsDeleted);

            if (dbRoom == null) return NotFound();

            RoomUpdateViewModel roomVM = new RoomUpdateViewModel
            {
                Id = dbRoom.Id,
                Name = dbRoom.Name,
                Description = dbRoom.Description,
                PersonCapacity = dbRoom.PersonCapacity,
                Size = dbRoom.Size,
                Price = dbRoom.Price,
                Popular = dbRoom.Popular,
                IsAvailable = dbRoom.IsAvailable,
                Number = dbRoom.Number,
                HotelId = dbRoom.HotelId,
                Hotels = await _context.Hotels.Where(hh => !hh.IsDeleted).ToListAsync(),
                Features = await _context.Features.Where(ff => !ff.IsDeleted).ToListAsync(),
                Services = await _context.Services.Where(ss => !ss.IsDeleted).ToListAsync()
            };

            return View(roomVM);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, RoomUpdateViewModel model)
        {
            var dbRoom = await _context.Rooms.Include(rf => rf.RoomFeatures.Where(rrf => !rrf.IsDeleted))
                .Include(rs => rs.RoomServices.Where(rrs => !rrs.IsDeleted))
                .FirstOrDefaultAsync(rr => !rr.IsDeleted);
            if (dbRoom == null) return NotFound();

            RoomUpdateViewModel roomVM = new RoomUpdateViewModel
            {
                Id = dbRoom.Id,
                Name = dbRoom.Name,
                Description = dbRoom.Description,
                PersonCapacity = dbRoom.PersonCapacity,
                Size = dbRoom.Size,
                Price = dbRoom.Price,
                Popular = dbRoom.Popular,
                IsAvailable = dbRoom.IsAvailable,
                Number = dbRoom.Number,
                HotelId = dbRoom.HotelId,
                Hotels = await _context.Hotels.Where(hh => !hh.IsDeleted).ToListAsync(),
                Features = await _context.Features.Where(ff => !ff.IsDeleted).ToListAsync(),
                Services = await _context.Services.Where(ss => !ss.IsDeleted).ToListAsync()
            };
            if (!ModelState.IsValid) return View(roomVM);



            dbRoom.Name = model.Name;
            dbRoom.Description = model.Description;
            dbRoom.PersonCapacity = model.PersonCapacity;
            dbRoom.Size = model.Size;
            dbRoom.Popular = model.Popular;
            dbRoom.IsAvailable = model.IsAvailable;
            dbRoom.Number = model.Number;
            dbRoom.Price = model.Price;

            var selectedHotel = await _context.Hotels.FirstOrDefaultAsync(hh => !hh.IsDeleted && hh.Id == model.HotelId);
            if (selectedHotel == null)
            {
                ModelState.AddModelError(nameof(RoomUpdateViewModel.HotelId), "Duzgun sechim edin");
                return View(roomVM);
            }
            dbRoom.HotelId = model.HotelId;

            List<RoomFeatures> roomFeaturesList = new List<RoomFeatures>();
            var roomFeatures = await _context.RoomFeatures.Where(rf => rf.RoomId == dbRoom.Id).Select(r => r.Features).ToListAsync();
            if (model.FeaturesId != null)
            {
                foreach (var featureId in model.FeaturesId)
                {
                    if (!roomFeatures.Any(f => f.Id == featureId))
                    {
                        var rf = await _context.RoomFeatures.Where(rf => rf.RoomId == dbRoom.Id && !rf.IsDeleted).ToListAsync();
                        foreach (var roomfeature in rf)
                        {
                            roomfeature.IsDeleted = true;
                        }
                    }
                }
                foreach (var feature in model.FeaturesId)
                {
                    roomFeaturesList.Add(new RoomFeatures { RoomId = dbRoom.Id, FeaturesId = feature });
                }
            }
            if (roomFeaturesList.Any()) await _context.RoomFeatures.AddRangeAsync(roomFeaturesList);

            List<RoomServices> roomServicesList = new List<RoomServices>();
            var roomServices = await _context.RoomServices.Where(rs => rs.RoomId == dbRoom.Id).Select(s => s.Service).ToListAsync();
            if (model.ServicesId != null)
            {
                foreach (var serviceId in model.ServicesId)
                {
                    if (!roomServices.Any(s => s.Id == serviceId))
                    {
                        var rs = await _context.RoomServices.Where(rs => rs.RoomId == dbRoom.Id && !rs.IsDeleted).ToListAsync();
                        foreach (var roomservice in rs)
                        {
                            roomservice.IsDeleted = true;
                        }
                    }
                }
                foreach (var service in model.ServicesId)
                {
                    roomServicesList.Add(new RoomServices { RoomId = dbRoom.Id, ServiceId = service });
                }
            }
            if (roomServicesList.Any()) await _context.RoomServices.AddRangeAsync(roomServicesList);

            if (model.Image != null)
            {
                if (!model.Image.IsImage())
                {
                    ModelState.AddModelError(nameof(RoomUpdateViewModel.Image), "File is not supported");
                    return View(roomVM);
                }

                if (model.Image.IsGreaterThanGivenSize(1000))
                {
                    ModelState.AddModelError(nameof(RoomUpdateViewModel.Image), "File size cannot be more than 1mb");
                    return View(roomVM);
                }

                var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "rooms"), model.Image);

                dbRoom.Image = imageName;
            }

            if (model.Images != null)
            {
                var roomImages = await _context.RoomImages.Where(i => i.RoomId == dbRoom.Id && !i.IsDeleted).ToListAsync();
                foreach (var img in roomImages)
                {
                    img.IsDeleted = true;
                }
                List<RoomImage> newImages = new List<RoomImage>();
                foreach (var image in model.Images)
                {
                    if (!image.IsImage())
                    {
                        ModelState.AddModelError(nameof(RoomUpdateViewModel.Images), "File is not supported");
                        return View(roomVM);
                    }

                    if (image.IsGreaterThanGivenSize(1000))
                    {
                        ModelState.AddModelError(nameof(RoomUpdateViewModel.Images), "File size cannot be more than 1mb");
                        return View(roomVM);
                    }

                    var imageName = FileUtility.CreateFile(Path.Combine(FileConstants.ImagePath, "rooms", "room"), image);
                    newImages.Add(new RoomImage { RoomId = dbRoom.Id, ImageURL = imageName });
                }
                await _context.RoomImages.AddRangeAsync(newImages);
            }

            _context.Rooms.Update(dbRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }

        // GET: RoomController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var contextRoom = await _context.Rooms.Include(rf => rf.RoomFeatures).Include(rs => rs.RoomServices)
                .FirstOrDefaultAsync(rr => rr.Id == id && !rr.IsDeleted);
            if (contextRoom == null) return NotFound();

            RoomViewModel roomVM = new RoomViewModel
            {
                Id = contextRoom.Id,
                Name = contextRoom.Name,
                Description = contextRoom.Description,
                Image = contextRoom.Image,
                Number = contextRoom.Number,
                PersonCapacity = contextRoom.PersonCapacity,
                Size = contextRoom.Size,
                Price = contextRoom.Price,
                Popular = contextRoom.Popular,
                Hotel = await _context.Hotels.FindAsync(contextRoom.HotelId),
                Features = await _context.RoomFeatures.Where(rf => rf.RoomId == contextRoom.Id && !rf.IsDeleted).Select(f => f.Features).ToListAsync(),
                Services = await _context.RoomServices.Where(rs => rs.RoomId == contextRoom.Id && !rs.IsDeleted).Select(s => s.Service).ToListAsync(),
                Images = await _context.RoomImages.Where(i => i.RoomId == contextRoom.Id && !i.IsDeleted).ToListAsync()
            };

            return View(roomVM);
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var contextRoom = await _context.Rooms.Include(rf => rf.RoomFeatures).Include(rs => rs.RoomServices)
                .FirstOrDefaultAsync(rr => rr.Id == id && !rr.IsDeleted);
                if (contextRoom == null) return NotFound();

                contextRoom.IsDeleted = true;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "Room");
            }
            catch
            {
                var contextRoom = await _context.Rooms.Include(rf => rf.RoomFeatures).Include(rs => rs.RoomServices)
                .FirstOrDefaultAsync(rr => rr.Id == id && !rr.IsDeleted);
                if (contextRoom == null) return NotFound();

                RoomViewModel roomVM = new RoomViewModel
                {
                    Id = contextRoom.Id,
                    Name = contextRoom.Name,
                    Description = contextRoom.Description,
                    Image = contextRoom.Image,
                    Number = contextRoom.Number,
                    PersonCapacity = contextRoom.PersonCapacity,
                    Size = contextRoom.Size,
                    Price = contextRoom.Price,
                    Popular = contextRoom.Popular,
                    Hotel = await _context.Hotels.FindAsync(contextRoom.HotelId),
                    Features = await _context.RoomFeatures.Where(rf => rf.RoomId == contextRoom.Id && !rf.IsDeleted).Select(f => f.Features).ToListAsync(),
                    Services = await _context.RoomServices.Where(rs => rs.RoomId == contextRoom.Id && !rs.IsDeleted).Select(s => s.Service).ToListAsync(),
                    Images = await _context.RoomImages.Where(i => i.RoomId == contextRoom.Id && !i.IsDeleted).ToListAsync()
                };

                ModelState.AddModelError("", "Gözlənilməz xəta baş verdi");
                return View(roomVM);
            }
        }
    }
}
