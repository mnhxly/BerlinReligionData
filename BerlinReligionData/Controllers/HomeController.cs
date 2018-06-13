using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            
            dataPoints.Add(new DataPoint(1496341800000, 2790));
            dataPoints.Add(new DataPoint(1496428200000, 3380));

            dataPoints1.Add(new DataPoint(1496341800000, 4000));
            dataPoints1.Add(new DataPoint(1496428200000, 6000));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);

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
