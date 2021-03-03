using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class SearchProductsForAuthorService : GenenicServiceBase<SanPham>, ISearchProductsForAuthorService
    {
        public SearchProductsForAuthorService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<ProductDTO> GetProductsSearchForAuhtorItems(string Name)
        {
            var productSearchForAuthor = DbContext.SanPhams
                .Where(x => x.TacGia.Contains(Name) || x.TenSP.Contains(Name) || x.LoaiSanPham.TenLoai.Contains(Name) || x.NhaSanXuat.TenNSX.Contains(Name))
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    TenSP = x.TenSP,
                    HinhAnh = x.HinhAnh,
                    Gia = x.Gia,
                    NgayCapNhat = x.NgayCapNhat,
                }).Distinct().ToList();
          
            return productSearchForAuthor;

        }
    }
}
