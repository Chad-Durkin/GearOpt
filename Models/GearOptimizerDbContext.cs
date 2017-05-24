using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GearOptimizer.Models
{
    public class GearOptimizerDbContext : IdentityDbContext<ApplicationUser>
    {
        public GearOptimizerDbContext()
        {
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<FullSet> FullSets { get; set; }
        public DbSet<Drop> Drops { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<ProfileFullSet> ProfileFullSets { get; set; }
        public DbSet<BossDrop> BossDrops { get; set; }
        public DbSet<FullSetGear> FullSetGears { get; set; }
        public DbSet<FullSetBoss> FullSetBosses { get; set; }
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
            builder.Entity<BossDrop>().HasKey(x => new { x.BossId, x.DropId });
            builder.Entity<FullSetGear>().HasKey(x => new { x.FullSetId, x.GearId });
            builder.Entity<FullSetBoss>().HasKey(x => new { x.FullSetId, x.BossId });
            builder.Entity<ProfileFullSet>().HasKey(x => new { x.FullSetId, x.ProfileId });
        }
    }
}
