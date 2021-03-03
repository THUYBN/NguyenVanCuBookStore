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
//    public class ProductsController : Controller
//    {
        
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Products
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                var products = db.Products.Include(p => p.Category).Include(p => p.Publisher);
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(products.ToList().OrderBy(t => t.NameProduct).ToPagedList(pageNumber, pageSize));
//            }
            
//        }

//        // GET: Admin/Products/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        // GET: Admin/Products/Create
//        public ActionResult Create()
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "NameCategory");
//                ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "NamePublisher");
//                return View();
//            }
//        }

//        // POST: Admin/Products/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [ValidateInput(false)]
//        public ActionResult Create([Bind(Include = "Id,CategoryId,PublisherId,NameProduct,Summary,Price,ImagePath,Barcode,ReleaseYear,Amount,Rating,CreatedDate,UpdatedDate,IsActive")] Product product, HttpPostedFileBase fileUpload)
//        {
//            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "NameCategory", product.CategoryId);
//            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "NamePublisher", product.PublisherId);

//            if (fileUpload == null)
//            {
//                ViewBag.Notification = "Choose image";
//                return View();
//            }

//            if (ModelState.IsValid)
//            {
//                //Luu ten file
//                var fileName = Path.GetFileName(fileUpload.FileName);
//                //Luu duong dan
//                var path = Path.Combine(Server.MapPath("~/ImagePD"), fileName);
//                //KT HINH ANH TON TAI CHUA
//                if (System.IO.File.Exists(path))
//                {
//                    ViewBag.Notification = "Image already exists";
//                }
//                else
//                {
//                    fileUpload.SaveAs(path);
//                }
//                product.Id = Guid.NewGuid();
//                product.ImagePath = fileName;
//                db.Products.Add(product);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
            
//            return View(product);
//        }

//        // GET: Admin/Products/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "NameCategory", product.CategoryId);
//            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "NamePublisher", product.PublisherId);
//            return View(product);
//        }

//        // POST: Admin/Products/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [ValidateInput(false)]
//        public ActionResult Edit([Bind(Include = "Id,CategoryId,PublisherId,NameProduct,Summary,Price,ImagePath,Barcode,ReleaseYear,Amount,Rating,CreatedDate,UpdatedDate,IsActive")] Product product, HttpPostedFileBase fileUpload)
//        {
//            if (ModelState.IsValid)
//            {
//                //if (fileUpload != null)
//                //{
//                //    //Luu ten file
//                //    var fileName = Path.GetFileName(fileUpload.FileName);
//                //    //Luu duong dan
//                //    var path = Path.Combine(Server.MapPath("~/ImagePD"), fileName);
//                //    //KT HINH ANH TON TAI CHUA
//                //    if (System.IO.File.Exists(path))
//                //    {
//                //        ViewBag.Notification = "Image already exists";
//                //    }
//                //    else
//                //    {
//                //        fileUpload.SaveAs(path);
//                //    }
//                //    product.ImagePath = fileName;
//                //}
//                db.Entry(product).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "NameCategory", product.CategoryId);
//            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "NamePublisher", product.PublisherId);
//            return View(product);
//        }

//        // GET: Admin/Products/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = db.Products.Find(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }

//        // POST: Admin/Products/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            Product product = db.Products.Find(id);
//            db.Products.Remove(product);
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
