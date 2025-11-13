namespace HotelBooking.API.Controllers
{
    using HotelBooking.API.Models;
    using HotelBooking.Components.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public BookingController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [HttpGet(Name = "Get Booking")]
        [ProducesResponseType<BookingResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookingResponse>> Get(string bookingId)
        {
            var booking = await this._bookingService.GetBookingAsync(bookingId);

            if (booking != null)
            {
                return Ok(new BookingResponse(booking));
            }

            return NotFound("No booking found with the corresponding Id");
        }

        [HttpPost(Name = "Book Room")]
        [ProducesResponseType<BookingCreatedResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookingCreatedResponse>> Post(BookingRequest booking)
        {
            // Do not allow bookings for past dates or zero/negative nights
            if (booking.StartDate < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return BadRequest("Start date must be in the future.");
            }
            if (booking.NumNights < 1)
            {
                return BadRequest("You must select a positive number of nights.");
            }

            // Check room availablility before booking
            bool roomAvailable = await this._roomService.IsRoomAvailableAsync(booking.RoomId, booking.NumPeople, booking.StartDate, booking.NumNights);
            if (roomAvailable)
            {
                string bookingId = await this._bookingService.AddBookingAsync(booking.RoomId, booking.Name, booking.Email, booking.NumPeople, booking.StartDate, booking.NumNights);
                return Ok(new BookingCreatedResponse(bookingId));
            }
            else
            {
                return BadRequest("The selected room is not available for the requested dates.");
            }
        }
    }
}
