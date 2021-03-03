using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;


namespace S3Train.Service
{
    public class CategoryService: GenenicServiceBase<LoaiSanPham>, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<LoaiSanPham> GetCategoryItems()
        {
            return this.EntityDbSet.ToList();
        }
    }
}
