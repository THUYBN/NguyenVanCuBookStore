using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class OrderService : GenenicServiceBase<HoaDon>, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Guid InsertOrder(HoaDon order)
        {
            order.Id = Guid.NewGuid();
            DbContext.HoaDons.Add(order);
            DbContext.SaveChanges();

            return order.Id;
        }

        public IList<OrderDTO> GetOrders(string ApplicationUserId)
        {
            var orderUser = (from p in DbContext.PhuongThucThanhToans
                             join o in DbContext.HoaDons on p.Id equals o.MaPhuongThuc
                             join a in DbContext.Users on o.ApplicationUserId equals a.Id
                             where a.Id == ApplicationUserId
                             select new
                             {
                                 o.Id,
                                 o.TrangThai,
                                 o.GhiChu,
                                 o.TongTien,
                                 a.HoTen,
                                 o.NgayLap,
                                 o.NgayCapNhat,
                                 p.TenPhuongThuc
                             }).ToList();

            var pro = orderUser
                .Select(n => new OrderDTO
                {
                    Id = n.Id,
                    TrangThai = n.TrangThai,
                    GhiChu = n.GhiChu,
                    TongTien = n.TongTien,
                    TenKH = n.HoTen,
                    NgayLap = n.NgayLap,
                    NgayCapNhat = n.NgayCapNhat,
                    TenPhuongThuc = n.TenPhuongThuc
                }).ToList();

            return pro;
        }
        public IList<ProductDTO> GetProductsByUserItems(Guid OrderId)
        {
            var proUser = (from p in DbContext.SanPhams 
                          join d in DbContext.CT_HoaDons on p.Id equals d.MaSP
                          join o in DbContext.HoaDons on d.MaHD equals o.Id
                          where o.Id == OrderId
                          select new
                          {
                              p.Id,
                              p.HinhAnh,
                              p.TenSP,
                              d.Gia,
                              d.SoLuong,
                              d.ThanhTien,
                              o.TrangThai,
                              o.TongTien,
                              o.NgayLap,
                              o.NgayCapNhat,
                              o.GhiChu
                          }).ToList();

            var pro = proUser
                .Select(n => new ProductDTO
                {
                    ProductId = n.Id,
                    HinhAnh = n.HinhAnh,
                    TenSP = n.TenSP,
                    Gia = n.Gia,
                    SoLuongDat = n.SoLuong,
                    ThanhTien = n.ThanhTien,
                    TrangThai = n.TrangThai,
                    TongTien = n.TongTien,
                    NgayTao = n.NgayLap,
                    NgayCapNhat = n.NgayCapNhat,
                    GhiChu = n.GhiChu
                }).ToList();

            return pro;
        }
    }
}
