using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using SwipeIT.Services;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "SwipeIT.db");
            optionsBuilder.UseSqlite($"Filename = {dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapRelations();

            //modelBuilder.Seed();  // @ Michiel "Couldn't get this to work but it's an extension methode :-)"
        }

        public void DeleteDb()
        {
            Database.EnsureDeleted();
        }
    }
}