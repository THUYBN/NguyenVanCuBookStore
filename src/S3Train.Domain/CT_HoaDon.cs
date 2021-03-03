using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class CT_HoaDon : EntityBase
    {
        public Guid MaSP { get; set; }
        public Guid MaHD { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal Gia { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }

    }
}
