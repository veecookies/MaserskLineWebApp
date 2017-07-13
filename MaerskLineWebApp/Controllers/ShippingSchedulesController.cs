using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLineWebApp.Models;

namespace MaerskLineWebApp.Controllers
{
    public class ShippingSchedulesController : Controller
    {
        private MaerskLineWebAppContext db = new MaerskLineWebAppContext();

        // GET: ShippingSchedules
        public ActionResult Index()
        {
            var shippingSchedules = db.ShippingSchedules.Include(s => s.Container).Include(s => s.Ship).Include(s => s.Shipyard1).Include(s => s.Shipyard2);
            return View(shippingSchedules.ToList());
        }

        // GET: ShippingSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingSchedule shippingSchedule = db.ShippingSchedules.Find(id);
            if (shippingSchedule == null)
            {
                return HttpNotFound();
            }
            return View(shippingSchedule);
        }

        // GET: ShippingSchedules/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Container_Description");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "Ship_Name");
            ViewBag.Departure_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name");
            ViewBag.Arrival_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name");
            return View();
        }

        // POST: ShippingSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "ShippingScheduleID,ShipID,ContainerID,Charges,Departure_Date,Arrival_Date,Departure_ShipyardID,Arrival_ShipyardID")] ShippingSchedule shippingSchedule)
        {
            if (ModelState.IsValid)
            {
                db.ShippingSchedules.Add(shippingSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Container_Description", shippingSchedule.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "Ship_Name", shippingSchedule.ShipID);
            ViewBag.Departure_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name", shippingSchedule.Departure_ShipyardID);
            ViewBag.Arrival_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name", shippingSchedule.Arrival_ShipyardID);
            return View(shippingSchedule);
        }

        // GET: ShippingSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingSchedule shippingSchedule = db.ShippingSchedules.Find(id);
            if (shippingSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Container_Description", shippingSchedule.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "Ship_Name", shippingSchedule.ShipID);
            ViewBag.Departure_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name", shippingSchedule.Departure_ShipyardID);
            ViewBag.Arrival_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name", shippingSchedule.Arrival_ShipyardID);
            return View(shippingSchedule);
        }

        // POST: ShippingSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "ShippingScheduleID,ShipID,ContainerID,Charges,Departure_Date,Arrival_Date,Departure_ShipyardID,Arrival_ShipyardID")] ShippingSchedule shippingSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "Container_Description", shippingSchedule.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "Ship_Name", shippingSchedule.ShipID);
            ViewBag.Departure_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name", shippingSchedule.Departure_ShipyardID);
            ViewBag.Arrival_ShipyardID = new SelectList(db.Shipyards, "ShipyardID", "Shipyard_Name", shippingSchedule.Arrival_ShipyardID);
            return View(shippingSchedule);
        }

        // GET: ShippingSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingSchedule shippingSchedule = db.ShippingSchedules.Find(id);
            if (shippingSchedule == null)
            {
                return HttpNotFound();
            }
            return View(shippingSchedule);
        }

        // POST: ShippingSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingSchedule shippingSchedule = db.ShippingSchedules.Find(id);
            db.ShippingSchedules.Remove(shippingSchedule);
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
