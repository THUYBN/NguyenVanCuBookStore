using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using S3Train.DTOs;

namespace S3Train.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _newProductService;
        private readonly IProductAdvertisementService _productAdvertisementService;
        private readonly ICategoryService _categoryService;
        private readonly ICSProductService _cSProductService;
        private readonly IPromotionDetailService _promotionProductService;
        private readonly IVPPService _vppService;

        public HomeController(IProductService newProductService, IProductAdvertisementService productAdvertisementService, ICategoryService categoryService, ICSProductService cSProductSerVice, IPromotionDetailService promotionDetailService, IVPPService vPPService)
        {
            _newProductService = newProductService;
            _productAdvertisementService = productAdvertisementService;
            _categoryService = categoryService;
            _cSProductService = cSProductSerVice;
            _promotionProductService = promotionDetailService;
            _vppService = vPPService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                SliderItems = GetHomeSlider(_productAdvertisementService.GetSliderItems()),
                NewProducts = GetHomeNewProducts(_newProductService.GetNewProductItems()),
                CSProducts = GetHomeCSProducts(_cSProductService.GetCSProductItems()),
                PromotionProducts = GetHomeBestSellerProducts(_promotionProductService.GetPromotionDetail()),
                VPPProducts = GetVPP(_vppService.GetVPP())

            };

            return View(model);
        }

        private static IEnumerable<IGrouping<int, VPPModels>> GetVPP(IList<ProductDTO> products)
        {
            return products.Select((x, i) => new VPPModels
            {
                Id = x.Id,
                ImagePath = x.HinhAnh,
                NameProduct = x.TenSP,
                UpdatedDate = x.NgayCapNhat,
                DisplayPrice = x.Gia,
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IEnumerable<IGrouping<int, ProductViewModel>> GetHomeNewProducts(IList<ProductDTO> products)
        {
            return products.Select((x, i) => new ProductViewModel
            {
                Id = x.Id,
                ImagePath = x.HinhAnh,
                NameProduct = x.TenSP,
                DisplayPrice = x.Gia,
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IEnumerable<IGrouping<int, CSProductViewModel>> GetHomeCSProducts(IList<ProductDTO> products)
        {
            return products.Select((x, i) => new CSProductViewModel
            {
                Id = x.Id,
                ImagePath = x.HinhAnh,
                NameProduct = x.TenSP,
                DisplayPrice = x.Gia,
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IEnumerable<IGrouping<int, PromotionProductViewModel>> GetHomeBestSellerProducts(IList<ProductDTO> promotionDetail)
        {
            return promotionDetail.Select((x, i) => new PromotionProductViewModel
            {
                Id = x.ProductId,
                ImagePath = x.HinhAnh,
                NameProduct = x.TenSP,
                Price = x.Gia,
                PromotionPercent = x.KhuyenMais.First().PhanTramKM,
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IList<SliderItemViewModel> GetHomeSlider(IList<ManHinhTrangChu> productAds)
        {
            return productAds.Select(x => new SliderItemViewModel
            {
                ProductId = x.MaSP,
                ImagePath = x.ImagePath,
                Title = x.Title,
                Description = x.Description,
                EventUrl = x.EventUrl,
            }).ToList();
        }

        private static IList<CategoryViewModel> GetHomeCategory(IList<LoaiSanPham> category)
        {
            return category.Select(x => new CategoryViewModel
            {
                NameCategory = x.TenLoai
            }).ToList();

        }



    }
}