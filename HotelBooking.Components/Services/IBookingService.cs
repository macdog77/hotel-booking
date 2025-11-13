namespace HotelBooking.Components.Services
{
    using System.Threading.Tasks;
    using HotelBooking.Components.DataModels;

    public interface IBookingService
    {
        Task<Booking?> GetBookingAsync(string bookingId);

        Task<string> AddBookingAsync(int roomId, string name, string email, int numPeople, DateOnly startDate, int numNights);
    }
}
