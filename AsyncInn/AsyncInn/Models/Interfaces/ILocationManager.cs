using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface ILocationManager
    {
        Task CreateLocation(Location location);

        void UpdateLocation(int id, Location location);

        void DeleteLocation(Location location);

        Task<Location> GetLocation(int id);

        Task<List<Location>> GetLocations();
    }
}
