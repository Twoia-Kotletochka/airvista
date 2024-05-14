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
    public class Bilet_tableController : Controller
    {
        private AirWEntities db = new AirWEntities();

        // GET: Bilet_table
        public ActionResult Index()
        {
            var bilet_table = db.Bilet_table.Include(b => b.Countries_table).Include(b => b.Countries_table1);
            return View(bilet_table.ToList());
        }

        // GET: Bilet_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet_table bilet_table = db.Bilet_table.Find(id);
            if (bilet_table == null)
            {
                return HttpNotFound();
            }
            return View(bilet_table);
        }

        // GET: Bilet_table/Create
        public ActionResult Create()
        {
            ViewBag.form_id = new SelectList(db.Countries_table, "id", "Country");
            ViewBag.to_id = new SelectList(db.Countries_table, "id", "Country");
            return View();
        }

        // POST: Bilet_table/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,form_id,to_id,date_from,price,type,date_to")] Bilet_table bilet_table)
        {
            if (ModelState.IsValid)
            {
                db.Bilet_table.Add(bilet_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.form_id = new SelectList(db.Countries_table, "id", "Country", bilet_table.form_id);
            ViewBag.to_id = new SelectList(db.Countries_table, "id", "Country", bilet_table.to_id);
            return View(bilet_table);
        }

        // GET: Bilet_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet_table bilet_table = db.Bilet_table.Find(id);
            if (bilet_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.form_id = new SelectList(db.Countries_table, "id", "Country", bilet_table.form_id);
            ViewBag.to_id = new SelectList(db.Countries_table, "id", "Country", bilet_table.to_id);
            return View(bilet_table);
        }

        // POST: Bilet_table/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,form_id,to_id,date_from,price,type,date_to")] Bilet_table bilet_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilet_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.form_id = new SelectList(db.Countries_table, "id", "Country", bilet_table.form_id);
            ViewBag.to_id = new SelectList(db.Countries_table, "id", "Country", bilet_table.to_id);
            return View(bilet_table);
        }

        // GET: Bilet_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet_table bilet_table = db.Bilet_table.Find(id);
            if (bilet_table == null)
            {
                return HttpNotFound();
            }
            return View(bilet_table);
        }

        // POST: Bilet_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilet_table bilet_table = db.Bilet_table.Find(id);
            db.Bilet_table.Remove(bilet_table);
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
