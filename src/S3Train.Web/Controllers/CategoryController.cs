using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using System;
using S3Train.DTOs;

namespace S3Train.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductsByCategoryService _productsByCategory;

        public CategoryController(IProductsByCategoryService ProductsByCategory)
        {
            _productsByCategory = ProductsByCategory;

        }
        // GET: ProductsByCategory
        public ActionResult ProductsByCategory(Guid CategoryId, int page = 1, int pagesize = 20)
        {
            var pro = _productsByCategory.GetProductsByCategoryItems(CategoryId);
            int totalRecord = 0;
            var productsByCategory = new HomeViewModel
                {
                    ProductsByCategory = GetBroductsByCategory(_productsByCategory.GetProductsByCategoryItems(CategoryId), ref totalRecord, page, pagesize)

                };
            ViewBag.ToTal = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((double)totalRecord / (double)pagesize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Pre = page - 1;

            return View(productsByCategory);
        }

        private static IList<CategoryViewModel> GetBroductsByCategory(IList<ProductDTO> proByCa, ref int totalRecord, int page = 1, int pagesize = 4)
        {
            var totalProd = proByCa.Select(x => new CategoryViewModel
            {
                Id = x.MaLoai,
                ImagePath = x.HinhAnh,
                Name = x.TenSP,
                DisplayPrice = x.Gia,
                ProductId = x.ProductId,
                NameCategory = x.LoaiSanPham.TenLoai,
                Price = x.Gia,
                UpdatedDate = x.NgayCapNhat,
                //PromotionPercent = x.Promotion.FirstOrDefault().PromotionPercent,
            });
            var model = totalProd.OrderBy(x => x.NameCategory).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            totalRecord = totalProd.Count();
            return model;
        }
    }
}