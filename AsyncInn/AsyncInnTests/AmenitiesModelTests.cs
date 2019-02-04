using AsyncInn.Models;
using AsyncInn.Data;
using AsyncInn.Models.Services;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsyncInnTests
{
    public class AmenitiesModelTests
    {
        [Fact]
        public void IDGetSet()
        {
            Amenities am = new Amenities();
            am.ID = 1;
            Assert.Equal(1, am.ID);
        }
        [Fact]
        public void NameGetSet()
        {
            Amenities am = new Amenities();
            am.Name = "Test";
            Assert.Equal("Test", am.Name);
        }
        [Fact]
        public async void CreateAmenities()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.ID = 1;
                am.Name = "TestName";

                AmenitiesManageService amManageService = new AmenitiesManageService(context);
                await amManageService.CreateAmenities(am);

                var result = context.AMENITIES.FirstOrDefault(a => a.ID == am.ID);

                Assert.Equal(am, result);
            }
        }
        [Fact]
        public async void UpdateAmenities()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.ID = 1;
                am.Name = "TestName";

                AmenitiesManageService amManageService = new AmenitiesManageService(context);
                await amManageService.CreateAmenities(am);

                Amenities amUpdate = am;
                amUpdate.Name = "TestNameUpdate";

                await amManageService.UpdateAmenities(amUpdate);
                var result = context.AMENITIES.FirstOrDefault(a => a.ID == am.ID);

                Assert.Equal(am, result);
            }
        }
        [Fact]
        public async void GetAmenities()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.Name = "TestName";

                AmenitiesManageService amManageService = new AmenitiesManageService(context);
                await amManageService.CreateAmenities(am);
                Amenities getAm = await amManageService.GetAmenities(am.ID);
                Assert.Equal(am.Name, getAm.Name);
            }
        }
        [Fact]
        public async void DeleteAmenities()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities am = new Amenities();
                am.ID = 1;
                am.Name = "TestName";

                AmenitiesManageService amManageService = new AmenitiesManageService(context);

                await amManageService.CreateAmenities(am);
                Amenities getAm = await amManageService.GetAmenities(am.ID);
                await amManageService.DeleteAmenities(getAm.ID);
                Amenities notFound = await amManageService.GetAmenities(am.ID);

                Assert.NotEqual(getAm, notFound);
            }
        }
    }
}
