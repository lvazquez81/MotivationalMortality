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
        [HttpPost]
        public ActionResult Index()
        {
            var view = new MainViewModel();
            view.Birthday = DateTime.Now;
            view.Messsage = "";
            view.WeeksGraphic = "";
            return View(view);
        }

        [HttpPost]
        public ActionResult Index(MainViewModel view)
        {
            MortalityReporter reporter = new MortalityReporter(new TimeProvider());
            LifeReport report = reporter.GetLifeReport("demo", view.Birthday);

            view.Messsage = FormatMessage(report.Name, report.YearsLived, report.WeeksLived);
            view.WeeksGraphic = CreateWeeksGraphic(report.WeeksLived);
            return View(view);
        }

        private static string FormatMessage(string name, int age, int numberofWeeks)
        {
            return string.Format("{0} is {1} years old and has lived {3} weeks.", name, age, numberofWeeks);
        }

        private static string CreateWeeksGraphic(int numberOfWeeks)
        {
            StringBuilder weeksGraphic = new StringBuilder();
            for (int i = 0; i < numberOfWeeks; i++)
            {
                weeksGraphic.Append("...... ");

                if (i % 12 == 0)
                {
                    weeksGraphic.AppendLine("<br/>");
                }
            }
            return weeksGraphic.ToString();
        }
    }
}