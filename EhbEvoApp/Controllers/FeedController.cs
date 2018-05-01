using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EhbEvo.Models;
using EhbEvoApp.Models;using Microsoft.AspNet.Identity;

namespace EhbEvoApp.Controllers
{
    public class FeedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //FILTER
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        public ActionResult Filter(String begin, String eind, String soort, String UserId, String PostType, String PostCategory, String Department, String Program)
        {
            String currentuserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.Find(currentuserId);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Department owndepartment = db.Departments.Find(currentUser.DepartmentId);
            if (owndepartment == null)
            {
                return HttpNotFound();
            }
            Department department = db.Departments.Find(Int32.Parse(Department));
            if (department == null)
            {
                return HttpNotFound();
            }
            Program program = db.Programs.Find(Int32.Parse(Program));
            if (program == null)
            {
                return HttpNotFound();
            }

            DateTime beginDatefilter = new DateTime();
            DateTime eindDatefilter = new DateTime();
            PostType typefilter = EhbEvo.Models.PostType.Idee;
            PostCategory categoryfilter = EhbEvo.Models.PostCategory.Onderwijs;
            

            var feedcontext = new FeedView();
            feedcontext.Users = db.Users.OrderBy(u => u.UserName);
            feedcontext.Departementen = db.Departments.OrderBy(d => d.DepartmentName);

            bool isBegin = (begin.Length > 1);
            if (isBegin) { beginDatefilter = DateTime.Parse(begin); };
            bool isEind = (eind.Length > 1);
            if (isEind) { eindDatefilter = DateTime.Parse(eind); };
            bool isSoort = !(soort.Equals("-1"));
            bool isUser = !(UserId.Equals("-1"));
            bool isPostType = !(PostType.Equals("-1"));
            if (isPostType) { typefilter = (PostType)Enum.Parse(typeof(PostType), PostType); };
            bool isPostCategory = !(PostCategory.Equals("-1"));
            if (isPostCategory) { categoryfilter = (PostCategory)Enum.Parse(typeof(PostCategory), PostCategory); };
            bool isDepartment = !(department.DepartmentName.Equals("* Meerdere Departmenten *"));
            bool isProgram = !(program.ProgramName.Equals("* Meerdere Opleidingen *"));
            //apply Filter
         
            //check if we need posts
            if(soort.Equals("Posts") || isSoort==false)
            {
                //db.Posts.Where(p => ((isBegin) ? p.Date >= beginDatefilter : true == true) && ((isEind) ? p.Date <= eindDatefilter : true == true) && ((isUser) ? p.UserId.Equals(UserId) : true == true) && ((isPostType) ? p.PostType == typefilter : true == true) && ((isPostCategory) ? p.PostCategory == categoryfilter : true == true));
                //iterate over all posts with linq filter
                foreach (var post in db.Posts.Where(p => ((isBegin) ? p.Date >= beginDatefilter : true == true) && ((isEind) ? p.Date <= eindDatefilter : true == true) && ((isUser) ? p.UserId.Equals(UserId) : true == true) && ((isPostType) ? p.PostType == typefilter : true == true) && ((isPostCategory) ? p.PostCategory == categoryfilter : true == true) && ((isDepartment) ? p.User.DepartmentId.ToString().Equals(Department) : true == true) && ((isProgram) ? p.User.ProgramId.ToString().Equals(Program) : true == true)))
                {
                    feedcontext.FeedItems.Add(post.Date, post);
                }
            }
           
            //check if we need feeback
            if (soort.Equals("Feedback") || isSoort == false)
            {
                //iterate over all feedback
                foreach (var feedback in db.Feedbacks.Where(f => (f.UserId.Equals(currentuserId) && (isBegin) ? f.Date >= beginDatefilter : true == true) && ((isEind) ? f.Date <= eindDatefilter : true == true) && ((isUser) ? f.Post.UserId.Equals(UserId) : true == true) && ((isPostType) ? f.Post.PostType == typefilter : true == true) && ((isPostCategory) ? f.Post.PostCategory == categoryfilter : true == true) && ((isDepartment) ? f.Post.User.DepartmentId.ToString().Equals(Department) : true == true) && ((isProgram) ? f.Post.User.ProgramId.ToString().Equals(Program) : true == true)))
                {
                    feedcontext.FeedItems.Add(feedback.Date, feedback);
                }
            }
            
            //check if we need comments
            if (soort.Equals("Commentaar") || isSoort == false)
            {
                //iterate over all comments
                foreach (var comment in db.Comments.Where(c => (c.Feedback.UserId.Equals(currentuserId) && (isBegin) ? c.Date >= beginDatefilter : true == true) && ((isEind) ? c.Date <= eindDatefilter : true == true) && ((isUser) ? c.UserId.Equals(UserId) : true == true) && ((isPostType) ? c.Feedback.Post.PostType == typefilter : true == true) && ((isPostCategory) ? c.Feedback.Post.PostCategory == categoryfilter : true == true) && ((isDepartment) ? c.User.DepartmentId.ToString().Equals(Department) : true == true) && ((isProgram) ? c.User.ProgramId.ToString().Equals(Program) : true == true)))
                {
                    feedcontext.FeedItems.Add(comment.Date, comment);
                }
            }

            //add filtervalues
            feedcontext.Filtervalues.Add(begin);
            feedcontext.Filtervalues.Add(eind);
            feedcontext.Filtervalues.Add(soort);
            feedcontext.Filtervalues.Add(UserId);
            feedcontext.Filtervalues.Add(PostType);
            feedcontext.Filtervalues.Add(PostCategory);
            feedcontext.Filtervalues.Add(Department);
            feedcontext.Filtervalues.Add(Program);

            if (owndepartment.DepartmentName.Equals("* Meerdere Departmenten *"))
            {
                ViewBag.AllDepartments = true;
            }
            else
            {
                ViewBag.AllDepartments = false;
            }

            return View("Index", feedcontext);
        }

