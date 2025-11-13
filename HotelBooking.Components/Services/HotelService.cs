namespace HotelBooking.Components.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HotelBooking.Components.DataModels;

    public class HotelService(HotelBookingContext context) : BaseService(context), IHotelService
    {
        public async Task<IEnumerable<Hotel>> FindHotelsAsync(string searchTerm, bool includeTest = false)
        {
            return await Task.FromResult(this.Context.Hotels
                .Where(h => !h.TestHotel || includeTest)
                .Where(h => h.Name.Contains(searchTerm))
                .AsEnumerable());
        }
    }
}
