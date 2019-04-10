using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomLocationAmenitiesManager
    {
        Task CreateRoomLocationAmenity(RoomLocationAmenities roomLocationAmenities);

        void UpdateRoomLocationAmenity(int id, RoomLocationAmenities roomLocationAmenities);

        void DeleteRoomLocationAmenity(RoomLocationAmenities roomLocationAmenities);

        Task<RoomLocationAmenities> GetRoomLocationAmenity(int id);

        Task<List<RoomLocationAmenities>> GetRoomLocationAmenities();
    }
}
