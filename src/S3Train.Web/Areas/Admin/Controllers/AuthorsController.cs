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
//using System.IO;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class AuthorsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Authors
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
//                return View(db.Authors.ToList().OrderBy(t => t.NameAuthor).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/Authors/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Author author = db.Authors.Find(id);
//            if (author == null)
//            {
//                return HttpNotFound();
//            }
//            return View(author);
//        }

//        // GET: Admin/Authors/Create
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

//        // POST: Admin/Authors/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [ValidateInput(false)]
//        public ActionResult Create([Bind(Include = "Id,NameAuthor,CreatedDate,UpdatedDate,IsActive")] Author author)
//        {
//            if (ModelState.IsValid)
//            {
//                author.Id = Guid.NewGuid();
//                db.Authors.Add(author);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(author);
//        }

//        // GET: Admin/Authors/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Author author = db.Authors.Find(id);
//            if (author == null)
//            {
//                return HttpNotFound();
//            }
//            return View(author);
//        }

//        // POST: Admin/Authors/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,NameAuthor,CreatedDate,UpdatedDate,IsActive")] Author author)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(author).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(author);
//        }

//        // GET: Admin/Authors/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Author author = db.Authors.Find(id);
//            if (author == null)
//            {
//                return HttpNotFound();
//            }
//            return View(author);
//        }

//        // POST: Admin/Authors/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Author author = db.Authors.Find(id);
//            db.Authors.Remove(author);
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
