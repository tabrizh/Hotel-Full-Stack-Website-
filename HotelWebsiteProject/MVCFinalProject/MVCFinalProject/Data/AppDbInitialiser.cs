using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCFinalProject.Data.Roles;
using MVCFinalProject.Models;
using MVCFinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinalProject.Data
{
    public class AppDbInitialiser
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Hotels
                if (!context.Hotels.Any())
                {
                    context.Hotels.AddRange(new List<Hotel>()
                    {
                        new Hotel()
                        {
                            Name = "Marriott",
                            Image = "marriott.jpg",
                            Description = "This is the description of Marriott Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 5,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Hilton",
                            Image = "hilton.jpg",
                            Description = "This is the description of Hilton Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 5,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Four Seasons",
                            Image = "fourSeasons.jpg",
                            Description = "This is the description of Four Seasons Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 5,
                            Popular = true
                        },
                        new Hotel()
                        {
                            Name = "Hyatt",
                            Image = "hyatt.jpg",
                            Description = "This is the description of Hyatt Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 5,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Inter Continental",
                            Image = "interContinental.jpg",
                            Description = "This is the description of Inter Continental Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 5,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Dorchester",
                            Image = "dorchester.jpg",
                            Description = "This is the description of Dorchester Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 5,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Radisson Collection",
                            Image = "radissonCollection.jpg",
                            Description = "This is the description of Radisson Collection Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 4,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Courtyard",
                            Image = "courtyard.jpg",
                            Description = "This is the description of Courtyard Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 4,
                            Popular = false
                        },
                        new Hotel()
                        {
                            Name = "Novotel",
                            Image = "novotel.jpg",
                            Description = "This is the description of Novotel Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 4,
                            Popular = true
                        },
                        new Hotel()
                        {
                            Name = "Ibis",
                            Image = "ibis.jpg",
                            Description = "This is the description of Ibis Hotel Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            StarCount = 3,
                            Popular = false
                        },
                    });
                    context.SaveChanges();
                }

                //Rooms
                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new List<Room>()
                    {
                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 65,
                            HotelId = 21,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 250,
                            HotelId = 21,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 250,
                            HotelId = 21,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 450,
                            HotelId = 21,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 950,
                            HotelId = 21,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 80,
                            HotelId = 22,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 270,
                            HotelId = 22,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 270,
                            HotelId = 22,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 490,
                            HotelId = 22,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 1120,
                            HotelId = 22,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 90,
                            HotelId = 23,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 280,
                            HotelId = 23,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 280,
                            HotelId = 23,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 495,
                            HotelId = 23,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 1140,
                            HotelId = 23,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 90,
                            HotelId = 24,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 280,
                            HotelId = 24,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 280,
                            HotelId = 24,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 495,
                            HotelId = 24,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 1140,
                            HotelId = 24,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 90,
                            HotelId = 25,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 280,
                            HotelId = 25,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 280,
                            HotelId = 25,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 495,
                            HotelId = 25,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 1140,
                            HotelId = 25,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 90,
                            HotelId = 26,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 280,
                            HotelId = 26,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 280,
                            HotelId = 26,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 495,
                            HotelId = 26,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 1140,
                            HotelId = 26,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 90,
                            HotelId = 27,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 280,
                            HotelId = 27,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 280,
                            HotelId = 27,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 495,
                            HotelId = 27,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Presidential",
                            Image = "1.jpg",
                            Description = "This is the description of Presidential Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 6,
                            Size = 120,
                            Price = 1140,
                            HotelId = 27,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 60,
                            HotelId = 28,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 100,
                            HotelId = 28,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 100,
                            HotelId = 28,
                            Number = 248
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 150,
                            HotelId = 28,
                            Number = 249
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 70,
                            HotelId = 29,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 90,
                            HotelId = 29,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 90,
                            HotelId = 29,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 240,
                            HotelId = 29,
                            Number = 248
                        },

                        new Room()
                        {
                            Name = "Single",
                            Image = "4.jpg",
                            Description = "This is the description of Single Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 1,
                            Size = 40,
                            Price = 20,
                            HotelId = 30,
                            Number = 245
                        },
                        new Room()
                        {
                            Name = "Double",
                            Image = "3.jpg",
                            Description = "This is the description of Double Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = true,
                            PersonCapacity = 2,
                            Size = 70,
                            Price = 40,
                            HotelId = 30,
                            Number = 246
                        },
                        new Room()
                        {
                            Name = "Twin",
                            Image = "2.jpg",
                            Description = "This is the description of Twin Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 3,
                            Size = 70,
                            Price = 40,
                            HotelId = 30,
                            Number = 247
                        },
                        new Room()
                        {
                            Name = "Executive",
                            Image = "3.jpg",
                            Description = "This is the description of Executive Room Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            Popular = false,
                            PersonCapacity = 4,
                            Size = 90,
                            Price = 90,
                            HotelId = 30,
                            Number = 248
                        },
                    });
                    context.SaveChanges();
                }

                //Roles
                if (!context.Roles.Any())
                {
                    context.Roles.Add(new IdentityRole { Name = RoleConstants.Admin, NormalizedName = RoleConstants.Admin.ToUpper() });
                    context.Roles.Add(new IdentityRole { Name = RoleConstants.Moderator, NormalizedName = RoleConstants.Moderator.ToUpper() });
                    context.Roles.Add(new IdentityRole { Name = RoleConstants.User, NormalizedName = RoleConstants.User.ToUpper() });
                    context.Roles.Add(new IdentityRole { Name = RoleConstants.Hotel, NormalizedName = RoleConstants.Hotel.ToUpper() });

                    context.SaveChanges();
                }
            }
        }
    }
}
