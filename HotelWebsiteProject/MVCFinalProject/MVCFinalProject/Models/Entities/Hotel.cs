using System.Collections.Generic;

namespace MVCFinalProject.Models.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; } = "";
        public string Description { get; set; }
        public byte StarCount { get; set; } = 0;
        public bool Popular { get; set; } = false;
        public ICollection<Room> Rooms { get; set; }
        public ICollection<HotelImage> Images { get; set; }
    }
}