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
    public class CapQuyensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 
        // GET: Admin/CapQuyens
        public ActionResult Index()
        {
            var capQuyens = db.CapQuyens.Include(c => c.ChucNang).Include(c => c.NhomNguoiDung);
            return View(capQuyens.ToList());
        }

        // GET: Admin/CapQuyens/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapQuyen capQuyen = db.CapQuyens.Find(id);
            if (capQuyen == null)
            {
                return HttpNotFound();
            }
            return View(capQuyen);
        }

        // GET: Admin/CapQuyens/Create
        public ActionResult Create()
        {
            ViewBag.MaCN = new SelectList(db.ChucNangs, "Id", "TenCN");
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom");
            return View();
        }

        // POST: Admin/CapQuyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaNhom,MaCN")] CapQuyen capQuyen)
        {
            if (ModelState.IsValid)
            {
                capQuyen.Id = Guid.NewGuid();
                db.CapQuyens.Add(capQuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCN = new SelectList(db.ChucNangs, "Id", "TenCN", capQuyen.MaCN);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", capQuyen.MaNhom);
            return View(capQuyen);
        }

        // GET: Admin/CapQuyens/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapQuyen capQuyen = db.CapQuyens.Find(id);
            if (capQuyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCN = new SelectList(db.ChucNangs, "Id", "TenCN", capQuyen.MaCN);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", capQuyen.MaNhom);
            return View(capQuyen);
        }

        // POST: Admin/CapQuyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaNhom,MaCN")] CapQuyen capQuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capQuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCN = new SelectList(db.ChucNangs, "Id", "TenCN", capQuyen.MaCN);
            ViewBag.MaNhom = new SelectList(db.NhomNguoiDungs, "Id", "TenNhom", capQuyen.MaNhom);
            return View(capQuyen);
        }

        // GET: Admin/CapQuyens/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapQuyen capQuyen = db.CapQuyens.Find(id);
            if (capQuyen == null)
            {
                return HttpNotFound();
            }
            return View(capQuyen);
        }

        // POST: Admin/CapQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CapQuyen capQuyen = db.CapQuyens.Find(id);
            db.CapQuyens.Remove(capQuyen);
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
