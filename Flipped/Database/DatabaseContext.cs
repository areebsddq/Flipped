using HubService.Database.Entitties;
using Microsoft.EntityFrameworkCore;

namespace HubService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Hub> Hubs { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Hub>()
                .HasMany<Lesson>()
                .WithOne();

            modelBuilder.Entity<Hub>()
                .Navigation(b => b.Lessons)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        */
            modelBuilder.Entity<Lesson>()
            .HasOne<Hub>()
            .WithMany()
            .HasForeignKey(p => p.HubId);
        }
    }
}
