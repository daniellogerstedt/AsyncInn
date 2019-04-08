using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomLocationAmenities
    {
        public int LocationId { get; set; }
        public int AmenitiesId { get; set; }
        public RoomLocation Location { get; set; }
        public AmenityPackage Amenities { get; set; }

    }
}
