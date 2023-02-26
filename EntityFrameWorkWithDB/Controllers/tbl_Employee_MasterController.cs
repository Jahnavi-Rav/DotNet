using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameWorkDB;

namespace EntityFrameWorkDB.Controllers
{
    public class tbl_Employee_MasterController : Controller
    {
        private DB_EmployeeEntities db = new DB_EmployeeEntities();

        // GET: tbl_Employee_Master
        public ActionResult Index()
        {
            return View(db.tbl_Employee_Master.ToList());
        }

        // GET: tbl_Employee_Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee_Master tbl_Employee_Master = db.tbl_Employee_Master.Find(id);
            if (tbl_Employee_Master == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee_Master);
        }

        // GET: tbl_Employee_Master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Employee_Master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Id,Employee_Name,Contact_No,Email,Address_Line1,Address_Line2,City,State,Country,Zip_Code,Active_Status")] tbl_Employee_Master tbl_Employee_Master)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Employee_Master.Add(tbl_Employee_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Employee_Master);
        }

        // GET: tbl_Employee_Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee_Master tbl_Employee_Master = db.tbl_Employee_Master.Find(id);
            if (tbl_Employee_Master == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee_Master);
        }

        // POST: tbl_Employee_Master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_Id,Employee_Name,Contact_No,Email,Address_Line1,Address_Line2,City,State,Country,Zip_Code,Active_Status")] tbl_Employee_Master tbl_Employee_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Employee_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Employee_Master);
        }

        // GET: tbl_Employee_Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee_Master tbl_Employee_Master = db.tbl_Employee_Master.Find(id);
            if (tbl_Employee_Master == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee_Master);
        }

        // POST: tbl_Employee_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Employee_Master tbl_Employee_Master = db.tbl_Employee_Master.Find(id);
            db.tbl_Employee_Master.Remove(tbl_Employee_Master);
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
