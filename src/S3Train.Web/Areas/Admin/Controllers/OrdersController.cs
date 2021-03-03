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
//    public class OrdersController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Orders
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                var orders = db.Orders.Include(o => o.ApplicationUser);
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(orders.ToList().OrderBy(t => t.DatePayment).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/Orders/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Order order = db.Orders.Find(id);
//            if (order == null)
//            {
//                return HttpNotFound();
//            }
//            return View(order);
//        }

//        // GET: Admin/Orders/Create
//        public ActionResult Create()
//        {
//            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FullName");
//            return View();
//        }

//        // POST: Admin/Orders/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,DatePayment,Status,Note,TotalMoney,ApplicationUserId,CreatedDate,UpdatedDate,IsActive")] Order order)
//        {
//            if (ModelState.IsValid)
//            {
//                order.Id = Guid.NewGuid();
//                db.Orders.Add(order);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FullName", order.ApplicationUserId);
//            return View(order);
//        }

//        // GET: Admin/Orders/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Order order = db.Orders.Find(id);
//            if (order == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FullName", order.ApplicationUserId);
//            return View(order);
//        }

//        // POST: Admin/Orders/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,DatePayment,Status,Note,TotalMoney,ApplicationUserId,CreatedDate,UpdatedDate,IsActive")] Order order)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(order).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FullName", order.ApplicationUserId);
//            return View(order);
//        }

//        // GET: Admin/Orders/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Order order = db.Orders.Find(id);
//            if (order == null)
//            {
//                return HttpNotFound();
//            }
//            return View(order);
//        }

//        // POST: Admin/Orders/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Order order = db.Orders.Find(id);
//            db.Orders.Remove(order);
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
