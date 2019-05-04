using System;
using System.Threading.Tasks;
using HotelInfo.Api.DTO;
using HotelInfo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelInfo.Api.Controllers
{
    [ApiController]
    [Route("api/hotels/{hotelId}/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService 
                ?? throw new ArgumentNullException(nameof(bookingService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBookingsForHotel(Guid hotelId)
        {
            var bookings = await _bookingService.GetBookingsForHotelAsync(hotelId);
            return Ok(bookings);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(Guid hotelId, Guid id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(hotelId, id);
            return Ok(booking);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBooking(Guid hotelId, BookingForAddOrUpdateDto bookingToAdd)
        {
            var booking = await _bookingService.AddBookingAsync(hotelId, bookingToAdd);
            return CreatedAtAction(nameof(GetBookingById), new { hotelId = booking.HotelId, id = booking.Id }, booking);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBooking(Guid hotelId, Guid id, [FromBody] BookingForAddOrUpdateDto bookingToUpdate)
        {
            await _bookingService.UpdateBookingAsync(hotelId, id, bookingToUpdate);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveBooking(Guid hotelId, Guid id)
        {
            await _bookingService.RemoveBookingAsync(hotelId, id);
            return NoContent();
        }
    }
}
