using MVCFinalProject.Models;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Models.Pages.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Views.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageBannerSection HomePageBannerSection { get; set; }
        public ICollection<Features> Features { get; set; }
        public ICollection<HomePageAboutSection> AboutSection { get; set; }
        public HomePageGallerySectionText GallerySection { get; set; }
        public ICollection<HomePageGallerySectionImage> GallerySectionImages { get; set; }
        public ICollection<HomePageFeaturesCard> FeaturesCards { get; set; }
        public HomePageTestimonialsSection TestimonialsSection { get; set; }
        public ICollection<HomePageTestimonials> Testimonials { get; set; }
        public HomePageRoomSection HomePageRoomSection { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}