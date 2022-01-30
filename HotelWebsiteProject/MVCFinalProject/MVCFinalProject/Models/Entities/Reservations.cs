using MVCFinalProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class Reservations : BaseEntity
    {
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
