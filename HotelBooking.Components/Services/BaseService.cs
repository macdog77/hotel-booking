namespace HotelBooking.Components.Services
{
    using HotelBooking.Components.DataModels;

    public class BaseService(HotelBookingContext context)
    {
        protected readonly HotelBookingContext Context = context;

        public async Task SaveChangesAsync()
        {
            await this.Context.SaveChangesAsync();
        }
    }
}
