//using Fiorella.Areas.Admin.Constants;
//using Fiorella.Areas.Admin.Utilities;
//using Fiorella.Areas.Admin.ViewModels;
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
//    public class SliderImgController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IWebHostEnvironment _env;
//        public SliderImgController(AppDbContext context, IWebHostEnvironment env)
//        {
//            _context = context;
//            _env = env;
//        }
//        public async Task<IActionResult> Index()
//        {
//            var SliderImages = await _context.SliderImages.ToListAsync();
//            return View(SliderImages);
//        }

//        public async Task<IActionResult> Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(SliderImageViewModel sliderImages)
//        {
//            foreach (var file in sliderImages.Files)
//            {
//                if (!ModelState.IsValid)
//                {
//                    return View();
//                }

//                if (!file.IsImage())
//                {
//                    ModelState.AddModelError(nameof(SliderImageViewModel.Files), "File is not supported");
//                    return View();
//                }

//                if (file.IsGreaterThanGivenSize(1000))
//                {
//                    ModelState.AddModelError(nameof(SliderImageViewModel.Files), "File size cannot be more than 1mb");
//                    return View();
//                }
//                SliderImg sliderImg = new SliderImg();

//                sliderImg.ImgUrl = FileUtility.CreateFile(FileConstants.ImagePath, file);
//                await _context.AddAsync(sliderImg);
//            }


//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            var sliderImg = await _context.SliderImages.FindAsync(id);
//            if (sliderImg == null)
//            {
//                return NotFound();
//            }

//            return View(sliderImg);
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteSliderImg(int id)
//        {
//            var sliderImg = await _context.SliderImages.FindAsync(id);
//            if (sliderImg == null)
//            {
//                return NotFound();
//            }

//            _context.SliderImages.Remove(sliderImg);
//            await _context.SaveChangesAsync();
//            FileUtility.DeleteFile(Path.Combine(FileConstants.ImagePath, sliderImg.ImgUrl));

//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Update(int id)
//        {
//            SliderImg sliderImg = await _context.SliderImages.FindAsync(id);
//            if (sliderImg == null)
//            {
//                return NotFound();
//            }

//            return View(sliderImg);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Update(int id, SliderImg sliderImg)
//        {
//            SliderImg contextSliderImage = await _context.SliderImages.FindAsync(id);

//            if (!ModelState.IsValid)
//            {
//                return View();
//            }

//            if (id != sliderImg.Id)
//            {
//                return BadRequest();
//            }

//            bool isExist = await _context.SliderImages.AnyAsync(s => s.Id == id);

//            if (!isExist)
//            {
//                return NotFound();
//            }

//            FileUtility.DeleteFile(Path.Combine(FileConstants.ImagePath, contextSliderImage.ImgUrl));
            
//            contextSliderImage.ImgUrl = FileUtility.CreateFile(FileConstants.ImagePath, sliderImg.File);
            

//            await _context.SaveChangesAsync();

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
