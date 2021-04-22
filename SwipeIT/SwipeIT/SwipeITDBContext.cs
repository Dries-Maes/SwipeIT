using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SwipeIT.Models;
using Xamarin.Essentials;

namespace SwipeIT
{
    public class SwipeITDBContext : DbContext
    {
        //public DbSet<Recruiter> Recruiters { get; set; }
        //public DbSet<Developer> Developers { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Skill> Skills { get; set; }

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
    }
}