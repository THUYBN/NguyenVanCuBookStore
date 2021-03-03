using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        //[Authorize]
        // GET: Admin/HomeAdmin
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(Guid? user)
        {
            if (Session["tendn"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var l = Session["tendn"].ToString();
                user = db.NhanViens.Where(m => m.TenDN == l).Select(m => m.Id).SingleOrDefault();
                if (user == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                NhanVien nv = db.NhanViens.Find(user);
                if (nv == null)
                {
                    return HttpNotFound();
                }
                return View(nv);
            }
        }

        public ActionResult TK(Guid? user)
        {
            if (Session["tendn"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var l = Session["tendn"].ToString();
                user = db.NhanViens.Where(m => m.TenDN == l).Select(m => m.Id).SingleOrDefault();
                if (user == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                NhanVien nv = db.NhanViens.Find(user);
                if (nv == null)
                {
                    return HttpNotFound();
                }
                return View(nv);
            }
        }

        public ActionResult ChangePassword(Guid? user)
        {
            var l = Session["tendn"].ToString();
            user = db.NhanViens.Where(m => m.TenDN == l).Select(m => m.Id).SingleOrDefault();
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(user);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "Id", "TenCV", nhanVien.MaCV);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", nhanVien.MaNhom);
            return View(nhanVien);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "Id,MaCV,TenNV,HinhAnh,DiaChi,GioiTinh,NgaySinh,SDT,Email,Password,MaNhom,CMND,TrangThai,TenDN")] NhanVien nhanVien, Guid? user, string Mkm, string Mkc, string Mkn)
        {
            ViewBag.MaCV = new SelectList(db.ChucVus, "Id", "TenCV", nhanVien.MaCV);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", nhanVien.MaNhom);
            var l = Session["tendn"].ToString();
            var pass = db.NhanViens.Where(m => m.TenDN == l).Select(m => m.Password).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (Mkc != pass)
                {
                    ViewBag.mk = "Sai mật khẩu";
                    TempData["Message"] = "Sai mật khẩu";
                    return RedirectToAction("ChangePassword");
                }
                else 
                {
                    if (Mkc == Mkm)
                    {
                        TempData["Message"] = "Không được đặt trùng mật khẩu cũ";
                        return RedirectToAction("ChangePassword");
                    } 
                    else if(Mkn != Mkm)
                    {
                        TempData["Message"] = "Mật khẩu không trùng khớp";
                        return RedirectToAction("ChangePassword");
                    }
                    else
                    {
                        nhanVien.Password = Mkm;
                        db.Entry(nhanVien).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("TK");
                    }   
                }
            }
            return View(nhanVien);
        }
    }
}