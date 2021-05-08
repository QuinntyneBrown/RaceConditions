using RaceConditions.Api.Models;
using RaceConditions.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RaceConditions.Api.Data
{
    public class RaceConditionsDbContext : DbContext, IRaceConditionsDbContext
    {
        public DbSet<Player> Players { get; private set; }
        public RaceConditionsDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RaceConditionsDbContext).Assembly);
        }

    }
}
