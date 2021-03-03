using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class PhanLoai : EntityBase
    {
        public string TenPhanLoai { get; set; }
        public virtual ICollection<LoaiSanPham> LoaiSanPhams { get; set; }

    }
}
