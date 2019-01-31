using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManeger
    {
        Task CreateRoom(Room room);

        Task<Room> GetRoom(int id);

        Task UpdateRoom(Room room);

        Task DeleteRoom(int id);
    }
}
