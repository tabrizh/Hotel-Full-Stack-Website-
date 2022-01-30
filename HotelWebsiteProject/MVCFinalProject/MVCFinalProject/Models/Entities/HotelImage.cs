using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class HotelImage : BaseEntity
    {
        public string ImageURL { get; set; }
        public bool IsMain { get; set; }
        public int? Order { get; set; } = 0;
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
    }
}
