using MVCFinalProject.Models;
using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class RoomFeatures : BaseEntity
    {
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public Features Features { get; set; }
        public int FeaturesId { get; set; }
    }
}
