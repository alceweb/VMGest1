using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VMGest1.Models;

namespace VMGest1.Controllers
{
    public class AzDettsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AzDetts
        public ActionResult Index()
        {
            var azDetts = db.AzDetts.Include(a => a.Aree).Include(a => a.Azioni);
            return View(azDetts.ToList());
        }

        // GET: AzDetts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzDett azDett = db.AzDetts.Find(id);
            if (azDett == null)
            {
                return HttpNotFound();
            }
            return View(azDett);
        }

        // GET: AzDetts/Create
        public ActionResult Create()
        {
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione");
            ViewBag.Azioni_Id = new SelectList(db.Azionis, "Azioni_Id", "Tipo");
            return View();
        }

        // POST: AzDetts/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AzioniDett_Id,Area_Id,Descrizione,Azioni_Id")] AzDett azDett)
        {
            if (ModelState.IsValid)
            {
                db.AzDetts.Add(azDett);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", azDett.Area_Id);
            ViewBag.Azioni_Id = new SelectList(db.Azionis, "Azioni_Id", "Tipo", azDett.Azioni_Id);
            return View(azDett);
        }

        // GET: AzDetts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzDett azDett = db.AzDetts.Find(id);
            if (azDett == null)
            {
                return HttpNotFound();
            }
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", azDett.Area_Id);
            ViewBag.Azioni_Id = new SelectList(db.Azionis, "Azioni_Id", "Tipo", azDett.Azioni_Id);
            return View(azDett);
        }

        // POST: AzDetts/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AzioniDett_Id,Area_Id,Descrizione,Azioni_Id")] AzDett azDett)
        {
            if (ModelState.IsValid)
            {
                db.Entry(azDett).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", azDett.Area_Id);
            ViewBag.Azioni_Id = new SelectList(db.Azionis, "Azioni_Id", "Tipo", azDett.Azioni_Id);
            return View(azDett);
        }

        // GET: AzDetts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzDett azDett = db.AzDetts.Find(id);
            if (azDett == null)
            {
                return HttpNotFound();
            }
            return View(azDett);
        }

        // POST: AzDetts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AzDett azDett = db.AzDetts.Find(id);
            db.AzDetts.Remove(azDett);
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
