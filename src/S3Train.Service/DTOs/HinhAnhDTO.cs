using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class HinhAnhDTO
    {
        public string TenLuuHinhAnh { get; set; }
        public IList<ProductDTO> SanPhams { get; set; }
    }
}
