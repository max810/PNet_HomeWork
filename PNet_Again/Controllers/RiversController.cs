using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PNet_HomeWork.Models;

namespace PNet_Again.Controllers
{
    public class RiversController : Controller
    {
        private WorldContext db = new WorldContext();

        // GET: Rivers
        public ActionResult Index()
        {
            return View(db.Rivers.ToList());
        }

        // GET: Rivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            River river = db.Rivers.Find(id);
            if (river == null)
            {
                return HttpNotFound();
            }
            return View(river);
        }

        // GET: Rivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RiverId,Name")] River river)
        {
            if (ModelState.IsValid)
            {
                db.Rivers.Add(river);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(river);
        }

        // GET: Rivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            River river = db.Rivers.Find(id);
            if (river == null)
            {
                return HttpNotFound();
            }
            return View(river);
        }

        // POST: Rivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RiverId,Name")] River river)
        {
            if (ModelState.IsValid)
            {
                db.Entry(river).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(river);
        }

        // GET: Rivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            River river = db.Rivers.Find(id);
            if (river == null)
            {
                return HttpNotFound();
            }
            return View(river);
        }

        // POST: Rivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            River river = db.Rivers.Find(id);
            db.Rivers.Remove(river);
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
