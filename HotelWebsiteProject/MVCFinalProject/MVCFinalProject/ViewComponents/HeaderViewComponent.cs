using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Data;
using MVCFinalProject.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var logo = _context.Logo.FirstOrDefault();
            var navLinks = _context.NavigationLinks.Where(n => !n.IsDeleted).ToList();
            var footerTags = _context.FooterTags.Where(n => !n.IsDeleted).ToList();
            LayoutViewModel layoutVM = new LayoutViewModel
            {
                LogoURL = logo,
                NavigationLinks = navLinks,
                FooterTags = footerTags
            };
            return View(layoutVM);
        }
    }
}
