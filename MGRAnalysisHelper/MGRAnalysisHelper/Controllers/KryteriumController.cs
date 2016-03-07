using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MGRAnalysisHelper.DAL;
using MGRAnalysisHelper.Models;

namespace MGRAnalysisHelper.Controllers
{
    public class KryteriumController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Kryterium
        public ActionResult Index()
        {
            return View(db.Kryteria.ToList());
        }

        // GET: Kryterium/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kryterium kryterium = db.Kryteria.Find(id);
            if (kryterium == null)
            {
                return HttpNotFound();
            }
            return View(kryterium);
        }

        // GET: Kryterium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kryterium/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Kryterium kryterium)
        {
            if (ModelState.IsValid)
            {
                db.Kryteria.Add(kryterium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kryterium);
        }

        // GET: Kryterium/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kryterium kryterium = db.Kryteria.Find(id);
            if (kryterium == null)
            {
                return HttpNotFound();
            }
            return View(kryterium);
        }

        // POST: Kryterium/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Kryterium kryterium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kryterium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kryterium);
        }

        // GET: Kryterium/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kryterium kryterium = db.Kryteria.Find(id);
            if (kryterium == null)
            {
                return HttpNotFound();
            }
            return View(kryterium);
        }

        // POST: Kryterium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kryterium kryterium = db.Kryteria.Find(id);
            db.Kryteria.Remove(kryterium);
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
