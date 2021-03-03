using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class KhuyenMai : EntityBase
    {
        public string TenKM { get; set; }
        [DataType(DataType.Date)]
        public DateTime ThoiGianBD { get; set; }
        [DataType(DataType.Date)]
        public DateTime ThoiGianKT { get; set; }
        public virtual ICollection<CT_KhuyenMai> CT_KhuyenMais { get; set; }

    }
}
