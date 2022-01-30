using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Category { get; set; }
        public string Description { get; set; }
        public byte PersonCapacity { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public bool Popular { get; set; }
        public DateTime? BookingStartDate { get; set; }
        public DateTime? BookingEndDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public byte HowManyAvailable { get; set; } 
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public ICollection<RoomImage> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }

        // Pivot Tables

        public ICollection<Features> Features { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
