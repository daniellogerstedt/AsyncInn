using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;

namespace AsyncInn.Data
{
    public class AsyncInnDBContext : DbContext
    {
        public AsyncInnDBContext(DbContextOptions<AsyncInnDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomLocationAmenities>().HasKey(rla => new { rla.Location, rla.Amenities });
        }

        // Database Tables.
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AmenityPackage> AmenityPackages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RoomLocation> RoomLocations { get; set; }
        public DbSet<RoomLocationAmenities> RoomLocationAmenities { get; set; }

    }
}
