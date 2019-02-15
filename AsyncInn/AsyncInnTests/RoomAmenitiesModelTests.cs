using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AsyncInnTests
{
    public class RoomAmenitiesModelTests
    {
        [Fact]
        public void HotelIdGetSet()
        {
            RoomAmenities hr = new RoomAmenities();
            hr.AmenitiesID = 1;
            Assert.True(hr.AmenitiesID == 1);
        }
        [Fact]
        public void RoomIdGetSet()
        {
            RoomAmenities hr = new RoomAmenities();
            hr.RoomID = 1;
            Assert.True(hr.RoomID == 1);
        }
        [Fact]
        public async void CreateHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.ID = 1;

                Room room = new Room();
                room.ID = 1;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                RoomAmenities ra = new RoomAmenities();
                ra.AmenitiesID = am.ID;
                ra.RoomID = room.ID;

                context.ROOMAMENITIES.Add(ra);
                await context.SaveChangesAsync();

                var result = await context.ROOM.Include("RoomAmenities").FirstOrDefaultAsync(x => x.ID == room.ID);
                Assert.Equal(1, result.RoomAmenities.Count);
            }
        }
        [Fact]
        public async void ReadHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("ReadRoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.ID = 1;

                Room room = new Room();
                room.ID = 1;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                RoomAmenities ra = new RoomAmenities();
                ra.AmenitiesID = am.ID;
                ra.RoomID = room.ID;

                context.ROOMAMENITIES.Add(ra);
                await context.SaveChangesAsync();

                var result = await context.ROOMAMENITIES.FirstOrDefaultAsync(x => x.RoomID == room.ID && x.AmenitiesID == am.ID);
                Assert.Equal(1, result.RoomID);
            }
        }
        [Fact]
        public async void DeleteHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.ID = 1;

                Room room = new Room();
                room.ID = 1;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                RoomAmenities ra = new RoomAmenities();
                ra.AmenitiesID = am.ID;
                ra.RoomID = room.ID;

                context.ROOMAMENITIES.Add(ra);
                await context.SaveChangesAsync();

                var raTest = await context.ROOMAMENITIES.FirstOrDefaultAsync(x => x.RoomID == room.ID && x.AmenitiesID == am.ID);

                context.ROOMAMENITIES.Remove(raTest);
                await context.SaveChangesAsync();

                var result = await context.ROOM.Include("RoomAmenities").FirstOrDefaultAsync(x => x.ID == room.ID);
                Assert.Equal(0, result.RoomAmenities.Count);
            }
        }
    }
}
