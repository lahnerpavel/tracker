using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tracker.Data.Models;

namespace Tracker.Data
{
    public class TrackerDbContext : DbContext
    {
        
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<VehicleLocation>? VehicleLocations { get; set; }


        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<VehicleLocation>()
                .HasOne(m => m.Vehicle)
                .WithMany(p => p.Locations);

            IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(type => type.GetForeignKeys())
                .Where(foreignKey => !foreignKey.IsOwnership && foreignKey.DeleteBehavior == DeleteBehavior.Cascade);
            
            foreach (var foreignKey in cascadeFKs)
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            AddTestingData(modelBuilder);
        }

        private void AddTestingData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, Brand = "Ford", Model = "Focus", RegistrationNumber = "ABC-123" },
                new Vehicle { VehicleId = 2, Brand = "Toyota", Model = "Camry", RegistrationNumber = "XYZ-789" }
            );

            modelBuilder.Entity<VehicleLocation>().HasData(
                new VehicleLocation { LocationId = 1, VehicleId = 1, Latitude = 48.8588443, Longitude = 2.2943506, Timestamp = DateTime.Now },
                new VehicleLocation { LocationId = 2, VehicleId = 2, Latitude = 34.052235, Longitude = -118.243683, Timestamp = DateTime.Now }
            );

        }
    }
}
