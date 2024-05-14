using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WDsite.Models;

namespace WDsite.Controllers
{
    public class persons_tableController : Controller
    {
        private AirWEntities db = new AirWEntities();

        // GET: persons_table
        public ActionResult Index()
        {
            return View(db.persons_table.ToList());
        }

        // GET: persons_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persons_table persons_table = db.persons_table.Find(id);
            if (persons_table == null)
            {
                return HttpNotFound();
            }
            return View(persons_table);
        }

        // GET: persons_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: persons_table/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,gender,phone_namber,email,password")] persons_table persons_table)
        {
            if (ModelState.IsValid)
            {
                db.persons_table.Add(persons_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persons_table);
        }

        // GET: persons_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persons_table persons_table = db.persons_table.Find(id);
            if (persons_table == null)
            {
                return HttpNotFound();
            }
            return View(persons_table);
        }

        // POST: persons_table/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,gender,phone_namber,email,password")] persons_table persons_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persons_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persons_table);
        }

        // GET: persons_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persons_table persons_table = db.persons_table.Find(id);
            if (persons_table == null)
            {
                return HttpNotFound();
            }
            return View(persons_table);
        }

        // POST: persons_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            persons_table persons_table = db.persons_table.Find(id);
            db.persons_table.Remove(persons_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
