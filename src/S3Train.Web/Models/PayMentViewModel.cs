using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S3Train.Domain;

namespace S3Train.Web.Models
{
    public class PayMentViewModel
    {
        public ApplicationUser User { get; set; }
        public decimal Total { get; set; }

        public List<CartViewModel> Cart { get; set; }
    }
}