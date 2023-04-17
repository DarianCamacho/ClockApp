using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClockApp.Models;

namespace ClockApp.Controllers
{
    public class AlarmsController : Controller
    {
        private ClockEntities db = new ClockEntities();

        // GET: Alarms
        public ActionResult Index()
        {
            return View(db.Alarms.ToList());
        }

        // GET: Alarms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarms alarms = db.Alarms.Find(id);
            if (alarms == null)
            {
                return HttpNotFound();
            }
            return View(alarms);
        }

        // GET: Alarms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alarms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlarmId,AlarmName,Hour,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday")] Alarms alarms)
        {
            if (ModelState.IsValid)
            {
                db.Alarms.Add(alarms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alarms);
        }

        // GET: Alarms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarms alarms = db.Alarms.Find(id);
            if (alarms == null)
            {
                return HttpNotFound();
            }
            return View(alarms);
        }

        // POST: Alarms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlarmId,AlarmName,Hour,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday")] Alarms alarms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alarms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alarms);
        }

        // GET: Alarms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarms alarms = db.Alarms.Find(id);
            if (alarms == null)
            {
                return HttpNotFound();
            }
            return View(alarms);
        }

        // POST: Alarms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alarms alarms = db.Alarms.Find(id);
            db.Alarms.Remove(alarms);
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
