﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CostLowApp.Models;

namespace CostLowApp.Controllers
{
    public class employeesController : Controller
    {
        private CostLowDatabaseEntities db = new CostLowDatabaseEntities();

        // GET: employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.department);
            return View(employees.ToList());
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id, id2);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            ViewBag.departmentId = new SelectList(db.departments, "departmentId", "departmentName");
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ssn,departmentId,storeNumber,phoneNumber,sallary,firstName,lastName")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departmentId = new SelectList(db.departments, "departmentId", "departmentName", employee.departmentId);
            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id, id2);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmentId = new SelectList(db.departments, "departmentId", "departmentName", employee.departmentId);
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ssn,departmentId,storeNumber,phoneNumber,sallary,firstName,lastName")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departmentId = new SelectList(db.departments, "departmentId", "departmentName", employee.departmentId);
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id, id2);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            employee employee = db.employees.Find(id, id2);
            db.employees.Remove(employee);
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

        public ActionResult EmployeePortal()
        {
            ViewBag.Message = "Employee Actions.";

            return View();
        }
    }
}
