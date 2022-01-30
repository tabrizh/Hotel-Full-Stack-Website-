using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.HotelViewModels
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } 
        public string Description { get; set; }
        public byte StarCount { get; set; } 
        public bool Popular { get; set; } 
        public ICollection<Room> Rooms { get; set; }
    }
}
