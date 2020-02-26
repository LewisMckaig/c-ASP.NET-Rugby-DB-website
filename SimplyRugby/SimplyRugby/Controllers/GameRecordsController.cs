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
    public class GameRecordsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: GameRecords
        public ActionResult Index()
        {
            var gameRecords = db.GameRecords.Include(g => g.Coach);
            return View(gameRecords.ToList());
        }

        // GET: GameRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameRecord gameRecord = db.GameRecords.Find(id);
            int CoachID = gameRecord.coachID;
            nonPlayer coach = db.nonPlayers.Find(CoachID);
            if (gameRecord == null)
            {
                return HttpNotFound();
            }
            var ViewModel = new getCoachName(gameRecord, coach);
            return View(ViewModel);
        }

        // GET: GameRecords/Create
        public ActionResult Create()
        {
            List<nonPlayer> coaches = new List<nonPlayer>(db.nonPlayers.ToList());
            ViewBag.coachID = new SelectList(coaches, "id", "FullName");
            return View();
        }

        // POST: GameRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,location,firstHalf,secondHalf,date,team,ptsFor,ptsAgainst,coachID")] GameRecord gameRecord)
        {
            gameRecord.Coach = db.nonPlayers.Find(gameRecord.coachID);
            if (ModelState.IsValid)
                {
                    db.GameRecords.Add(gameRecord);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View();
        }

        // GET: GameRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameRecord gameRecord = db.GameRecords.Find(id);
            if (gameRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.coachID = new SelectList(db.nonPlayers, "id", "FullName", gameRecord.coachID);
            return View(gameRecord);
        }

        // POST: GameRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,location,firstHalf,secondHalf,date,team,ptsFor,ptsAgainst,coachID")] GameRecord gameRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coachID = new SelectList(db.nonPlayers, "id", "fName", gameRecord.coachID);
            return View(gameRecord);
        }

        // GET: GameRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameRecord gameRecord = db.GameRecords.Find(id);
            if (gameRecord == null)
            {
                return HttpNotFound();
            }
            return View(gameRecord);
        }

        // POST: GameRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameRecord gameRecord = db.GameRecords.Find(id);
            db.GameRecords.Remove(gameRecord);
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
