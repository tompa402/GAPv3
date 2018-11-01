using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Service;
using GAPv3.ViewModels;

namespace GAPv3.Controllers
{
    public class NormsController : Controller
    {
        private readonly GAPv3Context _context;
        private readonly NormService _service;

        public NormsController()
        {
            _context = new GAPv3Context();
            _service = new NormService(_context);
        }

        // GET: Norms
        public ActionResult Index()
        {
            return View(_service.GetNormList());
        }

        public ActionResult NavItems()
        {
            return PartialView("_NavbarNorms", _service.GetNormsForNavbar());
        }

        // GET: Norms/CreatePartial
        public ActionResult CreatePartial()
        {
            var model = _service.CreateViewModel();
            return PartialView("_FormNorm", model);
        }

        // POST: Norms/Save
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NormViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_FormNorm", model);

            if (model.NormId == 0)
                _service.SaveNorm(model);
            else
                _service.UpdateNorm(model);
            
            return Json(new { success = true });
        }

        // GET: Norms/Edit/5
        public ActionResult Edit(int id)
        {
            var norm = _service.GetNormById(id);

            if (norm == null)
                return HttpNotFound();

            var model = _service.EditViewModel(norm);

            return PartialView("_FormNorm", model);
        }

        // GET: Norms/Details/5
        public ActionResult Details(int id)
        {
            var norm = _service.GetNormById(id);
            if (norm == null)
                return HttpNotFound();
            return PartialView("_Details", norm);
        }

        // TODO: implement activation/deactivation module

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
