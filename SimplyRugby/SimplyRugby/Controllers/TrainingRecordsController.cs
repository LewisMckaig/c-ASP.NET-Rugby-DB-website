using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyRugby.Models;
using SimplyRugby.ViewModels;

namespace SimplyRugby.Controllers
{
    public class TrainingRecordsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: TrainingRecords
        public ActionResult Index()
        {
            return View(db.TrainingRecords.ToList());
        }

        // GET: TrainingRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingRecord trainingRecord = db.TrainingRecords.Find(id);
            if (trainingRecord == null)
            {
                return HttpNotFound();
            }
            return View(trainingRecord);
        }

        // GET: TrainingRecords/Create
        public ActionResult Create()
        {
            var model = new CoachesViewModel
            {
                nonPlayers = db.nonPlayers,

            };
            return View(model);
        }

        // POST: TrainingRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoachesViewModel trainingRecord)
        {
            if (ModelState.IsValid)
            {
                TrainingRecord tr = new TrainingRecord();
                tr.nonPlayer_id = trainingRecord.nonplayer_id;
                tr.description = trainingRecord.description;
                tr.date = trainingRecord.date;
                tr.location = trainingRecord.location;
                tr.accidents = trainingRecord.accidents;
                tr.nonPlayer = db.nonPlayers.Find(tr.nonPlayer_id);
                tr.FullName = tr.nonPlayer.FullName;
                db.TrainingRecords.Add(tr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingRecord);
        }

        // GET: TrainingRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingRecord trainingRecord = db.TrainingRecords.Find(id);
            if (trainingRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.nonPlayer_id = new SelectList(db.nonPlayers, "id", "FullName", trainingRecord.nonPlayer_id);
            return View(trainingRecord);
        }

        // POST: TrainingRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nonPlayer_id,date,location,description,accidents")] TrainingRecord trainingRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingRecord);
        }

        // GET: TrainingRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingRecord trainingRecord = db.TrainingRecords.Find(id);
            if (trainingRecord == null)
            {
                return HttpNotFound();
            }
            return View(trainingRecord);
        }

        // POST: TrainingRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingRecord trainingRecord = db.TrainingRecords.Find(id);
            db.TrainingRecords.Remove(trainingRecord);
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
