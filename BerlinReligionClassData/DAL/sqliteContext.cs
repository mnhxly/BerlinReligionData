using System;
using BerlinReligionClassData.Models;
using Microsoft.EntityFrameworkCore;

namespace BerlinReligionClassData.DAL
{
    public class ReligionDatabaseContext : DbContext
    {
        /// <summary>
        /// Gets or sets the subventions.
        /// </summary>
        public DbSet<Subvention> Subventions { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=./religionDb.db");
        }

    }
}
