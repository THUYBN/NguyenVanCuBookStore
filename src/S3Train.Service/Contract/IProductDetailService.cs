using System;
using System.Collections.Generic;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Contract
{
    public interface IProductDetailService : IGenenicServiceBase<SanPham>
    {
        ProductDTO GetProductDetail(Guid id);
    }
}