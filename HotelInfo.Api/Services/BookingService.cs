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
    public class BookingService : IBookingService
    {
        private readonly IHotelInfoRepository _hotelInfoRepository;
        private readonly IMapper _mapper;

        public BookingService(IHotelInfoRepository hotelInfoRepository, IMapper mapper)
        {
            _hotelInfoRepository = hotelInfoRepository ?? throw new ArgumentNullException(nameof(hotelInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BookingDto> GetBookingByIdAsync(Guid hotelId, Guid id)
        {
            var booking = await _hotelInfoRepository
                .GetFirstAsync<Booking, Hotel>(b => b.HotelId == hotelId && b.Id == id, b => b.Hotel);

            if (booking == null)
                throw new NotFoundException($"Could not find booking with hotelId '{hotelId.ToString()}' and id '{id.ToString()}'");

            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsForHotelAsync(Guid hotelId)
        {
            var bookings = await _hotelInfoRepository
                .GetListAsync<Booking, Hotel>(b => b.HotelId == hotelId, b => b.Hotel);

            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> AddBookingAsync(Guid hotelId, BookingForAddOrUpdateDto bookingToAdd)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingToAdd);
            bookingEntity.HotelId = hotelId;

            _hotelInfoRepository.Add(bookingEntity);
            if (!await _hotelInfoRepository.SaveChangesAsync())
                throw new Exception("Trying to add booking failed");

            var createdId = bookingEntity.Id;

            bookingEntity = await _hotelInfoRepository
                .GetFirstAsync<Booking, Hotel>(b => b.HotelId == hotelId && b.Id == createdId, b => b.Hotel);

            if (bookingEntity == null)
                throw new NotFoundException($"Could not find booking with hotelId '{hotelId.ToString()}' and id '{createdId.ToString()}'");

            return _mapper.Map<BookingDto>(bookingEntity);
        }

        public async Task UpdateBookingAsync(Guid hotelId, Guid id, BookingForAddOrUpdateDto bookingToUpdate)
        {
            var bookingEntity = await _hotelInfoRepository
                .GetFirstAsync<Booking>(b => b.HotelId == hotelId && b.Id == id);

            if (bookingEntity == null)
                throw new NotFoundException($"Could not find booking with hotelId '{hotelId.ToString()}' and id '{id.ToString()}'");

            _mapper.Map(bookingToUpdate, bookingEntity);

            _hotelInfoRepository.Update(bookingEntity);
            if (!await _hotelInfoRepository.SaveChangesAsync())
                throw new Exception($"Trying to update booking with id '{id.ToString()}' failed");
        }

        public async Task RemoveBookingAsync(Guid hotelId, Guid id)
        {
            var bookingEntity = await _hotelInfoRepository
                .GetFirstAsync<Booking>(b => b.HotelId == hotelId && b.Id == id);

            if (bookingEntity == null)
                throw new NotFoundException($"Could not find booking with hotelId '{hotelId.ToString()}' and id '{id.ToString()}'");

            _hotelInfoRepository.Remove(bookingEntity);
            if (!await _hotelInfoRepository.SaveChangesAsync())
                throw new Exception($"Trying to remove booking with id '{id.ToString()}' failed");
        }
    }
}
