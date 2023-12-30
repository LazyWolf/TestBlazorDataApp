using Microsoft.EntityFrameworkCore;

namespace TestBlazorDataApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Hangout> Hangouts { get; set; }
        public DbSet<HangoutParticipant> HangoutParticipants { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Vote> VoteSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .ToTable("Friends");

            base.OnModelCreating(modelBuilder);
        }
    }
}
