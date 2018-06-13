using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD:BerlinReligionClassData/Controllers/HomeController.cs
using BerlinReligionClassData.Models;
using Newtonsoft.Json;
using BerlinReligionClassData.DAL;

namespace BerlinReligionClassData.Controllers
{
    public class HomeController : Controller
    {

=======
using BerlinReligionData.Models;
using BerlinReligionData.DAL;
using Newtonsoft.Json;

namespace BerlinReligionData.Controllers
{

    public class HomeController : Controller
    {

        //private readonly mysqlContext context;
        ////public HomeController(mysqlContext context) {
        ////    this.context = context;
        ////}
>>>>>>> master:BerlinReligionData/Controllers/HomeController.cs

        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
<<<<<<< HEAD:BerlinReligionClassData/Controllers/HomeController.cs

            using (var context = new ReligionDatabaseContext())
            {
                var subventionYears = from v in context.Subventions where v.Year == 2011 select v;

                foreach(var subvention in subventionYears){
                    dataPoints.Add(new DataPoint(subvention.Religion, subvention.SubventionAmount));
                }
            }


            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
=======
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            
            dataPoints.Add(new DataPoint(1496341800000, 2790));
            dataPoints.Add(new DataPoint(1496428200000, 3380));

            dataPoints1.Add(new DataPoint(1496341800000, 4000));
            dataPoints1.Add(new DataPoint(1496428200000, 6000));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
>>>>>>> master:BerlinReligionData/Controllers/HomeController.cs

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
