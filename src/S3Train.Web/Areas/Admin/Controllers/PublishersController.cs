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
//using PagedList.Mvc;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class PublishersController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Publishers
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
//                return View(db.Publishers.ToList().OrderBy(t => t.NamePublisher).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/Publishers/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Publisher publisher = db.Publishers.Find(id);
//            if (publisher == null)
//            {
//                return HttpNotFound();
//            }
//            return View(publisher);
//        }

//        // GET: Admin/Publishers/Create
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

//        // POST: Admin/Publishers/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,NamePublisher,CreatedDate,UpdatedDate,IsActive")] Publisher publisher)
//        {
//            if (ModelState.IsValid)
//            {
//                publisher.Id = Guid.NewGuid();
//                db.Publishers.Add(publisher);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(publisher);
//        }

//        // GET: Admin/Publishers/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Publisher publisher = db.Publishers.Find(id);
//            if (publisher == null)
//            {
//                return HttpNotFound();
//            }
//            return View(publisher);
//        }

//        // POST: Admin/Publishers/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,NamePublisher,CreatedDate,UpdatedDate,IsActive")] Publisher publisher)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(publisher).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(publisher);
//        }

//        // GET: Admin/Publishers/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Publisher publisher = db.Publishers.Find(id);
//            if (publisher == null)
//            {
//                return HttpNotFound();
//            }
//            return View(publisher);
//        }

//        // POST: Admin/Publishers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Publisher publisher = db.Publishers.Find(id);
//            db.Publishers.Remove(publisher);
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
