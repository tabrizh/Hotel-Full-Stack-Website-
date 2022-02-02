using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.PageViewModels.HomePageViewModels
{
    public class HomePageBannerViewModel
    {
        [Required]
        public string Heading { get; set; }
        [Required]
        public string SubHeading { get; set; }
        public IFormFile File { get; set; }

        //Get
        public string Image { get; set; }
    }
}
