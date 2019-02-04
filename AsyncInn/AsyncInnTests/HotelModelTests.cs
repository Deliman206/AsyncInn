using AsyncInn.Models;
using AsyncInn.Data;
using AsyncInn.Models.Services;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsyncInnTests
{
    public class HotelModelTests
    {
        [Fact]
        public void IDGetSet()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 1;
            Assert.Equal(1, hotel.ID);
        }
        [Fact]
        public void NameGetSet()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Test";
            Assert.Equal("Test", hotel.Name);
        }
        [Fact]
        public void CityGetSet()
        {
            Hotel hotel = new Hotel();
            hotel.City = "Test";
            Assert.Equal("Test", hotel.City);
        }
        [Fact]
        public void PhoneGetSet()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = 1234;
            Assert.Equal(1234, hotel.Phone);
        }
        [Fact]
        public async void CreateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using(AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);

                var result = context.HOTEL.FirstOrDefault(h => h.ID == hotel.ID);

                Assert.Equal(hotel, result);
            }
        }
        [Fact]
        public async void UpdateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel1 = new Hotel();
                hotel1.ID = 1;
                hotel1.Name = "TestName";
                hotel1.City = "TestCity";
                hotel1.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel1);

                Hotel hotel2 = hotel1;
                hotel2.Name = "UpdateName";
                hotel2.City = "UpdateCity";
                hotel2.Phone = 1234567890;
                
                await hotelManageService.UpdateHotel(hotel2);

                var result = context.HOTEL.FirstOrDefault(h => h.ID == hotel1.ID);
                Assert.Equal("UpdateName", hotel1.Name);
            }
        }
        [Fact]
        public async void GetHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);

                Hotel getHotel = await hotelManageService.GetHotel(hotel.ID);

                Assert.Equal(hotel.ID, getHotel.ID);
            }
        }
        [Fact]
        public async System.Threading.Tasks.Task DeleteHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.Name = "TestName";
                hotel.City = "TestCity";
                hotel.Phone = 1234;

                HotelManageService hotelManageService = new HotelManageService(context);
                await hotelManageService.CreateHotel(hotel);
                Hotel found = await hotelManageService.GetHotel(hotel.ID);
                await hotelManageService.DeleteHotel(hotel.ID);
                Hotel notFound = await hotelManageService.GetHotel(hotel.ID);
                Assert.NotEqual(notFound, found);
            }
        }
    }
}
