﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracker.Data;

#nullable disable

namespace Tracker.Data.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    [Migration("20231017104655_Migation 17102")]
    partial class Migation17102
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<long>("GenresGenreId")
                        .HasColumnType("bigint");

                    b.Property<long>("MoviesMovieId")
                        .HasColumnType("bigint");

                    b.HasKey("GenresGenreId", "MoviesMovieId");

                    b.HasIndex("MoviesMovieId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MoviePerson", b =>
                {
                    b.Property<long>("ActorsPersonId")
                        .HasColumnType("bigint");

                    b.Property<long>("MoviesAsActorMovieId")
                        .HasColumnType("bigint");

                    b.HasKey("ActorsPersonId", "MoviesAsActorMovieId");

                    b.HasIndex("MoviesAsActorMovieId");

                    b.ToTable("MovieActors", (string)null);
                });

            modelBuilder.Entity("Tracker.Data.Models.Genre", b =>
                {
                    b.Property<long>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GenreId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1L,
                            Name = "sci-fi"
                        },
                        new
                        {
                            GenreId = 2L,
                            Name = "adventure"
                        },
                        new
                        {
                            GenreId = 3L,
                            Name = "action"
                        },
                        new
                        {
                            GenreId = 4L,
                            Name = "romantic"
                        },
                        new
                        {
                            GenreId = 5L,
                            Name = "animated"
                        },
                        new
                        {
                            GenreId = 6L,
                            Name = "comedy"
                        });
                });

            modelBuilder.Entity("Tracker.Data.Models.Movie", b =>
                {
                    b.Property<long>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MovieId"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DirectorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Tracker.Data.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PersonId"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1L,
                            Biography = "Vlastním jménem George Walton Lucas, Jr. se narodil 14. května 1944 v Modestu, Kalifornii. Zde také vystudoval proslulou University of Southern California (USC)...",
                            BirthDate = new DateTime(1944, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "USA",
                            Name = "George Lucas",
                            Role = 1
                        },
                        new
                        {
                            PersonId = 2L,
                            Biography = "Irvin Kershner se narodil ve Filadelfii rodičům židovského původu. Jeho uměleckým zaměřením bylo zpočátku hraní na hudební nástroje...",
                            BirthDate = new DateTime(1923, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "USA",
                            Name = "Irvin Kershner",
                            Role = 1
                        },
                        new
                        {
                            PersonId = 3L,
                            Biography = "Harrison vyrůstal na Chicagském předměstí, kde jeho otec pracoval jako reklamní manažer. Po střední škole začal Harrison studovat filozofii...",
                            BirthDate = new DateTime(1942, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "USA",
                            Name = "Harrison Ford",
                            Role = 0
                        });
                });

            modelBuilder.Entity("Tracker.Data.Models.Vehicle", b =>
                {
                    b.Property<long>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VehicleId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1L,
                            Brand = "Ford",
                            Model = "Focus",
                            RegistrationNumber = "ABC-123"
                        },
                        new
                        {
                            VehicleId = 2L,
                            Brand = "Toyota",
                            Model = "Camry",
                            RegistrationNumber = "XYZ-789"
                        });
                });

            modelBuilder.Entity("Tracker.Data.Models.VehicleLocation", b =>
                {
                    b.Property<long>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LocationId"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<long>("VehicleId")
                        .HasColumnType("bigint");

                    b.HasKey("LocationId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleLocations");

                    b.HasData(
                        new
                        {
                            LocationId = 1L,
                            Latitude = 48.858844300000001,
                            Longitude = 2.2943506,
                            Timestamp = new DateTime(2023, 10, 17, 12, 46, 54, 939, DateTimeKind.Local).AddTicks(8272),
                            VehicleId = 1L
                        },
                        new
                        {
                            LocationId = 2L,
                            Latitude = 34.052235000000003,
                            Longitude = -118.243683,
                            Timestamp = new DateTime(2023, 10, 17, 12, 46, 54, 939, DateTimeKind.Local).AddTicks(8308),
                            VehicleId = 2L
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("Tracker.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tracker.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviePerson", b =>
                {
                    b.HasOne("Tracker.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("ActorsPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tracker.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesAsActorMovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Tracker.Data.Models.Movie", b =>
                {
                    b.HasOne("Tracker.Data.Models.Person", "Director")
                        .WithMany("MoviesAsDirector")
                        .HasForeignKey("DirectorId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("Tracker.Data.Models.VehicleLocation", b =>
                {
                    b.HasOne("Tracker.Data.Models.Vehicle", "Vehicle")
                        .WithMany("Locations")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Tracker.Data.Models.Person", b =>
                {
                    b.Navigation("MoviesAsDirector");
                });

            modelBuilder.Entity("Tracker.Data.Models.Vehicle", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
