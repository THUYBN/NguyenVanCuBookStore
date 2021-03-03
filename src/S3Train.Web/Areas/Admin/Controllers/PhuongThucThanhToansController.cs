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
    public class PhuongThucThanhToansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PhuongThucThanhToans
        public ActionResult Index()
        {
            return View(db.PhuongThucThanhToans.ToList());
        }

        // GET: Admin/PhuongThucThanhToans/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhuongThucThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenPhuongThuc")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                phuongThucThanhToan.Id = Guid.NewGuid();
                db.PhuongThucThanhToans.Add(phuongThucThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(phuongThucThanhToan);
        }

        // POST: Admin/PhuongThucThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenPhuongThuc")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phuongThucThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(phuongThucThanhToan);
        }

        // POST: Admin/PhuongThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            db.PhuongThucThanhToans.Remove(phuongThucThanhToan);
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
