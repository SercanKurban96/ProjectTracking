using ProjectTracking.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTracking.Controllers
{
    public class OverviewController : Controller
    {
        private ProjectTrackingDbContext db = new ProjectTrackingDbContext();

        // GET: Overview
        public ActionResult Index()
        {
            int projectCount = db.EmployeeProjects.Count();
            ViewBag.projectCount = projectCount;

            int completedProjects = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == true).Count();
            ViewBag.completedProjects = completedProjects;

            int unfinishedProjects = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == false).Count();
            ViewBag.unfinishedProjects = unfinishedProjects;

            var highPriorityProjects = db.EmployeeProjects.Where(x => x.ProjectPriorityStatus == "Yüksek Öncelikli").Count();
            ViewBag.highPriorityProjects = highPriorityProjects;

            var middlePriorityProjects = db.EmployeeProjects.Where(x => x.ProjectPriorityStatus == "Orta Öncelikli").Count();
            ViewBag.middlePriorityProjects = middlePriorityProjects;

            var lowPriorityProjects = db.EmployeeProjects.Where(x => x.ProjectPriorityStatus == "Düşük Öncelikli").Count();
            ViewBag.lowPriorityProjects = lowPriorityProjects;

            var successAndHigh = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == true && x.ProjectPriorityStatus == "Yüksek Öncelikli").Count();
            ViewBag.successAndHigh = successAndHigh;

            var successAndMiddle = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == true && x.ProjectPriorityStatus == "Orta Öncelikli").Count();
            ViewBag.successAndMiddle = successAndMiddle;

            var successAndLow = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == true && x.ProjectPriorityStatus == "Düşük Öncelikli").Count();
            ViewBag.successAndLow = successAndLow;

            var employeeProjectList = db.EmployeeProjects.ToList();
            var employeeCompletedProjectCount = new Dictionary<int, int>(); // Personel ID'si ve tamamlanmış proje sayısı çiftlerini tutmak için
            foreach (var employee in db.EmployeeInformations.ToList())
            {
                int completedProjectCount = 0;

                foreach (var project in employee.EmployeeProjects)
                {
                    if (project.ProjectCompletionStatus == true)
                    {
                        completedProjectCount++;
                    }
                }
                employeeCompletedProjectCount[employee.EmployeeInformationID] = completedProjectCount;
            }
            var orderedEmployeeList = employeeCompletedProjectCount.OrderByDescending(x => x.Value); // Tamamlanmış proje sayısına göre personelleri sırala
            var mostCompletedEmployeeId = orderedEmployeeList.First().Key; // En çok tamamlanma sayısına sahip personeli al
            var mostCompletedEmployee = db.EmployeeInformations.FirstOrDefault(x=>x.EmployeeInformationID == mostCompletedEmployeeId);
            ViewBag.mostCompletedEmployee = mostCompletedEmployee.EmployeeNameSurname;

            int employeeCompletedMostProjectCount = employeeCompletedProjectCount[mostCompletedEmployeeId];
            ViewBag.employeeCompletedMostProjectCount = employeeCompletedMostProjectCount;

            return View();
        }

        public ActionResult GeneralStatistics()
        {
            var employees = db.EmployeeInformations.ToList();
            var employeeProjects = db.EmployeeProjects.ToList();
            var completedProjectCount = new Dictionary<int, int>();
            var unfinishedProjectCount = new Dictionary<int, int>();
            var totalProjectCount = new Dictionary<int, int>();

            foreach (var employee in employees)
            {
                int completedProject = 0;
                int unfinishedProject = 0;
                int totalProject = 0;

                foreach (var project in employeeProjects)
                {
                    if (project.EmployeeInformations.Contains(employee))
                    {
                        totalProject++;
                        if (project.ProjectCompletionStatus)
                        {
                            completedProject++;
                        }
                        else
                        {
                            unfinishedProject++;
                        }
                    }
                }
                completedProjectCount[employee.EmployeeInformationID] = completedProject;
                unfinishedProjectCount[employee.EmployeeInformationID] = unfinishedProject;
                totalProjectCount[employee.EmployeeInformationID] = totalProject;
            }
            ViewBag.completedProjectCount = completedProjectCount;
            ViewBag.unfinishedProjectCount = unfinishedProjectCount;
            ViewBag.totalProjectCount = totalProjectCount;

            int projectCount = db.EmployeeProjects.Count();
            ViewBag.projectCount = projectCount;

            int employeeCount = db.EmployeeInformations.Count();
            ViewBag.employeeCount = employeeCount;

            int completedProjects = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == true).Count();
            ViewBag.completedProjects = completedProjects;

            int unfinishedProjects = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == false).Count();
            ViewBag.unfinishedProjects = unfinishedProjects;

            var unfinishedAndHigh = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == false && x.ProjectPriorityStatus == "Yüksek Öncelikli").Count();
            ViewBag.unfinishedAndHigh = unfinishedAndHigh;

            var unfinishedAndMiddle = db.EmployeeProjects.Where(x => x.ProjectCompletionStatus == false && x.ProjectPriorityStatus == "Orta Öncelikli").Count();
            ViewBag.unfinishedAndMiddle = unfinishedAndMiddle;

            return View(employees);
        }
    }
}