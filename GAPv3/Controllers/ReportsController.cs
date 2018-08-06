using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.Service;
using GAPv3.ViewModels;

namespace GAPv3.Controllers
{
    public class ReportsController : Controller
    {
        private GAPv3Context db = new GAPv3Context(); // TODO: remove after all action methods are refactored
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Reports
        public ActionResult Index(int? id)
        {
            var reports = unitOfWork.ReportRepository.Get(filter: x => x.NormId == id, includeProperties: "Norm, Organisation");

            List<ReportViewModel> reportsViewModel = new List<ReportViewModel>();

            foreach (Report report in reports)
            {
                var reportViewModel = Mapper.Map<Report, ReportViewModel>(report);
                // TODO: getPopunjenost from service after initial data is inserted
                reportsViewModel.Add(reportViewModel);
            }

            return View(reportsViewModel);
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create(int? id)
        {
            List<NormItem> rv = db.NormItems.Where(item => item.NormId == id).ToList();

            return View(rv);
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportId,Name,NormId,OrganisationId")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name", report.NormId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "Name", report.OrganisationId);
            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name", report.NormId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "Name", report.OrganisationId);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,Name,NormId,OrganisationId")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NormId = new SelectList(db.Norms, "NormId", "Name", report.NormId);
            ViewBag.OrganisationId = new SelectList(db.Organisations, "OrganisationId", "Name", report.OrganisationId);
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
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
