using ProjectTracking.Models.ProjectTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTracking.Models.Employee
{
    public class EmployeeInformation
    {
        public EmployeeInformation()
        {
            this.EmployeeProjects = new HashSet<EmployeeProject>();
        }

        [Key]
        public int EmployeeInformationID { get; set; }

        [DisplayName("MAIL ADRESİ")] // İsimlendirmeler
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz.")]
        public string EmployeeEmail { get; set; }

        [DisplayName("ŞİFRE")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string EmployeePassword { get; set; }

        [DisplayName("YETKİ")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakterden fazla olamaz.")]
        public string EmployeeAuthority { get; set; }

        [DisplayName("AD SOYAD")]
        [StringLength(100, ErrorMessage = "Maksimum uzunluk 100 karakterden fazla olamaz.")]
        public string EmployeeNameSurname { get; set; }

        [DisplayName("PERSONEL GÖRSELİ")]
        public string EmployeeImage { get; set; }

        [DisplayName("TC KİMLİK NUMARASI")]
        [StringLength(11, ErrorMessage = "Maksimum uzunluk 11 karakterden fazla olamaz.")]
        public string EmployeeIdentificationNumber { get; set; }

        [DisplayName("DEPARTMANI")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string EmployeeDepartment { get; set; }

        [DisplayName("GÖREVİ")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string EmployeeTask { get; set; }

        [DisplayName("GÖREV AÇIKLAMASI")]
        public string EmployeePositionDescription { get; set; }

        [DisplayName("TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakterden fazla olamaz.")]
        public string EmployeePhoneNumber { get; set; }

        [DisplayName("ADRES BİLGİLERİ")]
        public string EmployeeAddress { get; set; }

        [DisplayName("MEDENİ HALİ")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string EmployeeMaritalStatus { get; set; }

        [DisplayName("YAKINLIK BİLGİSİ")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string ProximityInformation { get; set; }

        [DisplayName("YAKINININ TC KİMLİK NUMARASI")]
        [StringLength(11, ErrorMessage = "Maksimum uzunluk 11 karakterden fazla olamaz.")]
        public string ProximityInformationTRNumber { get; set; }

        [DisplayName("YAKINININ ADI SOYADI")]
        [StringLength(100, ErrorMessage = "Maksimum uzunluk 100 karakterden fazla olamaz.")]
        public string ProximityInformationNameSurname { get; set; }

        [DisplayName("YAKINININ TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakterden fazla olamaz.")]
        public string ProximityInformationPhoneNumber { get; set; }

        [DisplayName("DOĞUM TARİHİ")]
        public DateTime BirthDate { get; set; }

        [DisplayName("İŞE GİRİŞ TARİHİ")]
        public DateTime? DateOfRecruitment { get; set; }


        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}