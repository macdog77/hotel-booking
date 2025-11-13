namespace HotelBooking.Components.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HotelBooking.Components.DataModels;

    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> FindHotelsAsync(string searchTerm, bool includeTest = false);
    }
}
