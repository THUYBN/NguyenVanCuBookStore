using S3Train.Domain;
using S3Train.DTOs;
using System.Collections.Generic;

namespace S3Train.Contract
{
    public interface ISearchProductsForAuthorService : IGenenicServiceBase<SanPham>
    {
        IList<ProductDTO> GetProductsSearchForAuhtorItems(string Name);
    }
}
