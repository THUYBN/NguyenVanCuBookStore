using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class SanPham : EntityBase
    {
        public string TenSP { get; set; }
        public string TacGia { get; set; }
        public decimal Gia { get; set; }
        public string HinhAnh { get; set; }
        public float TrongLuong { get; set; }
        public int SoLuong { get; set; }
        public int SoTrang { get; set; }
        public string KichThuoc { get; set; }
        public string GhiChu { get; set; }
        public string ChatLuong { get; set; }
        public string MauSac { get; set; } 
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public bool TrangThai { get; set; }
        public Guid MaNN { get; set; }
        public Guid MaNSX { get; set; }
        public Guid MaNCC { get; set; }
        public Guid MaLoai { get; set; }
        public int? LuotXem { get; set; }
        [ForeignKey("MaNSX")]
        public virtual NhaSanXuat NhaSanXuat { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }
        [ForeignKey("MaNN")]
        public virtual NgonNgu NgonNgu { get; set; }
        public virtual ICollection<CT_KhuyenMai> CT_KhuyenMais { get; set; }
        public virtual ICollection<CT_HoaDon> CT_HoaDons { get; set; }
        [ForeignKey("MaLoai")]
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual ICollection<ManHinhTrangChu> ManHinhTrangChus { get; set; }



    }
}
