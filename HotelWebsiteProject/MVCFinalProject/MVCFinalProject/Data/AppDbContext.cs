using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Models.Account;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Models.Pages.Layout;
using MVCFinalProject.Models.Pages.HomePage;
using MVCFinalProject.Models.Pages.ServicePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinalProject.Models.Pages.AboutPage;
using MVCFinalProject.Models.Pages.ContactPage;
using MVCFinalProject.Models.Pages.HotelPage;
using MVCFinalProject.Models.Pages.RoomPage;

namespace MVCFinalProject.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Logo> Logo { get; set; }
        public DbSet<NavigationLinks> NavigationLinks { get; set; }
        public DbSet<HomePageBannerSection> HomePageBannerSection { get; set; }
        public DbSet<FooterTags> FooterTags { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<HomePageAboutSection> AboutSection { get; set; }
        public DbSet<HomePageGallerySectionText> GallerySectionText { get; set; }
        public DbSet<HomePageGallerySectionImage> GallerySectionImages { get; set; }
        public DbSet<HomePageFeaturesCard> FeaturesCards { get; set; }
        public DbSet<HomePageRoomSection> HomePageRoomSection { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RoomFeatures> RoomFeatures { get; set; }
        public DbSet<RoomServices> RoomServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<HomePageTestimonialsSection> TestimonialsSection { get; set; }
        public DbSet<HomePageTestimonials> Testimonials { get; set; }
        public DbSet<AboutPageSectionBanner> AboutPageSectionBanner { get; set; }
        public DbSet<AboutPageCEOSection> AboutPageCEOSection { get; set; }
        public DbSet<AboutPageVideoSection> AboutPageVideoSections { get; set; }
        public DbSet<AboutPageTeamSection> TeamSection { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<ServicePageBannerSection> ServicePageBannerSection { get; set; }
        public DbSet<ServicePageServicesSection> ServicePageServicesSections { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ContactPageBannerSection> ContactPageBannerSection { get; set; }
        public DbSet<ContactPageCardsSection> ContactPageCardsSection { get; set; }
        public DbSet<ContactPageMapSection> ContactPageMapSection { get; set; }
        public DbSet<HotelPageBanner> HotelPageBanner { get; set; }
        public DbSet<RoomPageBanner> RoomPageBanner { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
    }
}
