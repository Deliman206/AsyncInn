using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelManageService : IHotelManeger
    {
        // Bring in Database
        private AsyncInnDbContext _context { get; set; }

        public HotelManageService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.HOTEL.Add(hotel);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Hotel> GetHotel(int id)
        {
            return await  _context.HOTEL.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.HOTEL.Update(hotel);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.HOTEL.FirstOrDefault(h => h.ID == id);
            _context.HOTEL.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
