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

        public string FilterParticipantsByReligion (string religion) {
            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var participants = from v in context.Paricipants where v.Religion == religion select v;

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

                var sub1 = new Subvention (1, 26170923, 2011, "Evangelische Kirche");
                var sub2 = new Subvention (2, 25927285, 2012, "Evangelische Kirche");
                var sub3 = new Subvention (3, 25601313, 2013, "Evangelische Kirche");
                var sub4 = new Subvention (4, 25722940, 2014, "Evangelische Kirche");
                var sub5 = new Subvention (5, 25688712, 2015, "Evangelische Kirche");
                var sub6 = new Subvention (6, 28134983, 2016, "Evangelische Kirche");

                var sub7 = new Subvention (7, 13603080, 2011, "Humanistischer Verband");
                var sub8 = new Subvention (8, 14160080, 2012, "Humanistischer Verband");
                var sub9 = new Subvention (9, 14645942, 2013, "Humanistischer Verband");
                var sub10 = new Subvention (10, 15110188, 2014, "Humanistischer Verband");
                var sub11 = new Subvention (11, 15574620, 2015, "Humanistischer Verband");
                var sub12 = new Subvention (12, 18082480, 2016, "Humanistischer Verband");

                var sub13 = new Subvention (13, 7725543, 2011, "Erzbistum");
                var sub14 = new Subvention (14, 7676283, 2012, "Erzbistum");
                var sub15 = new Subvention (15, 7594242, 2013, "Erzbistum");
                var sub16 = new Subvention (16, 7513192, 2014, "Erzbistum");
                var sub17 = new Subvention (17, 7489158, 2015, "Erzbistum");
                var sub18 = new Subvention (18, 9024745, 2016, "Erzbistum");

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

                context.Subventions.Add (sub13);
                context.Subventions.Add (sub14);
                context.Subventions.Add (sub15);
                context.Subventions.Add (sub16);
                context.Subventions.Add (sub17);
                context.Subventions.Add (sub18);

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

                var par7 = new Participant (7, 25021, 2011, "Katholischer Religionsunterricht");
                var par8 = new Participant (8, 24709, 2012, "Katholischer Religionsunterricht");
                var par9 = new Participant (9, 24422, 2013, "Katholischer Religionsunterricht");
                var par10 = new Participant (10, 24188, 2014, "Katholischer Religionsunterricht");
                var par11 = new Participant (11, 24176, 2015, "Katholischer Religionsunterricht");
                var par12 = new Participant (12, 24243, 2016, "Katholischer Religionsunterricht");

                context.Paricipants.Add (par7);
                context.Paricipants.Add (par8);
                context.Paricipants.Add (par9);
                context.Paricipants.Add (par10);
                context.Paricipants.Add (par11);
                context.Paricipants.Add (par12);

                var par13 = new Participant (13, 49813, 2011, "Humanistischer Lebenskundeunterricht");
                var par14 = new Participant (14, 51871, 2012, "Humanistischer Lebenskundeunterricht");
                var par15 = new Participant (15, 53811, 2013, "Humanistischer Lebenskundeunterricht");
                var par16 = new Participant (16, 55559, 2014, "Humanistischer Lebenskundeunterricht");
                var par17 = new Participant (17, 56380, 2015, "Humanistischer Lebenskundeunterricht");
                var par18 = new Participant (18, 60257, 2016, "Humanistischer Lebenskundeunterricht");

                context.Paricipants.Add (par13);
                context.Paricipants.Add (par14);
                context.Paricipants.Add (par15);
                context.Paricipants.Add (par16);
                context.Paricipants.Add (par17);
                context.Paricipants.Add (par18);
                context.SaveChanges ();
            }

        }
    }
}