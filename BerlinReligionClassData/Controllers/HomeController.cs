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

            ViewBag.Subventions1 = subFilter.SubventionsByReligion ("Evangelische Kirche Berlin - Brandenburg - schlesische Oberlausitz");
            ViewBag.Subventions2 = subFilter.SubventionsByReligion ("Humanisitischer Verband Berlin - Brandenburg");
            ViewBag.Subventions3 = subFilter.SubventionsByReligion ("Erzbistum Berlin");
            ViewBag.Subventions4 = subFilter.SubventionsByReligion ("Islamische Föderation Berlin");
            ViewBag.Subventions5 = subFilter.SubventionsByReligion ("Jüdische Gemeinde zu Berlin");
            ViewBag.Subventions6 = subFilter.SubventionsByReligion ("Alevitische Gemeinde zu Berlin");
            ViewBag.Subventions7 = subFilter.SubventionsByReligion ("Christengemeinschaft im Lande Berlin");
            ViewBag.Subventions8 = subFilter.SubventionsByReligion ("Buddhistische Gesellschaft Berlin");
            ViewBag.Subventions9 = subFilter.SubventionsByReligion ("Lauder Beth Zion");
            ViewBag.Subventions10 = subFilter.SubventionsByReligion("Jüdische Traditionsschule");

            ViewBag.Participants2011 = partfilter.ParticipantsByYear (year: 2011);
            ViewBag.Participants2012 = partfilter.ParticipantsByYear (year: 2012);
            ViewBag.Participants2013 = partfilter.ParticipantsByYear (year: 2013);
            ViewBag.Participants2014 = partfilter.ParticipantsByYear (year: 2014);
            ViewBag.Participants2015 = partfilter.ParticipantsByYear (year: 2015);
            ViewBag.Participants2016 = partfilter.ParticipantsByYear (year: 2016);

            ViewBag.Participants1 = partfilter.ParticipantsByReligionKey (1);
            ViewBag.Participants2 = partfilter.ParticipantsByReligionKey (2);
            ViewBag.Participants3 = partfilter.ParticipantsByReligionKey (3);
            ViewBag.Participants4 = partfilter.ParticipantsByReligionKey (4);
            ViewBag.Participants5 = partfilter.ParticipantsByReligionKey (5);
            ViewBag.Participants6 = partfilter.ParticipantsByReligionKey(6);
            ViewBag.Participants7 = partfilter.ParticipantsByReligionKey(7);
            ViewBag.Participants8 = partfilter.ParticipantsByReligionKey(8);
            ViewBag.Participants9 = partfilter.ParticipantsByReligionKey(9);

            return View ();
        }

        public IActionResult About () {
            ViewData["Message"] = "BerlinReligion Data, the best Tool to analyze the different religion classes in Belin";
           
            return View ();
        }

        public IActionResult Contact () {
            ViewData["Message"] = "Our Contacts:";

            return View ();
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}