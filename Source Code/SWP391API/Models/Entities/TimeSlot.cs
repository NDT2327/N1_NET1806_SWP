using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models.Entities;

[Table("TimeSlot")]
public partial class TimeSlot
{
    [Key]
    public int SlotNumber { get; set; }

    public TimeOnly Duration { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly AvailableTime { get; set; }

    public bool IsReserved { get; set; }

    public int YardNumber { get; set; }

    [InverseProperty("SlotNumberNavigation")]
    public virtual ICollection<Pricing> Pricings { get; set; } = new List<Pricing>();

    [ForeignKey("YardNumber")]
    [InverseProperty("TimeSlots")]
    public virtual Yard YardNumberNavigation { get; set; } = null!;
}
