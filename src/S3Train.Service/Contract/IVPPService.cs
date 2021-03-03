using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Train.DTOs;
using S3Train.Domain;

namespace S3Train.Contract
{
    public interface IVPPService : IGenenicServiceBase<SanPham>
    {
        IList<ProductDTO> GetVPP();
    }
}
