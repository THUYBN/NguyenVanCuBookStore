using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class RelatedProductsService: GenenicServiceBase<SanPham>, IRelatedProductsService
    {
        public RelatedProductsService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public IList<ProductDTO> GetRelatedProducts(Guid AuthorId)
        //{
        //    var relatedProducts = DbContext.Products
        //                        .Where(n => n.Author_Products.Any(x => x.AuthorId == AuthorId))
        //                        .Select (n => new ProductDTO)
        //                        {
                                    
        //                        }
        //}

    }
}
