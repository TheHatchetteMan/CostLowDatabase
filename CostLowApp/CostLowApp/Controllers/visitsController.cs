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
    public class visitsController : Controller
    {
        private CostLowDatabaseEntities db = new CostLowDatabaseEntities();

        // GET: visits
        public ActionResult Index()
        {
            var visits = db.visits.Include(v => v.member).Include(v => v.store);
            return View(visits.ToList());
        }

        // GET: visits/Details/5
        public ActionResult Details(int? id, int? id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit visit = db.visits.Find(id, id2, id3);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: visits/Create
        public ActionResult Create()
        {
            ViewBag.customerId = new SelectList(db.members, "customerId", "firstName");
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address");
            return View();
        }

        // POST: visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerId,storeNumber,date,amountSpent")] visit visit)
        {
            if (ModelState.IsValid)
            {
                db.visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerId = new SelectList(db.members, "customerId", "firstName", visit.customerId);
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address", visit.storeNumber);
            return View(visit);
        }

        // GET: visits/Edit/5
        public ActionResult Edit(int? id, int? id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit visit = db.visits.Find(id, id2, id3);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerId = new SelectList(db.members, "customerId", "firstName", visit.customerId);
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address", visit.storeNumber);
            return View(visit);
        }

        // POST: visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerId,storeNumber,date,amountSpent")] visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerId = new SelectList(db.members, "customerId", "firstName", visit.customerId);
            ViewBag.storeNumber = new SelectList(db.stores, "storeNumber", "address", visit.storeNumber);
            return View(visit);
        }

        // GET: visits/Delete/5
        public ActionResult Delete(int? id, int? id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit visit = db.visits.Find(id, id2, id3);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int? id2, DateTime id3)
        {
            visit visit = db.visits.Find(id, id2, id3);
            db.visits.Remove(visit);
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

        public ActionResult VisitPortal()
        {
            ViewBag.Message = "Visit Actions.";

            return View();
        }
    }
}
