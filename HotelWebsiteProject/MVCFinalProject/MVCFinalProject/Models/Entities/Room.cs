using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Category { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public byte PersonCapacity { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public bool Popular { get; set; }
        public bool IsAvailable { get; set; } = true;
        public byte HowManyAvailable { get; set; } 
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public ICollection<RoomImage> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }

        // Pivot Tables
        public ICollection<RoomFeatures> RoomFeatures { get; set; }
        public ICollection<RoomCategories> RoomCategories { get; set; }
        public ICollection<RoomServices> RoomServices { get; set; }
        public ICollection<Reservations> Reservations { get; set; }
    }
}
