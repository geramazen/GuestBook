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
    public class MessagesController : Controller
    {
        private GuestBookEntities db = new GuestBookEntities();

        public ActionResult Index()
        {
            var Model = db.messages.ToList();
            return View(Model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        public ActionResult Create()
        {
            if (Session["UserName"] != null)
            {
                ViewBag.UID = new SelectList(db.users, "UID", "email");
                return View();
            }
            else
            {
                ViewBag.error = "You have to login to can Add a message";
                return RedirectToAction("Index", "users");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descreption")] message _message)
        {
            if (ModelState.IsValid)
            {
                _message.User_ID = Convert.ToInt32(Session["User ID"]);
                db.messages.Add(_message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_message);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.messages.Find(id);
            Session["MessageID"] = message.MID; //This session to catch the message ID and can pass it
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Descreption")] message message)
        {
            if (ModelState.IsValid)
            {
                message.User_ID = Convert.ToInt32(Session["User ID"]);
                message.MID = Convert.ToInt32(Session["MessageID"]);
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            message message = db.messages.Find(id);
            db.messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddReply(int? id)
        {
            if (Session["UserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                message _message = db.messages.Find(id);
                Session["MessageID"] = _message.MID; //Here Iam catch the parent message ID
                if (_message == null)
                {
                    return HttpNotFound();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "users");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReply([Bind(Include = "Descreption")] message _message)
        {
            if (ModelState.IsValid)
            {
                _message.User_ID = Convert.ToInt32(Session["User ID"]);
                _message.PID = Convert.ToInt32(Session["MessageID"]);
                db.messages.Add(_message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_message);
        }

    }
}
