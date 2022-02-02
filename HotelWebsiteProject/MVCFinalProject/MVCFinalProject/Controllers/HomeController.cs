using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel homeVM = new HomePageViewModel
            {
                HomePageBannerSection = await _context.HomePageBannerSection.FirstOrDefaultAsync(b => !b.IsDeleted), 
                Features = await _context.Features.Where(f => !f.IsDeleted && f.Selected).ToListAsync(),
                AboutSection = await _context.AboutSection.Where(a => !a.IsDeleted).ToListAsync(),
                GallerySection = await _context.GallerySectionText.FirstOrDefaultAsync(g => !g.IsDeleted),
                GallerySectionImages = await _context.GallerySectionImages.Where(i => !i.IsDeleted).ToListAsync(),
                FeaturesCards = await _context.FeaturesCards.Where(f => !f.IsDeleted).ToListAsync(),
                TestimonialsSection = await _context.TestimonialsSection.FirstOrDefaultAsync(t => !t.IsDeleted),
                Testimonials = await _context.Testimonials.Where(t => !t.IsDeleted).ToListAsync(),
                HomePageRoomSection = await _context.HomePageRoomSection.FirstOrDefaultAsync(t => !t.IsDeleted),
                Rooms = await _context.Rooms.Where(r => !r.IsDeleted && r.Popular).Take(10).ToListAsync(),
                Hotels = await _context.Hotels.Where(h => !h.IsDeleted).ToListAsync()
            };

            return View(homeVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
