using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GearOptimizer.Model
{
    public class GearOptimizerDbContext : DbContext
    {
        public GearOptimizerDbContext()
        {
        }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<FullSet> FullSets { get; set; }
        public DbSet<Drop> Drops { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<BossDrops> BossDrops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GearOptimizerWithMigrations;integrated security=True");
        }
        public GearOptimizerDbContext(DbContextOptions<GearOptimizerDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BossDrops>().HasKey(x => new { x.BossId, x.DropId });
        }
    }
}
