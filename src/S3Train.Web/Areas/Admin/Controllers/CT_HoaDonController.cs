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
    public class CT_HoaDonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CT_HoaDon
        public ActionResult Index(Guid? id)
        {
            var cT_HoaDons = db.CT_HoaDons.Include(c => c.HoaDon).Include(c => c.SanPham).Where(c => c.MaHD == id);
            return View(cT_HoaDons.ToList());
        }

        // GET: Admin/CT_HoaDon/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDons.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDon);
        }

        // GET: Admin/CT_HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "Id", "ApplicationUserId");
            ViewBag.MaSP = new SelectList(db.SanPhams, "Id", "TenSP");
            return View();
        }

        // POST: Admin/CT_HoaDon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaSP,MaHD,SoLuong,ThanhTien,Gia")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                cT_HoaDon.Id = Guid.NewGuid();
                db.CT_HoaDons.Add(cT_HoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDons, "Id", "ApplicationUserId", cT_HoaDon.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "Id", "TenSP", cT_HoaDon.MaSP);
            return View(cT_HoaDon);
        }

        // GET: Admin/CT_HoaDon/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDons.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "Id", "ApplicationUserId", cT_HoaDon.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "Id", "TenSP", cT_HoaDon.MaSP);
            return View(cT_HoaDon);
        }

        // POST: Admin/CT_HoaDon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaSP,MaHD,SoLuong,ThanhTien,Gia")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "Id", "ApplicationUserId", cT_HoaDon.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "Id", "TenSP", cT_HoaDon.MaSP);
            return View(cT_HoaDon);
        }

        // GET: Admin/CT_HoaDon/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDons.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDon);
        }

        // POST: Admin/CT_HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CT_HoaDon cT_HoaDon = db.CT_HoaDons.Find(id);
            db.CT_HoaDons.Remove(cT_HoaDon);
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
