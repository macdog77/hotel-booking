using System;
using System.Collections.Generic;

namespace HotelBooking.Components.DataModels;

public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte NumBeds { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
