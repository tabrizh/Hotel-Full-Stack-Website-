using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Data;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var navLinks = _context.NavigationLinks.Where(n => !n.IsDeleted).ToList();
            var footerTags = _context.FooterTags.Where(n => !n.IsDeleted).ToList();
            LayoutViewModel layoutVM = new LayoutViewModel
            {
                NavigationLinks = navLinks,
                FooterTags = footerTags
            };

            return View(layoutVM);
        }
    }
}
