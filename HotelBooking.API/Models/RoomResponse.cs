namespace HotelBooking.API.Models
{
    public class RoomResponse(int id, string roomType, int beds)
    {
        public int Id { get; set; } = id;

        public string RoomType { get; set; } = roomType;

        public int Beds { get; set; } = beds;
    }
}
