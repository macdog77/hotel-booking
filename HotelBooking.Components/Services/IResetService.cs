namespace HotelBooking.Components.Services
{
    public interface IResetService
    {
        Task ResetDatabaseAsync();

        Task ReseedDatabaseAsync(int numRooms);
    }
}
