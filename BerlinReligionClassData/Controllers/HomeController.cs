using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Controllers {
    public class HomeController : Controller {

        public ActionResult Index () {
            DataModel data = new DataModel ();
            ViewBag.DataPoints = data.FilterDataByYear (year: 2016);
            ViewBag.Participants = data.FilterDataByParticipants ();
            return View ();
        }

        public IActionResult About () {
            ViewData["Message"] = "Your application description page.";

            return View ();
        }

        public IActionResult Contact () {
            ViewData["Message"] = "Your contact page.";

            return View ();
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}