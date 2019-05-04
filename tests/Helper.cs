using System;
using AutoMapper;
using AutoMapper.Configuration;
using HotelInfo.Api;
using HotelInfo.Api.DAL.Contexts;
using HotelInfo.Api.DAL.Repository;
using HotelInfo.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace tests
{
    internal static class Helper
    {
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=HotelsDB;Trusted_Connection=True;";

        internal static readonly Guid NakatomiTowerPlazaId = Guid.Parse("45199a17-0d92-4c55-bcf9-1c9c99c931f1");
        internal static readonly Guid HansGruberBookingId = Guid.Parse("20790ead-e580-42db-af4e-54c126a02a7e");

        internal static IHotelService GetHotelService()
        {
            var repository = GetRepository();
            var mapper = GetMapper();

            var service = new HotelService(repository, mapper);
            return service;
        }

        internal static IBookingService GetBookingService()
        {
            var repository = GetRepository();
            var mapper = GetMapper();

            var service = new BookingService(repository, mapper);
            return service;
        }

        private static IMapper GetMapper()
        {
            var profile = new HotelInfoMappingProfile();
            var configuration = new MapperConfigurationExpression();
            configuration.AddProfile(profile);
            var configProvider = new MapperConfiguration(configuration);
            var mapper = new Mapper(configProvider);

            return mapper;
        }

        private static IHotelInfoRepository GetRepository()
        {
            var hotelInfoContext = GetDbContext();
            var hotelInfoRepository = new HotelInfoRepository(hotelInfoContext);
            return hotelInfoRepository;
        }

        private static HotelInfoContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelInfoContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            var hotelInfoContext = new HotelInfoContext(optionsBuilder.Options);
            return hotelInfoContext;
        }
    }
}
