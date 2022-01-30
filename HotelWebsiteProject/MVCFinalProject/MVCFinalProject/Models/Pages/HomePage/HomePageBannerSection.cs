using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Pages.HomePage
{
    public class HomePageBannerSection : BaseEntity
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string Image { get; set; }
    }
}
