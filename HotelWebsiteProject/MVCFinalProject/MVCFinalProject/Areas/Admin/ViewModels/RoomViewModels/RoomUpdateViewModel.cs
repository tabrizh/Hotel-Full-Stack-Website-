using Microsoft.AspNetCore.Http;
using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Areas.Admin.ViewModels.RoomViewModels
{
    public class RoomUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IFormFile Image { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Description { get; set; }

        [Required,Range(1, 6, ErrorMessage = "Minimum number is 1, maximum is 6")]
        public byte PersonCapacity { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool Popular { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public int HotelId { get; set; }
        public IFormFile[] Images { get; set; }
        public ICollection<int> FeaturesId { get; set; }
        public ICollection<int> ServicesId { get; set; }

        //Get Action
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Features> Features { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
