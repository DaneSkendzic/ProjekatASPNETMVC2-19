using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon_namestaja.Models;

namespace Salon_namestaja.Controllers
{
    public class SaloniController : Controller
    {
        private SalonDBEntities db = new SalonDBEntities();

        // GET: Saloni
        public ActionResult Index()
        {
            return View(db.tblSalons.ToList());
        }

        // GET: Saloni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSalon tblSalon = db.tblSalons.Find(id);
            if (tblSalon == null)
            {
                return HttpNotFound();
            }
            return View(tblSalon);
        }

        // GET: Saloni/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saloni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazic,Adresa,Telefon,Email,WebStranica,Pib,BrojZiroRacuna")] tblSalon tblSalon)
        {
            if (ModelState.IsValid)
            {
                db.tblSalons.Add(tblSalon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSalon);
        }

        // GET: Saloni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSalon tblSalon = db.tblSalons.Find(id);
            if (tblSalon == null)
            {
                return HttpNotFound();
            }
            return View(tblSalon);
        }

        // POST: Saloni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazic,Adresa,Telefon,Email,WebStranica,Pib,BrojZiroRacuna")] tblSalon tblSalon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSalon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSalon);
        }

        // GET: Saloni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSalon tblSalon = db.tblSalons.Find(id);
            if (tblSalon == null)
            {
                return HttpNotFound();
            }
            return View(tblSalon);
        }

        // POST: Saloni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSalon tblSalon = db.tblSalons.Find(id);
            db.tblSalons.Remove(tblSalon);
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
