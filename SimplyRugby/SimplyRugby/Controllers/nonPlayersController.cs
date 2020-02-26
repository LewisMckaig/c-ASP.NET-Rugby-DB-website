
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
    public class nonPlayersController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: nonPlayers
        public ActionResult Index()
        {
            return View(db.nonPlayers.ToList());
        }

        // GET: nonPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nonPlayer nonPlayer = db.nonPlayers.Find(id);
            if (nonPlayer == null)
            {
                return HttpNotFound();
            }
            return View(nonPlayer);
        }

        // GET: nonPlayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nonPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,SRUNum,fName,lName,dob,address,postCode,phone,email")] nonPlayer nonPlayer)
        {
            if (ModelState.IsValid)
            {
                db.nonPlayers.Add(nonPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nonPlayer);
        }

        // GET: nonPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nonPlayer nonPlayer = db.nonPlayers.Find(id);
            if (nonPlayer == null)
            {
                return HttpNotFound();
            }
            return View(nonPlayer);
        }

        // POST: nonPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SRUNum,fName,lName,dob,address,postCode,phone,email")] nonPlayer nonPlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nonPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nonPlayer);
        }

        // GET: nonPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nonPlayer nonPlayer = db.nonPlayers.Find(id);
            if (nonPlayer == null)
            {
                return HttpNotFound();
            }
            return View(nonPlayer);
        }

        // POST: nonPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nonPlayer nonPlayer = db.nonPlayers.Find(id);
            db.nonPlayers.Remove(nonPlayer);
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
