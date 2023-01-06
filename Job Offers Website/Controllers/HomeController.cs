using Job_Offers_Website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Details(int JobID)
        {
            var job = db.Jobs.Find(JobID);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["Jobid"] = JobID;
            return View (job);

        }
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["Jobid"];

            var check = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();
            if (check.Count < 1)
            {
            var job = new ApplyForJob();

            job.UserId = UserId;
            job.JobId = JobId;
            job.Message = Message;
            job.ApplyDate = DateTime.Now;

            db.ApplyForJobs.Add(job);
            db.SaveChanges();
                ViewBag.Result = "تم تأكيد التقدم لطلب الوظيفة";

            }
            else
            {
                ViewBag.Result = "عفواً لقد قمت بالفعل بالتقدم لهذة الوظيفة";
            }

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(Jobs.ToList());
        }
        [Authorize]
        public ActionResult DetailsOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);

        }
        public ActionResult Edit(int id)
        {
            var x = db.ApplyForJobs.Find(id);
            if (x == null)
            {
                return HttpNotFound();
            }
            return View(x);

        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {
            if (ModelState.IsValid)
            {
                //job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);
        }


    }
}