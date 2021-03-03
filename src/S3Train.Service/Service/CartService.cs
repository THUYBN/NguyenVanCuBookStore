using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class CartService : GenenicServiceBase<SanPham>, ICartService
    {
        public CartService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ProductDTO GetCart(Guid Id)
        {
            var cart = DbContext.SanPhams.Where(x => x.Id == Id)
                .Select(n => new ProductDTO
                {
                    Id = n.Id,
                    TenSP = n.TenSP,
                    HinhAnh = n.HinhAnh,
                    Gia = n.Gia,
                    SoLuong = n.SoLuong,
                    KhuyenMais = n.CT_KhuyenMais.Select(x => new PromotionDTO
                    {
                        PhanTramKM = x.PhanTramKM
                    }).ToList(),
                }).SingleOrDefault();
            return cart;
        }
    }
}
