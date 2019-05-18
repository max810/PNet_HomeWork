using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNet_Again.Models;

namespace PNet_HomeWork.Models
{
    public class WorldContext : DbContext
    {
        public DbSet<Fish> Fishes { get; set; }
        public DbSet<River> Rivers { get; set; }

        public WorldContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorldContext, PNet_Again.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SwimmingCharacteristics>().HasKey(sc => sc.FishId);
            modelBuilder.Entity<Fish>().HasRequired(f => f.SwimmingCharacteristics).WithRequiredPrincipal(sc => sc.Fish);

            modelBuilder.Entity<SwimmingCharacteristics>().Map(m => m.ToTable("Fishes"));

            modelBuilder.Entity<Fish>().Map(m =>
            {
                m.Properties(f => new { f.FishId, f.ScientificName, f.ShortName, f.RiverId, f.FinType });
                m.ToTable("Fishes");
            })
            .Map(m =>
            {
                m.Properties(f => new { f.FishId, f.Width, f.Height, f.Length });
                m.ToTable("FishSizes");
            });
        }
    }
}
