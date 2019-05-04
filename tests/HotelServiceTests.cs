using System;
using System.Linq;
using System.Threading.Tasks;
using HotelInfo.Api.DTO;
using Xunit;

namespace tests
{
    public class HotelServiceTests
    {
        [Fact]
        [Trait("Hotel", "Hotel")]
        public async Task GetHotelById()
        {
            var service = Helper.GetHotelService();
            var hotel = await service.GetHotelByIdAsync(Helper.NakatomiTowerPlazaId);

            Assert.NotNull(hotel);
            Assert.True(hotel.Id == Helper.NakatomiTowerPlazaId, "Got wrong hotel");
            Assert.True(!string.IsNullOrWhiteSpace(hotel.Name), "Hotel has no name");
        }

        [Fact]
        [Trait("Hotel", "Hotel")]
        public async Task GetHotelList()
        {
            var service = Helper.GetHotelService();
            var hotels = await service.GetHotelsByNameAsync(null);

            Assert.NotNull(hotels);
            Assert.NotEmpty(hotels);
        }

        [Fact]
        [Trait("Hotel", "Hotel")]
        public async Task GetHotelListByName()
        {
            var service = Helper.GetHotelService();
            var hotels = await service.GetHotelsByNameAsync("Nakatomi");
            Assert.NotNull(hotels);

            var list = hotels.ToList();
            
            Assert.NotEmpty(list);
            Assert.True(list.Count == 1, "Found more than one hotel");
        }

        [Fact]
        [Trait("Hotel", "Hotel")]
        public async Task AddHotel()
        {
            var service = Helper.GetHotelService();
            var hotelToAdd = new HotelForAddOrUpdateDto
            {
                Name = "Overlook Hotel",
                Address = "333 Wonderview Avenue, Colorado",
                StarRating = 4.5,
                Description = "The one with the ghosts and the potential family massacre"
            };

            var hotel = await service.AddHotelAsync(hotelToAdd);
            Assert.NotNull(hotel);
            Assert.True(!hotel.Id.Equals(Guid.Empty), "Adding hotel failed");
        }

        [Fact]
        [Trait("Hotel", "Hotel")]
        public async Task UpdateHotel()
        {
            var hotelId = Helper.NakatomiTowerPlazaId;

            var service = Helper.GetHotelService();
            var hotel = await service.GetHotelByIdAsync(hotelId);
            Assert.NotNull(hotel);

            var currentStarRating = hotel.StarRating;

            var hotelToUpdate = new HotelForAddOrUpdateDto
            {
                Name = hotel.Name,
                Address = hotel.Address,
                StarRating = ++hotel.StarRating
            };

            await service.UpdateHotelAsync(hotelId, hotelToUpdate);
            hotel = await service.GetHotelByIdAsync(hotelId);
            Assert.NotNull(hotel);
            Assert.Equal(currentStarRating + 1, hotel.StarRating);
        }
    }
}
