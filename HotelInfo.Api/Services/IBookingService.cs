using HotelInfo.Api.DTO;

namespace HotelInfo.Api.Services
{
    public interface IBookingService
    {
        Task<BookingDto> GetBookingByIdAsync(Guid hotelId, Guid id);

        Task<IEnumerable<BookingDto>> GetBookingsForHotelAsync(Guid hotelId);

        Task<BookingDto> AddBookingAsync(Guid hotelId, BookingForAddOrUpdateDto bookingToAdd);

        Task UpdateBookingAsync(Guid hotelId, Guid id, BookingForAddOrUpdateDto bookingToUpdate);

        Task RemoveBookingAsync(Guid hotelId, Guid id);
    }
}
