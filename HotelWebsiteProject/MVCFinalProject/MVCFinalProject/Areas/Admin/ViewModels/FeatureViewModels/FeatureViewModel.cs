using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.FeatureViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
    }
}
