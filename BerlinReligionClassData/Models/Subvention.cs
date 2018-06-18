using System;
using System.ComponentModel.DataAnnotations;

namespace BerlinReligionClassData.Models
{
    public class Subvention
    {
        [Key]
        public int Id { get; set; }
        public double SubventionAmount { get; set; }
        public int Year { get; set; }
        public string Religion { get; set; }
        // public int ReligionKey { get; set; }

        public Subvention(int id, double subventionAmount, int year, string religion)
        {
            this.Id = id;
            this.SubventionAmount = subventionAmount;
            this.Year = year;
            this.Religion = religion;
            // this.ReligionKey = religionKey;
        }

    }
}
