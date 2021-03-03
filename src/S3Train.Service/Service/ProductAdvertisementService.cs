using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;

namespace S3Train.Service
{
    public class ProductAdvertisementService : GenenicServiceBase<ManHinhTrangChu>, IProductAdvertisementService
    {
        public ProductAdvertisementService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ManHinhTrangChu> GetSliderItems()
        {
            return this.EntityDbSet.Where(x => x.AdType == ProductAdvertisementType.SliderBanner).ToList();
        }
    }
}