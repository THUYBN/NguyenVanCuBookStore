using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Train.DTOs;

namespace S3Train.Contract
{
    public interface ICSProductService : IGenenicServiceBase<SanPham>
    {
        IList<ProductDTO> GetCSProductItems();
    }
}
