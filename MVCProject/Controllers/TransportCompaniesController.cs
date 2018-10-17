using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProject.EF;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class TransportCompaniesController : Controller
    {
        private TransportsDbContext db = new TransportsDbContext();

        // GET: TransportCompanies
        public ActionResult Index()
        {
            return View(db.TransportCompanies.Include(tc => tc.Transports).ToList());
        }

        // GET: TransportCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportCompany transportCompany = db.TransportCompanies.Find(id);
            if (transportCompany == null)
            {
                return HttpNotFound();
            }
            return View(transportCompany);
        }

        // GET: TransportCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TransportCompany transportCompany)
        {
            if (ModelState.IsValid)
            {
                db.TransportCompanies.Add(transportCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportCompany);
        }

        // GET: TransportCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportCompany transportCompany = db.TransportCompanies.Find(id);
            if (transportCompany == null)
            {
                return HttpNotFound();
            }
            return View(transportCompany);
        }

        // POST: TransportCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TransportCompany transportCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportCompany);
        }

        // GET: TransportCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportCompany transportCompany = db.TransportCompanies.Find(id);
            if (transportCompany == null)
            {
                return HttpNotFound();
            }
            return View(transportCompany);
        }

        // POST: TransportCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportCompany transportCompany = db.TransportCompanies.Find(id);
            db.TransportCompanies.Remove(transportCompany);
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
