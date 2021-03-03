//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using S3Train.Domain;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class OrderDetailsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/OrderDetails
//        public ActionResult Index(Guid? Id)
//        {
//            var orderDetails = db.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(o => o.OrderId == Id);
//            return View(orderDetails.ToList());
//        }

//        // GET: Admin/OrderDetails/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            OrderDetail orderDetail = db.OrderDetails.Find(id);
//            if (orderDetail == null)
//            {
//                return HttpNotFound();
//            }
//            return View(orderDetail);
//        }

//        // GET: Admin/OrderDetails/Create
//        public ActionResult Create()
//        {
//            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Status");
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
//            return View();
//        }

//        // POST: Admin/OrderDetails/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,OrderId,ProductId,OrderQuantity,Price,Total,CreatedDate,UpdatedDate,IsActive")] OrderDetail orderDetail)
//        {
//            if (ModelState.IsValid)
//            {
//                orderDetail.Id = Guid.NewGuid();
//                db.OrderDetails.Add(orderDetail);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Status", orderDetail.OrderId);
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", orderDetail.ProductId);
//            return View(orderDetail);
//        }

//        // GET: Admin/OrderDetails/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            OrderDetail orderDetail = db.OrderDetails.Find(id);
//            if (orderDetail == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Status", orderDetail.OrderId);
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", orderDetail.ProductId);
//            return View(orderDetail);
//        }

//        // POST: Admin/OrderDetails/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,OrderId,ProductId,OrderQuantity,Price,Total,CreatedDate,UpdatedDate,IsActive")] OrderDetail orderDetail)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(orderDetail).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Status", orderDetail.OrderId);
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", orderDetail.ProductId);
//            return View(orderDetail);
//        }

//        // GET: Admin/OrderDetails/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            OrderDetail orderDetail = db.OrderDetails.Find(id);
//            if (orderDetail == null)
//            {
//                return HttpNotFound();
//            }
//            return View(orderDetail);
//        }

//        // POST: Admin/OrderDetails/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            OrderDetail orderDetail = db.OrderDetails.Find(id);
//            db.OrderDetails.Remove(orderDetail);
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
