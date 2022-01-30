using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class RoomImage : BaseEntity
    {
        public string ImageURL { get; set; }
        public bool IsMain { get; set; } = false;
        public int Order { get; set; } = 0;
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
