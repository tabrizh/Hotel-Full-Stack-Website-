using MVCFinalProject.Models.Entities;
using MVCFinalProject.Models.Pages.RoomPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class RoomPageViewModel
    {
        public RoomPageBanner RoomPageBanner { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
