using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class NewProductService : GenenicServiceBase<SanPham>, IProductService
    {
        public NewProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<ProductDTO> GetNewProductItems()
        {
            var newbook = (from c in DbContext.SanPhams
                           where c.NgayCapNhat != null && c.LoaiSanPham.PhanLoai.TenPhanLoai == "Sách"
                           orderby c.NgayTao descending
                           select new
                           {
                               c.Id,
                               c.TenSP,
                               c.Gia,
                               c.HinhAnh,
                               c.NgayCapNhat,
                           }).Take(20).ToList();
            var book = newbook
                .Select(n => new ProductDTO
               {
                   Id =n.Id,
                   TenSP = n.TenSP,
                   HinhAnh = n.HinhAnh,
                   Gia = n.Gia,
                   NgayCapNhat = n.NgayCapNhat,
               }).ToList();
            return book;
        }

       
    }
}