        // GET: Feed
        [Authorize(Roles = "Admin, Opleidingshoofd, Opleidingsmedewerker")]
        public ActionResult Index()
        {
            var feedcontext = new FeedView();
            feedcontext.Users = db.Users.OrderBy(u => u.UserName);
            feedcontext.Departementen = db.Departments.OrderBy(d => d.DepartmentName);
            String currentuserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.Find(currentuserId);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Department owndepartment = db.Departments.Find(currentUser.DepartmentId);
            if (owndepartment == null)
            {
                return HttpNotFound();
            }
            var ownprogramid = currentUser.ProgramId;
            Program ownprogram = db.Programs.Find(ownprogramid);
            if (ownprogram == null)
            {
                return HttpNotFound();
            }

            bool isDepartment = !(owndepartment.DepartmentName.Equals("* Meerdere Departmenten *"));
            bool isProgram = !(ownprogram.ProgramName.Equals("* Meerdere Opleidingen *"));


            //iterate over all posts
            foreach (var post in db.Posts.Where(p => ((isDepartment) ? p.User.DepartmentId == owndepartment.DepartmentId : true == true) && ((isProgram) ? p.User.ProgramId == ownprogram.ProgramId : true == true)))
            {
                feedcontext.FeedItems.Add(post.Date, post);
            }
            //iterate over all feedback
            foreach (var feedback in db.Feedbacks.Where(f => (f.UserId.Equals(currentuserId) && (isDepartment) ? f.Post.User.DepartmentId == owndepartment.DepartmentId : true == true) && ((isProgram) ? f.Post.User.ProgramId == ownprogram.ProgramId : true == true)))
            {
                feedcontext.FeedItems.Add(feedback.Date, feedback);
            }
            //iterate over all comments
            foreach (var comment in db.Comments.Where(c => (c.Feedback.UserId.Equals(currentuserId) && (isDepartment) ? c.User.DepartmentId == owndepartment.DepartmentId : true == true) && ((isProgram) ? c.User.ProgramId == ownprogram.ProgramId : true == true)))
            {
                feedcontext.FeedItems.Add(comment.Date, comment);
            }

            //Set default filtervalues
            feedcontext.Filtervalues.Add("");
            feedcontext.Filtervalues.Add("");
            feedcontext.Filtervalues.Add("-1");
            feedcontext.Filtervalues.Add("-1");
            feedcontext.Filtervalues.Add("-1");
            feedcontext.Filtervalues.Add("-1");
            feedcontext.Filtervalues.Add(currentUser.DepartmentId.ToString());
            feedcontext.Filtervalues.Add("-1");
            if(owndepartment.DepartmentName.Equals("* Meerdere Departmenten *"))
            {
                ViewBag.AllDepartments = true;
            }
            else
            {
                ViewBag.AllDepartments = false;
            }
            
            return View(feedcontext);
        }

        [AllowAnonymous]
        public ActionResult ProgramPartial(int? Id, int? programId)
        {
            ApplicationUser currentUser = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Department department = db.Departments.Find(Id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var ownprogramid = currentUser.ProgramId;
            Program ownprogram = db.Programs.Find(ownprogramid);
            if (ownprogram == null)
            {
                return HttpNotFound();
            }
            if (programId == null)
            {
                programId = -1;
            }
            ViewBag.OwnProgram = ownprogram;
            ViewBag.SelectedProgram = programId;
           
            return View("Programfeedselect", department);
        }

    }
}
