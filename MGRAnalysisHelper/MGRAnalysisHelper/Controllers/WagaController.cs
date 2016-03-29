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
    public class WagaController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Waga
        public ActionResult Index()
        {
            var wagi = db.Wagi.Include(w => w.Analiza).Include(w => w.Kryterium);
            return View(wagi.ToList());
        }

        public ActionResult Konfiguracja()
        {
            var wagi = db.Wagi.Include(w => w.Analiza).Include(w => w.Kryterium);
            return View(wagi.ToList());
        }

        // GET: Waga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waga waga = db.Wagi.Find(id);
            if (waga == null)
            {
                return HttpNotFound();
            }
            return View(waga);
        }

        // GET: Waga/Create
        public ActionResult Create()
        {
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa");
            ViewBag.KryteriumId = new SelectList(db.Kryteria, "Id", "Nazwa");
            return View();
        }

        // POST: Waga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wartosc,AnalizaId,KryteriumId")] Waga waga)
        {
            if (ModelState.IsValid)
            {
                db.Wagi.Add(waga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", waga.AnalizaId);
            ViewBag.KryteriumId = new SelectList(db.Kryteria, "Id", "Nazwa", waga.KryteriumId);
            return View(waga);
        }

        // GET: Waga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waga waga = db.Wagi.Find(id);
            if (waga == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", waga.AnalizaId);
            ViewBag.KryteriumId = new SelectList(db.Kryteria, "Id", "Nazwa", waga.KryteriumId);
            return View(waga);
        }

        // POST: Waga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wartosc,AnalizaId,KryteriumId")] Waga waga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", waga.AnalizaId);
            ViewBag.KryteriumId = new SelectList(db.Kryteria, "Id", "Nazwa", waga.KryteriumId);
            return View(waga);
        }

        // GET: Waga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waga waga = db.Wagi.Find(id);
            if (waga == null)
            {
                return HttpNotFound();
            }
            return View(waga);
        }

        // POST: Waga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Waga waga = db.Wagi.Find(id);
            db.Wagi.Remove(waga);
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
