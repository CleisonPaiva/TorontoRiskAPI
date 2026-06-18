using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Data
{
    public class TorontoRiskDbContext : DbContext
    {
        public TorontoRiskDbContext(DbContextOptions<TorontoRiskDbContext> options) : base(options) { }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Subway> Subways { get; set; }
        public DbSet<FloodZone> FloodZones { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().ToTable("hospitals", "public");
            modelBuilder.Entity<School>().ToTable("schools", "public");
            modelBuilder.Entity<Subway>().ToTable("subways", "public");
            modelBuilder.Entity<FloodZone>().ToTable("flood_zones", "public");
            modelBuilder.Entity<Neighborhood>().ToTable("neighborhood_risk", "public");
        }
    }

}
