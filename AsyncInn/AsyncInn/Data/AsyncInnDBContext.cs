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
            modelBuilder.Entity<RoomLocationAmenities>().HasKey(rla => new { rla.RoomLocationId, rla.AmenityPackageId });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    Bedrooms = 3,
                    Roomshape = "Square",
                    Nickname = "The Boxer"
                },
                new Room
                {
                    RoomId = 2,
                    Bedrooms = 3,
                    Roomshape = "Triangle",
                    Nickname = "The Pyramid"
                },
                new Room
                {
                    RoomId = 3,
                    Bedrooms = 2,
                    Roomshape = "Multifloor",
                    Nickname = "The Tower"
                },
                new Room
                {
                    RoomId = 4,
                    Bedrooms = 0,
                    Roomshape = "Circle",
                    Nickname = "The Beer Glass"
                });
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    Name = "Sea City",
                    Address = "123 Place Street",
                    City = "City of Sea",
                    State = "Some State",
                    Phone = "1111111111"
                });
            modelBuilder.Entity<AmenityPackage>().HasData(
                new AmenityPackage
                {
                    AmenityPackageId = 1,
                    Name = "The Fresh",
                    Cost = 9001,
                    AC = true,
                    OceanView = true,
                    MountainView = true,
                    Minibar = true,
                    PrivateBeach = true,
                    Hottub = true,
                    Penthouse = true,
                    Valet = true,
                    ContinentalBreakfast = true,
                    Coffee = true
                });
            modelBuilder.Entity<RoomLocation>().HasData(
                new RoomLocation
                {
                    RoomLocationId = 1,
                    LocationId = 1,
                    RoomId = 1,
                    PetFriendly = true,
                    Price = 1000,
                });
            modelBuilder.Entity<RoomLocationAmenities>().HasData(
                new RoomLocationAmenities
                {
                    RoomLocationId = 1,
                    AmenityPackageId = 1
                });
        }

        // Database Tables.
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AmenityPackage> AmenityPackages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RoomLocation> RoomLocations { get; set; }
        public DbSet<RoomLocationAmenities> RoomLocationAmenities { get; set; }

    }
}
