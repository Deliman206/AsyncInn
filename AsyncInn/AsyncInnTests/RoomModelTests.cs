using AsyncInn.Models;
using AsyncInn.Data;
using AsyncInn.Models.Services;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsyncInnTests
{
    public class RoomModelTests
    {
        [Fact]
        public void IDGetSet()
        {
            Room room = new Room();
            room.ID = 1;
            Assert.Equal(1, room.ID);
        }
        [Fact]
        public void NameGetSet()
        {
            Room room = new Room();
            room.Name = "Test";
            Assert.Equal("Test", room.Name);
        }
        [Fact]
        public void LayoutGetSet()
        {
            Room room = new Room();
            room.Layout =  Layout.Studio;
            Assert.Equal("Studio", room.Layout.ToString());
        }
        [Fact]
        public async void CreateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                var result = context.Am.FirstOrDefault(r => r.ID == room.ID);

                Assert.Equal(room, result);
            }
        }
        [Fact]
        public async void UpdateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);

                Room roomUpdate = room;
                roomUpdate.ID = 1;
                roomUpdate.Name = "TestNameUpdate";
                roomUpdate.Layout = Layout.OneBedroom;
                
                await roomManageService.UpdateRoom(roomUpdate);
                var result = context.Am.FirstOrDefault(r => r.ID == room.ID);

                Assert.Equal(room.Layout, result.Layout);
            }
        }
        [Fact]
        public async void GetRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);
                await roomManageService.CreateRoom(room);
                Room getRoom = await roomManageService.GetRoom(room.ID);
                Assert.Equal(room.Name, getRoom.Name);
            }
        }
        [Fact]
        public async void DeleteRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 1;
                room.Name = "TestName";
                room.Layout = Layout.Studio;

                RoomManageService roomManageService = new RoomManageService(context);

                await roomManageService.CreateRoom(room);
                Room getRoom = await roomManageService.GetRoom(room.ID);
                await roomManageService.DeleteRoom(getRoom.ID);
                Room notFound = await roomManageService.GetRoom(room.ID);

                Assert.NotEqual(getRoom, notFound);
            }
        }
    }
}
