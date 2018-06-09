using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace LeenartMalteProject.Models
{
   

    public class Subvention
    {
        public int Id { get; set; }
        public double SubventionAmount { get; set; }
        public int Year { get; set; }
        public string Religion { get; set; }

        public Subvention(int id, double subventionAmount, int year, string religion)
        {
            this.Id = id;
            this.SubventionAmount = subventionAmount;
            this.Year = year;
            this.Religion = religion;
        }
    }
    public class Participants
    {
        public int Id { get; set; }
        public double ParticipantAmount { get; set; }
        public int Year { get; set; }
        public string Religion { get; set; }

        public Participants(int id, double participantAmount, int year, string religion)
        {
            this.Id = id;
            this.ParticipantAmount = participantAmount;
            this.Year = year;
            this.Religion = religion;
        }

    }
    public class ReligionContext : DbContext

    {
        public DbSet<Subvention> Subventions { get; set; }
        //public DbSet<Year> Years { get; set; }
        //public DbSet<Subvention> Subventions { get; set; }
        //public DbSet<Participants> Participants { get; set; }


    }
    public class DataModel
    {
            public bool CheckIfDBAlreadyExists()
            {
                string startupPath = System.IO.Directory.GetCurrentDirectory();



                return true;

            }

            public void CreateDB()
            {

            using (var db = new ReligionContext())
                {
                var subvention = new Subvention(1, 100, 2017, "Evangelisch, ");

                db.Subventions.Add(subvention);
                    db.SaveChanges();

                }
          }
    }
}
