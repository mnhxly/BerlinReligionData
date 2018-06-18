using System;
namespace BerlinReligionClassData.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public double ParticipantAmount { get; set; }
        public int Year { get; set; }
        public string Religion { get; set; }
        // public int ReligionKey { get; set; }

        public Participant(int id, double participantAmount, int year, string religion)
        {
            this.Id = id;
            this.ParticipantAmount = participantAmount;
            this.Year = year;
            this.Religion = religion;
            // this.ReligionKey = religionKey;
        }

    }
}
