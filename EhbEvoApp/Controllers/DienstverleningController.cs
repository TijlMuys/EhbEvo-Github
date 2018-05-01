using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using EhbEvo.Models;
using EhbEvoApp.Models;
using Microsoft.AspNet.Identity;

namespace EhbEvoApp.Controllers
{
    public class DienstverleningController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Index()
        {
            var currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if(currentUserId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var posts = db.Posts.Where(p => p.PostCategory == PostCategory.Dienstverlening && p.UserId == currentUserId);
            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Create([Bind(Include = "Id,Evopoints,UserId,PostType,PostCategory,Title,Content,ImgUrl,Date")] Post post)
        {
            if (ModelState.IsValid)
            {
                //check if imageurl is empty
                if(post.ImgUrl == null)
                {
                    switch (post.PostType)
                    {
                        case PostType.Idee:
                            post.ImgUrl = Url.Content("~/Content/images/dienstverleningidee.png");
                            break;
                        case PostType.Plan:
                            post.ImgUrl = Url.Content("~/Content/images/dienstverleningplan.png");
                            break;
                        case PostType.Actie:
                            post.ImgUrl = Url.Content("~/Content/images/dienstverleningactie.png");
                            break;
                        default:
                            break;
                    }
                   
                }
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evopoints,UserId,PostType,PostCategory,Title,Content,ImgUrl,Date")] Post post)
        {
            if (ModelState.IsValid)
            {
                //check if imageurl is empty
                if (post.ImgUrl == null)
                {
                    switch (post.PostType)
                    {
                        case PostType.Idee:
                            post.ImgUrl = Url.Content("~/Content/images/dienstverleningidee.png");
                            break;
                        case PostType.Plan:
                            post.ImgUrl = Url.Content("~/Content/images/dienstverleningplan.png");
                            break;
                        case PostType.Actie:
                            post.ImgUrl = Url.Content("~/Content/images/dienstverleningactie.png");
                            break;
                        default:
                            break;
                    }

                }
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
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
