using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class NhanVien : EntityBase
    {
        public Guid MaCV { get; set; }
        public string TenNV { get; set; }
        public string HinhAnh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Guid MaNhom { get; set; }
        public string CMND { get; set; }
        public bool TrangThai { get; set; }
        public string TenDN { get; set; }
        [ForeignKey("MaCV")]
        public virtual ChucVu ChucVu { get; set; }
        [ForeignKey("MaNhom")]
        public virtual NhomNguoiDung NhomNguoiDung { get; set; }

    }
}
