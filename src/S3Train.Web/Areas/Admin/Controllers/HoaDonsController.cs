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
    public class HoaDonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/HoaDons
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var hoaDons = db.HoaDons.Include(h => h.ApplicationUser).Include(h => h.PhuongThucThanhToan);
            return View(hoaDons.ToList().OrderBy(t => t.NgayLap).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/HoaDons/Details/5
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

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "HoTen");
            ViewBag.MaPhuongThuc = new SelectList(db.PhuongThucThanhToans, "Id", "TenPhuongThuc");
            return View();
        }

        // POST: Admin/HoaDons/Create
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

        // GET: Admin/HoaDons/Edit/5
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
            List<SelectListItem> dropdownItems1 = new List<SelectListItem>();
            dropdownItems1.AddRange(new[]{
                               new SelectListItem() { Text = "Đã xác nhận", Value = "Đã xác nhận" },
                               new SelectListItem() { Text = "Đang giao hàng", Value = "Đang giao hàng" },
                               new SelectListItem() { Text = "Đã thanh toán", Value = "Đã thanh toán" },
                               new SelectListItem() { Text = "Giao thành công", Value = "Giao thành công" } });

            ViewData.Add("DropDownItems1", dropdownItems1);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaPhuongThuc,ApplicationUserId,NgayLap,GhiChu,NgayCapNhat,TrangThai,TongTien")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                hoaDon.NgayCapNhat = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> dropdownItems1 = new List<SelectListItem>();
            dropdownItems1.AddRange(new[]{
                               new SelectListItem() { Text = "Đã xác nhận", Value = "Đã xác nhận" },
                               new SelectListItem() { Text = "Đang giao hàng", Value = "Đang giao hàng" },
                               new SelectListItem() { Text = "Đã thanh toán", Value = "Đã thanh toán" },
                               new SelectListItem() { Text = "Giao thành công", Value = "Giao thành công" } });

            ViewData.Add("DropDownItems1", dropdownItems1);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "HoTen", hoaDon.ApplicationUserId);
            ViewBag.MaPhuongThuc = new SelectList(db.PhuongThucThanhToans, "Id", "TenPhuongThuc", hoaDon.MaPhuongThuc);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
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

        // POST: Admin/HoaDons/Delete/5
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
