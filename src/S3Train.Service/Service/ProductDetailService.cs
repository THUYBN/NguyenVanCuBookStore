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
    public class ProductDetailService : GenenicServiceBase<SanPham>, IProductDetailService
    {
        public ProductDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public ProductDTO GetProductDetail(Guid id)
        {
            var productDetail = DbContext.SanPhams.Include("NhaSanXuat").Include("NhaCungCap")
                .Where(u => u.Id == id)
                .Select(n => new ProductDTO
                {
                    Id = n.Id,
                    TenSP = n.TenSP,
                    HinhAnh = n.HinhAnh,
                    Gia = n.Gia,
                    GhiChu = n.GhiChu,
                    NgayCapNhat = n.NgayCapNhat,
                    SoLuong = n.SoLuong,
                    TrongLuong = n.TrongLuong,
                    KichThuoc = n.KichThuoc,
                    SoTrang = n.SoTrang,
                    ChatLuong = n.ChatLuong,
                    MauSac = n.MauSac,
                    TacGia = n.TacGia,
                    MaNSX = n.MaNSX,
                    NhaSanXuat = new AuthorDTO
                    {
                        TenNSX = n.NhaSanXuat.TenNSX
                    },
                    NhaCungCap = new NCCDTO
                    {
                        TenNCC = n.NhaCungCap.TenNCC
                    },
                    NgonNgu = new NgonNguDTO
                    {
                        TenNN = n.NgonNgu.TenNN
                    },
                    LoaiSanPham = new CategoryDTO
                    {
                        TenLoai = n.LoaiSanPham.TenLoai,
                        TenPhanLoai = n.LoaiSanPham.PhanLoai.TenPhanLoai
                    },
                    KhuyenMais = n.CT_KhuyenMais.Select(x => new PromotionDTO {
                        PhanTramKM = x.PhanTramKM
                    }).ToList(),
                }).SingleOrDefault();

                productDetail.RelatedProduct = DbContext.SanPhams
                .Where(q => q.TacGia == productDetail.TacGia && q.Id != id).Select(n => new ProductDTO {
                    Id = n.Id,
                    TenSP = n.TenSP,
                    HinhAnh = n.HinhAnh,
                    Gia = n.Gia
                }).ToList();
               

            return productDetail;

        }
    }
}
