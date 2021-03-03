using System;


namespace S3Train.Web.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string NameProduct { get; set; }
        public string Summary { get; set; }
        public decimal DisplayPrice { get; set; }
        public string Barcode { get; set; }
        public int Rating { get; set; }
        public int Grouping { get; set; }
    }
}