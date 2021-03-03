using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class CartViewModel
    {
        public ProductDTO Products { get; set; }
        public int Quantity { get; set; }
        public double PromotionPercent { get; set; }

       
    }
}