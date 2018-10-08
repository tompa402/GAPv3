using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Helpers;
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
        private GAPv3Context _context;
        private readonly ReportService _service;

        public ReportsController()
        {
            _context = new GAPv3Context();
            _service = new ReportService(_context);
        }

        // GET: Reports
        public ActionResult Index(int? id)
        {
            var models = _service.GetReportsForNorm(id);
            if (!models.Any())
                return HttpNotFound();

            return View(models);
        }

        /*// GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Report report = _unitOfWork.ReportRepository.GetById(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            report.ReportValues = report.ReportValues.Where(x => x.NormItem.ParentId == null).ToList();
            return View(report);
        }

        // GET: Reports/Statistic/5
        public ActionResult Statistic(int? id)
        {
            Report report = _unitOfWork.ReportRepository.GetById(id);
            var reportViewModel = _service.GetStatisticForReport(report);

            return View(reportViewModel);
        }

        // GET: Reports/New
        public ActionResult Create(int? id)
        {
            var rv = _unitOfWork.NormItemRepository.Get(filter: x => x.NormId == id && x.ParentId == null, orderBy: x => x.OrderBy(y => y.Order)).ToList();

            Report report = new Report()
            {
                NormId = id.GetValueOrDefault(),
                ReportValues = _service.CreateInitialReportValuesList(rv)
            };
            ViewBag.ControlId = new SelectList(_unitOfWork.ControlRepository.Get(), "ControlId", "Name");
            ViewBag.ReasonId = new SelectList(_unitOfWork.ReasonRepository.Get(), "ReasonId", "Name");
            ViewBag.StatusId = new SelectList(_unitOfWork.StatusRepository.Get(), "StatusId", "Name");
            ViewBag.OrganisationId = new SelectList(_unitOfWork.OrganisationRepository.Get(), "OrganisationId", "Name");
            return View(report);
        }

        // POST: Reports/New
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ReportRepository.Insert(report);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = report.NormId });
            }

            var rv = _unitOfWork.NormItemRepository.Get(filter: x => x.NormId == report.NormId && x.ParentId == null, orderBy: x => x.OrderBy(y => y.Order)).ToList();
            report.ReportValues = _service.CreateInitialReportValuesList(rv);
            ViewBag.ControlId = new SelectList(_unitOfWork.ControlRepository.Get(), "ControlId", "Name");
            ViewBag.ReasonId = new SelectList(_unitOfWork.ReasonRepository.Get(), "ReasonId", "Name");
            ViewBag.StatusId = new SelectList(_unitOfWork.StatusRepository.Get(), "StatusId", "Name");
            ViewBag.OrganisationId = new SelectList(_unitOfWork.OrganisationRepository.Get(), "OrganisationId", "Name");
            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = _unitOfWork.ReportRepository.GetById(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            report.ReportValues = report.ReportValues.Where(x => x.NormItem.ParentId == null).ToList();

            ViewBag.StatusId = _unitOfWork.StatusRepository.Get();
            ViewBag.OrganisationId = new SelectList(_unitOfWork.OrganisationRepository.Get(), "OrganisationId", "Name");
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ReportRepository.Update(report);
                _service.UpdateReportValues(report.ReportValues);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = report.NormId });
            }

            var rv = _unitOfWork.NormItemRepository.Get(filter: x => x.NormId == report.NormId && x.ParentId == null, orderBy: x => x.OrderBy(y => y.Order)).ToList();
            report.ReportValues = _service.CreateInitialReportValuesList(rv);
            ViewBag.StatusId = _unitOfWork.StatusRepository.Get();
            ViewBag.OrganisationId = new SelectList(_unitOfWork.OrganisationRepository.Get(), "OrganisationId", "Name");
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = _unitOfWork.ReportRepository.GetById(id);
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
            Report report = _unitOfWork.ReportRepository.GetById(id);
            _unitOfWork.ReportRepository.Delete(report);
            _unitOfWork.Save();
            return RedirectToAction("Index", new { id = report.NormId });
        }
        
            public ActionResult GetRainfallChart()
        {
            var key = new Chart(width: 600, height: 400)
                .AddSeries(
                    chartType: "pie",
                    legend: "Rainfall",
                    xValue: new[] { "Jan", "Feb", "Mar", "Apr", "May" },
                    yValues: new[] { "20", "20", "40", "10", "10" })
                .Write();

            return null;
        } 
        */

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
