using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Models;

namespace GAPv3.Controllers
{
    public class NormsController : Controller
    {
        private GAPv3Context db = new GAPv3Context();

        // GET: Norms
        public ActionResult Index()
        {
            return View(db.Norms.ToList());
        }

        // GET: Norms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Norm norm = db.Norms.Find(id);
            if (norm == null)
            {
                return HttpNotFound();
            }
            return View(norm);
        }

        // GET: Norms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Norms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NormId,Name,Description")] Norm norm)
        {
            if (ModelState.IsValid)
            {
                db.Norms.Add(norm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(norm);
        }

        // GET: Norms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Norm norm = db.Norms.Find(id);
            if (norm == null)
            {
                return HttpNotFound();
            }
            return View(norm);
        }

        // POST: Norms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NormId,Name,Description")] Norm norm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(norm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(norm);
        }

        // GET: Norms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Norm norm = db.Norms.Find(id);
            if (norm == null)
            {
                return HttpNotFound();
            }
            return View(norm);
        }

        // POST: Norms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Norm norm = db.Norms.Find(id);
            db.Norms.Remove(norm);
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
