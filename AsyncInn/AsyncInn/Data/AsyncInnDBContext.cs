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

        }
        public DbSet<Amenities> AMENITIES { get; set; }
        public DbSet<Hotel> HOTEL { get; set; }
        public DbSet<HotelRoom> HOTELROOM { get; set; }
        public DbSet<Room> ROOM { get; set; }
        public DbSet<RoomAmenities> ROOMAMENITIES { get; set; }

    }
}
