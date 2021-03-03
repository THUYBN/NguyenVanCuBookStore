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
//    public class PromotionDetailsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/PromotionDetails
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                var promotionDetails = db.PromotionDetails.Include(p => p.Product).Include(p => p.Promotion);
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(promotionDetails.ToList().OrderBy(t => t.CreatedDate).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/PromotionDetails/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PromotionDetail promotionDetail = db.PromotionDetails.Find(id);
//            if (promotionDetail == null)
//            {
//                return HttpNotFound();
//            }
//            return View(promotionDetail);
//        }

//        // GET: Admin/PromotionDetails/Create
//        public ActionResult Create()
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
//                ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "PromotionName");
//                return View();
//            }
//        }

//        // POST: Admin/PromotionDetails/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,ProductId,PromotionId,PromotionPercent,CreatedDate,UpdatedDate,IsActive")] PromotionDetail promotionDetail)
//        {
//            if (ModelState.IsValid)
//            {
//                promotionDetail.Id = Guid.NewGuid();
//                db.PromotionDetails.Add(promotionDetail);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", promotionDetail.ProductId);
//            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "PromotionName", promotionDetail.PromotionId);
//            return View(promotionDetail);
//        }

//        // GET: Admin/PromotionDetails/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PromotionDetail promotionDetail = db.PromotionDetails.Find(id);
//            if (promotionDetail == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", promotionDetail.ProductId);
//            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "PromotionName", promotionDetail.PromotionId);
//            return View(promotionDetail);
//        }

//        // POST: Admin/PromotionDetails/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,ProductId,PromotionId,PromotionPercent,CreatedDate,UpdatedDate,IsActive")] PromotionDetail promotionDetail)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(promotionDetail).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", promotionDetail.ProductId);
//            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "PromotionName", promotionDetail.PromotionId);
//            return View(promotionDetail);
//        }

//        // GET: Admin/PromotionDetails/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PromotionDetail promotionDetail = db.PromotionDetails.Find(id);
//            if (promotionDetail == null)
//            {
//                return HttpNotFound();
//            }
//            return View(promotionDetail);
//        }

//        // POST: Admin/PromotionDetails/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            PromotionDetail promotionDetail = db.PromotionDetails.Find(id);
//            db.PromotionDetails.Remove(promotionDetail);
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
