using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string HinhAnh { get; set; }
        public string TacGia { get; set; }
        public Guid ProductId { get; set; }
        public Guid MaLoai { get; set; }
        public Guid MaNSX { get; set; }
        public string TenSP { get; set; }
        public string GhiChu { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public int? LuotXem { get; set; }
        public int SoLuongDat { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public string UserId { get; set; }
        public string TrangThai { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiHD { get; set; }
        public string GhiChuHD { get; set; }

        public NCCDTO NhaCungCap  { get; set; }
        public NgonNguDTO NgonNgu { get; set; }
        public AuthorDTO NhaSanXuat { get; set; }
        public CategoryDTO LoaiSanPham { get; set; }
        public IList<PromotionDTO> KhuyenMais { get; set; }
        public List<ProductDTO> RelatedProduct { get; set; }
        public List<ProductDTO> UserProducts { get; set; }
        public float TrongLuong { get; set; }
        public int SoTrang { get; set; }
        public string KichThuoc { get; set; }
        public string ChatLuong { get; set; }
        public string MauSac { get; set; }
    }

}
