using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S3Train.Domain;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class NgonNgusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/NgonNgus
        public ActionResult Index()
        {
            return View(db.NgonNgus.ToList());
        }

        // GET: Admin/NgonNgus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NgonNgu ngonNgu = db.NgonNgus.Find(id);
            if (ngonNgu == null)
            {
                return HttpNotFound();
            }
            return View(ngonNgu);
        }

        // GET: Admin/NgonNgus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NgonNgus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenNN")] NgonNgu ngonNgu)
        {
            if (ModelState.IsValid)
            {
                ngonNgu.Id = Guid.NewGuid();
                db.NgonNgus.Add(ngonNgu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ngonNgu);
        }

        // GET: Admin/NgonNgus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NgonNgu ngonNgu = db.NgonNgus.Find(id);
            if (ngonNgu == null)
            {
                return HttpNotFound();
            }
            return View(ngonNgu);
        }

        // POST: Admin/NgonNgus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenNN")] NgonNgu ngonNgu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ngonNgu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ngonNgu);
        }

        // GET: Admin/NgonNgus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NgonNgu ngonNgu = db.NgonNgus.Find(id);
            if (ngonNgu == null)
            {
                return HttpNotFound();
            }
            return View(ngonNgu);
        }

        // POST: Admin/NgonNgus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NgonNgu ngonNgu = db.NgonNgus.Find(id);
            db.NgonNgus.Remove(ngonNgu);
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
