using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hackaton;
using hackaton.Models;

namespace hackaton.Controllers
{
    public class TransportController : Controller
    {
        private DataManager _DataManager;
        private ShipmentsContainer cont = new ShipmentsContainer();

        public TransportController(DataManager _DM)
        {
            _DataManager = _DM;
        }
        // GET: /Transport/
        public ActionResult Index()
        {
            return View(cont.TransportSet.ToList());
        }

        // GET: /Transport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = cont.TransportSet.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: /Transport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Transport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Source,Target,Mileage")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                cont.TransportSet.Add(transport);
                cont.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transport);
        }

        // GET: /Transport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = cont.TransportSet.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: /Transport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Source,Target,Mileage")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                cont.Entry(transport).State = EntityState.Modified;
                cont.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transport);
        }

        // GET: /Transport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = cont.TransportSet.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: /Transport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = cont.TransportSet.Find(id);
            cont.TransportSet.Remove(transport);
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
