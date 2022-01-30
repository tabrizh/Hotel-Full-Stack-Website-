using Microsoft.AspNetCore.Http;
using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.RoomViewModels
{
    public class RoomCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required, Range(1, 10000000, ErrorMessage = "Minimum number is 1")]
        public byte Count { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, Range(1, 6, ErrorMessage = "Minimum number is 1")]
        public byte PersonCapacity { get; set; }

        [Required, Range(15, 500, ErrorMessage = "Minimum number is 15")]
        public int Size { get; set; }

        [Required,Range(20, 100000, ErrorMessage = "Minimum number is 20")]
        public int Price { get; set; }

        [Required]
        public bool Popular { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public IFormFile[] Images { get; set; }

        [Required]
        public ICollection<int> FeaturesId { get; set; }

        [Required]
        public ICollection<int> ServicesId { get; set; }

        //Get Action
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Features> Features { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
