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
    public class TransportsController : Controller
    {
        private TransportsDbContext db = new TransportsDbContext();

        public ActionResult Index()
        {
            return View(db.Transports.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        public ActionResult Create()
        {
            CreateTransportViewModel view = new CreateTransportViewModel();
            db.Transportations.ToList().ForEach(t => {
                view.Transportations.Add(new TransportationViewModel() { ID = t.ID, Name = $"{t.CityFrom} - {t.CityTo}" });
            });
            view.TransportCompanies = db.TransportCompanies.ToList();
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Number,DriverName,TransportationId,TransportCompanyId")] CreateTransportViewModel transport)
        {
            if (ModelState.IsValid)
            {
                Transport newTransport = new Transport()
                {
                    DriverName = transport.DriverName,
                    Number = transport.Number,
                    Transportation = db.Transportations.First(t => t.ID == transport.TransportationId),
                    TransportCompany = db.TransportCompanies.First(t => t.ID == transport.TransportCompanyId)
                };
                db.Transports.Add(newTransport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transport);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            CreateTransportViewModel view = new CreateTransportViewModel()
            {
                ID = transport.ID,
                DriverName = transport.DriverName,
                Number = transport.Number,
                TransportCompanies = db.TransportCompanies.ToList(),
                TransportationId = transport.TransportationId,
                TransportCompanyId = transport.TransportCompanyId
            };
            db.Transportations.ToList().ForEach(t => {
                view.Transportations.Add(new TransportationViewModel() { ID = t.ID, Name = $"{t.CityFrom} - {t.CityTo}" });
            });
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Number,DriverName,TransportationId,TransportCompanyId")] CreateTransportViewModel transport)
        {
            if (ModelState.IsValid)
            {
                Transport updatedTransport = new Transport()
                {
                    ID = transport.ID,
                    DriverName = transport.DriverName,
                    Number = transport.Number,
                    Transportation = db.Transportations.First(t => t.ID == transport.TransportationId),
                    TransportCompany = db.TransportCompanies.First(t => t.ID == transport.TransportCompanyId),
                    TransportCompanyId = transport.TransportCompanyId,
                    TransportationId = transport.TransportationId
                };
                db.Entry(updatedTransport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transport);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = db.Transports.Find(id);
            db.Transports.Remove(transport);
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
