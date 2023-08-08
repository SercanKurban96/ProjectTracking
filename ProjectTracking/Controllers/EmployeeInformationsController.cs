using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTracking.Models.DataContext;
using ProjectTracking.Models.Employee;

namespace ProjectTracking.Controllers
{
    public class EmployeeInformationsController : Controller
    {
        private ProjectTrackingDbContext db = new ProjectTrackingDbContext(); // Veri tabanı bağlantısı

        // GET: EmployeeInformations
        public ActionResult Index() // Verileri listeler
        {
            return View(db.EmployeeInformations.ToList());
        }

        public ActionResult EmployeeCard()
        {
            return View(db.EmployeeInformations.ToList());
        }

        // GET: EmployeeInformations/Create
        public ActionResult Create() // Ekleme Oluşturma
        {
            return View();
        }

        // POST: EmployeeInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeInformations.Add(employeeInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            db.EmployeeInformations.Remove(employeeInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
