using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenitiesManageService : IAmenitiesManager
    {
        // Bring in Database
        private AsyncInnDbContext _context { get; set; }

        public AmenitiesManageService(AsyncInnDbContext context)
        {
            _context = context;
        }
        

        public async Task CreateAmenities(Amenities amenities)
        {
            _context.AMENITIES.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenities(int id)
        {
            return await _context.AMENITIES.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task UpdateAmenities(Amenities amenities)
        {
            _context.AMENITIES.Update(amenities);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAmenities(int id)
        {
            Amenities amenities = _context.AMENITIES.FirstOrDefault(h => h.ID == id);
            _context.AMENITIES.Remove(amenities);
            await _context.SaveChangesAsync();
        }
    }
}
