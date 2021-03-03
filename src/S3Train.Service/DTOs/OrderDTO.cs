using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class OrderDTO
    {
        public string TrangThai { get; set; }
        public Decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public string TenKH { get; set; }
        public Guid Id { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string TenPhuongThuc { get; set; }
    }
}
