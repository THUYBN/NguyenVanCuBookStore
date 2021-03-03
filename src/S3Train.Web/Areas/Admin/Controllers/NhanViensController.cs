using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using S3Train.Domain;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class NhanViensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/NhanViens
        public ActionResult Index(int? page, string search)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            if (search == null)
            {
                var nhanViens = db.NhanViens.Include(n => n.ChucVu).Include(n => n.NhomNguoiDung);
                return View(nhanViens.ToList().OrderBy(t => t.TenNV).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var nhanViens = db.NhanViens.Include(n => n.ChucVu).Include(n => n.NhomNguoiDung).Where(n=>n.TenNV.Contains(search)||n.TenDN.Contains(search));
                return View(nhanViens.ToList().OrderBy(t => t.TenNV).ToPagedList(pageNumber, pageSize));
            }
            
        }

        // GET: Admin/NhanViens/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.MaCV = new SelectList(db.ChucVus, "Id", "TenCV");
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom");
            return View();
        }

        // POST: Admin/NhanViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaCV,TenNV,HinhAnh,DiaChi,GioiTinh,NgaySinh,SDT,Email,Password,MaNhom,CMND,TrangThai,TenDN")] NhanVien nhanVien, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.Notification = "Chọn ảnh";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Luu ten file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan
                var path = Path.Combine(Server.MapPath("~/ImagePD"), fileName);
                //KT HINH ANH TON TAI CHUA
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Notification = "Ảnh bị trùng ";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                nhanVien.Id = Guid.NewGuid();
                nhanVien.HinhAnh = fileName;
                nhanVien.TrangThai = true;
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCV = new SelectList(db.ChucVus, "Id", "TenCV", nhanVien.MaCV);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", nhanVien.MaNhom);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "Id", "TenCV", nhanVien.MaCV);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", nhanVien.MaNhom);
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaCV,TenNV,HinhAnh,DiaChi,GioiTinh,NgaySinh,SDT,Email,Password,MaNhom,CMND,TrangThai,TenDN")] NhanVien nhanVien, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fileUpload != null)
                {
                    //Luu ten file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan
                    var path = Path.Combine(Server.MapPath("~/ImagePD"), fileName);
                    //KT HINH ANH TON TAI CHUA
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Notification = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    nhanVien.HinhAnh = fileName;
                }
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "Id", "TenCV", nhanVien.MaCV);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", nhanVien.MaNhom);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
