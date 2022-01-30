using MVCFinalProject.Models.Entities;
using MVCFinalProject.Models.Pages.HotelPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class HotelPageViewModel
    {
        public HotelPageBanner HotelPageBanner { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
