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
    public class ChucNangsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ChucNangs
        public ActionResult Index()
        {
            return View(db.ChucNangs.ToList());
        }

        // GET: Admin/ChucNangs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucNang chucNang = db.ChucNangs.Find(id);
            if (chucNang == null)
            {
                return HttpNotFound();
            }
            return View(chucNang);
        }

        // GET: Admin/ChucNangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChucNangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenCN")] ChucNang chucNang)
        {
            if (ModelState.IsValid)
            {
                chucNang.Id = Guid.NewGuid();
                db.ChucNangs.Add(chucNang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucNang);
        }

        // GET: Admin/ChucNangs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucNang chucNang = db.ChucNangs.Find(id);
            if (chucNang == null)
            {
                return HttpNotFound();
            }
            return View(chucNang);
        }

        // POST: Admin/ChucNangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenCN")] ChucNang chucNang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucNang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucNang);
        }

        // GET: Admin/ChucNangs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucNang chucNang = db.ChucNangs.Find(id);
            if (chucNang == null)
            {
                return HttpNotFound();
            }
            return View(chucNang);
        }

        // POST: Admin/ChucNangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ChucNang chucNang = db.ChucNangs.Find(id);
            db.ChucNangs.Remove(chucNang);
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
