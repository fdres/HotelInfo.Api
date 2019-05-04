using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelInfo.Api.DAL.Entities;
using HotelInfo.Api.DAL.Repository;
using HotelInfo.Api.DTO;
using HotelInfo.Api.Exceptions;

namespace HotelInfo.Api.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelInfoRepository _hotelInfoRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelInfoRepository hotelInfoRepository, IMapper mapper)
        {
            _hotelInfoRepository = hotelInfoRepository ?? throw new ArgumentNullException(nameof(hotelInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<HotelDto> GetHotelByIdAsync(Guid id)
        {
            var hotel = await _hotelInfoRepository
                .GetFirstAsync<Hotel>(h => h.Id == id);

            if (hotel == null)
                throw new NotFoundException($"Could not find hotel with id '{id.ToString()}'");

            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<IEnumerable<HotelDto>> GetHotelsByNameAsync(string name)
        {
            var hotels = string.IsNullOrWhiteSpace(name)
                ? await _hotelInfoRepository.GetListAsync<Hotel>()
                : await _hotelInfoRepository.GetListAsync<Hotel>(h => h.Name.Contains(name));

            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<HotelDto> AddHotelAsync(HotelForAddOrUpdateDto hotelToAdd)
        {
            var hotelEntity = _mapper.Map<Hotel>(hotelToAdd);

            _hotelInfoRepository.Add(hotelEntity);
            if (!await _hotelInfoRepository.SaveChangesAsync())
                throw new Exception("Trying to add hotel failed");

            var createdId = hotelEntity.Id;
            hotelEntity = await _hotelInfoRepository
                .GetFirstAsync<Hotel>(h => h.Id == createdId);

            if (hotelEntity == null)
                throw new NotFoundException($"Could not find hotel with id '{createdId.ToString()}'");

            return _mapper.Map<HotelDto>(hotelEntity);
        }

        public async Task UpdateHotelAsync(Guid id, HotelForAddOrUpdateDto hotelToUpdate)
        {
            var hotelEntity = await _hotelInfoRepository.GetFirstAsync<Hotel>(h => h.Id == id);
            if (hotelEntity == null)
                throw new NotFoundException($"Could not find hotel with id '{id.ToString()}'");

            _mapper.Map(hotelToUpdate, hotelEntity);

            _hotelInfoRepository.Update(hotelEntity);
            if (!await _hotelInfoRepository.SaveChangesAsync())
                throw new Exception($"Trying to update hotel with id '{id.ToString()}' failed");
        }

        public async Task RemoveHotelAsync(Guid id)
        {
            var hotelEntity = await _hotelInfoRepository.GetFirstAsync<Hotel>(h => h.Id == id);
            if (hotelEntity == null)
                throw new NotFoundException($"Could not find hotel with id '{id.ToString()}'");

            _hotelInfoRepository.Remove(hotelEntity);
            if (!await _hotelInfoRepository.SaveChangesAsync())
                throw new Exception($"Trying to remove hotel with id '{id.ToString()}' failed");
        }
    }
}
