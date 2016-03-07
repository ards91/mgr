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
    public class AnalizaController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Analiza
        public ActionResult Index()
        {
            return View(db.Analizy.ToList());
        }

        // GET: Analiza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analiza analiza = db.Analizy.Find(id);
            if (analiza == null)
            {
                return HttpNotFound();
            }
            return View(analiza);
        }

        // GET: Analiza/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Analiza/Analiza
        public ActionResult Analiza()
        {
            return View();
        }

        // POST: Analiza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,DataAnalizy")] Analiza analiza)
        {
            if (ModelState.IsValid)
            {
                db.Analizy.Add(analiza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(analiza);
        }

        // GET: Analiza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analiza analiza = db.Analizy.Find(id);
            ViewBag.Kryteria = db.Kryteria.ToList();
            if (analiza == null)
            {
                return HttpNotFound();
            }
            return View(analiza);
        }

        // POST: Analiza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,DataAnalizy")] Analiza analiza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analiza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(analiza);
        }

        // GET: Analiza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analiza analiza = db.Analizy.Find(id);
            if (analiza == null)
            {
                return HttpNotFound();
            }
            return View(analiza);
        }

        // POST: Analiza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Analiza analiza = db.Analizy.Find(id);
            db.Analizy.Remove(analiza);
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
