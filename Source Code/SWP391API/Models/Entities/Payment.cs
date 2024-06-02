using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models.Entities;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    public DateOnly PaymentDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PaymentStatus { get; set; } = null!;

    [InverseProperty("Payment")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
