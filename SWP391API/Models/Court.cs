using System;
using System.Collections.Generic;

namespace SWP391API.Models;

public partial class Court
{
    public string Location { get; set; } = null!;

    public string OperatingHour { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? PaymentInfor { get; set; }

    public int Quantity { get; set; }

    public int CourtId { get; set; }

    public int UserId { get; set; }
}
