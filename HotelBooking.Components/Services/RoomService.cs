namespace HotelBooking.Components.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HotelBooking.Components.DataModels;
    using Microsoft.EntityFrameworkCore;

    public class RoomService(HotelBookingContext context) : BaseService(context), IRoomService
    {
        public async Task<IEnumerable<Room>> FindAvailableRoomsAsync(int hotelId, int numPeople, DateOnly startDate, int numNights, bool includeTest = false)
        {
            DateOnly endDate = startDate.AddDays(numNights);

            return await Task.FromResult(
                this.Context.Hotels
                .Where(h => h.Id == hotelId && (includeTest || !h.TestHotel))
                .SelectMany(h => h.Rooms)
                .Where(r => r.RoomType.NumBeds >= numPeople && !r.Bookings.Any(b => b.StartDate < endDate && b.EndDate > startDate))
                .Include(r => r.RoomType)
                .AsEnumerable());
        }

        public async Task<bool> IsRoomAvailableAsync(int roomId, int numPeople, DateOnly startDate, int numNights, bool includeTest = false)
        {
            DateOnly endDate = startDate.AddDays(numNights);
            var room = await this.Context.Rooms.Include(r => r.Bookings).FirstOrDefaultAsync(r => r.Id == roomId && r.RoomType.NumBeds >= numPeople && (includeTest || !r.Hotel.TestHotel));
            return room != null && !room.Bookings.Any(b => b.StartDate < endDate && b.EndDate > startDate);
        }
    }
}
