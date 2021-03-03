using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public decimal DisplayPrice { get; set; }
        public string ImagePath { get; set; }
        public string Barcode { get; set; }
        public int ReleaseYear { get; set; }
        public int Amount { get; set; }
        public int? Rating { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal Price { get; set; }

        public string NamePublisher { get; set; }
        public string NCC { get; set; }
        public string NgonNgu { get; set; }
        public string AuthorName { get; set; }
        public double PromotionPercent { get; set; }
        public string CategoryName { get; set; }
        public string TenPhanLoai { get; set; }

        public float TrongLuong { get; set; }
        public int SoTrang { get; set; }
        public string KichThuoc { get; set; }
        public string ChatLuong { get; set; }
        public string MauSac { get; set; }

        public IList<ProductViewModel> RelatedProduct { get; set; }
    }
}