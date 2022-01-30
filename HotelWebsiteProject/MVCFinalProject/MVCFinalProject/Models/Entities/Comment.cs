using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Models.Entities
{
    public class Comment : BaseEntity
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public byte GivenStars { get; set; }
        public DateTime Date { get; set; }
        public string CommentText { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
