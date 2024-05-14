using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WDsite.Controllers
{
    public class about_travelController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
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