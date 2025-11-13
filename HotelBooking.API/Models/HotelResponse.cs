namespace HotelBooking.API.Models
{
    using HotelBooking.Components.DataModels;

    public class HotelResponse(Hotel hotel)
    {
        public int Id { get; set; } = hotel.Id;

        public string Name { get; set; } = hotel.Name;
    }
}
