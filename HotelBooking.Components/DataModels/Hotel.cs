using System;
using System.Collections.Generic;

namespace HotelBooking.Components.DataModels;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool TestHotel { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
