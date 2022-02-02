using Microsoft.AspNetCore.Http;
using MVCFinalProject.Models.Pages.HomePage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.PageViewModels.HomePageViewModels
{
    public class HomePageAboutViewModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string BtnText { get; set; }

        public IFormFile File { get; set; }
    }
}
