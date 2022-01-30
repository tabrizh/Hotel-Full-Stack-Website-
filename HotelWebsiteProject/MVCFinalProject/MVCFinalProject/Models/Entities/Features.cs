using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class Features : BaseEntity
    {
        public string Image { get; set; }
        public string Text { get; set; }
        public ICollection<RoomFeatures> RoomFeatures { get; set; }
    }
}
