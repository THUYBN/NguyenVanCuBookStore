//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using PagedList;
//using S3Train.Domain;
//using S3Train.Web.Areas.Admin.Data;

//namespace S3Train.Web.Areas.Admin.Controllers
//{
//    public class StaffsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Admin/Staffs
//        public ActionResult Index(int? page)
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                var staffs = db.Staffs.Include(s => s.Position);
//                int pageNumber = (page ?? 1);
//                int pageSize = 10;
//                return View(staffs.ToList().OrderBy(t => t.NameStaff).ToPagedList(pageNumber, pageSize));
//            }
//        }

//        // GET: Admin/Staffs/Details/5
//        public ActionResult Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NhanVien staff = db.Staffs.Find(id);
//            if (staff == null)
//            {
//                return HttpNotFound();
//            }
//            return View(staff);
//        }

//        // GET: Admin/Staffs/Create
//        public ActionResult Create()
//        {
//            if (Session["Email"] == null)
//            {
//                return RedirectToAction("Index", "Login");
//            }
//            else
//            {
//                ViewBag.PositionId = new SelectList(db.Positions, "Id", "NamePosition");
//                return View();
//            }
//        }

//        // POST: Admin/Staffs/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [ValidateInput(false)]
//        public ActionResult Create([Bind(Include = "Id,PositionId,NameStaff,ImagePath,Address,Sex,DateOfBirth,PhoneNumber,Email,Password,CreatedDate,UpdatedDate,IsActive")] NhanVien staff, HttpPostedFileBase fileUpload)
//        {
//            ViewBag.PositionId = new SelectList(db.Positions, "Id", "NamePosition", staff.PositionId);
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
//                staff.Id = Guid.NewGuid();
//                staff.Password = Encryptor.MD5Hash(staff.Password);
//                staff.ImagePath = fileName;
//                db.Staffs.Add(staff);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

            
//            return View(staff);
//        }

//        // GET: Admin/Staffs/Edit/5
//        public ActionResult Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NhanVien staff = db.Staffs.Find(id);
//            if (staff == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.PositionId = new SelectList(db.Positions, "Id", "NamePosition", staff.PositionId);
//            return View(staff);
//        }

//        // POST: Admin/Staffs/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,PositionId,NameStaff,ImagePath,Address,Sex,DateOfBirth,PhoneNumber,Email,Password,CreatedDate,UpdatedDate,IsActive")] NhanVien staff, HttpPostedFileBase fileUpload)
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
//                    staff.ImagePath = fileName;
//                }
//                staff.Password = Encryptor.MD5Hash(staff.Password);
//                db.Entry(staff).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.PositionId = new SelectList(db.Positions, "Id", "NamePosition", staff.PositionId);
//            return View(staff);
//        }

//        // GET: Admin/Staffs/Delete/5
//        public ActionResult Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            NhanVien staff = db.Staffs.Find(id);
//            if (staff == null)
//            {
//                return HttpNotFound();
//            }
//            return View(staff);
//        }

//        // POST: Admin/Staffs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(Guid id)
//        {
//            NhanVien staff = db.Staffs.Find(id);
//            db.Staffs.Remove(staff);
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
