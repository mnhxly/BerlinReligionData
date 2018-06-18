using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Models {

    public class DataModel {

        public string FilterDataByParticipants () {
            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var participants = from v in context.Paricipants select v;

                foreach (var participant in participants) {
                    dataPoints.Add (new DataPoint (Convert.ToString (participant.Year), participant.ParticipantAmount));
                }
            }
            
            return JsonConvert.SerializeObject (dataPoints);
        }

        public string FilterDataByYear (int year = 2011) {

            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var subventionYears = from v in context.Subventions where v.Year == year select v;

                foreach (var subvention in subventionYears) {
                    dataPoints.Add (new DataPoint (subvention.Religion, subvention.SubventionAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }

        public void CreateDB () {

            using (var context = new ReligionDatabaseContext ()) {
                //Clears and delete the database
                context.Database.EnsureDeleted ();

                //Creates the database
                context.Database.EnsureCreated ();

                var sub1 = new Subvention (1, 26170923, 2011, "Evangelsiche Kische");
                var sub2 = new Subvention (2, 25927285, 2012, "Evangelsiche Kische");
                var sub3 = new Subvention (3, 25601313, 2013, "Evangelsiche Kische");
                var sub4 = new Subvention (4, 25722940, 2014, "Evangelsiche Kische");
                var sub5 = new Subvention (5, 25688712, 2015, "Evangelsiche Kische");
                var sub6 = new Subvention (6, 28134983, 2016, "Evangelsiche Kische");

                var sub7 = new Subvention (7, 13603080, 2011, "Humanistischer Verband");
                var sub8 = new Subvention (8, 14160080, 2012, "Humanistischer Verband");
                var sub9 = new Subvention (9, 14645942, 2013, "Humanistischer Verband");
                var sub10 = new Subvention (10, 15110188, 2014, "Humanistischer Verband");
                var sub11 = new Subvention (11, 15574620, 2015, "Humanistischer Verband");
                var sub12 = new Subvention (12, 18082480, 2016, "Humanistischer Verband");

                context.Subventions.Add (sub1);
                context.Subventions.Add (sub2);
                context.Subventions.Add (sub3);
                context.Subventions.Add (sub4);
                context.Subventions.Add (sub5);
                context.Subventions.Add (sub6);

                context.Subventions.Add (sub7);
                context.Subventions.Add (sub8);
                context.Subventions.Add (sub9);
                context.Subventions.Add (sub10);
                context.Subventions.Add (sub11);
                context.Subventions.Add (sub12);

                var par1 = new Participant (1, 80393, 2011, "Evangelischer Religionsunterricht");
                var par2 = new Participant (2, 78800, 2012, "Evangelischer Religionsunterricht");
                var par3 = new Participant (3, 78255, 2013, "Evangelischer Religionsunterricht");
                var par4 = new Participant (4, 78735, 2014, "Evangelischer Religionsunterricht");
                var par5 = new Participant (5, 78771, 2015, "Evangelischer Religionsunterricht");
                var par6 = new Participant (6, 79549, 2016, "Evangelischer Religionsunterricht");

                context.Paricipants.Add (par1);
                context.Paricipants.Add (par2);
                context.Paricipants.Add (par3);
                context.Paricipants.Add (par4);
                context.Paricipants.Add (par5);
                context.Paricipants.Add (par6);

                context.SaveChanges ();
            }

        }
    }
}