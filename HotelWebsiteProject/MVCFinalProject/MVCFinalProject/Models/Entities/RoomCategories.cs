using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class RoomCategories : BaseEntity
    {
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
