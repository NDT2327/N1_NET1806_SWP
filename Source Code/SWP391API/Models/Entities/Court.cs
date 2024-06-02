﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models.Entities;

[Table("Court")]
public partial class Court
{
    [StringLength(100)]
    [Unicode(false)]
    public string Location { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string OperatingHour { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PaymentInfor { get; set; }

    public int Quantity { get; set; }

    [Key]
    [Column("CourtID")]
    public int CourtId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}