using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models.Entities;

[Table("Pricing")]
public partial class Pricing
{
    [Key]
    [Column("PricingID")]
    public int PricingId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("BookingTypeID")]
    public int BookingTypeId { get; set; }

    public int SlotNumber { get; set; }

    [ForeignKey("BookingTypeId")]
    [InverseProperty("Pricings")]
    public virtual BookingType BookingType { get; set; } = null!;

    [ForeignKey("SlotNumber")]
    [InverseProperty("Pricings")]
    public virtual TimeSlot SlotNumberNavigation { get; set; } = null!;
}
