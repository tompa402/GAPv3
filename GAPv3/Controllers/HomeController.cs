using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAPv3.DAL;

namespace GAPv3.Controllers
{
    public class HomeController : Controller
    {
        private GAPv3Context db = new GAPv3Context();

        public ActionResult Index()
        {
            var norms = db.Norms.ToList();
            return View(norms);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}