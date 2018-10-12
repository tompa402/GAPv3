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

        // GET: Reports/New
        public ActionResult New(int id)
        {
            var norm = _context.Norms.SingleOrDefault(n => n.NormId == id);
            if (norm == null)
                return HttpNotFound();

            var report = _service.CreateReportViewModel(id);

            return View("ReportsForm", report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int id)
        {
            var report = _service.GetById(id);
            if (report == null)
                return HttpNotFound();

            return View("ReportsForm", _service.EditViewModel(report));
        }

        // POST: Reports/Save
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Report report)
        {
            _service.InsertOrUpdate(report);
            return RedirectToAction("Index", "Reports", new {id = report.NormId});
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            var report = _service.GetById(id);
            if (report == null)
                return HttpNotFound();
            
            return View(_service.DetailsViewModel(report));
        }

        // GET: Reports/Statistic/5
        public ActionResult Statistic(int id)
        {
            var report = _service.GetById(id);
            if (report == null)
                return HttpNotFound();

            return View(_service.GetStatisticForReport(report));
        }

        // TODO: implement activation/deactivation module
        // TODO: implement chart statistic

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
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
        }*/
    }
}
