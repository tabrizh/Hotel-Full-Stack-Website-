using MVCFinalProject.Models.Pages.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class LayoutViewModel
    {
        public Logo LogoURL { get; set; }
        public ICollection<NavigationLinks> NavigationLinks { get; set; }
        public ICollection<FooterTags> FooterTags { get; set; }
    }
}
