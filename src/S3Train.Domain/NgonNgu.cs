using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class NgonNgu : EntityBase
    {
        public string TenNN { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
