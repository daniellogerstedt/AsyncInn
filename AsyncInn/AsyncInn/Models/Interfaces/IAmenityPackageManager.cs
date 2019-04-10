using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenityPackageManager
    {
        Task CreateAmenityPackage(AmenityPackage amenityPackage);

        void UpdateAmenityPackage(int id, AmenityPackage amenityPackage);

        void DeleteAmenityPackage(AmenityPackage amenityPackage);

        Task<AmenityPackage> GetAmenityPackage(int id);

        Task<List<AmenityPackage>> GetAmenityPackages();
    }
}
