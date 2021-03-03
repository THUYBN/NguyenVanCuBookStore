using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class AuthorDTO
    {
        public Guid MaNSX { get; set; }
        public string TenNSX { get; set; }
        public IList<ProductDTO> SanPhams { get; set; }
    }
}
