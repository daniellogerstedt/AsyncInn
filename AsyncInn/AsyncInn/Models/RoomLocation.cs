using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomLocation
    {
        public int RoomLocationId { get; set; }
        public int RoomId { get; set; }
        public int LocationId { get; set; }
        public Room Room { get; set; }
        public Location Location { get; set; }
        public int Price { get; set; }
        public bool PetFriendly { get; set; }
    }
}
