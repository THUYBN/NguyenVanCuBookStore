//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using S3Train.Domain;
//using System.IO;
//using PagedList;
//using PagedList.Mvc;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class ProductAdvertisementsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/ProductAdvertisements
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                var productadvertisments = db.ProductAdvertisements.Include(p => p.Product);
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(db.ProductAdvertisements.ToList().OrderBy(t => t.CreatedDate).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/ProductAdvertisements/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ManHinhTrangChu productAdvertisement = db.ProductAdvertisements.Find(id);
//            if (productAdvertisement == null)
//            {
//                return HttpNotFound();
//            }
//            return View(productAdvertisement);
//        }

//        // GET: Admin/ProductAdvertisements/Create
//        public ActionResult Create()
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
//                return View();
//            }
//        }

//        // POST: Admin/ProductAdvertisements/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [ValidateInput(false)]
//        public ActionResult Create([Bind(Include = "Id,ProductId,Title,Description,EventUrl,ImagePath,AdType,CreatedDate,UpdatedDate,IsActive")] ManHinhTrangChu productAdvertisement, HttpPostedFileBase fileUpload)
//        {
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
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
//                productAdvertisement.Id = Guid.NewGuid();
//                productAdvertisement.ImagePath = fileName;
//                db.ProductAdvertisements.Add(productAdvertisement);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(productAdvertisement);
//        }

//        // GET: Admin/ProductAdvertisements/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ManHinhTrangChu productAdvertisement = db.ProductAdvertisements.Find(id);
//            if (productAdvertisement == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
//            return View(productAdvertisement);
//        }

//        // POST: Admin/ProductAdvertisements/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [ValidateInput(false)]
//        public ActionResult Edit([Bind(Include = "Id,ProductId,Title,Description,EventUrl,ImagePath,AdType,CreatedDate,UpdatedDate,IsActive")] ManHinhTrangChu productAdvertisement, HttpPostedFileBase fileUpload)
//        {
//            if (ModelState.IsValid)
//            {
//                if (fileUpload != null)
//                {
//                    //Luu ten file
//                    var fileName = Path.GetFileName(fileUpload.FileName);
//                    //Luu duong dan
//                    var path = Path.Combine(Server.MapPath("~/ImagePD"), fileName);
//                    //KT HINH ANH TON TAI CHUA
//                    if (System.IO.File.Exists(path))
//                    {
//                        ViewBag.Notification = "Image already exists";
//                    }
//                    else
//                    {
//                        fileUpload.SaveAs(path);
//                    }
//                    productAdvertisement.ImagePath = fileName;
//                }
//                db.Entry(productAdvertisement).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.ProductId = new SelectList(db.Products, "Id", "NameProduct");
//            return View(productAdvertisement);
//        }

//        // GET: Admin/ProductAdvertisements/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ManHinhTrangChu productAdvertisement = db.ProductAdvertisements.Find(id);
//            if (productAdvertisement == null)
//            {
//                return HttpNotFound();
//            }
//            return View(productAdvertisement);
//        }

//        // POST: Admin/ProductAdvertisements/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            ManHinhTrangChu productAdvertisement = db.ProductAdvertisements.Find(id);
//            db.ProductAdvertisements.Remove(productAdvertisement);
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
