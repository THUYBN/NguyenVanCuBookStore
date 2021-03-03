using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;


namespace S3Train.Contract
{
    public interface IProductsByCategoryService : IGenenicServiceBase<LoaiSanPham>
    {
        IList<ProductDTO> GetProductsByCategoryItems(Guid CategoryId);
    }
}