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
            ViewBag.Subventions2011 = data.FilterDataByYear (year: 2011);
            ViewBag.Subventions2012 = data.FilterDataByYear (year: 2012);
            ViewBag.Subventions2013 = data.FilterDataByYear (year: 2013);
            ViewBag.Subventions2014 = data.FilterDataByYear (year: 2014);
            ViewBag.Subventions2015 = data.FilterDataByYear (year: 2015);
            ViewBag.Subventions2016 = data.FilterDataByYear (year: 2016);
            ViewBag.ParticipantsEvan = data.FilterParticipantsByReligion ("Evangelischer Religionsunterricht");
            ViewBag.ParticipantsKath = data.FilterParticipantsByReligion ("Katholischer Religionsunterricht");
            ViewBag.ParticipantsHuman = data.FilterParticipantsByReligion("Humanistischer Lebenskundeunterricht");
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