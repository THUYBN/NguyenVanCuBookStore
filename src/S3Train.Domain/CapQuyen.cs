using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class CapQuyen : EntityBase
    {
        public Guid MaNhom { get; set; }
        public Guid MaCN { get; set; }
        [ForeignKey("MaNhom")]
        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
        [ForeignKey("MaCN")]
        public virtual ChucNang ChucNang { get; set; }

    }
}
