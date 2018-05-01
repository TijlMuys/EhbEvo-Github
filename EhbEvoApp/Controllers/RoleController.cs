using EhbEvoApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EhbEvoApp.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        //Constructor
        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: All Roles
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        //Delete a new Role (GET)
        [Authorize(Roles = "Admin")]
        public ActionResult Delete()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        //Delete a new Role (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(string RoleName)
        {
            var Role = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Create a new Role (GET)
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        //Create a new Role (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}