using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class NhaSanXuat : EntityBase
    {
        public string TenNSX { get; set; }
        public string ThongTinThem { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
