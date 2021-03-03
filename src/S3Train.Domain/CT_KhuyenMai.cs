using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class CT_KhuyenMai : EntityBase
    {
        public Guid MaSP { get; set; }
        public Guid MaKM { get; set; }
        public int SoLuong { get; set; }
        public float PhanTramKM { get; set; }
        [ForeignKey("MaKM")]
        public virtual KhuyenMai KhuyenMai { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }

    }
}
