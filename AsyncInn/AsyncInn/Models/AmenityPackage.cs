using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class AmenityPackage
    {
        public int AmenityPackageId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool AC { get; set; }
        public bool OceanView { get; set; }
        public bool MountainView { get; set; }
        public bool Minibar { get; set; }
        public bool PrivateBeach { get; set; }
        public bool Hottub { get; set; }
        public bool Penthouse { get; set; }
        public bool Valet { get; set; }
        public bool ContinentalBreakfast { get; set; }
        public bool Coffee { get; set; }
    }
}
