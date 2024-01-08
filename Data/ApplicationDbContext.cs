using event_managment_API.Models;
using Microsoft.EntityFrameworkCore;

namespace event_managment_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeEvent>()
                .HasKey(ae => new { ae.AttendeeId, ae.EventId });

            modelBuilder.Entity<AttendeeEvent>()
                .HasOne<Event>(e => e.Event)
                .WithMany(ae => ae.AttendeeEvents)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<AttendeeEvent>()
                .HasOne<Attendee>(e => e.Attendee)
                .WithMany(ae => ae.AttendeeEvents)
                .HasForeignKey(a => a.AttendeeId);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<AttendeeEvent> AttendeeEvents { get; set; }
    }
}
