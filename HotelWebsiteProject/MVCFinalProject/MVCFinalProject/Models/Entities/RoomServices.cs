using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class RoomServices :BaseEntity
    {
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}
