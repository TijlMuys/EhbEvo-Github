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
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Feedback).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Create(int? feedbackId)
        {
            if (feedbackId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.FeedBackId = feedbackId;
            //Search feedback
            Feedback foundfeedback = db.Feedbacks.Find(feedbackId);
            if (foundfeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.Feedback = foundfeedback;
            //search post
            Post foundpost = db.Posts.Find(foundfeedback.Post.Id);
            if (foundpost == null)
            {
                return HttpNotFound();
            }
            ViewBag.Post = foundpost;
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,FeedbackId,Title,Content,Date")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                Feedback foundfeedback = db.Feedbacks.Find(comment.FeedbackId);
                if (foundfeedback == null)
                {
                    return HttpNotFound();
                }
                Post foundpost = db.Posts.Find(foundfeedback.PostId);
                if (foundpost == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Details", foundpost.PostCategory.ToString(), new { id = foundpost.Id });
            }

            ViewBag.FeedbackId = new SelectList(db.Feedbacks, "Id", "UserId", comment.FeedbackId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,FeedbackId,Title,Content,Date")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                Feedback foundfeedback = db.Feedbacks.Find(comment.FeedbackId);
                if (foundfeedback == null)
                {
                    return HttpNotFound();
                }
                Post foundpost = db.Posts.Find(foundfeedback.PostId);
                if (foundpost == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Details", foundpost.PostCategory.ToString(), new { id = foundpost.Id });
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            Feedback foundfeedback = db.Feedbacks.Find(comment.FeedbackId);
            if (foundfeedback == null)
            {
                return HttpNotFound();
            }
            Post foundpost = db.Posts.Find(foundfeedback.PostId);
            if (foundpost == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details", foundpost.PostCategory.ToString(), new { id = foundpost.Id });
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
