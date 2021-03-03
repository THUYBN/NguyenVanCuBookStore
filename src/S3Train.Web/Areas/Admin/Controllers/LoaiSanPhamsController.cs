using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;
using S3Train.Domain;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class LoaiSanPhamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/LoaiSanPhams
        public ActionResult Index(int? page)
        {
            var loaiSanPhams = db.LoaiSanPhams.Include(l => l.PhanLoai);
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(loaiSanPhams.ToList().OrderBy(t => t.TenLoai).ToPagedList(pageNumber, pageSize));

        }

        // GET: Admin/LoaiSanPhams/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "Id", "TenPhanLoai");
            return View();
        }

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenLoai,MaPhanLoai")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                loaiSanPham.Id = Guid.NewGuid();
                db.LoaiSanPhams.Add(loaiSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "Id", "TenPhanLoai", loaiSanPham.MaPhanLoai);
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "Id", "TenPhanLoai", loaiSanPham.MaPhanLoai);
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenLoai,MaPhanLoai")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "Id", "TenPhanLoai", loaiSanPham.MaPhanLoai);
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            db.LoaiSanPhams.Remove(loaiSanPham);
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
