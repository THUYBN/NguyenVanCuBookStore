using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class PromotionProductViewModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string NameProduct { get; set; }
        public decimal DisplayPrice { get; set; }
        public decimal Price { get; set; }
        public double PromotionPercent { get; set; }
        public int Grouping { get; set; }
    }
}