using ProjectTracking.Models.DataContext;
using ProjectTracking.Models.Employee;
using ProjectTracking.Models.ProjectTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTracking.Controllers
{
    public class EmployeeProjectsController : Controller
    {

        private ProjectTrackingDbContext db = new ProjectTrackingDbContext();

        // GET: EmployeeProjects
        public ActionResult Index()
        {
            var projectlist = db.EmployeeProjects.ToList();
            return View(projectlist);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmployeeInformationID = new SelectList(db.EmployeeInformations, "EmployeeInformationID", "EmployeeNameSurname");
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeProject project, int[] EmployeeInformationID)
        {
            foreach (var item in EmployeeInformationID)
            {
                project.EmployeeInformations.Add(db.EmployeeInformations.Find(item));
            }
            project.ProjectCreationDate = DateTime.Now;
            db.EmployeeProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = db.EmployeeProjects.Find(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeProject project)
        {
            var proj = db.EmployeeProjects.Find(project.EmployeeProjectID);
            proj.ProjectDescription = project.ProjectDescription;
            proj.ProjectTitle = project.ProjectTitle;
            proj.ProjectCompletionRate = project.ProjectCompletionRate;
            proj.ProjectPriorityStatus = project.ProjectPriorityStatus;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Complete(int id)
        {
            var proj = db.EmployeeProjects.Find(id);
            proj.ProjectCompletionStatus = true;
            proj.ProjectCompletionRate = 100;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}