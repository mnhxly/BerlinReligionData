using System;
using BerlinReligionData.Models;
using Microsoft.EntityFrameworkCore;

namespace BerlinReligionData.DAL
{
    public class ReligionDatabaseContext : DbContext
    {
        /// <summary>
        /// Gets or sets the subventions.
        /// </summary>
        public DbSet<Subvention> Subventions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=./religionDb.sqlite");
        }

    }
}
