using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Work.Models;

namespace Work.Controllers
{
    public class UserdataController : Controller
    {
        private InformationEntities db = new InformationEntities();

        // GET: /Userdata/
        public ActionResult Index()
        {
            return View(db.Data.ToList());
        }

        // GET: /Userdata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = db.Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // GET: /Userdata/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Person_ID,Name,Father_Name,Gender,Identity_Number,Date_of_Birth")] Datum datum)
        {
            using (InformationEntities apmodel = new InformationEntities())
            {

                //
                if (ModelState.IsValid)
                {
                    db.Data.Add(datum);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(datum);
            }
        }

        // GET: /Userdata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = db.Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: /Userdata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Person_ID,Name,Father_Name,Gender,Identity_Number,Date_of_Birth")] Datum datum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datum);
        }

        // GET: /Userdata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = db.Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: /Userdata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datum datum = db.Data.Find(id);
            db.Data.Remove(datum);
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
