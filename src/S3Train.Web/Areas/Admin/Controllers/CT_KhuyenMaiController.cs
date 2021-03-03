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
    public class CT_KhuyenMaiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CT_KhuyenMai
        public ActionResult Index(int? page, Guid? id)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var cT_KhuyenMais = db.CT_KhuyenMais.Include(c => c.KhuyenMai).Include(c => c.SanPham).Where(c => c.MaKM == id);
            return View(cT_KhuyenMais.ToList().OrderBy(t => t.SanPham.TenSP).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/CT_KhuyenMai/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_KhuyenMai cT_KhuyenMai = db.CT_KhuyenMais.Find(id);
            if (cT_KhuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(cT_KhuyenMai);
        }

        public JsonResult GetListSP(Guid MaKM)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<HOCSINH> ListHSinh = (from ct in db.CT_LOPHOC
            //                           join h in db.HOCSINHs on ct.MaHS equals h.MaHS
            //                           where ct.MaLop == MaLop
            //                           select h).ToList();
            var ListHS = (from hs in db.SanPhams
                          where !(from ct in db.CT_KhuyenMais
                                  join h in db.SanPhams on ct.MaSP equals h.Id
                                  where ct.MaKM == MaKM
                                  select h.TenSP).Contains(hs.TenSP)
                          select hs);
            // select new { s.HoTen }))
            //db.HOCSINHs.Where(x => x.HoTen !=
            //(from s in db.HOCSINHs join ct in db.CT_LOPHOC on s.MaHS equals ct.MaHS where ct.MaLop == MaLop
            // select new { s.HoTen })).ToList();
            //List<CT_LOPHOC> ListHSinh = db.CT_LOPHOC.Where(x => x.MaLop == MaLop).ToList();
            List<SanPham> ListHSinh = ListHS.ToList();
            return Json(ListHSinh, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/CT_KhuyenMai/Create
        public ActionResult Create()
        {
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "Id", "TenKM");
            ViewBag.MaSP = new SelectList(db.SanPhams.Where(n=>n.NgayCapNhat!=null), "Id", "TenSP");
            return View();
        }

        // POST: Admin/CT_KhuyenMai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaSP,MaKM,SoLuong,PhanTramKM")] CT_KhuyenMai cT_KhuyenMai)
        {
            if (ModelState.IsValid)
            {
                cT_KhuyenMai.Id = Guid.NewGuid();
                db.CT_KhuyenMais.Add(cT_KhuyenMai);
                db.SaveChanges();
                return RedirectToAction("Index", "KhuyenMais");
            }

            ViewBag.MaKM = new SelectList(db.KhuyenMais, "Id", "TenKM", cT_KhuyenMai.MaKM);
            ViewBag.MaSP = new SelectList(db.SanPhams.Where(n => n.NgayCapNhat != null), "Id", "TenSP", cT_KhuyenMai.MaSP);
            return RedirectToAction("Index", "KhuyenMais");
        }

        // GET: Admin/CT_KhuyenMai/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_KhuyenMai cT_KhuyenMai = db.CT_KhuyenMais.Find(id);
            if (cT_KhuyenMai == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "Id", "TenKM", cT_KhuyenMai.MaKM);
            ViewBag.MaSP = new SelectList(db.SanPhams, "Id", "TenSP", cT_KhuyenMai.MaSP);
            return View(cT_KhuyenMai);
        }

        // POST: Admin/CT_KhuyenMai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaSP,MaKM,SoLuong,PhanTramKM")] CT_KhuyenMai cT_KhuyenMai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_KhuyenMai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "KhuyenMais");
            }
            ViewBag.MaKM = new SelectList(db.KhuyenMais, "Id", "TenKM", cT_KhuyenMai.MaKM);
            ViewBag.MaSP = new SelectList(db.SanPhams, "Id", "TenSP", cT_KhuyenMai.MaSP);
            return View(cT_KhuyenMai);
        }

        // GET: Admin/CT_KhuyenMai/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_KhuyenMai cT_KhuyenMai = db.CT_KhuyenMais.Find(id);
            if (cT_KhuyenMai == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "KhuyenMais");
        }

        // POST: Admin/CT_KhuyenMai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CT_KhuyenMai cT_KhuyenMai = db.CT_KhuyenMais.Find(id);
            db.CT_KhuyenMais.Remove(cT_KhuyenMai);
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
