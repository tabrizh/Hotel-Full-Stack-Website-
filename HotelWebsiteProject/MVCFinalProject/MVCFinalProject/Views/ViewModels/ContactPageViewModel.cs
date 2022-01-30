using MVCFinalProject.Models.Pages.ContactPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class ContactPageViewModel
    {
        public ContactPageBannerSection ContactPageBannerSection { get; set; }
        public ICollection<ContactPageCardsSection> ContactPageCards { get; set; }
        public ContactPageMapSection ContactPageMapSection { get; set; }
    }
}
