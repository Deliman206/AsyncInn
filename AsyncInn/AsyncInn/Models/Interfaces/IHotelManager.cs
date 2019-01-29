using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManeger
    {
        Task CreateHotel(Hotel hotel);

        Task<Hotel> GetHotel(int id);

        void UpdateHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}
