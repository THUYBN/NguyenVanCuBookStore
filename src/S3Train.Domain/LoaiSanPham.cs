using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class LoaiSanPham : EntityBase
    {
        public string TenLoai { get; set; }
        public Guid MaPhanLoai { get; set; }
        [ForeignKey("MaPhanLoai")]
        public virtual PhanLoai PhanLoai { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }


    }
}
