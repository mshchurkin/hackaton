using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hackaton;

namespace hackaton.Controllers
{
    public class CargoController : Controller
    {
        private ShipmentsContainer cont = new ShipmentsContainer();

        // GET: /Cargo/
        public ActionResult Index()
        {
            return View(cont.CargoSet.ToList());
        }

        // GET: /Cargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = cont.CargoSet.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: /Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,GeoLat,GeoLong")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cont.CargoSet.Add(cargo);
                cont.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: /Cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = cont.CargoSet.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: /Cargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,GeoLat,GeoLong")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cont.Entry(cargo).State = EntityState.Modified;
                cont.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        // GET: /Cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = cont.CargoSet.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: /Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = cont.CargoSet.Find(id);
            cont.CargoSet.Remove(cargo);
            cont.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cont.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
