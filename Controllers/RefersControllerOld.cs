using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200Team3.DAL;
using MIS4200Team3.Models;

namespace MIS4200Team3.Controllers
{
    public class RefersControllerOld : Controller
    {
        private MIS4200Team3Context db = new MIS4200Team3Context();

        public IEnumerable Refers { get; private set; }

        // GET: Refers
        public ActionResult Index()
        {
            return View(db.Refers.ToList());
        }

        // GET: Refers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refer refer = db.Refers.Find(id);
            if (refer == null)
            {
                return HttpNotFound();
            }
            return View(refer);
        }

        // GET: Refers/Create
        [Authorize]
        public ActionResult Create()
        {
            //drop down code here
            var profile = db.Profiles.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            ViewBag.receiveID = new SelectList(profile, "ID", "fullName");
            return View();
        }

        // POST: Refers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "referneceID,firstName,lastName,employeeFirstName,employeeLastName,department,CompanyValue")] Refer refer)
        {
            if (ModelState.IsValid)
            {
                //grab the ID of the person logged in, linked to the profile6
                //id of the person who is receiving it
                Guid memberID;
              
                Guid.TryParse(User.Identity.GetUserId(), out memberID); //person GIVING reference (person logged in)
                refer.ID = memberID;
                db.Refers.Add(refer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var profile = db.Profiles.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            ViewBag.receiveID = new SelectList(profile, "ID", "fullName");
            return View(refer);
        }

        // GET: Refers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refer refer = db.Refers.Find(id);
            if (refer == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (refer.ID == memberID)
            {
                return View(refer);
            }
            else
            {
                return View("NotAuthenticated");
            }
        }

        // POST: Refers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "referneceID,firstName,lastName,employeeFirstName,employeeLastName,department,CompanyValue")] Refer refer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refer);
        }

        // GET: Refers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refer refer = db.Refers.Find(id);
            if (refer == null)
            {
                return HttpNotFound();
            }
            return View(refer);
        }

        // POST: Refers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refer refer = db.Refers.Find(id);
            db.Refers.Remove(refer);
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
