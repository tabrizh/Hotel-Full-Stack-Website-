using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.FeatureViewModels
{
    public class FeatureUpdateViewModel
    {
        public IFormFile File { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Name Field is Required")]
        public string Text { get; set; }
    }
}
