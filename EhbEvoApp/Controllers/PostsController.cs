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
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var posts = db.Posts.OrderByDescending(p => p.Date);
            return View(posts.ToList());
        }

       
    }
}
