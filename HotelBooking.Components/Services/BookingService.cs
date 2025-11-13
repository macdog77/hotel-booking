namespace HotelBooking.Components.Services
{
    using System;
    using System.Threading.Tasks;
    using HotelBooking.Components.DataModels;
    using Microsoft.EntityFrameworkCore;

    public class BookingService(HotelBookingContext context) : BaseService(context), IBookingService
    {
        public async Task<string> AddBookingAsync(int roomId, string name, string email, int numPeople, DateOnly startDate, int numNights)
        {
            Guid bookingId = Guid.CreateVersion7();

            this.Context.Bookings.Add(new Booking
            {
                Id = bookingId,
                RoomId = roomId,
                Name = name,
                Email = email,
                NumPeople = numPeople,
                StartDate = startDate,
                EndDate = startDate.AddDays(numNights)
            });

            await this.SaveChangesAsync();

            return bookingId.ToString();
        }

        public async Task<Booking?> GetBookingAsync(string bookingId)
        {
            return await this.Context.Bookings.Include(b => b.Room).ThenInclude(b => b.Hotel).FirstOrDefaultAsync(b => b.Id.ToString() == bookingId);
        }
    }
}
