using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task CreateAmenities(Amenities amenities);

        Task<Room> GetAmenities(int id);

        Task UpdateAmenities(Amenities amenities);

        Task DeleteAmenities(int id);
    }
}