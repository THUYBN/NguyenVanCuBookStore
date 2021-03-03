using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class NhaCungCap : EntityBase
    {
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string ThongTinThem { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
