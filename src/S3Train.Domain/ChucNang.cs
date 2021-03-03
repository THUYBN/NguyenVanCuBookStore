using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class ChucNang : EntityBase
    {
        public string TenCN { get; set; }
        public virtual ICollection<CapQuyen> CapQuyens { get; set; }

    }
}
