using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EhbEvo.Models;
using EhbEvoApp.Models;

namespace EhbEvoApp.Controllers
{
    public class FeedbackController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feedback
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks.Include(f => f.Post).Include(f => f.User);
            return View(feedbacks.ToList());
        }

        // GET: Feedback/Details/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedback/Create
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        public ActionResult Create(int? postId)
        {
            if (postId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PostId = postId;
            Post foundpost = db.Posts.Find(postId);
            if (foundpost == null)
            {
                return HttpNotFound();
            }
            ViewBag.Post = foundpost;

            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Title,PostId,Content,Rating,Date")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = feedback.Id });
            }

            ViewBag.PostId = new SelectList(db.Posts, "Id", "UserId", feedback.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedback/Edit/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Id", feedback.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", feedback.UserId);
            return View(feedback);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Title,PostId,Content,Rating,Date")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = feedback.Id });
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "UserId", feedback.PostId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedback/Delete/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index", "Feed");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
