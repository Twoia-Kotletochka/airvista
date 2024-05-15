using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WDsite.Models;

namespace WDsite.Controllers
{
    public class about_travelController : Controller
    {
        private static AirWEntities db = new AirWEntities();

        IEnumerable<Countries_table> countries = db.Countries_table;
        public ActionResult Index()
        {
            return View(countries);
        }

        public ActionResult baggage()
        {

            return View("bagaj");
        }
        public ActionResult aboard()
        {

            return View();
        }
        public ActionResult special_requirements()
        {
            return View();
        }
        public ActionResult additional_services()
        {
            return View();
        }
        public ActionResult inf_reg()
        {
            return View();
        }
       
    }
}