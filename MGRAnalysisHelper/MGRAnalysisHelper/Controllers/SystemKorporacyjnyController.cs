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
    public class SystemKorporacyjnyController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: SystemKorporacyjny
        public ActionResult Index()
        {
            return View(db.Systemy.ToList());
        }

        // GET: SystemKorporacyjny/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemKorporacyjny systemKorporacyjny = db.Systemy.Find(id);
            if (systemKorporacyjny == null)
            {
                return HttpNotFound();
            }
            return View(systemKorporacyjny);
        }

        // GET: SystemKorporacyjny/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemKorporacyjny/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Opis,Ocena")] SystemKorporacyjny systemKorporacyjny)
        {
            if (ModelState.IsValid)
            {
                db.Systemy.Add(systemKorporacyjny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemKorporacyjny);
        }

        // GET: SystemKorporacyjny/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemKorporacyjny systemKorporacyjny = db.Systemy.Find(id);
            if (systemKorporacyjny == null)
            {
                return HttpNotFound();
            }
            return View(systemKorporacyjny);
        }

        // POST: SystemKorporacyjny/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Opis,Ocena")] SystemKorporacyjny systemKorporacyjny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemKorporacyjny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemKorporacyjny);
        }

        // GET: SystemKorporacyjny/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemKorporacyjny systemKorporacyjny = db.Systemy.Find(id);
            if (systemKorporacyjny == null)
            {
                return HttpNotFound();
            }
            return View(systemKorporacyjny);
        }

        // POST: SystemKorporacyjny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SystemKorporacyjny systemKorporacyjny = db.Systemy.Find(id);
            db.Systemy.Remove(systemKorporacyjny);
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
