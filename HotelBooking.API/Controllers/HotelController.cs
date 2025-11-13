namespace HotelBooking.API.Controllers
{
    using HotelBooking.API.Models;
    using HotelBooking.Components.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet(Name = "Search Hotels")]
        [ProducesResponseType<IEnumerable<HotelResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HotelResponse>>> Get(string name)
        {
            var hotels = await _hotelService.FindHotelsAsync(name);

            if (!hotels.Any())
            {
                return BadRequest("No hotels found that match your search term.");
            }
            else
            {
                return Ok(hotels.Select(h => new HotelResponse(h)).AsEnumerable());
            }
        }
    }
}
