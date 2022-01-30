using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Models.Pages.HomePage
{
    public class HomePageTestimonials : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Country { get; set; }
        public string City { get; set; }
        public byte GivenRating { get; set; }
        public string Comment { get; set; }
    }
}
