using AutoMapper;
using HotelInfo.Api.DAL.Entities;
using HotelInfo.Api.DTO;

namespace HotelInfo.Api
{
    public class HotelInfoMappingProfile : Profile
    {
        public HotelInfoMappingProfile()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelForAddOrUpdateDto, Hotel>();

            CreateMap<Booking, BookingDto>()
                .ForMember(
                    dest => dest.HotelInfo,
                    opt => opt.MapFrom(src => $"{src.Hotel.Name} ( {src.Hotel.Address} )"));
            CreateMap<BookingForAddOrUpdateDto, Booking>();
        }
    }
}
