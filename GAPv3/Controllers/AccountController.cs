using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using GAPv3.DAL;
using GAPv3.Models;

namespace GAPv3.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User UserInput, string ReturnUrl = "")
        {
            //using (GAPv2Context dc = new GAPv2Context())
            //{
            //    var user = dc.User.Where(a => a.Email.Equals(UserInput.Email) && 
            //                                  a.Password.Equals(UserInput.Password)).FirstOrDefault();
            //    if (user != null)
            //    {
            //        FormsAuthentication.SetAuthCookie(user.Email, true);
            //        if (Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //}
            //ModelState.Remove("Password");
            //return View();
            //if (ModelState.IsValid)
            //{
            //    var isValidUser = Membership.ValidateUser(UserInput.Email, UserInput.Password);
            //    if (isValidUser)
            //    {
            //        FormsAuthentication.SetAuthCookie(UserInput.Email,true);
            //        if (Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //}


            if (ModelState.IsValid)
            {
                bool isValidUser = Membership.ValidateUser(UserInput.Email, UserInput.Password);
                if (isValidUser)
                {
                    User user = null;
                    using (GAPv3Context dc = new GAPv3Context())
                    {
                        user = dc.Users.Where(a => a.Email.Equals(UserInput.Email)).FirstOrDefault();
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

    }
}