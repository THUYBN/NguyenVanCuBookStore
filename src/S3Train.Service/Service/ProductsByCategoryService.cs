using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class ProductsByCategoryService : GenenicServiceBase<LoaiSanPham>, IProductsByCategoryService
    {
        public ProductsByCategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ProductDTO> GetProductsByCategoryItems(Guid CategoryId)
        {
            var product = DbContext.SanPhams.Include("LoaiSanPham")
                .Where(n => n.LoaiSanPham.Id == CategoryId)
                 .Select(n => new ProductDTO
                 {
                     ProductId = n.Id,
                     MaLoai = n.MaLoai,
                     TenSP = n.TenSP,
                     HinhAnh = n.HinhAnh,
                     Gia = n.Gia,
                     NgayCapNhat = n.NgayCapNhat,
                     LoaiSanPham = new CategoryDTO
                     {
                         TenLoai = n.LoaiSanPham.TenLoai
                     },
                     KhuyenMais = n.CT_KhuyenMais.Select(x => new PromotionDTO
                     {
                         PhanTramKM = x.PhanTramKM,
                     }).ToList(),
                 }).ToList();
            return product;
        }
    }
}
