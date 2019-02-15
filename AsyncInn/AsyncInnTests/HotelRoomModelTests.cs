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
    public class HotelRoomModelTests
    {
        [Fact]
        public void HotelIdGetSet()
        {
            HotelRoom hr = new HotelRoom();
            hr.HotelID = 1;
            Assert.True(hr.HotelID == 1);
        }
        [Fact]
        public void RoomIdGetSet()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomID = 1;
            Assert.True(hr.RoomID == 1);
        }
        [Fact]
        public void RoomNumberGetSet()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = "A104";
            Assert.True(hr.RoomNumber == "A104");
        }
        [Fact]
        public void RateGetSet()
        {
            HotelRoom hr = new HotelRoom();
            hr.Rate = "100";
            Assert.True(hr.Rate == "100");
        }

        [Fact]
        public async void CreateHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);

                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                HotelRoom hr = new HotelRoom();
                hr.HotelID = hotel.ID;
                hr.RoomID = room.ID;
                hr.RoomNumber = "A104";
                hr.Rate = "100";

                context.HOTELROOM.Add(hr);
                await context.SaveChangesAsync();

                var result = await context.HOTEL.Include("HotelRoom").FirstOrDefaultAsync(x => x.ID == hotel.ID);
                Assert.Equal(1, result.HotelRoom.Count);
            }
        }
        [Fact]
        public async void ReadHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("ReadHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);

                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                HotelRoom hr = new HotelRoom();
                hr.HotelID = hotel.ID;
                hr.RoomID = room.ID;
                hr.RoomNumber = "A104";
                hr.Rate = "100";

                context.HOTELROOM.Add(hr);
                await context.SaveChangesAsync();

                var result = await context.HOTELROOM.Where(h => h.HotelID == hotel.ID && h.RoomID == room.ID).FirstOrDefaultAsync();
                Assert.Equal("A104", result.RoomNumber);
            }
        }
        [Fact]
        public async void UpdateHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);

                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                HotelRoom hrTest = new HotelRoom();
                hrTest.HotelID = hotel.ID;
                hrTest.RoomID = room.ID;
                hrTest.RoomNumber = "A104";
                hrTest.Rate = "100";

                context.HOTELROOM.Add(hrTest);
                await context.SaveChangesAsync();

                HotelRoom hr = await context.HOTELROOM.Where(h => h.HotelID == hotel.ID && h.RoomID == room.ID).FirstOrDefaultAsync();
                hr.Rate = "250";

                context.HOTELROOM.Update(hr);
                await context.SaveChangesAsync();

                Assert.Equal("250", hrTest.Rate);
            }
        }
        [Fact]
        public async void DeleteHotelRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);

                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                HotelRoom hrTest = new HotelRoom();
                hrTest.HotelID = hotel.ID;
                hrTest.RoomID = room.ID;
                hrTest.RoomNumber = "A104";
                hrTest.Rate = "100";

                context.HOTELROOM.Add(hrTest);
                await context.SaveChangesAsync();

                HotelRoom hr = await context.HOTELROOM.Where(h => h.HotelID == hotel.ID && h.RoomID == room.ID).FirstOrDefaultAsync();

                context.HOTELROOM.Remove(hr);
                await context.SaveChangesAsync();

                var result = await context.HOTEL.Include("HotelRoom").FirstOrDefaultAsync(x => x.ID == hotel.ID);
                Assert.Equal(0, result.HotelRoom.Count);
            }
        }
    }
}
