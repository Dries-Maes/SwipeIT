using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using System.IO;
using Xamarin.Essentials;

namespace SwipeIT
{
    public class SwipeITDBContext : DbContext
    {
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<AvailableLocation> AvailableLocations { get; set; }
        public DbSet<DateLog> DateLogs { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public SwipeITDBContext()
        {
            Database.EnsureCreated();
        }

        // Database is autonmatically generated on first run
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "SwipeIT.db");
            optionsBuilder.UseSqlite($"Filename = {dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasMany(x => x.Recruiters);

            modelBuilder.Entity<Recruiter>().HasMany(x => x.Developers);

            modelBuilder.Entity<Developer>().HasMany(x => x.Skills);

            modelBuilder.Entity<Recruiter>().HasMany(x => x.Skills);

            modelBuilder.Entity<Developer>().HasMany(x => x.AvailableLocations);

            modelBuilder.Entity<Recruiter>().HasMany(x => x.AvailableLocations);

            //Todo mapping for locations (and dbset)
        }

        public void DeleteDb()
        {
            Database.EnsureDeleted();
        }
    }
}