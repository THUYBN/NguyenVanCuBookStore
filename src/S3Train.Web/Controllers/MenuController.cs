using S3Train.Contract;
using S3Train.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryService _categoryService;

        public MenuController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        // GET: Menu
        public ActionResult CategoriesMenu()
        {
            var categories = _categoryService.GetCategoryItems()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    NameCategory = x.TenLoai,
                    TenPhanLoai = x.PhanLoai.TenPhanLoai
                }).ToList();

            return PartialView("_MenuByCategories", categories);
        }
    }
}