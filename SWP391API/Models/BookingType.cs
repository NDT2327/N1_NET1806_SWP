using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models;

[Table("BookingType")]
public partial class BookingType
{
    [Key]
    [Column("BookingTypeID")]
    public int BookingTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("BookingType")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("BookingType")]
    public virtual ICollection<Pricing> Pricings { get; set; } = new List<Pricing>();
}
