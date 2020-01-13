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
    public class NamestajController : Controller
    {
        private SalonDBEntities db = new SalonDBEntities();

        // GET: Namestaj
        public ActionResult Index()
        {
            return View(db.tbl_Namestaj.ToList());
        }

        // GET: Namestaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Namestaj tbl_Namestaj = db.tbl_Namestaj.Find(id);
            if (tbl_Namestaj == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Namestaj);
        }

        // GET: Namestaj/Create
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult IsUnique(string Naziv)
        {
            bool isOccupied = db.tbl_Namestaj.Where(x => x.Naziv.Equals(Naziv)).Count() == 0;
            return Json(isOccupied, JsonRequestBehavior.AllowGet);
        }

        // POST: Namestaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Opis")] tbl_Namestaj tbl_Namestaj)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Namestaj.Add(tbl_Namestaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Namestaj);
        }

        // GET: Namestaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Namestaj tbl_Namestaj = db.tbl_Namestaj.Find(id);
            if (tbl_Namestaj == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Namestaj);
        }

        // POST: Namestaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Opis")] tbl_Namestaj tbl_Namestaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Namestaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Namestaj);
        }

        // GET: Namestaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Namestaj tbl_Namestaj = db.tbl_Namestaj.Find(id);
            if (tbl_Namestaj == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Namestaj);
        }

        // POST: Namestaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Namestaj tbl_Namestaj = db.tbl_Namestaj.Find(id);
            db.tbl_Namestaj.Remove(tbl_Namestaj);
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
