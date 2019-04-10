using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenityPackageService : IAmenityPackageManager
    {
        private AsyncInnDBContext _context;

        public AmenityPackageService(AsyncInnDBContext context)
        {
            _context = context;
        }


        public async Task CreateAmenityPackage(AmenityPackage amenityPackage)
        {
            _context.Add(amenityPackage);
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityPackage> GetAmenityPackage(int id)
        {
            return await _context.AmenityPackages.FindAsync(id);
        }

        public async Task<List<AmenityPackage>> GetAmenityPackages()
        {
            return await _context.AmenityPackages.ToListAsync();
        }

        public void DeleteAmenityPackage(AmenityPackage amenityPackage)
        {
            _context.Remove(amenityPackage);
        }

        public void UpdateAmenityPackage(int id, AmenityPackage amenityPackage)
        {
            throw new NotImplementedException();
        }
    }
}
