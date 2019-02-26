
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using new_assignment.Models;
using Microsoft.AspNet.Identity;

namespace new_assignment.Controllers
{
    public class finalordersController : Controller
    {
        private AssignmentEntities db = new AssignmentEntities();

        // GET: finalorders
        public ActionResult Index()
        {
            return View(db.finalorders.ToList());
        }

        public ActionResult SendEmail() {  
    return View();  
}  


        // GET: finalorders/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            finalorder finalorder = db.finalorders.Find(id);
            if (finalorder == null)
            {
                return HttpNotFound();
            }
            return View(finalorder);
        }

        // GET: finalorders/Create
        public ActionResult Create(decimal price)
        {
            string guest = Request.QueryString["guest"];
            ViewBag.price = price;
            ViewBag.guest = int.Parse(guest);
            return View();
        }

        // POST: finalorders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Phone_number,Email,Address,Party_date,Party_time")] finalorder finalorder)
        {
            if (User.Identity.GetUserId()==null)
            {
                ModelState.AddModelError("Error", "Please...Login to continue.");
                ViewBag.Name = new SelectList(db.finalorders, "Name", "Name");
                return RedirectToAction("Login","Account");
            }
            else
            {
                finalorder.id = Guid.NewGuid();
                db.finalorders.Add(finalorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finalorder);
        }

        // GET: finalorders/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            finalorder finalorder = db.finalorders.Find(id);
            if (finalorder == null)
            {
                return HttpNotFound();
            }
            return View(finalorder);
        }

        // POST: finalorders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Phone_number,Email,Address,Party_date,Party_time")] finalorder finalorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finalorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finalorder);
        }

        // GET: finalorders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            finalorder finalorder = db.finalorders.Find(id);
            if (finalorder == null)
            {
                return HttpNotFound();
            }
            return View(finalorder);
        }

        // POST: finalorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            finalorder finalorder = db.finalorders.Find(id);
            db.finalorders.Remove(finalorder);
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
