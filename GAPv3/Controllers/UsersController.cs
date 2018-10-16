using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.Service;

namespace GAPv3.Controllers
{
    public class UsersController : Controller
    {
        
        private readonly UserService _service;

        public UsersController()
        {
            _service = new UserService();
        }

        public ActionResult Index()
        {
            return View(_service.GetUsers());
        }

        //upload file method
        [HttpPost]
        public ActionResult CsvInsert(HttpPostedFileBase postedFile)
        {
            List<User> users = new List<User>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {

                        users.Add(new User()
                        {

                            Name = row.Split(',')[0],
                            LastName = row.Split(',')[1]
                        });
                    }
                }
            }

            return View(users);
        }
        //create user

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                _service.SaveUser(user);
                return RedirectToAction("Index", "Users");
            }

            return View(user);
        }
        public ActionResult Delete(int? id)
        {
            return RedirectToAction("Index", "Users");
        }

        public ActionResult Details(int? id)
        {
            User user = _service.DetailsUser(id);
            return View(user);
        }

        public ActionResult Update(int id)
        {
            User user = _service.Update(id);
            return View("Update", user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(User user)
        {
            _service.UpdateUser(user);
            return RedirectToAction("Index");

        }
        public User GetUserById(int? id)
        {
            return null;
        }

        public ActionResult Deactivate(int id)
        {
            _service.DeactivateUser(id);
            return RedirectToAction("Index");
        }


    }
}