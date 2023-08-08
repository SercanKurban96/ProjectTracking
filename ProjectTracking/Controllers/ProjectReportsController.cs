using ProjectTracking.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTracking.Controllers
{
    public class ProjectReportsController : Controller
    {
        // GET: ProjectReports
        public ProjectTrackingDbContext db = new ProjectTrackingDbContext();

        // Tamamlanmış Öncelikli Gruplar
        public ActionResult CompletedPriorityGroups()
        {
            return View();
        }

        public ActionResult VisualizeCompletedStatusGroup()
        {
            return Json(PriorityGroupType(), JsonRequestBehavior.AllowGet);
        }

        public List<ClassPriorityStatusAnalyze> PriorityGroupType()
        {
            ;
            List<ClassPriorityStatusAnalyze> cls = new List<ClassPriorityStatusAnalyze>();
            using (var c = new ProjectTrackingDbContext())
                cls = c.EmployeeProjects.Where(x => x.ProjectCompletionStatus == true).GroupBy(y => y.ProjectPriorityStatus).Select(z => new ClassPriorityStatusAnalyze
                {
                    priorityType = z.Key,
                    priorityPiece = z.Count(),
                }).ToList();
            return cls;
        }

        // Tamamlanmamış Öncelikli Gruplar
        public ActionResult UncompletedPriorityGroups()
        {
            return View();
        }

        public ActionResult VisualizeUncompletedStatusGroup()
        {
            return Json(PriorityUncompletedGroupType(), JsonRequestBehavior.AllowGet);
        }

        public List<ClassPriorityStatusAnalyze> PriorityUncompletedGroupType()
        {
            ;
            List<ClassPriorityStatusAnalyze> cls = new List<ClassPriorityStatusAnalyze>();
            using (var c = new ProjectTrackingDbContext())
                cls = c.EmployeeProjects.Where(x => x.ProjectCompletionStatus == false).GroupBy(y => y.ProjectPriorityStatus).Select(z => new ClassPriorityStatusAnalyze
                {
                    priorityType = z.Key,
                    priorityPiece = z.Count(),
                }).ToList();
            return cls;
        }

        public ActionResult GeneralProjectReports()
        {
            return View();
        }

        public ActionResult LiveSupport()
        {
            var support = db.EmployeeInformations.Where(x => x.EmployeeDepartment == "Yönetim");
            return View(support.ToList());
        }
    }
}