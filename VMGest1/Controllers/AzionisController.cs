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
    public class AzionisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Azionis
        public ActionResult Index()
        {
            int ut = Convert.ToInt32(Request.QueryString["ut"]);
            var azionis = db.Azionis.Where(u=>u.Anagrafica_Id == ut).Include(a => a.Anagrafica).OrderByDescending(a=>a.Data);
            var utente = db.Anagraficas.Where(u => u.Anagrafica_Id == ut);
            ViewBag.Utente = utente;
            ViewBag.AzionisCount = azionis.Count();
            return View(azionis.ToList());
        }

        // GET: Azionis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azioni azioni = db.Azionis.Find(id);
            if (azioni == null)
            {
                return HttpNotFound();
            }
            return View(azioni);
        }

        // GET: Azionis/Create
        public ActionResult Create(int id)
        {
            var utente = db.Anagraficas.Where(u => u.Anagrafica_Id == id);
            ViewBag.Utente = utente;
            var area = db.Arees;
            ViewBag.Area_Id = new SelectList(area, "Area_Id", "Descrizione");
            return View();
        }

        // POST: Azionis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(int id, [Bind(Include = "Azioni_Id,Tipo,Anagrafica_Id,Data,Descrizione")] Azioni azioni, Aree aree)
        {
            if (ModelState.IsValid)
            {
                azioni.Anagrafica_Id = id;
                azioni.Tipo = Request.QueryString["tipo"];
                db.Azionis.Add(azioni);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = id, ut = id });
            }

            ViewBag.Anagrafica_Id = new SelectList(db.Anagraficas, "Anagrafica_Id", "Nome", azioni.Anagrafica_Id);
            ViewBag.Area_Id = new SelectList(db.Arees, "Area_Id", "Descrizione", aree.Area_Id);
            return View(azioni);
        }

        // GET: Azionis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azioni azioni = db.Azionis.Find(id);
            if (azioni == null)
            {
                return HttpNotFound();
            }
            ViewBag.Anagrafica_Id = new SelectList(db.Anagraficas, "Anagrafica_Id", "Nome", azioni.Anagrafica_Id);
            return View(azioni);
        }

        // POST: Azionis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id,[Bind(Include = "Azioni_Id,Tipo,Anagrafica_Id,Data,Descrizione")] Azioni azioni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(azioni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = id, ut = Request.QueryString["ut"] });
            }
            return View(azioni);
        }

        // GET: Azionis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azioni azioni = db.Azionis.Find(id);
            if (azioni == null)
            {
                return HttpNotFound();
            }
            return View(azioni);
        }

        // POST: Azionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Azioni azioni = db.Azionis.Find(id);
            db.Azionis.Remove(azioni);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id, ut = Request.QueryString["ut"] });
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
