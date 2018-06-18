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

<<<<<<< Updated upstream
                foreach (var participant in participants) {
                    dataPoints.Add (new DataPoint (Convert.ToString (participant.Year), participant.ParticipantAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }
=======
                var sub1 = new Subvention(1, 26170923, 2011, "Evangelsiche Kische", 1);
                var sub2 = new Subvention(2, 25927285, 2012, "Evangelsiche Kische", 1);
                var sub3 = new Subvention(3, 25601313, 2013, "Evangelsiche Kische", 1);
                var sub4 = new Subvention(4, 25722940, 2014, "Evangelsiche Kische", 1);
                var sub5 = new Subvention(5, 25688712, 2015, "Evangelsiche Kische", 1);
                var sub6 = new Subvention(6, 28134983, 2016, "Evangelsiche Kische", 1);

                var sub7 = new Subvention(7, 13603080, 2011, "Humanistischer Verband",4);
                var sub8 = new Subvention(8, 14160080, 2012, "Humanistischer Verband", 4);
                var sub9 = new Subvention(9, 14645942, 2013, "Humanistischer Verband", 4);
                var sub10 = new Subvention(10, 15110188, 2014, "Humanistischer Verband", 4);
                var sub11 = new Subvention(11, 15574620, 2015, "Humanistischer Verband", 4);
                var sub12 = new Subvention(12, 18082480, 2016, "Humanistischer Verband", 4);
>>>>>>> Stashed changes

        public string FilterParticipantsByYear(int year, string religion){
            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var participants = from v in context.Paricipants where v.Year == year && v.Religion == religion select v;

                foreach (var participant in participants) {
                    dataPoints.Add (new DataPoint (Convert.ToString (participant.Year), participant.ParticipantAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }

        public string FilterDataByYear (int year = 2011) {

<<<<<<< Updated upstream
            List<DataPoint> dataPoints = new List<DataPoint> ();
=======
                var par1 = new Participant(1, 80393, 2011, "Evangelischer Religionsunterricht", 1);
                var par2 = new Participant(2, 78800, 2012, "Evangelischer Religionsunterricht", 1);
                var par3 = new Participant(3, 78255, 2013, "Evangelischer Religionsunterricht", 1);
                var par4 = new Participant(4, 78735, 2014, "Evangelischer Religionsunterricht", 1);
                var par5 = new Participant(5, 78771, 2015, "Evangelischer Religionsunterricht", 1);
                var par6 = new Participant(6, 79549, 2016, "Evangelischer Religionsunterricht", 1);
>>>>>>> Stashed changes

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

                var sub19 = new Subvention (19, 783792, 2011, "Islamische Föderation");
                var sub20 = new Subvention (20, 912931, 2012, "Islamische Föderation");
                var sub21 = new Subvention (21, 941873, 2013, "Islamische Föderation");
                var sub22 = new Subvention (22, 889569, 2014, "Islamische Föderation");
                var sub23 = new Subvention (23, 924576, 2015, "Islamische Föderation");
                var sub24 = new Subvention (24, 1015184, 2016, "Islamische Föderation");

                var sub25 = new Subvention (25, 611660, 2011, "Jüdische Gemeinde");
                var sub26 = new Subvention (26, 612705, 2012, "Jüdische Gemeinde");
                var sub27 = new Subvention (27, 460197, 2013, "Jüdische Gemeinde");
                var sub28 = new Subvention (28, 548451, 2014, "Jüdische Gemeinde");
                var sub29 = new Subvention (29, 630000, 2015, "Jüdische Gemeinde");
                var sub30 = new Subvention (30, 674441, 2016, "Jüdische Gemeinde");

                var sub31 = new Subvention (31, 24790, 2011, "Alevitische Gemeinde");
                var sub32 = new Subvention (32, 25288, 2012, "Alevitische Gemeinde");
                var sub33 = new Subvention (33, 23038, 2013, "Alevitische Gemeinde");
                var sub34 = new Subvention (34, 21201, 2014, "Alevitische Gemeinde");
                var sub35 = new Subvention (35, 26033, 2015, "Alevitische Gemeinde");
                var sub36 = new Subvention (36, 32229, 2016, "Alevitische Gemeinde");

                var sub37 = new Subvention (37, 20561, 2011, "Christengemeinschaft");
                var sub38 = new Subvention (38, 19465, 2012, "Christengemeinschaft");
                var sub39 = new Subvention (39, 20606, 2013, "Christengemeinschaft");
                var sub40 = new Subvention (40, 23156, 2014, "Christengemeinschaft");
                var sub41 = new Subvention (41, 25106, 2015, "Christengemeinschaft");
                var sub42 = new Subvention (42, 30743, 2016, "Christengemeinschaft");

                var sub43 = new Subvention (43, 4036, 2011, "Buddhistische Gesellschaft");
                var sub44 = new Subvention (44, 1436, 2012, "Buddhistische Gesellschaft");
                var sub45 = new Subvention (45, 2080, 2013, "Buddhistische Gesellschaft");
                var sub46 = new Subvention (46, 1832, 2014, "Buddhistische Gesellschaft");
                var sub47 = new Subvention (47, 1881, 2015, "Buddhistische Gesellschaft");
                var sub48 = new Subvention (48, 2147, 2016, "Buddhistische Gesellschaft");

                var sub49 = new Subvention (49, 0, 2011, "Lauder Beth Zion");
                var sub50 = new Subvention (50, 7755, 2012, "Lauder Beth Zion");
                var sub51 = new Subvention (51, 16876, 2013, "Lauder Beth Zion");
                var sub52 = new Subvention (52, 19624, 2014, "Lauder Beth Zion");
                var sub53 = new Subvention (53, 23000, 2015, "Lauder Beth Zion");
                var sub54 = new Subvention (54, 28556, 2016, "Lauder Beth Zion");

                var sub55 = new Subvention (55, 0, 2011, "Jüdische Traditionsschule");
                var sub56 = new Subvention (56, 0, 2012, "Jüdische Traditionsschule");
                var sub57 = new Subvention (57, 0, 2013, "Jüdische Traditionsschule");
                var sub58 = new Subvention (58, 12627, 2014, "Jüdische Traditionsschule");
                var sub59 = new Subvention (59, 33144, 2015, "Jüdische Traditionsschule");
                var sub60 = new Subvention (60, 38074, 2016, "Jüdische Traditionsschule");

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
                context.Subventions.Add (sub19);
                context.Subventions.Add (sub20);
                context.Subventions.Add (sub21);
                context.Subventions.Add (sub22);
                context.Subventions.Add (sub23);
                context.Subventions.Add (sub24);
                context.Subventions.Add (sub25);
                context.Subventions.Add (sub26);
                context.Subventions.Add (sub27);
                context.Subventions.Add (sub28);
                context.Subventions.Add (sub29);
                context.Subventions.Add (sub30);
                context.Subventions.Add (sub31);
                context.Subventions.Add (sub32);
                context.Subventions.Add (sub33);
                context.Subventions.Add (sub34);
                context.Subventions.Add (sub35);
                context.Subventions.Add (sub36);
                context.Subventions.Add (sub37);
                context.Subventions.Add (sub38);
                context.Subventions.Add (sub39);
                context.Subventions.Add (sub40);
                context.Subventions.Add (sub41);
                context.Subventions.Add (sub42);
                context.Subventions.Add (sub43);
                context.Subventions.Add (sub44);
                context.Subventions.Add (sub45);
                context.Subventions.Add (sub46);
                context.Subventions.Add (sub47);
                context.Subventions.Add (sub48);
                context.Subventions.Add (sub49);
                context.Subventions.Add (sub50);
                context.Subventions.Add (sub51);
                context.Subventions.Add (sub52);
                context.Subventions.Add (sub53);
                context.Subventions.Add (sub54);
                context.Subventions.Add (sub55);
                context.Subventions.Add (sub56);
                context.Subventions.Add (sub57);
                context.Subventions.Add (sub58);
                context.Subventions.Add (sub59);
                context.Subventions.Add (sub60);

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