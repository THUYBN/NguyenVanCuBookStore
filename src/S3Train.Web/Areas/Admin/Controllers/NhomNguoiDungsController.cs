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
    public class NhomNguoiDungsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/NhomNguoiDungs
        public ActionResult Index()
        {
            return View(db.NhomNguoiDungs.ToList());
        }

        // GET: Admin/NhomNguoiDungs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomNguoiDung nhomNguoiDung = db.NhomNguoiDungs.Find(id);
            if (nhomNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nhomNguoiDung);
        }

        // GET: Admin/NhomNguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhomNguoiDungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenNhom")] NhomNguoiDung nhomNguoiDung)
        {
            if (ModelState.IsValid)
            {
                nhomNguoiDung.Id = Guid.NewGuid();
                db.NhomNguoiDungs.Add(nhomNguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomNguoiDung);
        }

        // GET: Admin/NhomNguoiDungs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomNguoiDung nhomNguoiDung = db.NhomNguoiDungs.Find(id);
            if (nhomNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nhomNguoiDung);
        }

        // POST: Admin/NhomNguoiDungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenNhom")] NhomNguoiDung nhomNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomNguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomNguoiDung);
        }

        // GET: Admin/NhomNguoiDungs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomNguoiDung nhomNguoiDung = db.NhomNguoiDungs.Find(id);
            if (nhomNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nhomNguoiDung);
        }

        // POST: Admin/NhomNguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NhomNguoiDung nhomNguoiDung = db.NhomNguoiDungs.Find(id);
            db.NhomNguoiDungs.Remove(nhomNguoiDung);
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
