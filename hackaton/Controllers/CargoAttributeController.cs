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
    public class CargoAttributeController : Controller
    {
        private ShipmentsContainer cont = new ShipmentsContainer();

        // GET: /CargoAttribute/
        public ActionResult Index()
        {
            return View(cont.CargoAttributeSet.ToList());
        }

        // GET: /CargoAttribute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoAttribute cargoattribute = cont.CargoAttributeSet.Find(id);
            if (cargoattribute == null)
            {
                return HttpNotFound();
            }
            return View(cargoattribute);
        }

        // GET: /CargoAttribute/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CargoAttribute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Attribute,Value")] CargoAttribute cargoattribute)
        {
            if (ModelState.IsValid)
            {
                cont.CargoAttributeSet.Add(cargoattribute);
                cont.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargoattribute);
        }

        // GET: /CargoAttribute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoAttribute cargoattribute = cont.CargoAttributeSet.Find(id);
            if (cargoattribute == null)
            {
                return HttpNotFound();
            }
            return View(cargoattribute);
        }

        // POST: /CargoAttribute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Attribute,Value")] CargoAttribute cargoattribute)
        {
            if (ModelState.IsValid)
            {
                cont.Entry(cargoattribute).State = EntityState.Modified;
                cont.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargoattribute);
        }

        // GET: /CargoAttribute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoAttribute cargoattribute = cont.CargoAttributeSet.Find(id);
            if (cargoattribute == null)
            {
                return HttpNotFound();
            }
            return View(cargoattribute);
        }

        // POST: /CargoAttribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CargoAttribute cargoattribute = cont.CargoAttributeSet.Find(id);
            cont.CargoAttributeSet.Remove(cargoattribute);
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
