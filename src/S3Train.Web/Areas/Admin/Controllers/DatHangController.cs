using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using S3Train.Domain;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class DatHangController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DatHang
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var hoaDons = db.HoaDons.Include(h => h.ApplicationUser).Include(h => h.PhuongThucThanhToan);
            return View(hoaDons.ToList().OrderBy(t => t.NgayLap).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DatHang/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/DatHang/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "HoTen");
            ViewBag.MaPhuongThuc = new SelectList(db.PhuongThucThanhToans, "Id", "TenPhuongThuc");
            return View();
        }

        // POST: Admin/DatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaPhuongThuc,ApplicationUserId,NgayLap,GhiChu,NgayCapNhat,TrangThai,TongTien")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                hoaDon.Id = Guid.NewGuid();
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "HoTen", hoaDon.ApplicationUserId);
            ViewBag.MaPhuongThuc = new SelectList(db.PhuongThucThanhToans, "Id", "TenPhuongThuc", hoaDon.MaPhuongThuc);
            return View(hoaDon);
        }

        // GET: Admin/DatHang/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "HoTen", hoaDon.ApplicationUserId);
            ViewBag.MaPhuongThuc = new SelectList(db.PhuongThucThanhToans, "Id", "TenPhuongThuc", hoaDon.MaPhuongThuc);
            return View(hoaDon);
        }

        // POST: Admin/DatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaPhuongThuc,ApplicationUserId,NgayLap,GhiChu,NgayCapNhat,TrangThai,TongTien")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "HoTen", hoaDon.ApplicationUserId);
            ViewBag.MaPhuongThuc = new SelectList(db.PhuongThucThanhToans, "Id", "TenPhuongThuc", hoaDon.MaPhuongThuc);
            return View(hoaDon);
        }

        // GET: Admin/DatHang/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/DatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
