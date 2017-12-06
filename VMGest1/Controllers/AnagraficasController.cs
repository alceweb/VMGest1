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
    public class AnagraficasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Anagraficas
        public ActionResult Index()
        {
            var anagraficaCount = db.Anagraficas.Count();
            ViewBag.AnagraficaCount = anagraficaCount;
            return View(db.Anagraficas.OrderBy(c=>c.Cognome).ToList());
        }

        //POST: anagraficas/Index
        [HttpPost]
        [ValidateAntiForgeryToken]


        // GET: Anagraficas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica);
        }

        // GET: Anagraficas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anagraficas/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Anagrafica_Id,Nome,Cognome,Indirizzo,CAP,Città,Telefono,Cellulare,Email,DataNascita,LuogoNascita,CodiceFiscale")] Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                db.Anagraficas.Add(anagrafica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anagrafica);
        }

        // GET: Anagraficas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica);
        }

        // POST: Anagraficas/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Anagrafica_Id,Nome,Cognome,Indirizzo,CAP,Città,Telefono,Cellulare,Email,DataNascita,LuogoNascita,CodiceFiscale")] Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anagrafica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }

        // GET: Anagraficas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            var azioniCount = db.Azionis.Where(u => u.Anagrafica_Id == id).Count();
            ViewBag.AzioniCount = azioniCount;
            if (anagrafica == null)
            {
                return HttpNotFound();
            }
            return View(anagrafica);
        }

        // POST: Anagraficas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anagrafica anagrafica = db.Anagraficas.Find(id);
            db.Anagraficas.Remove(anagrafica);
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
