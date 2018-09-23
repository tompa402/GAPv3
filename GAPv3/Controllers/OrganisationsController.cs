using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.Service;
using GAPv3.ViewModels;

namespace GAPv3.Controllers
{
    public class OrganisationsController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly OrganisationService _service;

        public OrganisationsController()
        {
            _service = new OrganisationService(_unitOfWork);
        }

        // GET: Organisations
        public ActionResult Index()
        {
            IEnumerable<Organisation> organisation = _service.GetOrganisations();
            return View(organisation);
        }

        // GET: Organisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = _service.GetOrganisationById(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // GET: Organisations/Create
        public ActionResult Create()
        {
            UserOrganisationViewModel model = new UserOrganisationViewModel()
            {
                UsersList = _service.GetUser(),
            };
            return View(model);
        }

        // POST: Organisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserOrganisationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.SaveUserOrganisation(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Organisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = _service.GetOrganisationById(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganisationId,Name,Address,Ownership,Type,EmployeesNumber,Size,GuardService,VideoSurveillance,BuildingPossession,ITService,Location,AssetOne,AssetTwo,AssetThree,Created,Modified")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateUserOrganisation(organisation);
                return RedirectToAction("Index");
            }
            return View(organisation);
        }

        // GET: Organisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = _service.GetOrganisationById(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Organisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organisation organisation = _service.GetOrganisationById(id);
            _service.DeleteOrganisation(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
