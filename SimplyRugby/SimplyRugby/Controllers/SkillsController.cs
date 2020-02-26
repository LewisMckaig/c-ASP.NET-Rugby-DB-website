using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyRugby.Models;

namespace SimplyRugby.Controllers
{
    public class SkillsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Skills
        public ActionResult Index()
        {
            var skills = db.Skills.Include(s => s.player);
            return View(skills.ToList());
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            ViewBag.playerId = new SelectList(db.Players, "id", "Fullname");
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,standard,spin,pop,front,rear,side,scrabble,Drop,punt,grubber,Goal,Date,playerId")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skills);
                db.SaveChanges();
                return RedirectToAction("/../Players/Details", new { id = skills.playerId });
            }

            ViewBag.playerId = new SelectList(db.Players, "id", "fName", skills.playerId);
            return View(skills);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            ViewBag.playerId = new SelectList(db.Players, "id", "fName", skills.playerId);
            return View(skills);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,standard,spin,pop,front,rear,side,scrabble,Drop,punt,grubber,Goal,Date,playerId")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.playerId = new SelectList(db.Players, "id", "fName", skills.playerId);
            return View(skills);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.Skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skills skills = db.Skills.Find(id);
            Player player = db.Players.Find(skills.playerId);
            String team = player.team;
            db.Skills.Remove(skills);
            db.SaveChanges();
            if (team == "Junior")
            {
                return RedirectToAction("/../Players/Junior");
            }
            else
            {
                return RedirectToAction("/../Players/Senior");
            }
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
