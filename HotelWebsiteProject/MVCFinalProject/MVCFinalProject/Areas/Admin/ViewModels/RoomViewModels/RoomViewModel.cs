using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.RoomViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public byte PersonCapacity { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public bool Popular { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Hotel Hotel { get; set; }
        public ICollection<RoomImage> Images { get; set; }
        public ICollection<Features> Features { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
