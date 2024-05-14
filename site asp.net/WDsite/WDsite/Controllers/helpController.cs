using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WDsite.Models;

namespace WDsite.Controllers
{

    public class helpController : Controller
    {
        private static AirWEntities db = new AirWEntities();

        IEnumerable<Countries_table> countries = db.Countries_table;
        public ActionResult help()
        {

            return View(countries);
        }

        public ActionResult baggage_requirements()
        {

            return View();
        }
        public ActionResult travel_requirements()
        {

            return View();
        }
        public ActionResult animal_transportation()
        {

            return View();
        }
        public ActionResult animals_in_baggage()
        {

            return View();
        }
        public ActionResult guide_dog()
        {

            return View();
        }
        public ActionResult refound()
        {

            return View();
        }
        public ActionResult feedback()
        {

            return View();
        }
        public ActionResult special()
        {
            return View();
        }
        
    }
}