
using System.Collections.Generic;
using System.Linq;


namespace S3Train.Web.Models
{
    public class HomeViewModel
    {
        public IList<SliderItemViewModel> SliderItems { get; set; }
        public IEnumerable<IGrouping<int, ProductViewModel>> NewProducts { get; set; }
        public IEnumerable<IGrouping<int, CSProductViewModel>> CSProducts { get; set; }
        public IEnumerable<IGrouping<int, VPPModels>> VPPProducts { get; set; }
        public IEnumerable<IGrouping<int, PromotionProductViewModel>> PromotionProducts { get; set; }
        public IList<CategoryViewModel> ProductsByCategory { get; set; }
        public IList<ProductViewModel> newProducts { get; set; }
        public IList<CSProductViewModel> csProducts { get; set; }
        public IList<VPPModels> vppProducts { get; set; }
        public IList<PromotionProductViewModel> bestSellerProducts { get; set; }
        public IList<ProductsSearchForNameViewModel> productsSearchForName { get; set; }
        public IList<OrderProViewModel> OrderProViewModel { get; set; }
    }
}