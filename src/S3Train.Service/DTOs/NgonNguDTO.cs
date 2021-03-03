using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class NgonNguDTO
    {
        public Guid MaNN { get; set; }
        public string TenNN { get; set; }
        public IList<ProductDTO> SanPhams { get; set; }
    }
}
