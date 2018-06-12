using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BerlinReligionData.Models;

namespace BerlinReligionData.DAL
{
    public class mysqlContext : IdentityDbContext<ApplicationData>
    {
        public mysqlContext(DbContextOptions<mysqlContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Subvention> Subventions { get; set; }
    }
}
