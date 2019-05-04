using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelInfo.Api.DTO;

namespace HotelInfo.Api.Services
{
    public interface IHotelService
    {
        Task<HotelDto> GetHotelByIdAsync(Guid id);

        Task<IEnumerable<HotelDto>> GetHotelsByNameAsync(string name);

        Task<HotelDto> AddHotelAsync(HotelForAddOrUpdateDto hotelToAdd);

        Task UpdateHotelAsync(Guid id, HotelForAddOrUpdateDto hotelToUpdate);

        Task RemoveHotelAsync(Guid id);
    }
}
