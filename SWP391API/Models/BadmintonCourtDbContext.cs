using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWP391API.Models;

public partial class BadmintonCourtDbContext : DbContext
{
    public BadmintonCourtDbContext()
    {
    }

    public BadmintonCourtDbContext(DbContextOptions<BadmintonCourtDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-RK55B73L;Database=dbSWP;User Id=sa;Password=123456;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Court__C3A67CFA1A3441D9");

            entity.ToTable("Court");

            entity.Property(e => e.CourtId).HasColumnName("CourtID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OperatingHour)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentInfor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A9FA2D725");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Account__UserID");

            entity.ToTable("Account");

            entity.Property(e => e.UserID).HasColumnName("UserID");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
