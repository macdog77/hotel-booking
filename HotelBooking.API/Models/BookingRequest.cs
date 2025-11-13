namespace HotelBooking.API.Models
{
    public class BookingRequest(int roomId, string name, string email, int numPeople, DateOnly startDate, int numNights)
    {
        public int RoomId { get; } = roomId;
        public string Name { get; } = name;
        public string Email { get; } = email;
        public int NumPeople { get; } = numPeople;
        public DateOnly StartDate { get; } = startDate;
        public int NumNights { get; } = numNights;
    }
}
