using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace SwipeIT
{
    internal class SwipeITDBContext : DbContext
    {
        public SwipeITDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "SwipeIT.db");
            optionsBuilder.UseSqlite($"Filename = {dbPath}");
        }
    }
}