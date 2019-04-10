using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        Task CreateRoom(Room room);

        void UpdateRoom(int id, Room room);

        void DeleteRoom(Room room);

        Task<Room> GetRoom(int id);

        Task<List<Room>> GetRooms();
    }
}
