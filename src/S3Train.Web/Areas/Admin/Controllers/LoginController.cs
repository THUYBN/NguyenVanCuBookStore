using S3Train.Domain;
using S3Train.Service;
using S3Train.Web.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                ViewBag.email = cookie["tendn"].ToString();
                //string EncryptedPassword = cookie["password"].ToString();
                //byte[] b = Convert.FromBase64String(EncryptedPassword);
                //string decryptPassword = ASCIIEncoding.ASCII.GetString(b);
                //ViewBag.password = decryptPassword.ToString();
                ViewBag.password = cookie["password"].ToString();
                ViewBag.hinhanh = cookie["hinhanh"].ToString();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login l)
        {
            ////var result = new Account().Login(model.Email, model.Password);
            //if(Membership.ValidateUser(model.Email, model.Password) && ModelState.IsValid)
            //{
            //    //SessionHelper.SetSession(new UserSession() { Email = model.Email });
            //    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
            //    return RedirectToAction("Index", "HomeAdmin");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Username or password wrong!");
            //}
            HttpCookie cookie = new HttpCookie("Login");
            if (ModelState.IsValid == true)
            {
                if (l.RememberMe == true)
                {
                    cookie["tendn"] = l.TenDN;
                    cookie["password"] = l.Password;
                    cookie["hinhanh"] = l.HinhAnh;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                var str = Encryptor.MD5Hash(l.Password);
                var t = db.NhanViens.ToList();
                var row = db.NhanViens.Where(m => m.TenDN == l.TenDN && m.Password == l.Password).SingleOrDefault();
                

                if (row != null)
                        
                    {
                            var Y = db.NhanViens.Where(m => m.TenDN == l.TenDN).Select(m => m.HinhAnh);
                            var T = db.NhanViens.Where(m => m.TenDN == l.TenDN).Select(m => m.NhomNguoiDung.TenNhom);
                            Session["hinhanh"] = Y;
                            Session["tendn"] = l.TenDN;
                            Session["tennhom"] = T;
                            return RedirectToAction("Index", "HomeAdmin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai!");
                    }
                    
                }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["tendn"] != null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }
            return View();

        }
    }
}