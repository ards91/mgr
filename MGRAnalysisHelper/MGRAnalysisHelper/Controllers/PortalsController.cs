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
    public class PortalsController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Portals
        public ActionResult Index()
        {
            return View(db.Portale.ToList());
        }

        // GET: Portals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portal portal = db.Portale.Find(id);
            if (portal == null)
            {
                return HttpNotFound();
            }
            return View(portal);
        }

        // GET: Portals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Opis")] Portal portal)
        {
            if (ModelState.IsValid)
            {
                db.Portale.Add(portal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portal);
        }

        // GET: Portals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portal portal = db.Portale.Find(id);
            if (portal == null)
            {
                return HttpNotFound();
            }
            return View(portal);
        }

        // POST: Portals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Opis")] Portal portal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portal);
        }

        // GET: Portals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portal portal = db.Portale.Find(id);
            if (portal == null)
            {
                return HttpNotFound();
            }
            return View(portal);
        }

        // POST: Portals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portal portal = db.Portale.Find(id);
            db.Portale.Remove(portal);
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
