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
    public class GuardiansController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Guardians
        public ActionResult Index()
        {
            var guardians = db.Guardians.Include(g => g.player);
            return View(guardians.ToList());
        }

        // GET: Guardians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guardian guardian = db.Guardians.Find(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            return View(guardian);
        }

        // GET: Guardians/Create
        public ActionResult Create()
        {
            Junior junior = new Junior(db.Players.ToList());
            List<Player> juniorPlayers = junior.juniorTeam; 

            ViewBag.playerID = new SelectList(juniorPlayers, "id", "FullName");
            return View();
        }

        // POST: Guardians/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fName,lName,address,phone,relation,playerID")] Guardian guardian)
        {
            guardian.player = db.Players.Find(guardian.playerID);
            if (ModelState.IsValid)
            {
                db.Guardians.Add(guardian);
                db.SaveChanges();
                return RedirectToAction("../Players/Junior");
            }

            Junior junior = new Junior(db.Players.ToList());
            List<Player> juniorPlayers = junior.juniorTeam;
            ViewBag.playerID = new SelectList(juniorPlayers, "id", "FullName");
            return View(guardian);
        }

        // GET: Guardians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guardian guardian = db.Guardians.Find(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            ViewBag.playerID = new SelectList(db.Players, "id", "fName", guardian.playerID);
            return View(guardian);
        }

        // POST: Guardians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fName,lName,address,phone,relation,playerID")] Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guardian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.playerID = new SelectList(db.Players, "id", "fName", guardian.playerID);
            return View(guardian);
        }

        // GET: Guardians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guardian guardian = db.Guardians.Find(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            return View(guardian);
        }

        // POST: Guardians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guardian guardian = db.Guardians.Find(id);
            db.Guardians.Remove(guardian);
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
