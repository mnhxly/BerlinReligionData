﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BerlinReligionClassData.Models.Helper.ParticipantFilter;
using BerlinReligionClassData.Models.Helper.SubventionFilter;

namespace BerlinReligionClassData.Controllers {
    public class HomeController : Controller {
        private const string Evangelisch = "Evangelischer Religionsunterricht";
        private const string Katholisch = "Katholischer Religionsunterricht";
        private const string Humanistisch = "Humanistischer Lebenskundeunterricht";
        public ActionResult Index () {
            ParticipantFilter partfilter = new ParticipantFilter ();
            SubventionFilter subFilter = new SubventionFilter();
            ViewBag.Subventions2011 = subFilter.DataByYear (year: 2011);
            ViewBag.Subventions2012 = subFilter.DataByYear (year: 2012);
            ViewBag.Subventions2013 = subFilter.DataByYear (year: 2013);
            ViewBag.Subventions2014 = subFilter.DataByYear (year: 2014);
            ViewBag.Subventions2015 = subFilter.DataByYear (year: 2015);
            ViewBag.Subventions2016 = subFilter.DataByYear (year: 2016);
            ViewBag.ParticipantsEvan2011 = partfilter.ParticipantsByYear (year: 2011, religion: Evangelisch);
            ViewBag.ParticipantsEvan = partfilter.ParticipantsByReligion (Evangelisch);
            ViewBag.ParticipantsKath = partfilter.ParticipantsByReligion (Katholisch);
            ViewBag.ParticipantsHuman = partfilter.ParticipantsByReligion (Humanistisch);
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