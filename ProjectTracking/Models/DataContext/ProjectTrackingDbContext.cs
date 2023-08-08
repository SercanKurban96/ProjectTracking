using ProjectTracking.Models.Employee;
using ProjectTracking.Models.ProjectTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTracking.Models.DataContext
{
    public class ProjectTrackingDbContext : DbContext
    {
        public ProjectTrackingDbContext(): base("ProjectTrackingDb")
        {

        }

        public DbSet<EmployeeInformation> EmployeeInformations { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    }
}