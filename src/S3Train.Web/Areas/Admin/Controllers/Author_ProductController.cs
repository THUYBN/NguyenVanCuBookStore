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
//    public class Author_ProductController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Author_Product
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                var author_Products = db.Author_Products.Include(a => a.Author).Include(a => a.Product);
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(author_Products.ToList().OrderBy(t => t.ProductId).ToPagedList(pageNumber, pageSize));
//            }
            
//        }

//        // GET: Admin/Author_Product/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Author_Product author_Product = db.Author_Products.Find(id);
//            if (author_Product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(author_Product);
//        }

//        // GET: Admin/Author_Product/Create
//        public ActionResult Create()
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.AuthorId = new SelectList(db.Authors, "Id", "NameAuthor");
//                ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
//                return View();
//            }
            
//        }

//        // POST: Admin/Author_Product/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,AuthorId,ProductId,Role,Location,CreatedDate,UpdatedDate,IsActive")] Author_Product author_Product)
//        {
//            if (ModelState.IsValid)
//            {
//                author_Product.Id = Guid.NewGuid();
//                db.Author_Products.Add(author_Product);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "NameAuthor", author_Product.AuthorId);
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", author_Product.ProductId);
//            return View(author_Product);
//        }

//        // GET: Admin/Author_Product/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Author_Product author_Product = db.Author_Products.Find(id);
//            if (author_Product == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "NameAuthor", author_Product.AuthorId);
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", author_Product.ProductId);
//            return View(author_Product);
//        }

//        // POST: Admin/Author_Product/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,AuthorId,ProductId,Role,Location,CreatedDate,UpdatedDate,IsActive")] Author_Product author_Product)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(author_Product).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "NameAuthor", author_Product.AuthorId);
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct", author_Product.ProductId);
//            return View(author_Product);
//        }

//        // GET: Admin/Author_Product/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Author_Product author_Product = db.Author_Products.Find(id);
//            if (author_Product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(author_Product);
//        }

//        // POST: Admin/Author_Product/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Author_Product author_Product = db.Author_Products.Find(id);
//            db.Author_Products.Remove(author_Product);
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
