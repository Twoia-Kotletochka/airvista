using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.WebPages;
using WDsite.Models;
namespace WDsite.Controllers
{
    public class HomeController : Controller
    {
        private static AirWEntities db = new AirWEntities();
        IEnumerable<Countries_table> countries = db.Countries_table;

        public ActionResult Index()
        {
            return View(countries);
        }
        public ActionResult view_airvista()
        {
            return View("MAirVista");
        }
        public ActionResult business()
        {
            return View();
        }
        public ActionResult successful_reservation()
        {
            Bilet_table bilet1 = db.Bilet_table.Find(Session["bilet1"]);
            Bilet_table bilet2 = db.Bilet_table.Find(Session["bilet2"]);

            ViewBag.from = bilet1.Countries_table.Country;
            ViewBag.to = bilet1.Countries_table1.Country;
            ViewBag.b1 = bilet1;
            ViewBag.b2 = bilet2;
            ViewBag.date1 = bilet1.date_from.Value.ToString("dd.MM.yyyy");
            ViewBag.date2 = bilet2.date_from.Value.ToString("dd.MM.yyyy");
            return View();
        }
        public ActionResult food_and_drinks()
        {
            IEnumerable<Countries_table> countries = db.Countries_table;
            return View(countries);
        }
        public ActionResult baggage()
        {
            IEnumerable<Countries_table> countries = db.Countries_table;
            return View(countries);
        }
        public ActionResult airvista_upgrade()
        {
            IEnumerable<Countries_table> countries = db.Countries_table;
            return View(countries);
        }
        public ActionResult premium()
        {
            return View();
        }
        public ActionResult choose_place()
        {
            Bilet_table b1 = db.Bilet_table.Find(Session["bilet1"]);
            Bilet_table b2 = db.Bilet_table.Find(Session["bilet2"]);
            ViewBag.from1 = db.Countries_table.Find(b1.form_id).Redu;
            ViewBag.to1 = db.Countries_table.Find(b1.to_id).Redu;
            ViewBag.from2 = db.Countries_table.Find(b2.form_id).Redu;
            ViewBag.to2 = db.Countries_table.Find(b2.to_id).Redu;

            IEnumerable<Place_table> p1 = from u in db.Place_table
                                               where u.id_bilet == b1.id
                                               select u;

            IEnumerable<Place_table> p2 = from u in db.Place_table
                                               where u.id_bilet == b2.id
                                               select u;

            string[] places1 = p1.Select(u => u.place_name).ToArray();
            string[] places2 = p2.Select(u => u.place_name).ToArray();


            ViewBag.places1 = places1;
            ViewBag.places2 = places2;

            return View();
        }
        [HttpPost]
        public ActionResult choose_place(string value1, string value2)
        {
            Session["place1"] = value1;
            Session["place2"] = value2;
            Place_table ch_place1 = new Place_table();
            Place_table ch_place2 = new Place_table();
            ch_place1.id_bilet = db.Bilet_table.Find(Session["bilet1"]).id;
            ch_place2.id_bilet = db.Bilet_table.Find(Session["bilet2"]).id;
            ch_place1.place_name = value1;
            ch_place2.place_name = value2;
            ch_place1.date = DateTime.Now;
            ch_place2.date = DateTime.Now;

            db.Place_table.Add(ch_place1);
            db.Place_table.Add(ch_place2);
            db.SaveChanges();

            return RedirectToAction("payment_method");
        }
        public void SaveCurrencyText(string currencyText)
        {
            Session["val"] = currencyText;
        }
        public ActionResult help()
        {
            return View();
        }
        public ActionResult about_trip()
        {

            return View();
        }
        public ActionResult econom_class()
        {

            return View();
        }

        [HttpPost]
        public ActionResult choose_tariff(int hiddenValue1, int hiddenValue2)
        {
            Session["bilet1"] = hiddenValue1;
            Session["bilet2"] = hiddenValue2;
            return View();
        }

