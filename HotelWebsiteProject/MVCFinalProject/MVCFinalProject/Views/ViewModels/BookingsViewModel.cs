using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class BookingsViewModel
    {
        public int RoomId { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }
        public byte AdultCount { get; set; }
        public byte ChildrenCount { get; set; }
    }
}
