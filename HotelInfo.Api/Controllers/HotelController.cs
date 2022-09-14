using HotelInfo.Api.DTO;
using HotelInfo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelInfo.Api.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService 
                ?? throw new ArgumentNullException(nameof(hotelService));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetHotelsByName(string name)
        {
            var hotels = await _hotelService.GetHotelsByNameAsync(name);
            return Ok(hotels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            return Ok(hotel);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddHotel(HotelForAddOrUpdateDto hotelToAdd)
        {
            var hotel = await _hotelService.AddHotelAsync(hotelToAdd);
            return CreatedAtAction(nameof(GetHotelById), new {id = hotel.Id}, hotel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelForAddOrUpdateDto hotelToUpdate)
        {
            await _hotelService.UpdateHotelAsync(id, hotelToUpdate);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveHotel(Guid id)
        {
            await _hotelService.RemoveHotelAsync(id);
            return NoContent();
        }
    }
}
