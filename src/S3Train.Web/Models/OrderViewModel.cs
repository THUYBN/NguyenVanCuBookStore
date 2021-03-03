using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class OrderViewModel
    {
        public string UserId { get; set; }
        public decimal TotalPayment { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public decimal Total { get; set; }
    }
}