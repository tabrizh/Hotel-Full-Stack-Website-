using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.HotelViewModels
{
    public class HotelCreateViewModel
    {
        [Required(ErrorMessage = "You Cannot Leave this Field Empty"), 
            MinLength(5, ErrorMessage = "Minimum Length is 5 Characters"), 
            MaxLength(100, ErrorMessage = "Max Length is 100 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Cannot Leave this Field Empty")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "You Cannot Leave this Field Empty"),
            MinLength(10, ErrorMessage = "Minimum Length is 50 Characters"),
            MaxLength(500, ErrorMessage = "Max Length is 500 Characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You Cannot Leave this Field Empty"), Range(1,5, ErrorMessage = "Star count can be a number between 1 and 5")]
        public byte StarCount { get; set; }
        public bool Popular { get; set; } = false;
    }
}
