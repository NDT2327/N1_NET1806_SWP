using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models;

[Table("Account")]
public partial class Account
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("isAdmin")]
    public bool IsAdmin { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("User")]
    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();

    [ForeignKey("RoleId")]
    [InverseProperty("Accounts")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<Yard> YardNumbers { get; set; } = new List<Yard>();
}
