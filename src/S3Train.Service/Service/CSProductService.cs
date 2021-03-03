using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class CSProductService : GenenicServiceBase<SanPham>, ICSProductService
    {
        public CSProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<ProductDTO> GetCSProductItems()
        {
            var csbook = DbContext.SanPhams
                .Where(x => x.LoaiSanPham.PhanLoai.TenPhanLoai == "Sách" && x.NgayCapNhat == null)
                .Select(n => new ProductDTO
                {
                    Id = n.Id,
                    TenSP = n.TenSP,
                    HinhAnh = n.HinhAnh,
                    Gia = n.Gia,
                    NgayCapNhat = n.NgayCapNhat,
                    KhuyenMais = n.CT_KhuyenMais.Select(x => new PromotionDTO
                    {
                        PhanTramKM = x.PhanTramKM,
                    }).ToList(),
                }).ToList();
            return csbook;
        }
    }
}
