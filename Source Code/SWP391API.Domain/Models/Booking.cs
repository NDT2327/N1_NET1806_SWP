using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models;

[Table("Booking")]
public partial class Booking
{
    [Key]
    [Column("BookingID")]
    public int BookingId { get; set; }

    public DateOnly BookingDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("PaymentID")]
    public int PaymentId { get; set; }

    [Column("BookingTypeID")]
    public int BookingTypeId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [InverseProperty("Booking")]
    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    [ForeignKey("BookingTypeId")]
    [InverseProperty("Bookings")]
    public virtual BookingType BookingType { get; set; } = null!;

    [ForeignKey("PaymentId")]
    [InverseProperty("Bookings")]
    public virtual Payment Payment { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Bookings")]
    public virtual User User { get; set; } = null!;
}
