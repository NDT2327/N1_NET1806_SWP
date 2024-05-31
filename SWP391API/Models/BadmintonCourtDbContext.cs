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

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<BookingType> BookingTypes { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Pricing> Pricings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    public virtual DbSet<Yard> Yards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-RK55B73L;Database=dbSWP;User Id=sa;Password=123456;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Account__1788CCAC4818A75D");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__RoleID__4BAC3F29");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD932C80BF");

            entity.HasOne(d => d.BookingType).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Booking__5629CD9C");

            entity.HasOne(d => d.Payment).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Payment__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__UserID__571DF1D5");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__BookingD__8136D47A85100558");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingDe__Booki__5CD6CB2B");
        });

        modelBuilder.Entity<BookingType>(entity =>
        {
            entity.HasKey(e => e.BookingTypeId).HasName("PK__BookingT__649EC4B1B44F0D56");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.CourtId).HasName("PK__Court__C3A67CFA1A3441D9");

            entity.HasOne(d => d.User).WithMany(p => p.Courts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Court__UserID__5070F446");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A58AA2980E7");
        });

        modelBuilder.Entity<Pricing>(entity =>
        {
            entity.HasKey(e => e.PricingId).HasName("PK__Pricing__EC306B729B026D4E");

            entity.HasOne(d => d.BookingType).WithMany(p => p.Pricings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pricing__Booking__05D8E0BE");

            entity.HasOne(d => d.SlotNumberNavigation).WithMany(p => p.Pricings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pricing__SlotNum__06CD04F7");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A9FA2D725");
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(e => e.SlotNumber).HasName("PK__TimeSlot__0D659BB607369AF0");

            entity.HasOne(d => d.YardNumberNavigation).WithMany(p => p.TimeSlots)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TimeSlot__YardNu__02FC7413");
        });

        modelBuilder.Entity<Yard>(entity =>
        {
            entity.HasKey(e => e.YardNumber).HasName("PK__Yard__2A5B921D632D78A7");

            entity.HasOne(d => d.Court).WithMany(p => p.Yards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Yard__CourtID__59FA5E80");

            entity.HasMany(d => d.Users).WithMany(p => p.YardNumbers)
                .UsingEntity<Dictionary<string, object>>(
                    "WorkingAt",
                    r => r.HasOne<Account>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__working_a__UserI__60A75C0F"),
                    l => l.HasOne<Yard>().WithMany()
                        .HasForeignKey("YardNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__working_a__YardN__5FB337D6"),
                    j =>
                    {
                        j.HasKey("YardNumber", "UserId").HasName("PK__working___FB231ED70244C9F8");
                        j.ToTable("working_at");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
