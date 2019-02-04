using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(ce => new { ce.HotelID, ce.RoomID});
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.RoomID, ce.AmenitiesID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Hotel Seattle",
                    City = "Seattle",
                    Phone = 2065556699
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Hotel Springs",
                    City = "Colorado Springs",
                    Phone = 5095556699
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Hotel Surf",
                    City = "Paia",
                    Phone = 8085556699
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Hotel Magic",
                    City = "Salem",
                    Phone = 2065556699
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Hotel Risk",
                    City = "Las Vegas",
                    Phone = 2065556699
                });
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "The Pad",
                    Layout = Layout.Studio,

                },
                new Room
                {
                    ID = 2,
                    Name = "Relax and Meditate",
                    Layout = Layout.Studio,

                },
                new Room
                {
                    ID = 3,
                    Name = "The Get Away",
                    Layout = Layout.OneBedroom,

                },
                new Room
                {
                    ID = 4,
                    Name = "Comfy Office",
                    Layout = Layout.OneBedroom,

                },
                new Room
                {
                    ID = 5,
                    Name = "Family Snoozer",
                    Layout = Layout.TwoBedroom,

                },
                new Room
                {
                    ID = 6,
                    Name = "Party Room",
                    Layout = Layout.TwoBedroom,

                });
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "TV"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "WiFi"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Bathroom Attire"
                },
                new Amenities
                {
                ID = 5,
                Name = "Mini Bar"
                });
        }

        public DbSet<Amenities> AMENITIES { get; set; }
        public DbSet<Hotel> HOTEL { get; set; }
        public DbSet<HotelRoom> HOTELROOM { get; set; }
        public DbSet<Room> Am { get; set; }
        public DbSet<RoomAmenities> ROOMAMENITIES { get; set; }

    }
}
