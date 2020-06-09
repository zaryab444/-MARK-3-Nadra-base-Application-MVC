using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work.Models;

namespace Work.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private InformationEntities db = new InformationEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            Datum user = new Datum();
            return View(user);
        }
        [HttpPost]
        public ActionResult Registration(Datum uvm)
        {
            using (InformationEntities apmodel = new InformationEntities())
            {
                if (apmodel.Data.Any(x => x.Name == uvm.Name ))
                {
                    ViewBag.DuplicateMessage = "Already exist";
                    return View("Registration", uvm);


                }
                apmodel.Data.Add(uvm);
                apmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.sucessMessage = "Registration Completed";
            return View("Registration", new Datum());





        }
        public ActionResult Create()
        {
            return View();
        }

       
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Person_ID,Name,Father_Name,Gender,Identity_Number,Date_of_Birth")] Datum datum)
        {
            if (ModelState.IsValid)
            {
                db.Data.Add(datum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datum);
        }

    }
}