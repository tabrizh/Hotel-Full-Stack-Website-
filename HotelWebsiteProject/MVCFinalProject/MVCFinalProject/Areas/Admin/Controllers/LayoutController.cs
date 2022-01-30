//using Fiorella.DAL;
//using Fiorella.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Fiorella.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class LayoutController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _env;
//        public LayoutController(AppDbContext context, IWebHostEnvironment env)
//        {
//            _context = context;
//            _env = env;
//        }
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Layouts.ToListAsync());
//        }

//        public async Task<IActionResult> Details(int id)
//        {
//            var link = await _context.Layouts.FindAsync(id);
//            if (link == null)
//            {
//                return NotFound();
//            }
//            return View(link);
//        }

//        public async Task<IActionResult> Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Layout layout)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View();
//            }

//            if (!layout.File.ContentType.Contains("image"))
//            {
//                ModelState.AddModelError(nameof(Layout.File), "File is not supported");
//                return View();
//            }

//            if (layout.File.Length > 1024 * 1000)
//            {
//                ModelState.AddModelError(nameof(Layout.File), "File size cannot be more than 1mb");
//                return View();
//            }

//            string fileName = Guid.NewGuid() + layout.File.FileName;
//            string webRootPath = _env.WebRootPath;

//            FileStream stream = new FileStream(Path.Combine(webRootPath, "img", fileName), FileMode.Create);
//            await layout.File.CopyToAsync(stream);
//            stream.Close();

//            layout.Logo = fileName;
//            await _context.Layouts.AddAsync(layout);
//            await _context.SaveChangesAsync();

//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            Layout layout = await _context.Layouts.FindAsync(id);
//            if (layout == null)
//            {
//                return NotFound();
//            }
//            return View(layout);
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteLayout(int id)
//        {
//            Layout layout = await _context.Layouts.FindAsync(id);
//            if (layout == null)
//            {
//                return NotFound();
//            }

//            _context.Layouts.Remove(layout);
//            await _context.SaveChangesAsync();

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
