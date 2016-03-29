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
    public class Ocena_KryteriumController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Ocena_Kryterium
        public ActionResult Index()
        {
            var ocenyKryterium = db.OcenyKryterium.Include(o => o.kryterium).Include(o => o.porownania).Include(o => o.portal);
            return View(ocenyKryterium.ToList());
        }

        public ActionResult Ocena(int? id,int? id1)
        {
            ViewBag.System1 = db.Portale.Where(e => e.ID == id).SingleOrDefault();
            ViewBag.System2 = db.Portale.Where(e => e.ID == id1).SingleOrDefault();
            var ocenyKryterium = db.OcenyKryterium.Include(o => o.kryterium).Include(o => o.porownania).Include(o => o.portal);
            return View(ocenyKryterium.ToList());
        }

        // GET: Ocena_Kryterium/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena_Kryterium ocena_Kryterium = db.OcenyKryterium.Find(id);
            if (ocena_Kryterium == null)
            {
                return HttpNotFound();
            }
            return View(ocena_Kryterium);
        }

        // GET: Ocena_Kryterium/Create
        public ActionResult Create()
        {
            ViewBag.KryteriumID = new SelectList(db.Kryteria, "Id", "Nazwa");
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa");
            ViewBag.PortalId = new SelectList(db.Portale, "ID", "Nazwa");
            return View();
        }

        // POST: Ocena_Kryterium/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wartosc,Opis,KryteriumID,PortalId,AnalizaId")] Ocena_Kryterium ocena_Kryterium)
        {
            if (ModelState.IsValid)
            {
                db.OcenyKryterium.Add(ocena_Kryterium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KryteriumID = new SelectList(db.Kryteria, "Id", "Nazwa", ocena_Kryterium.KryteriumID);
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", ocena_Kryterium.AnalizaId);
            ViewBag.PortalId = new SelectList(db.Portale, "ID", "Nazwa", ocena_Kryterium.PortalId);
            return View(ocena_Kryterium);
        }

        // GET: Ocena_Kryterium/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena_Kryterium ocena_Kryterium = db.OcenyKryterium.Find(id);
            if (ocena_Kryterium == null)
            {
                return HttpNotFound();
            }
            ViewBag.KryteriumID = new SelectList(db.Kryteria, "Id", "Nazwa", ocena_Kryterium.KryteriumID);
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", ocena_Kryterium.AnalizaId);
            ViewBag.PortalId = new SelectList(db.Portale, "ID", "Nazwa", ocena_Kryterium.PortalId);
            return View(ocena_Kryterium);
        }

        // POST: Ocena_Kryterium/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wartosc,Opis,KryteriumID,PortalId,AnalizaId")] Ocena_Kryterium ocena_Kryterium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocena_Kryterium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KryteriumID = new SelectList(db.Kryteria, "Id", "Nazwa", ocena_Kryterium.KryteriumID);
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", ocena_Kryterium.AnalizaId);
            ViewBag.PortalId = new SelectList(db.Portale, "ID", "Nazwa", ocena_Kryterium.PortalId);
            return View(ocena_Kryterium);
        }


        public ActionResult WystawOcene(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena_Kryterium ocena_Kryterium = db.OcenyKryterium.Find(id);
            if (ocena_Kryterium == null)
            {
                return HttpNotFound();
            }
            ViewBag.KryteriumID = new SelectList(db.Kryteria, "Id", "Nazwa", ocena_Kryterium.KryteriumID);
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", ocena_Kryterium.AnalizaId);
            ViewBag.PortalId = new SelectList(db.Portale, "ID", "Nazwa", ocena_Kryterium.PortalId);
            return View(ocena_Kryterium);
        }

        // POST: Ocena_Kryterium/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WystawOcene([Bind(Include = "Id,Wartosc,Opis,KryteriumID,PortalId,AnalizaId")] Ocena_Kryterium ocena_Kryterium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocena_Kryterium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Ocena", new {id = 1, id1 = 2});
            }
            ViewBag.KryteriumID = new SelectList(db.Kryteria, "Id", "Nazwa", ocena_Kryterium.KryteriumID);
            ViewBag.AnalizaId = new SelectList(db.Analizy, "Id", "Nazwa", ocena_Kryterium.AnalizaId);
            ViewBag.PortalId = new SelectList(db.Portale, "ID", "Nazwa", ocena_Kryterium.PortalId);
            return View(ocena_Kryterium);
        }

        // GET: Ocena_Kryterium/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocena_Kryterium ocena_Kryterium = db.OcenyKryterium.Find(id);
            if (ocena_Kryterium == null)
            {
                return HttpNotFound();
            }
            return View(ocena_Kryterium);
        }

        // POST: Ocena_Kryterium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ocena_Kryterium ocena_Kryterium = db.OcenyKryterium.Find(id);
            db.OcenyKryterium.Remove(ocena_Kryterium);
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
