using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string TenLoai { get; set; }
        public string TenPhanLoai { get; set; }

        public IList<ProductDTO> SanPhams { get; set; }
    }
}
