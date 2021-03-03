using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using System;
using PagedList;
using PagedList.Mvc;
using S3Train.DTOs;

namespace S3Train.Web.Controllers
{
    public class ProductsSearchForNameController : Controller
    {
        private readonly ISearchProductsForAuthorService _searchForAuthor;

        public ProductsSearchForNameController(ISearchProductsForAuthorService searchForAuthor)
        {
            _searchForAuthor = searchForAuthor;
        }

        public ActionResult ProductsSearchForAuthor(string Name, int page = 1, int pagesize = 20)
        {
            int totalRecord = 0;

            var productsSearchForAuthor = new HomeViewModel
            {
                productsSearchForName = GetProductsSearchForName(_searchForAuthor.GetProductsSearchForAuhtorItems(Name), ref totalRecord, page, pagesize)
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

            return View(productsSearchForAuthor);
        }

        private IList<ProductsSearchForNameViewModel> GetProductsSearchForName(IList<ProductDTO> proForAuthor, ref int totalRecord, int page = 1, int pagesize = 4)
        {
            var totalPro = proForAuthor.Select(x => new ProductsSearchForNameViewModel
            {
                Id = x.Id,
                ImagePath = x.HinhAnh,
                NameProduct = x.TenSP,
                DisplayPrice = x.Gia,
                UpdatedDate = x.NgayCapNhat,
            });

            var model = totalPro.OrderBy(x => x.NameProduct).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            totalRecord = totalPro.Count();

            return model;
        }
    }
}