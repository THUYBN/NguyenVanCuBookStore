
using System;

namespace S3Train.Web.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public Guid MaPhanLoai { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string TenPhanLoai { get; set; }
        public string Summary { get; set; }
        public string Barcode { get; set; }
        public decimal DisplayPrice { get; set; }
        public string ImagePath { get; set; }
        public string NameCategory { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal Price { get; set; }
        public double PromotionPercent { get; set; }
    }
}