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
    public class VPPService : GenenicServiceBase<SanPham>, IVPPService
    {
        public VPPService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ProductDTO> GetVPP()
        {
            var newbook = (from c in DbContext.SanPhams
                           where c.LoaiSanPham.PhanLoai.TenPhanLoai == "Văn Phòng Phẩm"
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
                    Id = n.Id,
                    TenSP = n.TenSP,
                    HinhAnh = n.HinhAnh,
                    Gia = n.Gia,
                    NgayCapNhat = n.NgayCapNhat,
                }).ToList();
            return book;
        }
    }
}
