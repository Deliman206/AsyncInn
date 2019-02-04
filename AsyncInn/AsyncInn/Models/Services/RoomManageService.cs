using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomManageService : IRoomManeger
    {
        // Bring in Database
        private AsyncInnDbContext _context { get; set; }

        public RoomManageService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Am.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = _context.Am.FirstOrDefault(h => h.ID == id);
            _context.Am.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Am.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Am.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
