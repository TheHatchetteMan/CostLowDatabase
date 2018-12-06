//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  employeesController.cs
//  Purpose:    Create a controller to hold functions for the employees group
//              of views.
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

using System;
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
    //Contorller definition
    public class employeesController : Controller
    {
        private CostLowDatabaseEntities db = new CostLowDatabaseEntities();

        // GET: employees
        //Return view of index of employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.department);
            return View(employees.ToList());
        }

        // GET: employees/Details/5
        //Return view of details about a selected employee
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
        //Allows creation of a new employee
        public ActionResult Create()
        {
            ViewBag.departmentId = new SelectList(db.departments, "departmentId", "departmentName");
            return View();
        }

        // POST: employees/Create
        //Sends new employee to the database
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
        //Allows editing of an employee
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
        //Sends edited employee data to the database
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
        //Gathers employee to be deleted
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
        //Deletes selected employee from database
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

        //Returns view of employee portal with employee actions
        public ActionResult EmployeePortal()
        {
            ViewBag.Message = "Employee Actions.";

            return View();
        }
    }
}