        public ActionResult input_data(int? id)
        {
            if (id == 1)
            {
                Session["tariff"] = "Basic";
                Session["tariff_price"] = 0;
                Session["id_tariff"] = 1;
            }
            else if (id == 2)
            {
                Session["tariff"] = "Regular";
                Session["tariff_price"] = 650;
                Session["id_tariff"] = 2;
            }
            else if (id == 3)
            {
                Session["tariff"] = "PLUS";
                Session["tariff_price"] = 837;
                Session["id_tariff"] = 3;
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult input_data(string fname, string sname, string email, string namber, string gender)
        {
            if (fname.IsEmpty() || sname.IsEmpty() || email.IsEmpty() || namber.IsEmpty() || gender.IsEmpty())
            {
                Session["ErrorMessage"] = "Усі поля повинні бути заповненні";
                return RedirectToAction("input_data", new { id = Session["id_tariff"] });
            }

            Session["ErrorMessage"] = null;
            Session["fname"] = fname;
            Session["sname"] = sname;
            Session["email"] = email;
            Session["namber"] = namber;
            Session["gender"] = gender;

            return RedirectToAction("choose_place");
        }
        public ActionResult payment_method()
        {
            Bilet_table bilet1 = db.Bilet_table.Find(Session["bilet1"]);
            Bilet_table bilet2 = db.Bilet_table.Find(Session["bilet2"]);

            ViewBag.from = bilet1.Countries_table.Country;
            ViewBag.to = bilet1.Countries_table1.Country;
            ViewBag.b1 = bilet1;
            ViewBag.b2 = bilet2;
            ViewBag.date1 = bilet1.date_from.Value.ToString("dd.MM.yyyy");
            ViewBag.date2 = bilet2.date_from.Value.ToString("dd.MM.yyyy");
            return View();
        }

        public ActionResult additional_services()
        {

            return View();
        }
        public ActionResult special_requirements()
        {

            return View();
        }

        [HttpPost]
        public ActionResult exit()
        {
            Session["account"] = null;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult login(string email, string password)
        {
             

                IEnumerable<persons_table> query = from u in db.persons_table
                                                   where u.email == email
                                                   select u;
                if (IsEmpty(query) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    persons_table person = query.First();
                    person.password = AESEncryption.Decrypt(person.password);
                    if (person.password == password)
                    {
                        Session["account"] = person;
                        Session["first_name"] = person.first_name;
                    }
                
                }
            return RedirectToAction("Index");
        }
        bool IsEmpty(IEnumerable en)
        {
            foreach (var c in en) { return false; }
            return true;
        }

        [HttpPost]
        public ActionResult Registration([Bind(Include = "id,first_name,last_name,gender,phone_namber,email,password")] persons_table persons_table)
        {

            if (ModelState.IsValid)
            {
                
                IEnumerable<persons_table> person = from u in db.persons_table
                  where u.email.ToString() == persons_table.email.ToString()
                  select u;

                if (IsEmpty(person))
                {
                    persons_table p = persons_table;
                    p.password = AESEncryption.Encrypt(persons_table.password);
                    db.persons_table.Add(persons_table);
                    db.SaveChanges();
               
                    return RedirectToAction("Index");
                }

            }

            ViewBag.AccIs = "Щось пішло не так можливо обліковий запис з такою адресою вже існує";
            return RedirectToAction("Index");

        }



        public ActionResult bilet_search_test()
        {
            ViewBag.form_id = new SelectList(db.Countries_table, "id", "Country");
            ViewBag.to_id = new SelectList(db.Countries_table, "id", "Country");
            return View();
        }




        //[HttpPost]
        //public ActionResult bilet_search_test([Bind(Include = "id,form_id,to_id,date_from,price,type,date_to")] Bilet_table bilet_table)
        //{
        //    Bilet_table b = bilet_table;

        //    IEnumerable<Bilet_table> bilets = db.Bilet_table;
        //    var query = from u in bilets
        //                where u.Countries_table.id == bilet_table.form_id && u.Countries_table1.id == bilet_table.to_id
        //                select u;

        //    Countries_table c1 = db.Countries_table.Find(b.form_id);
        //    Countries_table c2 = db.Countries_table.Find(b.to_id);
        //    ViewBag.from = c1.Country;
        //    ViewBag.to = c2.Country;
        //    CultureInfo ci = CultureInfo.InvariantCulture;
        //    ViewBag.ci = ci;
        //    return View("bilet_search_post", query.ToList());
        //}

        [HttpPost]
        public ActionResult bilet_search_test(string country_from, string country_to, DateTime? date_from, DateTime? date_to)
        {

            if (country_from.IsEmpty() || country_to.IsEmpty() || country_from == "З" || country_to == "До")
            {
                return View("bilet_search_post", countries);
            }

            var cf = db.Countries_table
                    .Where(b => b.Country == country_from)
                    .FirstOrDefault();
            var ct = db.Countries_table
                    .Where(b => b.Country == country_to)
                    .FirstOrDefault();
            IEnumerable<Bilet_table> bilets = db.Bilet_table;
            var query = from u in bilets
                        where u.Countries_table.id == cf.id && u.Countries_table1.id == ct.id
                        select u;
            var q1 = from i in query
                     where i.date_from >= date_from && i.date_to <= date_from?.AddDays(1)
                     select i;



            IEnumerable<Bilet_table> bilets2 = db.Bilet_table;
            var query2 = from u in bilets2
                         where u.Countries_table.id == ct.id && u.Countries_table1.id == cf.id
                         select u;
            var q2 = from i in query2
                     where i.date_from >= date_to && i.date_to <= date_to?.AddDays(1)
                     select i;


            ViewBag.from = cf.Country;
            ViewBag.to = ct.Country;
            CultureInfo ci = CultureInfo.InvariantCulture;
            ViewBag.ci = ci;
            ViewBag.from_date = date_from.Value.ToString("dd.MM.yyyy");
            ViewBag.to_date = date_to.Value.ToString("dd.MM.yyyy");
            ViewBag.list1 = q1.ToList();
            ViewBag.list2 = q2.ToList();

            if (IsEmpty(q1) && IsEmpty(q2))
            {
                ViewBag.list1 = null;
                ViewBag.list2 = null;
                return View("bilet_search_post", countries);
            }else if (IsEmpty(q1))
            {
                ViewBag.list1 = null;
                
                return View("bilet_search_post", countries);
            }
            else if (IsEmpty(q2))
            {
                ViewBag.list2 = null;
                return View("bilet_search_post", countries);
            }

            return View("bilet_search_post", countries);
        }

        [HttpPost]
        public ActionResult bilet_search_one_side(string country_from1, string country_to1, DateTime? date_from)
        {

            if (country_from1.IsEmpty() || country_to1.IsEmpty() || country_from1 == "З" || country_to1 == "До")
            {
                return View("bilet_search_post", countries);
            }

            var cf = db.Countries_table
                    .Where(b => b.Country == country_from1)
                    .FirstOrDefault();
            var ct = db.Countries_table
                    .Where(b => b.Country == country_to1)
                    .FirstOrDefault();
            IEnumerable<Bilet_table> bilets = db.Bilet_table;
            var query = from u in bilets
                        where u.Countries_table.id == cf.id && u.Countries_table1.id == ct.id
                        select u;
            var q1 = from i in query
                     where i.date_from >= date_from && i.date_to <= date_from?.AddDays(1)
                     select i;



            


            ViewBag.from = cf.Country;
            ViewBag.to = ct.Country;
            CultureInfo ci = CultureInfo.InvariantCulture;
            ViewBag.ci = ci;
            ViewBag.from_date = date_from.Value.ToString("dd.MM.yyyy");
           
            ViewBag.list1 = q1.ToList();
            

            if (IsEmpty(q1))
            {
                ViewBag.list1 = null;
                
                return View("bilet_search_post_one_side", countries);
            }
            else if (IsEmpty(q1))
            {
                ViewBag.list1 = null;

                return View("bilet_search_post_one_side", countries);
            }
           

            return View("bilet_search_post_one_side", countries);
        }



        //choose_tariff_one_side
        [HttpPost]
        public ActionResult choose_tariff_one_side(int hiddenValue1)
        {
            Session["bilet1"] = hiddenValue1;
            return View();
        }


        public ActionResult input_data_one_side(int? id)
        {
            if (id == 1)
            {
                Session["tariff"] = "Basic";
                Session["tariff_price"] = 0;
                Session["id_tariff"] = 1;
            }
            else if (id == 2)
            {
                Session["tariff"] = "Regular";
                Session["tariff_price"] = 650;
                Session["id_tariff"] = 2;
            }
            else if (id == 3)
            {
                Session["tariff"] = "PLUS";
                Session["tariff_price"] = 837;
                Session["id_tariff"] = 3;
            }

            return View();
        }
        [HttpPost]
        public ActionResult input_data_one_side(string fname, string sname, string email, string namber, string gender)
        {
            if (fname.IsEmpty() || sname.IsEmpty() || email.IsEmpty() || namber.IsEmpty() || gender.IsEmpty())
            {
                Session["ErrorMessage"] = "Усі поля повинні бути заповненні";
                return RedirectToAction("input_data_one_side", new { id = Session["id_tariff"] });
            }

            Session["ErrorMessage"] = null;
            Session["fname"] = fname;
            Session["sname"] = sname;
            Session["email"] = email;
            Session["namber"] = namber;
            Session["gender"] = gender;

            return RedirectToAction("choose_place_one_side");
        }


        public ActionResult choose_place_one_side()
        {
            Bilet_table b1 = db.Bilet_table.Find(Session["bilet1"]);
           
            ViewBag.from1 = db.Countries_table.Find(b1.form_id).Redu;
            ViewBag.to1 = db.Countries_table.Find(b1.to_id).Redu;
           

            IEnumerable<Place_table> p1 = from u in db.Place_table
                                          where u.id_bilet == b1.id
                                          select u;

          

            string[] places1 = p1.Select(u => u.place_name).ToArray();
         


            ViewBag.places1 = places1;
           

            return View();
        }
        [HttpPost]
        public ActionResult choose_place_one_side(string value1)
        {
            Session["place1"] = value1;
           
            Place_table ch_place1 = new Place_table();
           
            ch_place1.id_bilet = db.Bilet_table.Find(Session["bilet1"]).id;
           
            ch_place1.place_name = value1;
            
            ch_place1.date = DateTime.Now;
          

            db.Place_table.Add(ch_place1);
            
            db.SaveChanges();

            return RedirectToAction("payment_method_one_side");
        }

        public ActionResult payment_method_one_side()
        {
            Bilet_table bilet1 = db.Bilet_table.Find(Session["bilet1"]);
            

            ViewBag.from = bilet1.Countries_table.Country;
            ViewBag.to = bilet1.Countries_table1.Country;
            ViewBag.b1 = bilet1;
          
            ViewBag.date1 = bilet1.date_from.Value.ToString("dd.MM.yyyy");
            
            return View();
        }

        public ActionResult successful_reservation_one_side()
        {
            Bilet_table bilet1 = db.Bilet_table.Find(Session["bilet1"]);
            

            ViewBag.from = bilet1.Countries_table.Country;
            ViewBag.to = bilet1.Countries_table1.Country;
            ViewBag.b1 = bilet1;
          
            ViewBag.date1 = bilet1.date_from.Value.ToString("dd.MM.yyyy");
          
            return View();
        }

    }

}