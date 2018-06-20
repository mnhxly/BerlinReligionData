using System;
using System.Collections.Generic;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Models.Helper.SubventionFilter {
    public class SubventionFilter {
        
        public string DataByYear (int year = 2011) {

            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var subventionYears = from v in context.Subventions where v.Year == year select v;

                foreach (var subvention in subventionYears) {
                    dataPoints.Add (new DataPoint (subvention.Religion, subvention.SubventionAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }


    }
}