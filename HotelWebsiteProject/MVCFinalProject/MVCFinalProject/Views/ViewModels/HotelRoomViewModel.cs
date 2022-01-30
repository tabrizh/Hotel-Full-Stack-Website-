using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class HotelRoomViewModel
    {
        public RoomPageViewModel RoomPageViewModel { get; set; }
        public Hotel Hotel { get; set; }
    }
}
