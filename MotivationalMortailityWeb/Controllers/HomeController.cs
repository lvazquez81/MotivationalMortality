using MotivationalMortailityWeb.Models;
using MotivationalMortality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MotivationalMortailityWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var view = new RequestProfileViewModel();
            view.Birthday = new DateTime(1981, 04, 29);
            view.SelectedCountry = "Mexico";
            view.Countries = CountryCatalog.GetCountryList();
            view.Gender = GenderType.Male;
            return View(view);
        }

        [HttpPost]
        public ActionResult Index(RequestProfileViewModel view)
        {
            string csvProfilesPath = Server.MapPath(@"bin\MortalityProfiles.csv");
            MortalityReporter reporter = new MortalityReporter(new TimeProvider(), csvProfilesPath);
            LifeReport report = reporter.GetLifeReport(view.Birthday.Value, view.Gender.Value, view.SelectedCountry);

            ViewProfileViewModel responseView = new ViewProfileViewModel(view);
            responseView.Countries = CountryCatalog.GetCountryList();
            responseView.Messsage = MortalityReporter.FormatMessage(report);
            responseView.LifeExpectancyGraph = CreateExpectancyGraph(report.WeeksLived, report.ExpectedWeeks);
            return this.View("Report", responseView);
        }

        private static string CreateExpectancyGraph(int weeksLived, int weeksLifeExpectancy)
        {
            int difference = weeksLifeExpectancy - weeksLived;
            
            string livedGraph = string.Concat(Enumerable.Repeat<string>("x", weeksLived));
            string weeksLeft = string.Concat(Enumerable.Repeat<string>(".", difference));

            return string.Format("{0}{1}", livedGraph, weeksLeft);
        }
    }
}