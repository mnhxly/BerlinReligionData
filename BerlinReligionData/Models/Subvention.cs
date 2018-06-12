using System;
namespace BerlinReligionData.Models
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
}
