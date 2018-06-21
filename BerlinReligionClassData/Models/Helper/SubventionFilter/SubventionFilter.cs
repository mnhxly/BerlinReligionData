using System;
using System.Collections.Generic;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Models.Helper.SubventionFilter {
    public class SubventionFilter {

        /// <summary>
        /// Datas the by year.
        /// </summary>
        /// <returns>The by year. Returned as a JSON string</returns>
        /// <param name="year">Year. Default is 2011</param>
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

        /// <summary>
        /// Subventions by religion.
        /// </summary>
        /// <returns>The by religion. Returned as a JSON string</returns>
        /// <param name="religion">Religion.</param>
        public string SubventionsByReligion (string religion) {
            List<DataPoint> dataPoints = new List<DataPoint> ();

            using (var context = new ReligionDatabaseContext ()) {
                var subventions = from v in context.Subventions where v.Religion == religion.Trim() select v;

                foreach (var subvention in subventions) {
                    dataPoints.Add (new DataPoint (Convert.ToString (subvention.Year), subvention.SubventionAmount));
                }
            }

            return JsonConvert.SerializeObject (dataPoints);
        }


    }
}