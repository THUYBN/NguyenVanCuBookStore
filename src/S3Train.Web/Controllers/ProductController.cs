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
    public class ProductController : Controller
    {
        private readonly IProductDetailService _detailProductService;

        public ProductController(IProductDetailService detailProductService)
        {
            _detailProductService = detailProductService;

        }

        public ActionResult Detail(Guid id)
        {
            var prodDetail = _detailProductService.GetProductDetail(id);
            var productDetailViewModel = new ProductDetailViewModel();

                if(prodDetail.KhuyenMais.Count() != 0)
                {
                    productDetailViewModel = new ProductDetailViewModel
                    {

                        Id = prodDetail.Id,
                        Name = prodDetail.TenSP,
                        ImagePath = prodDetail.HinhAnh,
                        DisplayPrice = prodDetail.Gia,
                        Price = prodDetail.Gia,
                        Summary = prodDetail.GhiChu,
                        NCC = prodDetail.NhaCungCap.TenNCC,
                        CategoryName = prodDetail.LoaiSanPham.TenLoai,
                        UpdatedDate = prodDetail.NgayCapNhat,
                        Amount = prodDetail.SoLuong,
                        AuthorName = prodDetail.TacGia,
                        PromotionPercent = prodDetail.KhuyenMais.FirstOrDefault().PhanTramKM,
                        NamePublisher = prodDetail.NhaSanXuat.TenNSX,
                        TrongLuong = prodDetail.TrongLuong,
                        KichThuoc = prodDetail.KichThuoc,
                        SoTrang = prodDetail.SoTrang,
                        ChatLuong = prodDetail.ChatLuong,
                        MauSac = prodDetail.MauSac,
                        TenPhanLoai = prodDetail.LoaiSanPham.TenPhanLoai,
                        NgonNgu = prodDetail.NgonNgu.TenNN,
                        RelatedProduct = prodDetail.RelatedProduct.Select(q => new ProductViewModel
                        {
                            Id = q.Id,
                            NameProduct = q.TenSP,
                            ImagePath = q.HinhAnh,
                            DisplayPrice = q.Gia
                        }).ToList()

                    };
                }else
                {
                productDetailViewModel = new ProductDetailViewModel
                {

                    Id = prodDetail.Id,
                    Name = prodDetail.TenSP,
                    ImagePath = prodDetail.HinhAnh,
                    DisplayPrice = prodDetail.Gia,
                    Price = prodDetail.Gia,
                    Summary = prodDetail.GhiChu,
                    AuthorName = prodDetail.TacGia,
                    NamePublisher = prodDetail.NhaSanXuat.TenNSX,
                    NCC = prodDetail.NhaCungCap.TenNCC,
                    CategoryName = prodDetail.LoaiSanPham.TenLoai,
                    UpdatedDate = prodDetail.NgayCapNhat,
                    TrongLuong = prodDetail.TrongLuong,
                    KichThuoc = prodDetail.KichThuoc,
                    SoTrang = prodDetail.SoTrang,
                    ChatLuong = prodDetail.ChatLuong,
                    MauSac = prodDetail.MauSac,
                    Amount = prodDetail.SoLuong,
                    TenPhanLoai = prodDetail.LoaiSanPham.TenPhanLoai,
                    NgonNgu = prodDetail.NgonNgu.TenNN,
                    RelatedProduct = prodDetail.RelatedProduct.Select(q => new ProductViewModel
                    {
                        Id = q.Id,
                        NameProduct = q.TenSP,
                        ImagePath = q.HinhAnh,
                        DisplayPrice = q.Gia
                    }).ToList()

                };
            }
                
            return View(productDetailViewModel);
        }

    }

       
}