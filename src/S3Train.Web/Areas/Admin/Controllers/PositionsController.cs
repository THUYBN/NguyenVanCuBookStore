//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using PagedList;
//using S3Train.Domain;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class PositionsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Positions
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(db.Positions.ToList().OrderBy(t => t.NamePosition).ToPagedList(pageNumber, pageSize));
//            }
                
//        }

//        // GET: Admin/Positions/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ChucVu position = db.Positions.Find(id);
//            if (position == null)
//            {
//                return HttpNotFound();
//            }
//            return View(position);
//        }

//        // GET: Admin/Positions/Create
//        public ActionResult Create()
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                return View();
//            }
            
//        }

//        // POST: Admin/Positions/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,NamePosition,CreatedDate,UpdatedDate,IsActive")] ChucVu position)
//        {
//            if (ModelState.IsValid)
//            {
//                position.Id = Guid.NewGuid();
//                db.Positions.Add(position);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(position);
//        }

//        // GET: Admin/Positions/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ChucVu position = db.Positions.Find(id);
//            if (position == null)
//            {
//                return HttpNotFound();
//            }
//            return View(position);
//        }

//        // POST: Admin/Positions/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,NamePosition,CreatedDate,UpdatedDate,IsActive")] ChucVu position)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(position).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(position);
//        }

//        // GET: Admin/Positions/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ChucVu position = db.Positions.Find(id);
//            if (position == null)
//            {
//                return HttpNotFound();
//            }
//            return View(position);
//        }

//        // POST: Admin/Positions/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            ChucVu position = db.Positions.Find(id);
//            db.Positions.Remove(position);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
