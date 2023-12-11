using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tracker.Data.Models;


namespace Tracker.Data
{
    public class TrackerDbContext : IdentityDbContext
    {

        public DbSet<Person>? People { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<VehicleLocation>? VehicleLocations { get; set; }


        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.UseUtcDateTime();

            modelBuilder
                .Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(p => p.MoviesAsDirector);

            modelBuilder
                .Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(p => p.MoviesAsActor)
                .UsingEntity(j => j.ToTable("MovieActors"));

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

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "George Lucas",
                    BirthDate = new DateTime(1944, 4, 15, 0, 0, 0, DateTimeKind.Utc),
                    Country = "USA",
                    Biography = "Vlastním jménem George Walton Lucas, Jr. se narodil 14. května 1944 v Modestu, Kalifornii. Zde také vystudoval proslulou University of Southern California (USC)...",
                    Role = PersonRole.Director
                },
                new Person
                {
                    PersonId = 2,
                    Name = "Irvin Kershner",
                    BirthDate = new DateTime(1923, 4, 29, 0, 0, 0, DateTimeKind.Utc),
                    Country = "USA",
                    Biography = "Irvin Kershner se narodil ve Filadelfii rodičům židovského původu. Jeho uměleckým zaměřením bylo zpočátku hraní na hudební nástroje...",
                    Role = PersonRole.Director
                },
                new Person
                {
                    PersonId = 3,
                    Name = "Harrison Ford",
                    BirthDate = new DateTime(1942, 7, 13, 0, 0, 0, DateTimeKind.Utc),
                    Country = "USA",
                    Biography = "Harrison vyrůstal na Chicagském předměstí, kde jeho otec pracoval jako reklamní manažer. Po střední škole začal Harrison studovat filozofii...",
                    Role = PersonRole.Actor
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "sci-fi" },
                new Genre { GenreId = 2, Name = "adventure" },
                new Genre { GenreId = 3, Name = "action" },
                new Genre { GenreId = 4, Name = "romantic" },
                new Genre { GenreId = 5, Name = "animated" },
                new Genre { GenreId = 6, Name = "comedy" }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, Brand = "Ford", Model = "Focus", RegistrationNumber = "ABC-123" },
                new Vehicle { VehicleId = 2, Brand = "Toyota", Model = "Camry", RegistrationNumber = "XYZ-789" },
                new Vehicle { VehicleId = 3, Brand = "Chevrolet", Model = "Malibu", RegistrationNumber = "DEF-456" },
                new Vehicle { VehicleId = 4, Brand = "Honda", Model = "Civic", RegistrationNumber = "GHI-789" }
            );

            modelBuilder.Entity<VehicleLocation>().HasData(
                new VehicleLocation { LocationId = 1, VehicleId = 1, Latitude = 48.8588443, Longitude = 2.2943506, Timestamp = DateTime.UtcNow },
                new VehicleLocation { LocationId = 2, VehicleId = 2, Latitude = 34.052235, Longitude = -118.243683, Timestamp = DateTime.UtcNow }
            );

        }

        private void ConfigureUtcDateTime(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        // Zde je specifická syntaxe pro PostgreSQL
                        property.SetColumnType("timestamp with time zone");
                    }
                }
            }
        }

    }

    public static class ModelBuilderExtensions
    {
        public static void UseUtcDateTime(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetColumnType("timestamp with time zone");
                    }
                }
            }
        }

    }

    public static class DateTimeExtensions
    {
        public static DateTime? SetKindUtc(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.SetKindUtc();
            }
            else
            {
                return null;
            }
        }
        public static DateTime SetKindUtc(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc) { return dateTime; }
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
    }

}
