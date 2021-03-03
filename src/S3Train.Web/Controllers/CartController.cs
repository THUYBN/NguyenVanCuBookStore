using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using S3Train.Web.Models;
using S3Train.Domain;
using S3Train.Contract;
using System.Collections.Generic;
using System;
using S3Train.DTOs;
using System.Data.Entity;
using WebApplication2;

namespace S3Train.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public const string CartSession = "CartSession";
        public CartController(ICartService cartService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;

        }
        // GET: Cart
        public ActionResult MyCart()
        {
            var cart = (List<CartViewModel>)Session[CartSession];

            return View(cart);
        }

        public ActionResult AddItems(Guid Id, int Quantity = 1)
        {
            var CartItem = _cartService.GetCart(Id);
            var currentCartItems = (List<CartViewModel>)Session[CartSession] ?? new List<CartViewModel>(); 
            if(CartItem.KhuyenMais.Count() !=0)
            {
                if (currentCartItems.Exists(x => x.Products.Id == Id))
                {
                    currentCartItems.SingleOrDefault(q => q.Products.Id == Id).Quantity += Quantity;
                }
                else
                {
                    currentCartItems.Add(new CartViewModel
                    {
                        Quantity = Quantity,
                        Products = new ProductDTO
                        {
                            Id = Id,
                            TenSP = CartItem.TenSP,
                            HinhAnh = CartItem.HinhAnh,
                            Gia = CartItem.Gia,
                            SoLuong = CartItem.SoLuong,
                        },
                        PromotionPercent = CartItem.KhuyenMais.FirstOrDefault().PhanTramKM,

                    });
                }
                Session[CartSession] = currentCartItems;
            }
            else
            {
                if (currentCartItems.Exists(x => x.Products.Id == Id))
                {
                    currentCartItems.SingleOrDefault(q => q.Products.Id == Id).Quantity += Quantity;
                }
                else
                {
                    currentCartItems.Add(new CartViewModel
                    {
                        Quantity = Quantity,
                        Products = new ProductDTO
                        {
                            Id = Id,
                            TenSP = CartItem.TenSP,
                            HinhAnh = CartItem.HinhAnh,
                            Gia = CartItem.Gia,
                            SoLuong = CartItem.SoLuong,
                        },
                    });
                }
                Session[CartSession] = currentCartItems;
            }
            
            return Json(new {
                status = "success",
            });
        }

        public ActionResult UpdateQuantity(Guid Id, int NewQuan)
        {
            List<CartViewModel> cart = (List<CartViewModel>)Session[CartSession];
            CartViewModel updateItem = cart.FirstOrDefault(m => m.Products.Id == Id);

            if (updateItem != null)
            {
                updateItem.Quantity = NewQuan;

            }
            return Json(updateItem);

        }


        public ActionResult RemoveItem(Guid Id)
        {
            var removeCart = (List<CartViewModel>)Session[CartSession];
            removeCart.RemoveAll(x => x.Products.Id == Id);
            Session[CartSession] = removeCart;
            return Json(removeCart);

        }
        
        public ActionResult PayMent()
        {
            var userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var cartSession = (List<CartViewModel>)Session[CartSession];
            var payMent = new PayMentViewModel
            {
               
                    Cart = cartSession,
                    User = new ApplicationUser
                    {
                        HoTen = user.HoTen,
                        DiaChi = user.DiaChi,
                        PhoneNumber = user.PhoneNumber,
                        Quan = user.Quan,
                        Phuong = user.Phuong,
                        ThanhPho = user.ThanhPho
                    }
            };
            return View(payMent);
        }

        public ActionResult Order(string Note, string PhuongThuc)
        {
            string ketqua = "";
            var userId = User.Identity.GetUserId();
            var cartSession = (List<CartViewModel>)Session[CartSession];
            if (PhuongThuc == "Tiền mặt")
            {
                var order = new HoaDon
                {
                    ApplicationUserId = userId,
                    NgayLap = DateTime.Now,
                    NgayCapNhat = DateTime.Now,
                    TongTien = cartSession.Sum(m => m.Quantity * m.Products.Gia),
                    TrangThai = "Chưa xác nhận",
                    GhiChu = Note,
                    MaPhuongThuc = db.PhuongThucThanhToans.Where(m => m.TenPhuongThuc == "Tiền mặt").Select(m => m.Id).FirstOrDefault()
                };
                var id = _orderService.InsertOrder(order);
                foreach (var item in cartSession)
                {
                    var orderDetail = new CT_HoaDon
                    {
                        MaHD = id,
                        SoLuong = item.Quantity,
                        Gia = item.Products.Gia,
                        ThanhTien = item.Quantity * item.Products.Gia,
                        MaSP = item.Products.Id,
                    };
                    _orderDetailService.InsertOrderDetail(orderDetail);
                }
                Session[CartSession] = null;
            }
            else
            {
                var order = new HoaDon
                {
                    ApplicationUserId = userId,
                    NgayLap = DateTime.Now,
                    NgayCapNhat = DateTime.Now,
                    TongTien = cartSession.Sum(m => m.Quantity * m.Products.Gia),
                    TrangThai = "Chưa xác nhận",
                    GhiChu = Note,
                    MaPhuongThuc = db.PhuongThucThanhToans.Where(m => m.TenPhuongThuc == "Onepay").Select(m => m.Id).FirstOrDefault()
                };
                var id = _orderService.InsertOrder(order);
                foreach (var item in cartSession)
                {
                    var orderDetail = new CT_HoaDon
                    {
                        MaHD = id,
                        SoLuong = item.Quantity,
                        Gia = item.Products.Gia,
                        ThanhTien = item.Quantity * item.Products.Gia,
                        MaSP = item.Products.Id,
                    };
                    _orderDetailService.InsertOrderDetail(orderDetail);
                }
                
                
                string mathanhtoantructuyen = id.ToString();
                switch (PhuongThuc)
                {
                    case "Onepay":
                        string SERCURE_SECRET = OnepayCode.SERCURE_SECRET;
                        VPCRequest conn = new VPCRequest(OnepayCode.VPCRequest);
                        conn.SetSecureSecret(SERCURE_SECRET);
                        conn.AddDigitalOrderField("Title", "onepay paygate");
                        conn.AddDigitalOrderField("vpc_Locale", "vn");
                        conn.AddDigitalOrderField("vpc_Version", "2");
                        conn.AddDigitalOrderField("vpc_Command", "pay");
                        conn.AddDigitalOrderField("vpc_Merchant", OnepayCode.Merchant);
                        conn.AddDigitalOrderField("vpc_AccessCode", OnepayCode.AccessCode);
                        conn.AddDigitalOrderField("vpc_MerchTxnRef", mathanhtoantructuyen);
                        conn.AddDigitalOrderField("vpc_OrderInfo", mathanhtoantructuyen);
                        conn.AddDigitalOrderField("vpc_Amount", (cartSession.Sum(m => m.Quantity * m.Products.Gia) * 100).ToString());

                        conn.AddDigitalOrderField("vpc_SHIP_Street01", "");
                        conn.AddDigitalOrderField("vpc_SHIP_Province", "");
                        conn.AddDigitalOrderField("vpc_SHIP_City", "");
                        conn.AddDigitalOrderField("vpc_SHIP_Country", "");
                        conn.AddDigitalOrderField("vpc_Customer_Phone", "");
                        conn.AddDigitalOrderField("vpc_Customer_Email", "");
                        conn.AddDigitalOrderField("vpc_Customer_Id", "");

                        conn.AddDigitalOrderField("vpc_TicketNo", Request.UserHostAddress);
                        String url = conn.Create3PartyQueryString();
                        ketqua = url;
                        Response.Write(ketqua);
                        //return Redirect(ketqua);
                        break;
                }
                Response.Write(ketqua);
                Session[CartSession] = null;
            }
            return View("MyCart");
        }

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AddAddress()
        {
            var user = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            var model = new ApplicationUser
            {
                Id = user.Id,
                DiaChi = user.DiaChi,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                EmailConfirmed = user.EmailConfirmed,
                SecurityStamp = user.SecurityStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                UserName = user.UserName,
                HoTen = user.HoTen,
                NgaySinh = user.NgaySinh,
                GioiTinh = user.GioiTinh,
                Phuong = user.Phuong,
                Quan = user.Quan,
                ThanhPho = user.ThanhPho,
                QuocGia = user.QuocGia,
                TrangThai = user.TrangThai
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAddress([Bind(Include = "Id,DiaChi,Email,PasswordHash,EmailConfirmed,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,HoTen,NgaySinh,GioiTinh,Quan,ThanhPho,QuocGia,TrangThai,Phuong")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PayMent", "Cart");
            }
            return View(user);
        }
    }
}