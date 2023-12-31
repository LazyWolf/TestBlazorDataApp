using Microsoft.EntityFrameworkCore;
using TestBlazorDataApp.Data.Models;

namespace TestBlazorDataApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>()
                .ToTable("Things");

            base.OnModelCreating(modelBuilder);
        }
    }
}
