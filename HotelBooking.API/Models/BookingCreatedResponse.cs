namespace HotelBooking.API.Models
{
    public class BookingCreatedResponse(string bookingId)
    {
        public string BookingId { get; set; } = bookingId;
    }
}
