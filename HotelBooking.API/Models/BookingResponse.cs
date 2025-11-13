using HotelBooking.Components.DataModels;

namespace HotelBooking.API.Models
{
    public class BookingResponse(string bookingId, string name, string email, int numPeople, string hotelName, DateOnly startDate, int numNights)
    {
        public string BookingId { get; set; } = bookingId;
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public int NumPeople { get; set; } = numPeople;
        public string HotelName { get; set; } = hotelName;
        public DateOnly Date { get; set; } = startDate;
        public int NumNights { get; set; } = numNights;

        public BookingResponse(Booking booking) : this(booking.Id.ToString(), booking.Name, booking.Email, booking.NumPeople, booking.Room.Hotel.Name, booking.StartDate, booking.EndDate.DayNumber - booking.StartDate.DayNumber)
        {
        }
    }
}
