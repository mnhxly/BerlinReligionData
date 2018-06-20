using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using BerlinReligionClassData.Models.Helper.ParticipantFilter;
using BerlinReligionClassData.Models.Helper.SubventionFilter;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Controllers {
    public class HomeController : Controller {
        private const string Evangelisch = "Evangelischer Religionsunterricht";
        private const string Katholisch = "Katholischer Religionsunterricht";
        private const string Islamisch = "Islamischer Religionsunterricht";

        private const string Humanistisch = "Humanistischer Lebenskundeunterricht";

        private const string Sonstig = "Sonstiger Religions- und Weltanschauungsunterricht";

        public ActionResult Index () {
            ParticipantFilter partfilter = new ParticipantFilter ();
            SubventionFilter subFilter = new SubventionFilter ();
            ViewBag.Subventions2011 = subFilter.DataByYear (year: 2011);
            ViewBag.Subventions2012 = subFilter.DataByYear (year: 2012);
            ViewBag.Subventions2013 = subFilter.DataByYear (year: 2013);
            ViewBag.Subventions2014 = subFilter.DataByYear (year: 2014);
            ViewBag.Subventions2015 = subFilter.DataByYear (year: 2015);
            ViewBag.Subventions2016 = subFilter.DataByYear (year: 2016);
            ViewBag.Participants2011 = partfilter.ParticipantsByYear (year: 2011);
            ViewBag.Participants2012 = partfilter.ParticipantsByYear (year: 2012);
            ViewBag.Participants2013 = partfilter.ParticipantsByYear (year: 2013);
            ViewBag.Participants2014 = partfilter.ParticipantsByYear (year: 2014);
            ViewBag.Participants2015 = partfilter.ParticipantsByYear (year: 2015);
            ViewBag.Participants2016 = partfilter.ParticipantsByYear (year: 2016);
            ViewBag.ParticipantsEvan = partfilter.ParticipantsByReligion (Evangelisch);
            ViewBag.ParticipantsKath = partfilter.ParticipantsByReligion (Katholisch);
            ViewBag.ParticipantsHuman = partfilter.ParticipantsByReligion (Humanistisch);
            ViewBag.ParticipantsIslam = partfilter.ParticipantsByReligion (Islamisch);
            ViewBag.ParticipantsSonst = partfilter.ParticipantsByReligion (Sonstig);
            return View ();
        }

        public IActionResult About () {
            ViewData["Message"] = "Your application description page.";
            ExcelReader excel = new ExcelReader ();
            excel.ReadDataSource ();
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