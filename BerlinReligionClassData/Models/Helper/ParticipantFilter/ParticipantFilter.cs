using System;
using System.Collections.Generic;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Models.Helper.ParticipantFilter {
    
    public class ParticipantFilter {
        
        public string ParticipantsByReligionKey (int religionKey) {
            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var participants = from v in context.Participants where v.ReligionKey == religionKey select v;

                foreach (var participant in participants) {
                    dataPoints.Add (new DataPoint (Convert.ToString (participant.Year), participant.ParticipantAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }

        public string ParticipantsByYear (int year) {
            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var participants = from v in context.Participants where v.Year == year select v;

                foreach (var participant in participants) {
                    dataPoints.Add (new DataPoint (Convert.ToString (participant.Religion), participant.ParticipantAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }
    }
}