using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class ChucVu : EntityBase
    {
        public string TenCV { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
