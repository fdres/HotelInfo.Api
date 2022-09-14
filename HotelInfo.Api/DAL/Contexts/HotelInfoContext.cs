using HotelInfo.Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelInfo.Api.DAL.Contexts
{
    public class HotelInfoContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public HotelInfoContext(DbContextOptions<HotelInfoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasIndex(h => h.Name).IsUnique();


            #region Initial Data Seed

            var nakatomiTowerPlazaId = Guid.Parse("45199a17-0d92-4c55-bcf9-1c9c99c931f1");
            var cloudCityInnId = Guid.Parse("caeeea98-23c2-4e29-9550-7417123b0ea1");
            var hotelTransylvaniaId = Guid.Parse("fb5312f7-559a-4ddf-840a-353fa5b54f82");

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = nakatomiTowerPlazaId,
                    Name = "Nakatomi Tower Plaza",
                    Address = "Los Angeles, CA 90067, USA",
                    StarRating = 5,
                    Description = "The one with the heist and all the murdering during Christmas '88"
                },
                new Hotel
                {
                    Id = cloudCityInnId,
                    Name = "Cloud City Inn",
                    Address = "Second cloud on the left, Cloud City, Bespin System",
                    StarRating = 2,
                    Description = "The one where Darth Vader captured Han Solo and met with his son for the first time"
                },
                new Hotel
                {
                    Id = hotelTransylvaniaId,
                    Name = "Hotel Transylvania",
                    Address = "Somewhere in the transylvanian mountains, Romania",
                    StarRating = 4,
                    Description = "The one where all the \"monsters\" gather to just relax and have some fun"
                }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = Guid.Parse("20790ead-e580-42db-af4e-54c126a02a7e"),
                    HotelId = nakatomiTowerPlazaId,
                    CustomerSurname = "Gruber",
                    CustomerName = "Hans",
                    PaxNumber = 2
                },
                new Booking
                {
                    Id = Guid.Parse("c45ab61c-f957-4f14-8f86-e83f81829238"),
                    HotelId = nakatomiTowerPlazaId,
                    CustomerSurname = "McLane",
                    CustomerName = "John",
                    PaxNumber = 4
                },
                new Booking
                {
                    Id = Guid.Parse("d60fbaec-00b5-409a-aa1c-46c969e6bfb1"),
                    HotelId = cloudCityInnId,
                    CustomerSurname = "Solo",
                    CustomerName = "Han",
                    PaxNumber = 1
                },
                new Booking
                {
                    Id = Guid.Parse("37bd242d-b39f-4593-9142-3614357a58c4"),
                    HotelId = cloudCityInnId,
                    CustomerSurname = "Skywalker",
                    CustomerName = "Luke",
                    PaxNumber = 3
                },
                new Booking
                {
                    Id = Guid.Parse("55852b8f-6bc9-4b2e-9768-8d918d2ac09e"),
                    HotelId = cloudCityInnId,
                    CustomerSurname = "Organa",
                    CustomerName = "Leia",
                    PaxNumber = 1
                },
                new Booking
                {
                    Id = Guid.Parse("6ebc2ce2-8efb-41ae-ac21-539c4e3e8433"),
                    HotelId = cloudCityInnId,
                    CustomerSurname = "Vader",
                    CustomerName = "Darth",
                    PaxNumber = 1
                },
                new Booking
                {
                    Id = Guid.Parse("3899fb02-83c3-46a7-8c4f-a1167a56a95d"),
                    HotelId = hotelTransylvaniaId,
                    CustomerSurname = "Count Dracula",
                    CustomerName = "-",
                    PaxNumber = 2
                },
                new Booking
                {
                    Id = Guid.Parse("f4945645-1ddb-4e2e-9a33-845562e8ad3c"),
                    HotelId = hotelTransylvaniaId,
                    CustomerSurname = "Frankenstein's Monster",
                    CustomerName = "-",
                    PaxNumber = 2
                },
                new Booking
                {
                    Id = Guid.Parse("cf4b082c-377c-4afd-baf7-038fac25c4fe"),
                    HotelId = hotelTransylvaniaId,
                    CustomerSurname = "The Wolfman",
                    CustomerName = "-",
                    PaxNumber = 12
                },
                new Booking
                {
                    Id = Guid.Parse("fe04cf9b-04d0-42d4-89e9-9233a314b82f"),
                    HotelId = hotelTransylvaniaId,
                    CustomerSurname = "Skellington",
                    CustomerName = "Jack",
                    PaxNumber = 1
                }
            );

            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }
}
