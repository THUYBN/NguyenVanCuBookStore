using System;

namespace S3Train.Web.Models
{
    public class CSProductViewModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string NameProduct { get; set; }
        public decimal DisplayPrice { get; set; }
        public int Grouping { get; set; }
    }
}