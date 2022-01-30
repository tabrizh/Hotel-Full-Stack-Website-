using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
