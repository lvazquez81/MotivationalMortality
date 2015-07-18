using MotivationalMortailityWeb.Models;
using MotivationalMortality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotivationalMortailityWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var view = new MainViewModel();
            view.Birthday = new DateTime(1981, 04, 29);
            view.Messsage = "You are 34 years old and have wasted 67 weeks out of 100.";
            view.WeeksGraphic = "############################################################";
            return View(view);
        }
    }
}