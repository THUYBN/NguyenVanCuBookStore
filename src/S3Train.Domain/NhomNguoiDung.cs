using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class NhomNguoiDung : EntityBase
    {
        public string TenNhom { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<CapQuyen> CapQuyens { get; set; }

    }
}
