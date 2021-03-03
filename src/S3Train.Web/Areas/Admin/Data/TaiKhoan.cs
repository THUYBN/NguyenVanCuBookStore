using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3Train.Web.Areas.Admin.Data
{
    public class TaiKhoan
    {
        public Guid Id { get; set; }
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
        [Required]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Không trùng với mật khẩu mới")]
        public string ConfirmPassword { get; set; }
        public Guid MaNhom { get; set; }
        public string CMND { get; set; }
        public bool TrangThai { get; set; }
        public string TenDN { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
    }
}