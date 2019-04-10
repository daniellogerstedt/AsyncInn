using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoomManager
    {
        private AsyncInnDBContext _context;

        public RoomService(AsyncInnDBContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public void DeleteRoom(Room room)
        {
            _context.Remove(room);
        }

        public void UpdateRoom(int id, Room room)
        {
            throw new NotImplementedException();
        }
    }
}
