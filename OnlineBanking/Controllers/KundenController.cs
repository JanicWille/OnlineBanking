using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.DAL;
using OnlineBanking.Models;

namespace OnlineBanking.Controllers
{
    public class KundenController : Controller
    {
        private BankingContext db = new BankingContext();

        // GET: Kunden
        public ActionResult Index()
        {
            return View(db.Kunde.ToList());
        }

        // GET: Kunden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // GET: Kunden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kunden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nachname,Vorname,Geburtsdatum")] Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                db.Kunde.Add(kunde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kunde);
        }

        // GET: Kunden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // POST: Kunden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nachname,Vorname,Geburtsdatum")] Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kunde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kunde);
        }

        // GET: Kunden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // POST: Kunden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kunde kunde = db.Kunde.Find(id);
            db.Kunde.Remove(kunde);
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
