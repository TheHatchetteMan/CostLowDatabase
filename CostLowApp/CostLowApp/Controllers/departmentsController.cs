//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  departmentsController.cs
//  Purpose:    Create a controller to hold functions for the departments group
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
    //Controller definition
    public class departmentsController : Controller
    {
        private CostLowDatabaseEntities db = new CostLowDatabaseEntities();

        // GET: departments
        //Returns view of index of departments
        public ActionResult Index()
        {
            var departments = db.departments.Include(d => d.store);
            return View(departments.ToList());
        }

        // GET: departments/Details/5
        //Returns view of details form selected department
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department department = db.departments.Find(id, id2);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: departments/Create
        //Allows creation of a new department
        public ActionResult Create()
        {
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address");
            return View();
        }

        // POST: departments/Create
        //Sends created department to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "departmentId,storeNumber,phoneExtension,departmentName")] department department)
        {
            if (ModelState.IsValid)
            {
                db.departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address", department.storeNumber);
            return View(department);
        }

        // GET: departments/Edit/5
        //Allows editing of a department
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department department = db.departments.Find(id, id2);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address", department.storeNumber);
            return View(department);
        }

        // POST: departments/Edit/5
        //Sends edited data to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "departmentId,storeNumber,phoneExtension,departmentName")] department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address", department.storeNumber);
            return View(department);
        }

        // GET: departments/Delete/5
        //Gathers department to be deleted
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department department = db.departments.Find(id, id2);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: departments/Delete/5
        //Deletes selected department from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            department department = db.departments.Find(id, id2);
            db.departments.Remove(department);
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

        //Returns view of department portal with department actions
        public ActionResult DepartmentPortal()
        {
            ViewBag.Message = "Department Actions.";

            return View();
        }
    }
}
