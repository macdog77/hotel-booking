namespace HotelBooking.API.Controllers
{
    using HotelBooking.API.Models;
    using HotelBooking.Components.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet(Name = "Get Available Rooms")]
        [ProducesResponseType<IEnumerable<RoomResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RoomResponse>>> Get(int hotelId, int numPeople, DateOnly startDate, int numNights)
        {
            if(startDate < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return BadRequest("Start date must be in the future.");
            }

            if (numNights < 1)
            {
                return BadRequest("You must select a positive number of nights.");
            }

            var rooms = await _roomService.FindAvailableRoomsAsync(hotelId, numPeople, startDate, numNights);
            if (rooms.Count() > 0)
            {
                return Ok(rooms.Select(r => new RoomResponse(r.Id, r.RoomType.Name, r.RoomType.NumBeds)));
            }

            return BadRequest("There are no rooms available at your chosen hotel that match you criteria.");
        }
    }
}
