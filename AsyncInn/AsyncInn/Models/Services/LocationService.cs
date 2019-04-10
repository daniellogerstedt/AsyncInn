using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class LocationService : ILocationManager
    {
        private AsyncInnDBContext _context;

        public LocationService (AsyncInnDBContext context)
        {
            _context = context;
        }


        public async Task CreateLocation(Location location)
        {
            _context.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task<Location> GetLocation(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<List<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public void DeleteLocation(Location location)
        {
            _context.Remove(location);
        }

        public void UpdateLocation(int id, Location location)
        {
            throw new NotImplementedException();
        }
    }
}
