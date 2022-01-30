//using Fiorella.DAL;
//using Fiorella.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Fiorella.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class CategoryController : Controller
//    {
//        private readonly AppDbContext _context;
//        public CategoryController(AppDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IActionResult> Index()
//        {
//            var categories = await _context.Categories.ToListAsync();
//            return View(categories);
//        }
//        public async Task<IActionResult> Details(int id)
//        {
//            var category = await _context.Categories.FindAsync(id);
//            if (category == null)
//            {
//                return NotFound();
//            }
//            return View(category);
//        }

        
//        public async Task<IActionResult> Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Category category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View();
//            }

//            await _context.Categories.AddAsync(category);
//            _context.SaveChanges();

//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Update(int id)
//        {
//            if (await _context.Categories.FindAsync(id) == null)
//            {
//                return NotFound();
//            }
//            return View(await _context.Categories.FindAsync(id));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Update(int id, Category category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(category);
//            }

//            if (id != category.Id)
//            {
//                return BadRequest();
//            }

//            bool isExist = await _context.Categories.AnyAsync(c => c.Id == id);

//            if (!isExist)
//            {
//                return NotFound();
//            }

//            _context.Categories.Update(category);
//            await _context.SaveChangesAsync();

//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            Category category = await _context.Categories.FindAsync(id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            return View(category);
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteCategory(int id)
//        {
//            Category category = await _context.Categories.FindAsync(id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            _context.Categories.Remove(category);
//            await _context.SaveChangesAsync();

//            return RedirectToAction(nameof(Index));
//        }


//    }
//}




