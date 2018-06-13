using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BerlinReligionClassData.Models;
using Newtonsoft.Json;
using BerlinReligionClassData.DAL;

namespace BerlinReligionClassData.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            using (var context = new ReligionDatabaseContext())
            {
                var subventionYears = from v in context.Subventions where v.Year == 2011 select v;

                foreach(var subvention in subventionYears){
                    dataPoints.Add(new DataPoint(subvention.Religion, subvention.SubventionAmount));
                }
            }


            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
