using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IRoomLocationManager
    {
        Task CreateRoomLocation(RoomLocation roomLocation);

        void UpdateRoomLocation(int id, RoomLocation roomLocation);

        void DeleteRoomLocation(RoomLocation roomLocation);

        Task<RoomLocation> GetRoomLocation(int id);

        Task<List<RoomLocation>> GetRoomLocations();
    }
}
