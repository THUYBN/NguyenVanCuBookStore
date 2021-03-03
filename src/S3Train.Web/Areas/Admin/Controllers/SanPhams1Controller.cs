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
    public class SanPhams1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/SanPhams1
        public ActionResult Index(int? page, string search)
        {
            
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            if (search == null)
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).Include(s => s.NgonNgu).Include(s => s.NhaCungCap).Include(s => s.NhaSanXuat).Where(s => s.LoaiSanPham.PhanLoai.TenPhanLoai == "Văn Phòng Phẩm");
                return View(sanPhams.ToList().OrderBy(t => t.NgayCapNhat).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).Include(s => s.NgonNgu).Include(s => s.NhaCungCap).Include(s => s.NhaSanXuat).Where(s => s.LoaiSanPham.PhanLoai.TenPhanLoai == "Văn Phòng Phẩm" && (s.TenSP.Contains(search)||s.TacGia.Contains(search)));
                return View(sanPhams.ToList().OrderBy(t => t.NgayCapNhat).ToPagedList(pageNumber, pageSize));

            }

        }

        // GET: Admin/SanPhams1/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams1/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "Id", "TenLoai");
            ViewBag.MaNN = new SelectList(db.NgonNgus, "Id", "TenNN");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "Id", "TenNCC");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats, "Id", "TenNSX");
            return View();
        }

        // POST: Admin/SanPhams1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenSP,TacGia,Gia,HinhAnh,TrongLuong,SoLuong,SoTrang,KichThuoc,GhiChu,ChatLuong,MauSac,NgayTao,NgayCapNhat,TrangThai,MaNN,MaNSX,MaNCC,MaLoai,LuotXem")] SanPham sanPham, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "Id", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNN = new SelectList(db.NgonNgus, "Id", "TenNN", sanPham.MaNN);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "Id", "TenNCC", sanPham.MaNCC);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats, "Id", "TenNSX", sanPham.MaNSX);
            var nn = db.NgonNgus.Where(t => t.TenNN == "Việt Nam").Select(t => t.Id).SingleOrDefault();
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
                sanPham.Id = Guid.NewGuid();
                sanPham.HinhAnh = fileName;
                sanPham.MaNN = nn;
                sanPham.NgayTao = DateTime.Today;
                sanPham.LuotXem = 0;
                sanPham.TrangThai = true;
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(sanPham);
        }

        // GET: Admin/SanPhams1/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "Id", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNN = new SelectList(db.NgonNgus, "Id", "TenNN", sanPham.MaNN);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "Id", "TenNCC", sanPham.MaNCC);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats, "Id", "TenNSX", sanPham.MaNSX);
            return View(sanPham);
        }

        // POST: Admin/SanPhams1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenSP,TacGia,Gia,HinhAnh,TrongLuong,SoLuong,SoTrang,KichThuoc,GhiChu,ChatLuong,MauSac,NgayTao,NgayCapNhat,TrangThai,MaNN,MaNSX,MaNCC,MaLoai,LuotXem")] SanPham sanPham, HttpPostedFileBase fileUpload)
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
                    sanPham.HinhAnh = fileName;
                }
                var l = db.NgonNgus.Where(n => n.TenNN == "Việt Nam").Select(n => n.Id).FirstOrDefault();
                sanPham.LuotXem = 0;
                sanPham.MaNN = l;
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSanPhams, "Id", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNN = new SelectList(db.NgonNgus, "Id", "TenNN", sanPham.MaNN);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "Id", "TenNCC", sanPham.MaNCC);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats, "Id", "TenNSX", sanPham.MaNSX);
            return View(sanPham);
        }

        // GET: Admin/SanPhams1/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
