using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using GAPv3.DAL;
using GAPv3.Handlers;
using GAPv3.Helpers;
using GAPv3.Models;
using GAPv3.Service;

namespace GAPv3.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _service = new UserService();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User userInput, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                bool isValidUser =
                    Membership.ValidateUser(userInput.Email, PasswordHandler.EncryptPassword(userInput.Password));

                if (isValidUser)
                {
                    if (CredentialsManager.IsIdentical(userInput.Email, userInput.Password))
                    {
                        return RedirectToAction("ChangePassword");
                    }

                    User user = null;
                    using (GAPv3Context dc = new GAPv3Context())
                    {
                        user = dc.Users.Where(a => a.Email.Equals(userInput.Email)).FirstOrDefault();
                    }

                    if (user != null)
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string data = js.Serialize(user);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now,
                            DateTime.Now.AddMinutes(30), true, data);
                        string encToken = FormsAuthentication.Encrypt(ticket);
                        HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
                        Response.Cookies.Add(authoCookies);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }


            ModelState.Remove("Password");
            return View();

        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(User userInput)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (GAPv3Context _context = new GAPv3Context())
                {
                    user = _context.Users.Where(a => a.Email.Equals(userInput.Email)).FirstOrDefault();
                }

                if (user != null)
                {
                    if (!CredentialsManager.IsIdentical(userInput.Email, userInput.Password))
                    {
                        _service.UpdatePass(userInput);
                        return RedirectToAction("Login");

                    }

                    return RedirectToAction("ChangePassword");
                }
            }
            ModelState.Remove("Password");
            return View();
        }

    }
}