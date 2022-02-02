using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.PageViewModels.HomePageViewModels
{
    public class HomePageFeaturesViewModel
    {
        public ICollection<int> SelectedFeatures { get; set; }

        //Get
        public ICollection<Features> Features { get; set; }
    }
}
