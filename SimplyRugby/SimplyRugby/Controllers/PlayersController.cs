using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyRugby.CustomExceptions;
using SimplyRugby.Models;
using SimplyRugby.ViewModels;

namespace SimplyRugby.Controllers
{
    public class PlayersController : Controller
    {
        private AppDBContext db = new AppDBContext();

        public ActionResult Senior()
        {
            try
            {
                Senior SeniorTeam = new Senior(db.Players.ToList());
                return View(SeniorTeam.seniorTeam.ToList());
            }
            catch (InvalidTeamException)
            {
                Console.Write("Team Name Not Valid");
            }
            return View();
        }

        public ActionResult Junior()
        {
            try
            {
                Junior JuniorTeam = new Junior(db.Players.ToList());
                return View(JuniorTeam.juniorTeam.ToList());
            }
            catch (InvalidTeamException)
            {
                Console.Write("Team Name Not Valid");
            }
            return View();
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(id);
            var ViewModel = new PlayerData(player, db.Skills.ToList(), db.Guardians.ToList());
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(ViewModel);
        }

        // GET: Players/Create
        public ActionResult CreateJunior()
        {
            var player = new juniorGuardian();
            return View(player);
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJunior(juniorGuardian junior)
        {
            junior.team = "Junior";
                Player player = new Player();
                player = junior.setPlayer();

                Guardian guardian = new Guardian();
                guardian = junior.setGuardian();
                db.Players.Add(player);
                db.SaveChanges();
                guardian.playerID = player.id;
                db.Guardians.Add(guardian);
                db.SaveChanges();
                return RedirectToAction("Junior");
        }

        public ActionResult CreateSenior()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSenior([Bind (Include = "id,SRUNum,fName,lName,dob,address,postCode,phoneNum,email,doctor,doctorAddress,doctorPhone,position,healthissues,team,nok,nokTele")]Player player)
        {
                player.team = "Senior";
                db.Players.Add(player);
                db.SaveChanges();
                
                return RedirectToAction("Senior");
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SRUNum,fName,lName,dob,address,postCode,phoneNum,email,doctor,doctorAddress,doctorPhone,position,healthissues,team,nok,nokTele")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                if (player.team == "Junior")
                {
                    return RedirectToAction("Junior");
                }
                else if (player.team == "Senior")
                {
                    return RedirectToAction("Senior");
                }
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction(player.team);
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
