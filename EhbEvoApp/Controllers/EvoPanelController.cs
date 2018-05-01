using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EhbEvoApp.Models;
using Microsoft.AspNet.Identity;

namespace EhbEvoApp.Controllers
{
    public class EvoPanelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: EvoPanel
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker, Docent, Personeel")]
        public ActionResult Index()
        {
            //getcurrentuser
            String currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.Find(currentUserId);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var currentUserPosts = currentUser.Posts.ToList();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(currentUser);
        }
    }
}