using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.Service;
using GAPv3.ViewModels;

namespace GAPv3.Controllers
{
    public class HomeMessagesController : Controller
    {
        private GAPv3Context _context;
        private readonly HomeMessageService _service;

        public HomeMessagesController()
        {
            _context = new GAPv3Context();
            _service = new HomeMessageService(_context);
        }

        // GET: HomeMessages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JumbotronMessages()
        {
            return PartialView("_JumbotronMessages", _service.GetActiveMessages());
        }

        // GET: HomeMessages/Administration
        public ActionResult Administration()
        {
            return View(_service.GetMessages());
        }

        public ActionResult New()
        {
            return PartialView("_FormHomeMessage", new HomeMessage()); ;
        }

        // GET: HomeMessages/Edit/5
        public ActionResult Edit(int id)
        {
            var homeMessage = _service.GetById(id);
            if (homeMessage == null)
                return HttpNotFound();

            return PartialView("_FormHomeMessage", homeMessage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(HomeMessage model)
        {
            if (model.HomeMessageId == 0)
                _service.AddMessage(model);
            else
           {
                _service.UpdateMessage(model);
            }
            return RedirectToAction("Administration", "HomeMessages");
        }

        // POST: HomeMessages/Activation
        public ActionResult ChangeIsActive(int msgId)
        {
            _service.DeactivateSingleHomeMessage(msgId);
            return Json(new { changeActiveIcon = true });
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