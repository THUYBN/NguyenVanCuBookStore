using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S3Train.Service
{
    public class PromotionDetailService: GenenicServiceBase<CT_KhuyenMai>, IPromotionDetailService
    {
        public PromotionDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ProductDTO> GetPromotionDetail()
        {
            var product = DbContext.SanPhams
                .Where(n => n.CT_KhuyenMais.Any(a => a.PhanTramKM > 0))
                .Select(n => new ProductDTO
                {
                    ProductId = n.Id,
                    TenSP = n.TenSP,
                    HinhAnh = n.HinhAnh,
                    Gia = n.Gia,
                    KhuyenMais = n.CT_KhuyenMais.Select(x => new PromotionDTO
                    {
                        PhanTramKM = x.PhanTramKM,
                    }).ToList(),
                }).ToList();

            return product;
        }
    }
}
