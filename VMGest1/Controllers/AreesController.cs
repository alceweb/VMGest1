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
    public class AreesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Arees
        public ActionResult Index()
        {
            var areeCount = db.Arees.Count();
            ViewBag.AreeCount = areeCount;
            return View(db.Arees.ToList());
        }

        // GET: Arees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aree aree = db.Arees.Find(id);
            if (aree == null)
            {
                return HttpNotFound();
            }
            return View(aree);
        }

        // GET: Arees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arees/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Area_Id,Descrizione,Anamnesi,Valutazione,Trattamento")] Aree aree)
        {
            if (ModelState.IsValid)
            {
                db.Arees.Add(aree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aree);
        }

        // GET: Arees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aree aree = db.Arees.Find(id);
            if (aree == null)
            {
                return HttpNotFound();
            }
            return View(aree);
        }

        // POST: Arees/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Area_Id,Descrizione,Anamnesi,Valutazione,Trattamento")] Aree aree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aree);
        }

        // GET: Arees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aree aree = db.Arees.Find(id);
            if (aree == null)
            {
                return HttpNotFound();
            }
            return View(aree);
        }

        // POST: Arees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aree aree = db.Arees.Find(id);
            db.Arees.Remove(aree);
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
