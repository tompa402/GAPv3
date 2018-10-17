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
using GAPv3.Service;

namespace GAPv3.Controllers
{
    public class NormItemsController : Controller
    {
        private readonly GAPv3Context _context;
        private readonly NormItemService _service;

        public NormItemsController()
        {
            _context = new GAPv3Context();
            _service = new NormItemService(_context);
        }

        // GET: NormItems
        public ActionResult Index(int id)
        {
            var normItems = _context.NormItems.Include(n => n.Norm).Include(n => n.Parent).Where(n => n.NormId == id);
            return PartialView("_NormItemList",normItems.ToList());
        }

        /*// GET: NormItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NormItem normItem = db.NormItems.Find(id);
            if (normItem == null)
            {
                return HttpNotFound();
            }
            return View(normItem);
        }

        // GET: NormItems/Create
        public ActionResult Create()
        {
            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name");
            ViewBag.ParentId = new SelectList(db.NormItems, "NormItemId", "Name");
            return View();
        }

        // POST: NormItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NormItemId,Name,IsItem,Order,NormId,ParentId")] NormItem normItem)
        {
            if (ModelState.IsValid)
            {
                db.NormItems.Add(normItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name", normItem.NormId);
            ViewBag.ParentId = new SelectList(db.NormItems, "NormItemId", "Name", normItem.ParentId);
            return View(normItem);
        }

        // GET: NormItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NormItem normItem = db.NormItems.Find(id);
            if (normItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name", normItem.NormId);
            ViewBag.ParentId = new SelectList(db.NormItems, "NormItemId", "Name", normItem.ParentId);
            return View(normItem);
        }

        // POST: NormItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NormItemId,Name,IsItem,Order,NormId,ParentId")] NormItem normItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name", normItem.NormId);
            ViewBag.ParentId = new SelectList(db.NormItems, "NormItemId", "Name", normItem.ParentId);
            return View(normItem);
        }

        // GET: NormItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NormItem normItem = db.NormItems.Find(id);
            if (normItem == null)
            {
                return HttpNotFound();
            }
            return View(normItem);
        }

        // POST: NormItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NormItem normItem = db.NormItems.Find(id);
            db.NormItems.Remove(normItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
