using System;
using System.Collections.Generic;

namespace HotelBooking.Components.DataModels;

public partial class Booking
{
    public Guid Id { get; set; }

    public int RoomId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int NumPeople { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual Room Room { get; set; } = null!;
}
