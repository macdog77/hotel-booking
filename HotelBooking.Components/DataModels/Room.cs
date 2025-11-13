using System;
using System.Collections.Generic;

namespace HotelBooking.Components.DataModels;

public partial class Room
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int RoomTypeId { get; set; }

    public int RoomNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual RoomType RoomType { get; set; } = null!;
}
