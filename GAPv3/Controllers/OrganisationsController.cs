using System.Collections.Generic;

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
        private GAPv3Context _context;
        private readonly OrganisationService _service;

        public OrganisationsController()
        {
            _context = new GAPv3Context();
            _service = new OrganisationService(_context);
        }

        // GET: Organisations
        public ActionResult Index()
        {
            return View(_service.GetOrganisations());
        }

        // GET: Organisations/Details/5
        public ActionResult Details(int id)
        {
            var organisation = _service.GetOrganisationById(id);

            if (organisation == null)
                return HttpNotFound();

            return View(organisation);
        }

        // GET: Organisations/New
        public ActionResult New()
        {
            var model = _service.CreateViewModel();
            return View("OrganisationForm", model);
        }

        // POST: Organisations/New
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserOrganisationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _service.CreateViewModel();
                viewModel.Organisation = model.Organisation;
                return View("OrganisationForm", viewModel);
            }

            if (model.Organisation.OrganisationId == 0)
                _service.SaveUserOrganisation(model);
            else
                _service.UpdateUserOrganisation(model);
            
            return RedirectToAction("Index", "Organisations");
        }

        // GET: Organisations/Edit/5
        public ActionResult Edit(int id)
        {
            var organisation = _service.GetOrganisationById(id);

            if (organisation == null)
                return HttpNotFound();

            var model = _service.EditViewModel(organisation);

            return View("OrganisationForm", model);
        }

        // GET: Organisations/Activation
        public ActionResult Activation()
        {
            return View(_service.GetOrganisations());
        }

        // POST: Organisations/Activation
        public ActionResult ChangeIsActive(int orgId)
        {
            if (orgId == 0)
            {
                _service.DeactivateAllOrganisations();
                return View("Activation", _service.GetOrganisations());
            }
            _service.DeactivateSingleOrganisation(orgId);
            return Json(new { success = true });
        }

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
