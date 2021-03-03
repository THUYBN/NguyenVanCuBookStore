using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class NCCDTO
    {
        public Guid MaNCC { get; set; }
        public string TenNCC { get; set; }
        public IList<ProductDTO> SanPhams { get; set; }
    }
}
