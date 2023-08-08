using ProjectTracking.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTracking.Models.ProjectTracking
{
    public class EmployeeProject
    {
        public EmployeeProject()
        {
            this.EmployeeInformations = new HashSet<EmployeeInformation>();
        }

        [Key]
        public int EmployeeProjectID { get; set; }

        [DisplayName("Proje Başlığı")]
        [StringLength(150, ErrorMessage = "Maksimum uzunluk 150 karakterden fazla olamaz.")]
        public string ProjectTitle { get; set; }

        [DisplayName("Açıklaması")]
        public string ProjectDescription { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime ProjectCreationDate { get; set; }

        [DisplayName("Öncelik Durumu")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string ProjectPriorityStatus { get; set; }

        [DisplayName("Tamamlanma Oranı")]
        public int ProjectCompletionRate { get; set; }

        [DisplayName("Tamamlanma Tarihi")]
        public DateTime? ProjectCompletionDate { get; set; }

        [DisplayName("Tamamlanma Durumu")]
        public bool ProjectCompletionStatus { get; set; }


        public virtual ICollection<EmployeeInformation> EmployeeInformations { get; set; }
    }
}