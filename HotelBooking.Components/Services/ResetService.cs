using HotelBooking.Components.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Components.Services
{
    public class ResetService(HotelBookingContext context) : BaseService(context), IResetService
    {
        public async Task ReseedDatabaseAsync(int numRooms)
        {
            await this.ResetDatabaseAsync();

            Context.Hotels.Add(new Hotel() { Name = "Edinburgh City Centre" });
            Context.Hotels.Add(new Hotel() { Name = "Edinburgh Gyle" });
            Context.Hotels.Add(new Hotel() { Name = "Glasgow" });
            Context.Hotels.Add(new Hotel() { Name = "Dundee" });
            Context.Hotels.Add(new Hotel() { Name = "Dunfermline" });
            Context.Hotels.Add(new Hotel() { Name = "Inverness" });
            Context.Hotels.Add(new Hotel() { Name = "Test Hotel", TestHotel = true });

            Context.RoomTypes.Add(new RoomType() { Name = "Standard", NumBeds = 1 });
            Context.RoomTypes.Add(new RoomType() { Name = "Double", NumBeds = 2 });
            Context.RoomTypes.Add(new RoomType() { Name = "Deluxe", NumBeds = 3 });

            await context.SaveChangesAsync();
            await this.AddRooms(numRooms);
        }

        public async Task ResetDatabaseAsync()
        {
            await context.Database.ExecuteSqlAsync($"DELETE FROM [Booking];");
            await context.Database.ExecuteSqlAsync($"DELETE FROM [Room]; DBCC CHECKIDENT ('[Room]', RESEED, 0);");
            await context.Database.ExecuteSqlAsync($"DELETE FROM [RoomType]; DBCC CHECKIDENT ('[RoomType]', RESEED, 0);");
            await context.Database.ExecuteSqlAsync($"DELETE FROM [Hotel]; DBCC CHECKIDENT ('[Hotel]', RESEED, 0);");
            await context.SaveChangesAsync();
        }

        private async Task AddRooms(int numRooms)
        {
            var hotels = await Context.Hotels.ToListAsync();
            var roomTypes = await Context.RoomTypes.ToListAsync();

            foreach(var hotel in hotels)
            {
                Random r = new Random(hotel.Id);

                for(int cnt = 1; cnt <=6; cnt++)
                {
                    hotel.Rooms.Add(new Room() { RoomType = roomTypes[r.Next(roomTypes.Count)], RoomNumber = cnt });
                }
            }

            await Context.SaveChangesAsync();
        }
    }
}
