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
    [Authorize]
    public class AzioniDettsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AzioniDetts
        public ActionResult Index()
        {
            var azioniDetts = db.AzioniDetts.Include(a => a.Aree).Include(a => a.Azioni);
            return View(azioniDetts.ToList());
        }

        // GET: AzioniDetts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzioniDett azioniDett = db.AzioniDetts.Find(id);
            if (azioniDett == null)
            {
                return HttpNotFound();
            }
            return View(azioniDett);
        }

        // GET: AzioniDetts/Create
        public ActionResult Create(int id)
        {
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione");
            ViewBag.Azione = id;
            return View();
        }

        // POST: AzioniDetts/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [Bind(Include = "AzioniDett_Id,Area_Id,Descrizione,Azioni_Id")] AzioniDett azioniDett)
        {
            if (ModelState.IsValid)
            {
                azioniDett.Azioni_Id = id;
                db.AzioniDetts.Add(azioniDett);
                db.SaveChanges();
                return RedirectToAction("Index", "Azionis", new { id = id, ut = Request.QueryString["ut"] });
            }

            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", azioniDett.Area_Id);
            return View(azioniDett);
        }

        // GET: AzioniDetts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzioniDett azioniDett = db.AzioniDetts.Find(id);
            if (azioniDett == null)
            {
                return HttpNotFound();
            }
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", azioniDett.Area_Id);
            return View(azioniDett);
        }

        // POST: AzioniDetts/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AzioniDett_Id,Area_Id,Descrizione,Azioni_Id")] AzioniDett azioniDett)
        {
            if (ModelState.IsValid)
            {
                int az = Convert.ToInt32(Request.QueryString["az"]);
                db.Entry(azioniDett).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Azionis", new { id = az, ut = Request.QueryString["ut"] });
            }
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", azioniDett.Area_Id);
            return View(azioniDett);
        }

        // GET: AzioniDetts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AzioniDett azioniDett = db.AzioniDetts.Find(id);
            if (azioniDett == null)
            {
                return HttpNotFound();
            }
            return View(azioniDett);
        }

        // POST: AzioniDetts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int az = Convert.ToInt32(Request.QueryString["az"]);
            AzioniDett azioniDett = db.AzioniDetts.Find(id);
            db.AzioniDetts.Remove(azioniDett);
            db.SaveChanges();
            return RedirectToAction("Index", "Azionis", new { id = az, ut = Request.QueryString["ut"] });
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
