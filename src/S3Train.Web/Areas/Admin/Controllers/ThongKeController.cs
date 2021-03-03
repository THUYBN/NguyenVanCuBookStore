using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            Tab();
            DateTime datenow = DateTime.Parse(DateTime.Now.ToShortDateString());
            ViewBag.title_char1 = "Biểu đồ doanh thu 15 ngày gần nhất";
            Char1(datenow.AddDays(-14), datenow);
            return View();
        }
        [HttpPost]
        public ActionResult Index(String start, String end)
        {
            if (start == "" || end == "")
                return RedirectToAction("Index", "ThongKe");
            Tab();
            DateTime datenow = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime dateS = DateTime.Parse(start);
            DateTime dateE = DateTime.Parse(end);
            ViewBag.title_char1 = "Biểu đồ doanh thu từ ngày " + start + " đến ngày " + end;
            Char1(dateS, dateE);
            return View();
        }
        private void Tab()
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var tong = db.HoaDons.Where(t => t.TrangThai == "Giao thành công" && t.NgayLap >= firstDayOfMonth).Sum(t => (decimal?)t.TongTien).GetValueOrDefault();
            if (tong != null)
                ViewBag.tien_ht = String.Format("{0:0,0.00}", tong);
            else
                ViewBag.tien_ht = "0";

            ViewBag.so_hoa_don = db.HoaDons.Count();
            ViewBag.so_san_pham = db.SanPhams.Where(u => u.TrangThai == true).Count();
            ViewBag.so_khach_hang = db.Users.Count();
            ViewBag.so_khuyen_mai = db.KhuyenMais.Count();
        }
        private void Char1(DateTime start, DateTime end)
        {
            List<Double> C1sl = new List<Double>();
            List<String> C1name = new List<String>();
            int num = (end - start).Days;
            double tong = 0;
            for (int i = 0; i <= num; i++)
            {
                DateTime f1 = end.AddDays(-num + i);
                DateTime f2 = f1.AddDays(1);
                var q = db.HoaDons.Where(t => t.TrangThai== "Giao thành công" &&  t.NgayLap > f1 && t.NgayLap < f2).Sum(t => (decimal?)t.TongTien).GetValueOrDefault();
                if (q == null)
                    q = 0;
                tong += (double)q;
                C1sl.Add((Double)q);
                C1name.Add(f1.Day.ToString() + " / " + f1.Month.ToString());
            }
            ViewBag.tong_tien = "Tổng doanh thu từ ngày " + start.ToShortDateString() + " tới ngày " + end.ToShortDateString() + " là " + String.Format("{0:0,0.00}", tong) + " VND";
            ViewBag.C1sl = C1sl;
            ViewBag.C1name = C1name;
        }
       
    }
}