using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models;

[Table("Yard")]
public partial class Yard
{
    [Key]
    public int YardNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("CourtID")]
    public int CourtId { get; set; }

    [ForeignKey("CourtId")]
    [InverseProperty("Yards")]
    public virtual Court Court { get; set; } = null!;

    [InverseProperty("YardNumberNavigation")]
    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();

    [ForeignKey("YardNumber")]
    [InverseProperty("YardNumbers")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
