using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWP391API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP391API.Infrastructure
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Court> Courts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Court>();
        }

        //public virtual DbSet<Booking> Bookings { get; set; }

        //public virtual DbSet<BookingDetail> BookingDetails { get; set; }

        //public virtual DbSet<BookingType> BookingTypes { get; set; }

        //

        //public virtual DbSet<Payment> Payments { get; set; }

        //public virtual DbSet<Pricing> Pricings { get; set; }

        //public virtual DbSet<TimeSlot> TimeSlots { get; set; }

        //public virtual DbSet<Yard> Yards { get; set; }
    }
}
