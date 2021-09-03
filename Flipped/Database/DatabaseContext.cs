using HubService.Database.Entitties;
using Microsoft.EntityFrameworkCore;

namespace HubService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Hub> Hubs { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<HubService.Database.Entitties.Lesson> Lesson { get; set; }
    }
}
