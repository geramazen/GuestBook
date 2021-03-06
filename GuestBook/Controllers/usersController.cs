using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class usersController : Controller
    {
        private GuestBookEntities db = new GuestBookEntities();

        [HttpGet]
        [ActionName("Registar")]
        public ActionResult Registar_Get()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Registar")]
        public ActionResult Registar_Post([Bind(Include = "email,UserName,password")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                Session["UserName"]=user.UserName;
                return RedirectToAction("index","Messages");
            }
            return View(user);
        }

        [HttpGet, ActionName("Login")]
        public ActionResult Login_get()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult Login_post([Bind(Include = "email,password")] user user)
        {
            var rec = db.users.Where(x => x.email == user.email && x.password == user.password).ToList().FirstOrDefault();
            if (rec != null)
            {
                Session["UserName"] = rec.UserName; //This session will be used to know if the user is logged in or not
                Session["User ID"] = rec.UID; //This session Will be used to allow the user edit and delete only the messages that carry his ID.
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "invalid user";
                return View(user);

            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["User ID"] = null;
            return RedirectToAction("Login");
        }
       
        public ActionResult Index()
        {
            return View();
        }

    }
}
