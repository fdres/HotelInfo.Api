using System;
using System.Threading.Tasks;
using HotelInfo.Api.DTO;
using Xunit;

namespace tests
{
    public class BookingServiceTests
    {
        [Fact]
        [Trait("Booking", "Booking")]
        public async Task GetBookingById()
        {
            var service = Helper.GetBookingService();
            var booking = await service.GetBookingByIdAsync(Helper.NakatomiTowerPlazaId, Helper.HansGruberBookingId);

            Assert.NotNull(booking);
            Assert.True(booking.Id == Helper.HansGruberBookingId, "Got wrong booking");
            Assert.True(!string.IsNullOrWhiteSpace(booking.CustomerSurname), "Booking has no customer surname");
        }

        [Fact]
        [Trait("Booking", "Booking")]
        public async Task GetBookingsForHotel()
        {
            var service = Helper.GetBookingService();
            var bookings = await service.GetBookingsForHotelAsync(Helper.NakatomiTowerPlazaId);
            Assert.NotNull(bookings);
            Assert.NotEmpty(bookings);
        }

        [Fact]
        [Trait("Booking", "Booking")]
        public async Task AddBooking()
        {
            var service = Helper.GetBookingService();
            var bookingToAdd = new BookingForAddOrUpdateDto
            {
                CustomerSurname = "Stark",
                CustomerName = "Eddard",
                PaxNumber = 2
            };

            var booking = await service.AddBookingAsync(Helper.NakatomiTowerPlazaId, bookingToAdd);
            Assert.NotNull(booking);
            Assert.True(!booking.Id.Equals(Guid.Empty), "Adding booking failed");
        }

        [Fact]
        [Trait("Booking", "Booking")]
        public async Task UpdateBooking()
        {
            var hotelId = Helper.NakatomiTowerPlazaId;
            var bookingId = Helper.HansGruberBookingId;

            var service = Helper.GetBookingService();
            var booking = await service.GetBookingByIdAsync(hotelId, bookingId);
            Assert.NotNull(booking);

            var currentPaxNumber = booking.PaxNumber;

            var bookingToUpdate = new BookingForAddOrUpdateDto
            {
                CustomerSurname = booking.CustomerSurname,
                CustomerName = booking.CustomerName,
                PaxNumber = ++booking.PaxNumber
            };

            await service.UpdateBookingAsync(hotelId, bookingId, bookingToUpdate);
            booking = await service.GetBookingByIdAsync(hotelId, bookingId);
            Assert.NotNull(booking);
            Assert.Equal(currentPaxNumber + 1, booking.PaxNumber);
        }
    }
}
