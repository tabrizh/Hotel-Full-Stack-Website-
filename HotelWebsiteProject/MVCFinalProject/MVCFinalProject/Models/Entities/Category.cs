using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public ICollection<RoomCategories> RoomCategories { get; set; }
    }
}
