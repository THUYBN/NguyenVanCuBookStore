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
//    public class CategoriesController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Categories
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
//                return View(db.Categories.ToList().OrderBy(t => t.NameCategory).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/Categories/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Category category = db.Categories.Find(id);
//            if (category == null)
//            {
//                return HttpNotFound();
//            }
//            return View(category);
//        }

//        // GET: Admin/Categories/Create
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

//        // POST: Admin/Categories/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,NameCategory,CreatedDate,UpdatedDate,IsActive")] Category category)
//        {
//            if (ModelState.IsValid)
//            {
//                category.Id = Guid.NewGuid();
//                db.Categories.Add(category);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(category);
//        }

//        // GET: Admin/Categories/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Category category = db.Categories.Find(id);
//            if (category == null)
//            {
//                return HttpNotFound();
//            }
//            return View(category);
//        }

//        // POST: Admin/Categories/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,NameCategory,CreatedDate,UpdatedDate,IsActive")] Category category)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(category).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(category);
//        }

//        // GET: Admin/Categories/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Category category = db.Categories.Find(id);
//            if (category == null)
//            {
//                return HttpNotFound();
//            }
//            return View(category);
//        }

//        // POST: Admin/Categories/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Category category = db.Categories.Find(id);
//            db.Categories.Remove(category);
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
