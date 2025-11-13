namespace HotelBooking.Components.Services
{
    using HotelBooking.Components.DataModels;

    public interface IRoomService
    {
        Task<IEnumerable<Room>> FindAvailableRoomsAsync(int hotelId, int numPeople, DateOnly startDate, int numNights, bool includeTest = false);

        Task<bool> IsRoomAvailableAsync(int roomId, int numPeople, DateOnly startDate, int numNights, bool includeTest = false);
    }
}
