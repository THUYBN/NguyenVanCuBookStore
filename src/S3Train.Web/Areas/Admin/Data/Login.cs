using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using S3Train.Domain;

namespace S3Train.Web.Areas.Admin.Data
{
    public class Login
    {
        [Required(ErrorMessage = "Chưa điền tên đăng nhập")]
        public string TenDN { get; set; }
        [Required(ErrorMessage = "Chưa điền password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string HinhAnh { get; set; }
        public string TenNhom { get; set; }
    }
}