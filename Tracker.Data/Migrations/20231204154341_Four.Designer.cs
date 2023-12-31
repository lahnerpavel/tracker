﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tracker.Data;

#nullable disable

namespace Tracker.Data.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    [Migration("20231204154341_Four")]
    partial class Four
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

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

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MovieId"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DirectorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("MovieId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Tracker.Data.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PersonId"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1L,
                            Biography = "Vlastním jménem George Walton Lucas, Jr. se narodil 14. května 1944 v Modestu, Kalifornii. Zde také vystudoval proslulou University of Southern California (USC)...",
                            BirthDate = new DateTime(1944, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Country = "USA",
                            Name = "George Lucas",
                            Role = 1
                        },
                        new
                        {
                            PersonId = 2L,
                            Biography = "Irvin Kershner se narodil ve Filadelfii rodičům židovského původu. Jeho uměleckým zaměřením bylo zpočátku hraní na hudební nástroje...",
                            BirthDate = new DateTime(1923, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc),
                            Country = "USA",
                            Name = "Irvin Kershner",
                            Role = 1
                        },
                        new
                        {
                            PersonId = 3L,
                            Biography = "Harrison vyrůstal na Chicagském předměstí, kde jeho otec pracoval jako reklamní manažer. Po střední škole začal Harrison studovat filozofii...",
                            BirthDate = new DateTime(1942, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc),
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

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("VehicleId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

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
                        },
                        new
                        {
                            VehicleId = 3L,
                            Brand = "Chevrolet",
                            Model = "Malibu",
                            RegistrationNumber = "DEF-456"
                        },
                        new
                        {
                            VehicleId = 4L,
                            Brand = "Honda",
                            Model = "Civic",
                            RegistrationNumber = "GHI-789"
                        });
                });

            modelBuilder.Entity("Tracker.Data.Models.VehicleLocation", b =>
                {
                    b.Property<long>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("LocationId"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

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
                            Timestamp = new DateTime(2023, 12, 4, 15, 43, 39, 739, DateTimeKind.Utc).AddTicks(4129),
                            VehicleId = 1L
                        },
                        new
                        {
                            LocationId = 2L,
                            Latitude = 34.052235000000003,
                            Longitude = -118.243683,
                            Timestamp = new DateTime(2023, 12, 4, 15, 43, 39, 739, DateTimeKind.Utc).AddTicks(4132),
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
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
