using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class PhuongThucThanhToan : EntityBase
    {
        public string TenPhuongThuc { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}
