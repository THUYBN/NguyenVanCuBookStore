//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using S3Train.Domain;
//using PagedList;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class PromotionsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Promotions
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
//                return View(db.Promotions.ToList().OrderBy(t => t.PromotionName).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/Promotions/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Promotion promotion = db.Promotions.Find(id);
//            if (promotion == null)
//            {
//                return HttpNotFound();
//            }
//            return View(promotion);
//        }

//        // GET: Admin/Promotions/Create
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

//        // POST: Admin/Promotions/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,PromotionName,StartTime,EndTime,CreatedDate,UpdatedDate,IsActive")] Promotion promotion)
//        {
//            if (ModelState.IsValid)
//            {
//                promotion.Id = Guid.NewGuid();
//                db.Promotions.Add(promotion);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(promotion);
//        }

//        // GET: Admin/Promotions/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Promotion promotion = db.Promotions.Find(id);
//            if (promotion == null)
//            {
//                return HttpNotFound();
//            }
//            return View(promotion);
//        }

//        // POST: Admin/Promotions/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,PromotionName,StartTime,EndTime,CreatedDate,UpdatedDate,IsActive")] Promotion promotion)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(promotion).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(promotion);
//        }

//        // GET: Admin/Promotions/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Promotion promotion = db.Promotions.Find(id);
//            if (promotion == null)
//            {
//                return HttpNotFound();
//            }
//            return View(promotion);
//        }

//        // POST: Admin/Promotions/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Promotion promotion = db.Promotions.Find(id);
//            db.Promotions.Remove(promotion);
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
