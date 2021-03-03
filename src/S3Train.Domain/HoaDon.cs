using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class HoaDon : EntityBase
    {
        public Guid MaPhuongThuc { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime NgayLap { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }
        public decimal TongTien { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("MaPhuongThuc")]
        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }
        public virtual ICollection<CT_HoaDon> CT_HoaDons { get; set; }

    }
}
