using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerReparationStore.DAL;
using ComputerReparationStore.Models;

namespace ComputerReparationStore.Controllers
{
    public class ReparationOrdersController : Controller
    {
        private ReparationOrderContext db = new ReparationOrderContext();

        // GET: ReparationOrders
        public ActionResult Index()
        {
            return View(db.ReparationOrders.ToList());
        }

        // GET: ReparationOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReparationOrder reparationOrder = db.ReparationOrders.Find(id);
            if (reparationOrder == null)
            {
                return HttpNotFound();
            }
            return View(reparationOrder);
        }

        // GET: ReparationOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReparationOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Status")] ReparationOrder reparationOrder)
        {
            if (ModelState.IsValid)
            {
                db.ReparationOrders.Add(reparationOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reparationOrder);
        }

        // GET: ReparationOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReparationOrder reparationOrder = db.ReparationOrders.Find(id);
            if (reparationOrder == null)
            {
                return HttpNotFound();
            }
            return View(reparationOrder);
        }

        // POST: ReparationOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Status")] ReparationOrder reparationOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparationOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reparationOrder);
        }

        // GET: ReparationOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReparationOrder reparationOrder = db.ReparationOrders.Find(id);
            if (reparationOrder == null)
            {
                return HttpNotFound();
            }
            return View(reparationOrder);
        }

        // POST: ReparationOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReparationOrder reparationOrder = db.ReparationOrders.Find(id);
            db.ReparationOrders.Remove(reparationOrder);
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
