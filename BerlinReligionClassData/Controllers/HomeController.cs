using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Controllers {
    public class HomeController : Controller {
        private const string Evangelisch = "Evangelischer Religionsunterricht";
        private const string Katholisch = "Katholischer Religionsunterricht";
        private const string Humanistisch = "Humanistischer Lebenskundeunterricht";
        public ActionResult Index () {
            DataModel data = new DataModel ();
            ViewBag.Subventions2011 = data.FilterDataByYear (year: 2011);
            ViewBag.Subventions2012 = data.FilterDataByYear (year: 2012);
            ViewBag.Subventions2013 = data.FilterDataByYear (year: 2013);
            ViewBag.Subventions2014 = data.FilterDataByYear (year: 2014);
            ViewBag.Subventions2015 = data.FilterDataByYear (year: 2015);
            ViewBag.Subventions2016 = data.FilterDataByYear (year: 2016);
            ViewBag.ParticipantsEvan2011 = data.FilterParticipantsByYear (year: 2011, religion: Evangelisch);
            ViewBag.ParticipantsEvan = data.FilterParticipantsByReligion (Evangelisch);
            ViewBag.ParticipantsKath = data.FilterParticipantsByReligion (Katholisch);
            ViewBag.ParticipantsHuman = data.FilterParticipantsByReligion (Humanistisch);
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